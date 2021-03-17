using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class LoggedinUserData
    {
        // Private Members
        private User m_User;
        private IDictionary<string, List<PostWrapper>> m_DictionaryOfPostsByPlaces = new Dictionary<string, List<PostWrapper>>();
        private IDictionary<string, List<PostWrapper>> m_DictionaryOfPostsByLikes = new Dictionary<string, List<PostWrapper>>();
        private IDictionary<string, List<PostWrapper>> m_DictionaryOfPostsByComments = new Dictionary<string, List<PostWrapper>>();
        private IDictionary<string, List<PhotoWrapper>> m_DictionaryOfPhotosByAlbumName = new Dictionary<string, List<PhotoWrapper>>();

        private ICollection<AlbumWrapper> m_ListOfAlbums = new List<AlbumWrapper>();

        private ICollection<UserWrapper> m_ListOfFriends = new List<UserWrapper>();
        private ICollection<GroupWrapper> m_ListOfGroups = new List<GroupWrapper>();
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

        private void AddPostToDictionaryByPlace(string i_PlaceName, PostWrapper i_Post)
        {
            AddElementToDictionaryByKey(i_PlaceName, m_DictionaryOfPostsByPlaces, i_Post);
        }
        private void AddPostToDictionaryByLikes(PostWrapper i_PostWrapper)
        {
            int numOfLikes = i_PostWrapper.Post.LikedBy.Count();
            AddPostToDictionaryByNumericValue(numOfLikes, m_DictionaryOfPostsByLikes, i_PostWrapper);
        }

        private void AddPostToDictionaryByNumericValue(int numericValue, IDictionary<string, List<PostWrapper>> i_DictionaryOfPosts, PostWrapper i_PostWrapper)
        {
            if (numericValue >= 1 && numericValue <= 10)
            {
                AddElementToDictionaryByKey("1-10", i_DictionaryOfPosts, i_PostWrapper);
            }
            else if (numericValue >= 11 && numericValue <= 20)
            {
                AddElementToDictionaryByKey("11-20", i_DictionaryOfPosts, i_PostWrapper);
            }
            else if (numericValue >= 21 && numericValue <= 50)
            {
                AddElementToDictionaryByKey("21-50", i_DictionaryOfPosts, i_PostWrapper);
            }
            else if (numericValue >= 51 && numericValue <= 100)
            {
                AddElementToDictionaryByKey("51-100", i_DictionaryOfPosts, i_PostWrapper);
            }
            else if (numericValue >= 101 && numericValue <= 200)
            {
                AddElementToDictionaryByKey("101-200", i_DictionaryOfPosts, i_PostWrapper);
            }
            else if (numericValue > 200)
            {
                AddElementToDictionaryByKey("Above 200", i_DictionaryOfPosts, i_PostWrapper);
            }
        }

        private void AddPostToDictionaryByComments(PostWrapper i_PostWrapper)
        {
            int numOfComments = i_PostWrapper.Post.Comments.Count();

            AddPostToDictionaryByNumericValue(numOfComments, m_DictionaryOfPostsByComments, i_PostWrapper);

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

        public List<PostWrapper> FetchAllPosts()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            List<PostWrapper> listOfPosts = new List<PostWrapper>();
            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                listOfPosts.Add(postWrapper);
            }
            return listOfPosts;
        }

        public void FetchPostsByPlaces()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByPlaces.Clear();

            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                Page page = post.Place;
                if (page != null && page.Name != null)
                {
                    AddPostToDictionaryByPlace(page.Name, postWrapper);
                }
            }
        }

        public void FetchPostsByNumOfLikes()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByLikes.Clear();
            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                AddPostToDictionaryByLikes(postWrapper);
            }
        }

        public void FetchPostsByNumOfComments()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            m_DictionaryOfPostsByComments.Clear();
            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                AddPostToDictionaryByComments(postWrapper);
            }
        }

        public void FetchFriends()
        {
            foreach (User friend in m_User.Friends)
            {
                m_ListOfFriends.Add(new UserWrapper(friend));
            }
        }

        public void FetchGroups()
        {
            foreach (Group group in m_User.Groups)
            {
                m_ListOfGroups.Add(new GroupWrapper(group));
            }
        }

        public void FetchAlbums()
        {
            foreach (Album album in m_User.Albums)
            {
                m_ListOfAlbums.Add(new AlbumWrapper(album));
            }
        }

        public List<PhotoWrapper> FetchPhotosByAlbumName(string i_AlbumName)
        {
            int index = 1;
            List<PhotoWrapper> listOfPhotos = new List<PhotoWrapper>();
            foreach (Album album in m_User.Albums)
            {
                if(album.Name == i_AlbumName)
                { 
                    foreach(Photo photo in album.Photos)
                    {
                        listOfPhotos.Add(new PhotoWrapper(photo, index));
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
                foreach (KeyValuePair<string, List<PostWrapper>> entry in m_DictionaryOfPostsByPlaces)
                {
                    string placeName = entry.Key;
                    placesNamesList.Add(placeName);
                }
            }

            return placesNamesList;
        }

        public ICollection<PostWrapper> getAllPosts()
        {
            if (m_User.Posts.Count != 0)
            {
                return (ICollection<PostWrapper>)m_User.Posts;
            }
            else
            {
                return null;
            }
        }

        public ICollection<UserWrapper> getAllFriends()
        {
            return m_ListOfFriends;
        }

        public ICollection<GroupWrapper> getAllGroups()
        {
            return m_ListOfGroups;
        }

        public ICollection<AlbumWrapper> getAllAlbums()
        {
             return m_ListOfAlbums;
        }
        public ICollection<PostWrapper> getPostsByPlaceName(string i_PlaceName)
        {
            return m_DictionaryOfPostsByPlaces[i_PlaceName];
        }

        public ICollection<PostWrapper> getPostsByNumOfLikes(string i_NumOfLikes)
        {
            return m_DictionaryOfPostsByLikes[i_NumOfLikes];
        }

        public ICollection<PostWrapper> getPostsByNumOfComments(string i_NumOfComments)
        {
            return m_DictionaryOfPostsByLikes[i_NumOfComments];
        }

        public ICollection<PhotoWrapper> getPhotosByAlbumName(string i_AlbumName)
        {
            return m_DictionaryOfPhotosByAlbumName[i_AlbumName];
        }
    }
}
