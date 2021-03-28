using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookDeskAppLogic;
using Message = FacebookWrapper.ObjectModel.Message;

namespace B21_Ex01_Oron_311141188_Gilad_316418854
{
    public partial class MainForm : Form
    {
        // Private Members
        private const string k_AllTitle = "All";
        private const string k_PlacesTitle = "Places";
        private const string k_CommentsTitle = "Comments";
        private const string k_LikesTitle = "Likes";
        private LoggedinUserData m_LoggedinUserData;

        // Constructors
        public MainForm()
        {
            InitializeComponent();
            comboBoxPostsSubFilter.Visible = false;
            labelPostsSubFilter.Visible = false;
        }

        // Private Methods

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //------------------------  General functions  -------------------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        private void setListBox<T>(ICollection<T> list, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (T elem in list)
            {
                listBox.Items.Add(elem);
            }
        }

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //------------------- Setting ListBox of posts functions----------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        private void SetPostsListByPlaces(string i_PlaceName)
        {
            ICollection<Post> listOfPosts = m_LoggedinUserData.GetPostsByPlaceName(i_PlaceName);
            ICollection<PostWrapper> listOfPostsWrapper = genereateListOfPostsWrappers(listOfPosts);
            setListBox(listOfPostsWrapper, listBoxShowPosts);
        }

        private void SetListBoxPostsByComments(string i_NumOfComments)
        {
            ICollection<Post> listOfPosts = m_LoggedinUserData.GetPostsByNumOfComments(i_NumOfComments);
            ICollection<PostWrapper> listOfPostsWrapper = genereateListOfPostsWrappers(listOfPosts);
            setListBox(listOfPostsWrapper, listBoxShowPosts);
        }

        private void SetListBoxPostsByLikes(string i_NumOfLikes)
        {
            ICollection<Post> listOfPosts = m_LoggedinUserData.GetPostsByNumOfLikes(i_NumOfLikes);
            ICollection<PostWrapper> listOfPostsWrapper = genereateListOfPostsWrappers(listOfPosts);
            setListBox(listOfPostsWrapper, listBoxShowPosts);
        }

        private void SetListBoxPostsByListOfAll()
        {
            ICollection<Post> listOfPosts = m_LoggedinUserData.FetchAllPosts();
            ICollection<PostWrapper> listOfPostsWrapper = genereateListOfPostsWrappers(listOfPosts);
            setListBox(listOfPostsWrapper, listBoxShowPosts);
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
        private void SetComboboxPostsSubFilter(ICollection<string> i_Options)
        {
            foreach (string option in i_Options)
            {
                comboBoxPostsSubFilter.Items.Add(option);
            }
        }

        private void SetComboboxPostsSubFilterByPlaces()
        {
            labelPostsSubFilter.Text = "Filter by places";
            m_LoggedinUserData.FetchPostsByPlaces();
            List<string> listOfPlacesNames = m_LoggedinUserData.GetPlaceNamesOfPosts();
            SetComboboxPostsSubFilter(listOfPlacesNames);
        }

        private void SetComboboxPostsSubFilterByLikes()
        {
            labelPostsSubFilter.Text = "Filter by likes";
            m_LoggedinUserData.FetchPostsByNumOfLikes();
            SetComboboxPostsSubFilterByNumericOptions();
        }

        private void setComboboxPostsSubFilterByComments()
        {
            labelPostsSubFilter.Text = "Filter by comments";
            m_LoggedinUserData.FetchPostsByNumOfComments();
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
            SetComboboxPostsSubFilter(listOfNumOfOptions);
        }

        private void comboBoxPostsSubFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string optionOfFilter = comboBoxPostsFilter.Text;
            string optionOfSubFilter = comboBoxPostsSubFilter.Text;

            listBoxShowPosts.Items.Clear();

            if (optionOfFilter == k_PlacesTitle)
            {
                SetPostsListByPlaces(optionOfSubFilter);
            }
            else if (optionOfFilter == k_LikesTitle)
            {
                SetListBoxPostsByLikes(optionOfSubFilter);
            }
            else if (optionOfFilter == k_CommentsTitle)
            {
                SetListBoxPostsByComments(optionOfSubFilter);
            }
        }

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //-----------------combobox of filter of posts functions---------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        private void SetComboBoxPostsFilter()
        {
            comboBoxPostsFilter.Items.Clear();
            comboBoxPostsFilter.Items.Add(k_AllTitle);
            comboBoxPostsFilter.Items.Add(k_PlacesTitle);
            comboBoxPostsFilter.Items.Add(k_LikesTitle);
            comboBoxPostsFilter.Items.Add(k_CommentsTitle);
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
            else if (category == k_PlacesTitle)
            {
                SetGeneralOptionsToSubFilterComponents();
                SetComboboxPostsSubFilterByPlaces();
            }
            else if (category == k_LikesTitle)
            {
                SetGeneralOptionsToSubFilterComponents();
                SetComboboxPostsSubFilterByLikes();
            }
            else if (category == k_CommentsTitle)
            {
                SetGeneralOptionsToSubFilterComponents();
                setComboboxPostsSubFilterByComments();
            }
        }

        private void SetGeneralOptionsToSubFilterComponents()
        {
            comboBoxPostsSubFilter.Visible = true;
            labelPostsSubFilter.Visible = true;
            comboBoxPostsSubFilter.Items.Clear();
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
                m_LoggedinUserData = new LoggedinUserData();
                try
                {
                    m_LoggedinUserData.FetchAlbums();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Problem in fetching albums");
                }

                SetUserDetails();
                SetComboBoxPostsFilter();
                setListBoxAlbums();
                m_LoggedinUserData.FetchFriends();
                m_LoggedinUserData.FetchGroups();
                ICollection<User> listOfFriends = m_LoggedinUserData.GetAllFriends();
                ICollection<Group> listOfGroups = m_LoggedinUserData.GetAllGroups();
                setListBox(genereateListOfFriendWrappers(listOfFriends), listBoxFriends);
                setListBox(genereateListOfGroupWrappers(listOfGroups), listBoxGroups);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in the code\n");
            }
        }

        private void SetUserDetails()
        {
            userNameLabel.Text = "Welcome, " + m_LoggedinUserData.User.Name;
            pictureBoxProfile.ImageLocation = m_LoggedinUserData.User.PictureNormalURL;
            labelNameVal.Text = m_LoggedinUserData.User.Name;
            pictureBoxAbout.ImageLocation = m_LoggedinUserData.User.PictureNormalURL;
            labelGenderVal.Text = m_LoggedinUserData.User.Gender.ToString();
            labelBirthYearVal.Text = m_LoggedinUserData.User.Birthday;
        }

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //---------------------------Albums functions---------------------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        private void setListBoxAlbums()
        {
            ICollection<Album> listOfAlbums = m_LoggedinUserData.GetAllAlbums();
            ICollection<AlbumWrapper> listOfAlbumsWrapper = genereateListOfAlbumWrappers(listOfAlbums);
            setListBox(listOfAlbumsWrapper, listBoxAlbums);
        }

        private void setListBoxPhotos(string i_AlbumName)
        {
            ICollection<Photo> listOfPhotos = m_LoggedinUserData.FetchPhotosByAlbumName(i_AlbumName);
            ICollection<PhotoWrapper> listOfPhotosWrapper = genereateListOfPhotosWrappers(listOfPhotos);
            setListBox(listOfPhotosWrapper, listBoxPhotos);
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            string albumName = (listBoxAlbums.SelectedItem as AlbumWrapper).ToString();
            setListBoxPhotos(albumName);
        }

        private void listBoxPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhotoWrapper photoWrapper = listBoxPhotos.SelectedItem as PhotoWrapper;
            pictureBoxPhoto.ImageLocation = photoWrapper.Photo.PictureNormalURL;
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserWrapper userWrapper = listBoxFriends.SelectedItem as UserWrapper;

            labelFriendNameVal.Text = userWrapper.User.Name;
            labelFriendGenderVal.Text = userWrapper.User.Gender.ToString();
            labelFriendBirthYearVal.Text = userWrapper.User.Birthday.ToString();
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            GroupWrapper groupWrapper = listBoxGroups.SelectedItem as GroupWrapper;
            labelAboutThisGroup.Text = groupWrapper.Group.Description;
        }

        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        //---------------------------Wrapper functions--------------------------//
        //----------------------------------------------------------------------//
        //----------------------------------------------------------------------//
        private ICollection<PostWrapper> genereateListOfPostsWrappers(ICollection<Post> listOfPosts)
        {
            ICollection<PostWrapper> listOfPostWrapper = new List<PostWrapper>();
            foreach (Post post in listOfPosts)
            {
                PostWrapper postWrapper = new PostWrapper(post);
                listOfPostWrapper.Add(postWrapper);
            }

            return listOfPostWrapper;
        }

        private ICollection<UserWrapper> genereateListOfFriendWrappers(ICollection<User> listOfUsers)
        {
            ICollection<UserWrapper> listOfUserWrapper = new List<UserWrapper>();
            foreach (User user in listOfUsers)
            {
                UserWrapper userWrapper = new UserWrapper(user);
                listOfUserWrapper.Add(userWrapper);
            }

            return listOfUserWrapper;
        }

        private ICollection<GroupWrapper> genereateListOfGroupWrappers(ICollection<Group> listOfGroups)
        {
            ICollection<GroupWrapper> listOfGroupsWrapper = new List<GroupWrapper>();
            foreach (Group group in listOfGroups)
            {
                GroupWrapper groupWrapper = new GroupWrapper(group);
                listOfGroupsWrapper.Add(groupWrapper);
            }

            return listOfGroupsWrapper;
        }

        private ICollection<AlbumWrapper> genereateListOfAlbumWrappers(ICollection<Album> listOfAlbums)
        {
            ICollection<AlbumWrapper> listOfAlbumsWrapper = new List<AlbumWrapper>();
            foreach (Album album in listOfAlbums)
            {
                AlbumWrapper albumWrapper = new AlbumWrapper(album);
                listOfAlbumsWrapper.Add(albumWrapper);
            }

            return listOfAlbumsWrapper;
        }

        private ICollection<PhotoWrapper> genereateListOfPhotosWrappers(ICollection<Photo> listOfPhotos)
        {
            ICollection<PhotoWrapper> listOfAlbumsWrapper = new List<PhotoWrapper>();
            int index = 1;
            foreach (Photo photo in listOfPhotos)
            {
                PhotoWrapper photoWrapper = new PhotoWrapper(photo, index);
                listOfAlbumsWrapper.Add(photoWrapper);
                index++;
            }

            return listOfAlbumsWrapper;
        }

        private void buttonBestHourToPost_Click(object sender, EventArgs e)
        {
            int bestHourToPost = m_LoggedinUserData.GetBestTimeForStatus();
            string text = $"Best hour to post: {bestHourToPost}:00";
            labelBestHourToPost.Text = text;
        }

        private void buttonCreatePost_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_LoggedinUserData.User.PostStatus(richTextBoxCreatePost.Text);
                MessageBox.Show("Status was posted!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not post status :(");
            }
        }
    }
}
