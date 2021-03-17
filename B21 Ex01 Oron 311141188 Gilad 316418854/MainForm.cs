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

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //------------------- Setting ListBox of posts functions----------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//

        private void SetListBoxPostsByCollectionOfPosts(ICollection<PostWrapper> collectionOfPosts)
        {
            foreach (PostWrapper post in collectionOfPosts)
            {
                listBoxShowPosts.Items.Add(post);
            }
        }
        private void SetPostsListByPlaces(string i_PlaceName)
        {
            List<PostWrapper> listOfPosts = getListOfPostsByPlaceName(placeName);
            SetListBoxPostsByCollectionOfPosts(listOfPosts);
        }

        private void SetListBoxPostsByComments(string i_NumOfComments)
        {
            List<PostWrapper> listOfPosts = getListOfPostsByNumOfComments(i_NumOfLikes);
            SetListBoxPostsByCollectionOfPosts(listOfPosts);
        }

        private void SetListBoxPostsByLikes(string i_NumOfLikes)
        {
            List<PostWrapper> listOfPosts = getListOfPostsByNumOfLikes(i_NumOfLikes);
            SetListBoxPostsByCollectionOfPosts(listOfPosts);
        }

        private void SetListBoxPostsByListOfAll()
        {
            ICollection<PostWrapper> listOfPosts = getAllPosts();
            SetListBoxPostsByCollectionOfPosts(listOfPosts);
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostWrapper postWrapper = listBoxShowPosts.SelectedItem as PostWrapper;
            string postName = postWrapper.Post.Name;
            string postMessage = postWrapper.Post.Message;
            string postPictureURL = postWrapper.Post.PictureURL;
            postNameLabel.Text = postName;
            postBody.Text = postMessage;
            pictureBoxPost.ImageLocation = postPictureURL;
        }


        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //----------- Setting combobox of sub filter of posts functions---------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//


        private void setComboboxPostsSubFilter(ICollection<string> i_Options)
        {
            foreach (string option in i_Options)
            {
                comboBoxPostsSubFilter.Items.Add(option);
            }
        }

        private void setComboboxPostsSubFilterByPlaces()
        {

            List<string> listOfPlacesNames = getPlaceNamesOfPosts();
            setComboboxPostsSubFilter(listOfPlacesNames);
        }

        private void setComboboxPostsSubFilterByLikes()
        {
            SetComboboxPostsSubFilterByNumericOptions();
        }

        private void setComboboxPostsSubFilterByComments()
        {
            SetComboboxPostsSubFilterByNumericOptions();
        }

        private void SetComboboxPostsSubFilterByNumericOptions()
        {
            List<string> listOfNumOfOptions = new List<string>();
            listOfNumOfOptions.Add("1-10");
            listOfNumOfOptions.Add("11-20");
            listOfNumOfOptions.Add("20-50");
            listOfNumOfOptions.Add("51-100");
            listOfNumOfOptions.Add("100-200");
            listOfNumOfOptions.Add("Above 200");
            setComboboxPostsSubFilter(listOfNumOfOptions);
        }

        private void comboBoxPostsSubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optionOfFilter = comboBoxPostsFilter.Text;
            string optionOfSubFilter = comboBoxPostsSubFilter.Text;

            listBoxShowPosts.Items.Clear();

            if (optionOfFilter == "Places")
            {
                SetPostsListByPlaces(optionOfSubFilter);
            }
            else if (optionOfFilter == "Likes")
            {
                SetListBoxPostsByLikes(optionOfSubFilter);
            }
            else if (optionOfFilter == "Comments")
            {
                SetListBoxPostsByComments(optionOfSubFilter);
            }
        }


        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //-----------------combobox of filter of posts functions---------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//


        private void setComboBoxPostsFilter()
        {
            comboBoxPostsFilter.Items.Add("All");
            comboBoxPostsFilter.Items.Add("Places");
            comboBoxPostsFilter.Items.Add("Likes");
            comboBoxPostsFilter.Items.Add("Comments");
        }

        private void comboBoxPostsFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = comboBoxPostsFilter.Text;
            if (category == "All")
            {
                comboBoxPostsSubFilter.Visible = false;
                labelPostsSubFilter.Visible = false;
                listBoxShowPosts.Items.Clear();
                SetListBoxPostsByListOfAll();
            }
            else if (category == "Places")
            {
                SetGeneralOptionsToSubFilterComponents();
                setComboboxPostsSubFilterByPlaces();
            }
            else if (category == "Likes")
            {
                SetGeneralOptionsToSubFilterComponents();
                setComboboxPostsSubFilterByLikes();
            }
            else if (category == "Comments")
            {
                SetGeneralOptionsToSubFilterComponents();
                setComboboxPostsSubFilterByComments();
            }
        }

        private void SetGeneralOptionsToSubFilterComponents()
        {
            comboBoxPostsSubFilter.Visible = true;
            labelPostsSubFilter.Visible = true;
            listBoxShowPosts.Items.Clear();
        }

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //---------------------------login functions----------------------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//

        private void pictureBoxLogin_Click(object sender, EventArgs e)
        {
            try
            {
                login();
                SetUserDetails();
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

        private void SetUserDetails()
        {
            userNameLabel.Text = "Welcome, " + m_User.Name;
            pictureBoxProfile.ImageLocation = m_User.PictureNormalURL;
        }

        private void fetchPosts()
        {
            setComboBoxPostsFilter();
        }

        private void fetchAlbums()
        {

        }


    }
}
