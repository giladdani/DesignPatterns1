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
        private IDictionary<string, PostWrapper> m_DictionaryOfPostsByPostID = new Dictionary<string, PostWrapper>();

        public LoggedinUserData()
        {
            login();
            FetchPosts();
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

        private void AddPostToDictionaryByPlace(string placeName, PostWrapper post)
        {
            if (m_DictionaryOfPostsByPlaces.ContainsKey(placeName))
            {
                m_DictionaryOfPostsByPlaces[placeName].Add(post);
            }
            else
            {
                m_DictionaryOfPostsByPlaces.Add(placeName, new List<PostWrapper>());
                m_DictionaryOfPostsByPlaces[placeName].Add(post);
            }
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
                }
                m_DictionaryOfPostsByPostID.Add(post.Id, postWrapper);

            }
        }

        private void FetchAlbums()
        {

        }

        private List<string> getPlaceNamesOfPosts()
        {
            List<string> placesNamesList = new List<string>();

            if (m_DictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (KeyValuePair<string, List<PostWrapper>> entry in m_dictionaryOfPostsByPlaces)
                {
                    string placeName = entry.Key;
                    placesNamesList.Add(placeName);
                }
            }

            return placesNamesList;
        }

        public ICollection<PostWrapper> getAllPosts()
        {
            if (m_DictionaryOfPostsByPostID.Count != 0)
            {
                return m_DictionaryOfPostsByPostID.Values;
            }
            else
            {
                return null;
            }
        }
    }
}
