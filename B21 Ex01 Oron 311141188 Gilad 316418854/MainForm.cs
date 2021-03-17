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
       

        // Constructors
        public MainForm()
        {
            InitializeComponent();
            comboBoxPostsSubFilter.Enabled = false;
            labelPostsSubFilter.Enabled = false;
        }

        // Private Methods
   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optionOfFilter = comboBoxPostsFilter.Text;
            string optionOfSubFilter = comboBoxPostsSubFilter.Text;

            listBoxShowPosts.Items.Clear();

            if(optionOfFilter == "places")
            {
                setPostsListByPlace(optionOfSubFilter);
            }
        }

        private void setPostsListByPlace(string i_PlaceName)
        {
            List<PostWrapper> listOfPosts = getListOfPostsByPlaceName(placeName);
            foreach (PostWrapper post in listOfPosts)
            {
                listBoxShowPosts.Items.Add(post);
            }
        }

        private void setAllPostsToList()
        {
            listBoxShowPosts.Items.Clear();
            if (m_dictionaryOfPostsByPostID.Count != 0)
            {
                ICollection<PostWrapper> listOfPosts = m_dictionaryOfPostsByPostID.Values;
                foreach(PostWrapper post in listOfPosts)
                {
                    listBoxShowPosts.Items.Add(post);
                }
            }
        }
        

        private void setComboboxPostsSubFilter()
        {

        }

        private void setComboBoxCategoryPosts()
        {
            comboBoxPostsFilter.Items.Add("All");
            comboBoxPostsFilter.Items.Add("Places");

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostWrapper postWrapper = listBoxShowPosts.SelectedItem as PostWrapper;
            string postName = postWrapper.Post.Name;
            string postMessage = postWrapper.Post.Message;
            string postPictureURL = postWrapper.Post.PictureURL;
            postNameLabel.Text = postName;
            postBody.Text = postMessage;
            pictureBoxPost.ImageLocation = postPictureURL;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
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
            setCombobox();
            setComboBoxCategoryPosts();
        }

        private void comboBoxCategoryPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxPostsFilter.Text;
            if(category == "All")
            {
                comboBoxPostsSubFilter.Visible = false;
                labelPostsSubFilter.Visible = false;
                setAllPostsToList();
            }
            else if(category == "Places")
            {
                comboBoxPostsSubFilter.Visible = true;
                labelPostsSubFilter.Visible = true;
                listBoxShowPosts.Items.Clear();
            }
        }

        private void fetchAlbums()
        {
        }


    }
}
