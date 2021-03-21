using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class LoggedinUserData
    {
        // Private Members
        private User m_User;
        private IDictionary<string, List<Post>> m_DictionaryOfPostsByPlaces = new Dictionary<string, List<Post>>();
        private IDictionary<string, List<Post>> m_DictionaryOfPostsByLikes = new Dictionary<string, List<Post>>();
        private IDictionary<string, List<Post>> m_DictionaryOfPostsByComments = new Dictionary<string, List<Post>>();
        private IDictionary<string, List<Photo>> m_DictionaryOfPhotosByAlbumName = new Dictionary<string, List<Photo>>();

        private ICollection<Album> m_ListOfAlbums = new List<Album>();

        private ICollection<User> m_ListOfFriends = new List<User>();
        private ICollection<Group> m_ListOfGroups = new List<Group>();
        public LoggedinUserData()
        {
            login();
           // FetchPosts();
           // FetchAlbums();
        }

        public User User
        {
            get
            {
                return m_User;
            }
            set
            {
                m_User = value;
            }
        }

        private void AddElementToDictionaryByKey<T>(string i_Key, IDictionary<string, List<T>> i_Dictionary, T i_Element)
        {
            if (i_Dictionary.ContainsKey(i_Key))
            {
                i_Dictionary[i_Key].Add(i_Element);
            }
            else
            {
                i_Dictionary.Add(i_Key, new List<T>());
                i_Dictionary[i_Key].Add(i_Element);
            }
        }

        private void AddPostToDictionaryByPlace(string i_PlaceName, Post i_Post)
        {
            AddElementToDictionaryByKey(i_PlaceName, m_DictionaryOfPostsByPlaces, i_Post);
        }
        private void AddPostToDictionaryByLikes(Post i_Post)
        {
            int numOfLikes = i_Post.LikedBy.Count();
            AddPostToDictionaryByNumericValue(numOfLikes, m_DictionaryOfPostsByLikes, i_Post);
        }

        private void AddPostToDictionaryByNumericValue(int numericValue, IDictionary<string, List<Post>> i_DictionaryOfPosts, Post i_Post)
        {
            if (numericValue >= 1 && numericValue <= 10)
            {
                AddElementToDictionaryByKey("1-10", i_DictionaryOfPosts, i_Post);
            }
            else if (numericValue >= 11 && numericValue <= 20)
            {
                AddElementToDictionaryByKey("11-20", i_DictionaryOfPosts, i_Post);
            }
            else if (numericValue >= 21 && numericValue <= 50)
            {
                AddElementToDictionaryByKey("21-50", i_DictionaryOfPosts, i_Post);
            }
            else if (numericValue >= 51 && numericValue <= 100)
            {
                AddElementToDictionaryByKey("51-100", i_DictionaryOfPosts, i_Post);
            }
            else if (numericValue >= 101 && numericValue <= 200)
            {
                AddElementToDictionaryByKey("101-200", i_DictionaryOfPosts, i_Post);
            }
            else if (numericValue > 200)
            {
                AddElementToDictionaryByKey("Above 200", i_DictionaryOfPosts, i_Post);
            }
        }

        private void AddPostToDictionaryByComments(Post i_Post)
        {
            int numOfComments = i_Post.Comments.Count();

            AddPostToDictionaryByNumericValue(numOfComments, m_DictionaryOfPostsByComments, i_Post);

        }

        public void login()
        {
            string accessToken = "EAApWCcm2aMsBAPX5AVpKgzgOdYRAeafAvP8zPPKisGTUzLAhSqxebpdpzXWPyM0LSoZCDnCQGQNfzexYrzHQTCeCb9sv21F6sQYzt0Gwr6HVK5s8Tejc6ZCI9YzrZARCcvxD9eQ7u1sJvDRndgvhQ165GnU1m9IWy97QJZAH6QZDZD";
                LoginResult result = FacebookService.Connect(accessToken);
                //LoginResult result = FacebookService.Login("2909349805975755",
                //    "public_profile",
                //    "email",
                //    "publish_to_groups",
                //    "user_birthday",
                //    "user_age_range",
                //    "user_gender",
                //    "user_link",
                //    "user_tagged_places",
                //    "user_videos",
                //    "publish_to_groups",
                //    "groups_access_member_info",
                //    "user_friends",
                //    "user_events",
                //    "user_likes",
                //    "user_location",
                //    "user_photos",
                //    "user_posts",
                //    "user_hometown"
                //    );
                m_User = result.LoggedInUser;
        }

        public List<Post> FetchAllPosts()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            List<Post> listOfPosts = new List<Post>();
            foreach (Post post in posts)
            {
                listOfPosts.Add(post);
            }
            return listOfPosts;
        }

        public void FetchPostsByPlaces()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByPlaces.Clear();

            foreach (Post post in posts)
            {
                Page page = post.Place;
                if (page != null && page.Name != null)
                {
                    AddPostToDictionaryByPlace(page.Name, post);
                }
            }
        }

        public void FetchPostsByNumOfLikes()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByLikes.Clear();
            foreach (Post post in posts)
            {
                AddPostToDictionaryByLikes(post);
            }
        }

        public void FetchPostsByNumOfComments()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByComments.Clear();
            foreach (Post post in posts)
            {
                AddPostToDictionaryByComments(post);
            }
        }

        public void FetchFriends()
        {
            foreach (User friend in m_User.Friends)
            {
                m_ListOfFriends.Add(friend);
            }
        }

        public void FetchGroups()
        {
            foreach (Group group in m_User.Groups)
            {
                m_ListOfGroups.Add(group);
            }
        }

        public void FetchAlbums()
        {
            foreach (Album album in m_User.Albums)
            {
                m_ListOfAlbums.Add(album);
            }
        }

        public List<Photo> FetchPhotosByAlbumName(string i_AlbumName)
        {
            int index = 1;
            List<Photo> listOfPhotos = new List<Photo>();
            foreach (Album album in m_User.Albums)
            {
                if(album.Name == i_AlbumName)
                { 
                    foreach(Photo photo in album.Photos)
                    {
                        listOfPhotos.Add(photo);
                        index++;
                    }

                }
            }
            return listOfPhotos;

        }

        public List<string> getPlaceNamesOfPosts()
        {
            List<string> placesNamesList = new List<string>();

            if (m_DictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (KeyValuePair<string, List<Post>> entry in m_DictionaryOfPostsByPlaces)
                {
                    string placeName = entry.Key;
                    placesNamesList.Add(placeName);
                }
            }

            return placesNamesList;
        }

        public ICollection<Post> getAllPosts()
        {
            if (m_User.Posts.Count != 0)
            {
                return m_User.Posts;
            }
            else
            {
                return null;
            }
        }

        public ICollection<User> getAllFriends()
        {
            return m_ListOfFriends;
        }

        public ICollection<Group> getAllGroups()
        {
            return m_ListOfGroups;
        }

        public ICollection<Album> getAllAlbums()
        {
             return m_ListOfAlbums;
        }
        public ICollection<Post> getPostsByPlaceName(string i_PlaceName)
        {
            return m_DictionaryOfPostsByPlaces[i_PlaceName];
        }

        public ICollection<Post> getPostsByNumOfLikes(string i_NumOfLikes)
        {
            return m_DictionaryOfPostsByLikes[i_NumOfLikes];
        }

        public ICollection<Post> getPostsByNumOfComments(string i_NumOfComments)
        {
            return m_DictionaryOfPostsByLikes[i_NumOfComments];
        }

        public ICollection<Photo> getPhotosByAlbumName(string i_AlbumName)
        {
            return m_DictionaryOfPhotosByAlbumName[i_AlbumName];
        }
    }
}
