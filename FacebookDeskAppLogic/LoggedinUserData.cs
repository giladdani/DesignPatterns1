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
            
        public LoggedinUserData()
        {
            login();
            FetchPosts();
            FetchAlbums();
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


        private void AddPostToDictionaryByKey(string i_Key, IDictionary<string, List<PostWrapper>> i_DictionaryOfPosts, PostWrapper post)
        {
            if (i_DictionaryOfPosts.ContainsKey(i_Key))
            {
                i_DictionaryOfPosts[i_Key].Add(post);
            }
            else
            {
                i_DictionaryOfPosts.Add(i_Key, new List<PostWrapper>());
                i_DictionaryOfPosts[i_Key].Add(post);
            }
        }

        private void AddPostToDictionaryByPlace(string i_PlaceName, PostWrapper i_Post)
        {
            AddElementToDictionaryByKey<PostWrapper>(i_PlaceName, m_DictionaryOfPostsByPlaces, i_Post);
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
                AddElementToDictionaryByKey("1-10", i_DictionaryOfPosts, i_PostWrapper);
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
                AddElementToDictionaryByKey(">200", i_DictionaryOfPosts, i_PostWrapper);
            }
        }

        private void AddPostToDictionaryByComments(PostWrapper i_PostWrapper)
        {
            int numOfComments = i_PostWrapper.Post.Comments.Count();

            AddPostToDictionaryByNumericValue(numOfComments, m_DictionaryOfPostsByComments, i_PostWrapper);

        }
        public List<PostWrapper> getListOfPostsByPlaceName(string i_PlaceName)
        {
            List<PostWrapper> listOfPosts = m_DictionaryOfPostsByPlaces[i_PlaceName];
            if (m_DictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (PostWrapper post in listOfPosts)
                {
                    listOfPosts.Add(post);
                }
            }
            return listOfPosts;
        }
        public List<PostWrapper> getListOfPostsByNumOfLikes(string i_NumOfLikes)
        {
            List<PostWrapper> listOfPosts = m_DictionaryOfPostsByPlaces[i_NumOfLikes];
            if (m_DictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (PostWrapper post in listOfPosts)
                {
                    listOfPosts.Add(post);
                }
            }
            return listOfPosts;
        }
        public List<PostWrapper> getListOfPostsByNumOfComments(string i_NumOfComments)
        {
            List<PostWrapper> listOfPosts = m_DictionaryOfPostsByPlaces[i_NumOfComments];
            if (m_DictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (PostWrapper post in listOfPosts)
                {
                    listOfPosts.Add(post);
                }
            }
            return listOfPosts;
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

        private void FetchPosts()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;

            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                Page page = post.Place;
                if (page != null && page.Name != null)
                {
                    AddPostToDictionaryByPlace(page.Name, postWrapper);
                    AddPostToDictionaryByComments(postWrapper);
                    AddPostToDictionaryByLikes(postWrapper);
                }

            }
        }

        private void FetchAlbums()
        {
            foreach (Album album in m_User.Albums)
            {
                m_ListOfAlbums.Add(new AlbumWrapper(album));
                int index = 1;
                foreach (Photo photo in album.Photos)
                {
                    AddElementToDictionaryByKey(album.Name, m_DictionaryOfPhotosByAlbumName, new PhotoWrapper(photo, index));
                    index++;
                }
            }
            

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

        public ICollection<AlbumWrapper> getAllAlbums()
        {
            if (m_User.Posts.Count != 0)
            {
                return m_ListOfAlbums;
            }
            else
            {
                return null;
            }
        }
    }
}
