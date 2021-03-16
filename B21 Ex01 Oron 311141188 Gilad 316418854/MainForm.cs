using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;


namespace B21_Ex01_Oron_311141188_Gilad_316418854
{
    public partial class MainForm : Form
    {
        // Private Members
        private User m_User;
        private IDictionary<string, List<PostWrapper>> m_dictionaryOfPostsByPlaces = new Dictionary<string, List<PostWrapper>>();
        private IDictionary<string, PostWrapper> m_dictionaryOfPostsByPostID = new Dictionary<string, PostWrapper>();

        // Constructors
        public MainForm()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
            FilterPostsLabel.Enabled = false;
        }

        // Private Methods
        private void addPostToDictionaryFromPostsCollection(FacebookObjectCollection<Post> posts)
        {
            foreach (Post post in posts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                Page page = post.Place;
                if (page != null && page.Name != null)
                {
                    addPostToDictionaryByPlace(page.Name, postWrapper);
                }
                m_dictionaryOfPostsByPostID.Add(post.Id, postWrapper);

            }
        }

        private void addPostToDictionaryByPlace(string placeName, PostWrapper post)
        {
            if (m_dictionaryOfPostsByPlaces.ContainsKey(placeName))
            {
                m_dictionaryOfPostsByPlaces[placeName].Add(post);
            }
            else
            {
                m_dictionaryOfPostsByPlaces.Add(placeName, new List<PostWrapper>());
                m_dictionaryOfPostsByPlaces[placeName].Add(post);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string placeName = comboBox1.Text;
            listBox1.Items.Clear();
                
            if (m_dictionaryOfPostsByPlaces.Count != 0)
            {
                List<PostWrapper> listOfPosts = m_dictionaryOfPostsByPlaces[placeName];
                foreach (PostWrapper post in listOfPosts)
                {
                    listBox1.Items.Add(post);

                }
            }
        }

        private void setAllPostsToList()
        {
            listBox1.Items.Clear();
            if (m_dictionaryOfPostsByPostID.Count != 0)
            {
                ICollection<PostWrapper> listOfPosts = m_dictionaryOfPostsByPostID.Values;
                foreach(PostWrapper post in listOfPosts)
                {
                    listBox1.Items.Add(post);
                }
            }
        }
        

        private void setCombobox()
        {
            if (m_dictionaryOfPostsByPlaces.Count != 0)
            {
                foreach (KeyValuePair<string, List<PostWrapper>> entry in m_dictionaryOfPostsByPlaces)
                {
                    string placeName = entry.Key;
                    comboBox1.Items.Add(placeName);
                }
            }


        }

        private void setComboBoxCategoryPosts()
        {
            comboBoxCategoryPosts.Items.Add("All");
            comboBoxCategoryPosts.Items.Add("Places");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostWrapper postWrapper = listBox1.SelectedItem as PostWrapper;
            string postName = postWrapper.Post.Name;
            string postMessage = postWrapper.Post.Message;
            string postPictureURL = postWrapper.Post.PictureURL;
            postNameLabel.Text = postName;
            postBody.Text = postMessage;
            pictureBoxPost.ImageLocation = postPictureURL;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string accessToken = "EAApWCcm2aMsBAPX5AVpKgzgOdYRAeafAvP8zPPKisGTUzLAhSqxebpdpzXWPyM0LSoZCDnCQGQNfzexYrzHQTCeCb9sv21F6sQYzt0Gwr6HVK5s8Tejc6ZCI9YzrZARCcvxD9eQ7u1sJvDRndgvhQ165GnU1m9IWy97QJZAH6QZDZD";
            try
            {
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
                setUserDetails();
                fetchPosts();
                fetchAlbums();
                Console.WriteLine("Access Token: " + result.AccessToken);
                Console.WriteLine("UserName:" + m_User.Name + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in the code\n");
            }

        }

        private void setUserDetails()
        {
            userNameLabel.Text = "Welcome, " + m_User.Name;
            pictureBoxProfile.ImageLocation = m_User.PictureNormalURL;
        }

        private void fetchPosts()
        {
            FacebookObjectCollection<Post> posts = m_User.Posts;
            if (posts.Count != 0)
            {
                addPostToDictionaryFromPostsCollection(posts);
            }
            setCombobox();
            setComboBoxCategoryPosts();
        }

        private void comboBoxCategoryPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxCategoryPosts.Text;
            if(category == "All")
            {
                comboBox1.Enabled = false;
                FilterPostsLabel.Enabled = false;
                setAllPostsToList();
            }
            else if(category == "Places")
            {
                comboBox1.Enabled = true;
                FilterPostsLabel.Enabled = true;
                listBox1.Items.Clear();
            }
        }

        private void fetchAlbums()
        {
            Hashtable hash = new Hashtable();
            foreach (Album album in m_User.Albums)
            {
                if (hash.ContainsKey(album.PrivcaySettings) == false)
                {
                    hash.Add(album.PrivcaySettings, album);
                    comboBoxAlbumPrivacy.Items.Add(album.PrivcaySettings);
                }
            }
        }

        private void comboBoxAlbumPrivacy_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxAlbums.Items.Clear();
            string chosenPrivacy = comboBoxAlbumPrivacy.SelectedItem.ToString();
            foreach (Album album in m_User.Albums)
            {
                if (album.PrivcaySettings.Equals(chosenPrivacy))
                {
                    listBoxAlbums.Items.Add(album.Name);
                }
            }
        }


    }
}
