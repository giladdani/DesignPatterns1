namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.FilterPostsLabel = new System.Windows.Forms.Label();
            this.postNameLabel = new System.Windows.Forms.Label();
            this.postBody = new System.Windows.Forms.Label();
            this.panelPostBody = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.panelPost = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPosts = new System.Windows.Forms.TabPage();
            this.comboBoxCategoryPosts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPhotos = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxPhotos = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAlbumPrivacy = new System.Windows.Forms.ComboBox();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.labelPrivacyFilter = new System.Windows.Forms.Label();
            this.tabFriends = new System.Windows.Forms.TabPage();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.tabLikedPhotos = new System.Windows.Forms.TabPage();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.tabFavoriteTeams = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.panelPostBody.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panelPost.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPosts.SuspendLayout();
            this.tabPhotos.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(38, 199);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(207, 164);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(48, 152);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(819, 97);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(210, 151);
            this.pictureBoxProfile.TabIndex = 3;
            this.pictureBoxProfile.TabStop = false;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(847, 58);
            this.userNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 17);
            this.userNameLabel.TabIndex = 4;
            // 
            // FilterPostsLabel
            // 
            this.FilterPostsLabel.AutoSize = true;
            this.FilterPostsLabel.Location = new System.Drawing.Point(45, 120);
            this.FilterPostsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FilterPostsLabel.Name = "FilterPostsLabel";
            this.FilterPostsLabel.Size = new System.Drawing.Size(141, 17);
            this.FilterPostsLabel.TabIndex = 5;
            this.FilterPostsLabel.Text = "Filter posts by places";
            // 
            // postNameLabel
            // 
            this.postNameLabel.AutoSize = true;
            this.postNameLabel.Location = new System.Drawing.Point(25, 0);
            this.postNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postNameLabel.Name = "postNameLabel";
            this.postNameLabel.Size = new System.Drawing.Size(0, 17);
            this.postNameLabel.TabIndex = 6;
            // 
            // postBody
            // 
            this.postBody.AutoSize = true;
            this.postBody.Location = new System.Drawing.Point(33, 66);
            this.postBody.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.postBody.Name = "postBody";
            this.postBody.Size = new System.Drawing.Size(0, 17);
            this.postBody.TabIndex = 7;
            // 
            // panelPostBody
            // 
            this.panelPostBody.AutoScroll = true;
            this.panelPostBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPostBody.Controls.Add(this.postBody);
            this.panelPostBody.Location = new System.Drawing.Point(23, 68);
            this.panelPostBody.Margin = new System.Windows.Forms.Padding(4);
            this.panelPostBody.Name = "panelPostBody";
            this.panelPostBody.Size = new System.Drawing.Size(312, 177);
            this.panelPostBody.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.pictureBoxPost);
            this.panel2.Location = new System.Drawing.Point(23, 266);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 143);
            this.panel2.TabIndex = 9;
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.Location = new System.Drawing.Point(13, 4);
            this.pictureBoxPost.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(295, 135);
            this.pictureBoxPost.TabIndex = 0;
            this.pictureBoxPost.TabStop = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panelPost
            // 
            this.panelPost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPost.Controls.Add(this.panel4);
            this.panelPost.Controls.Add(this.panelPostBody);
            this.panelPost.Controls.Add(this.panel2);
            this.panelPost.Location = new System.Drawing.Point(311, 51);
            this.panelPost.Margin = new System.Windows.Forms.Padding(4);
            this.panelPost.Name = "panelPost";
            this.panelPost.Size = new System.Drawing.Size(376, 431);
            this.panelPost.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.postNameLabel);
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(351, 48);
            this.panel4.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(806, 282);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 53);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPosts);
            this.tabControl2.Controls.Add(this.tabPhotos);
            this.tabControl2.Controls.Add(this.tabFriends);
            this.tabControl2.Controls.Add(this.tabEvents);
            this.tabControl2.Controls.Add(this.tabLikedPhotos);
            this.tabControl2.Controls.Add(this.tabGroups);
            this.tabControl2.Controls.Add(this.tabFavoriteTeams);
            this.tabControl2.Location = new System.Drawing.Point(28, 21);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(747, 530);
            this.tabControl2.TabIndex = 14;
            this.tabControl2.Tag = "fds";
            // 
            // tabPosts
            // 
            this.tabPosts.Controls.Add(this.comboBoxCategoryPosts);
            this.tabPosts.Controls.Add(this.label1);
            this.tabPosts.Controls.Add(this.FilterPostsLabel);
            this.tabPosts.Controls.Add(this.listBox1);
            this.tabPosts.Controls.Add(this.comboBox1);
            this.tabPosts.Controls.Add(this.panelPost);
            this.tabPosts.Location = new System.Drawing.Point(4, 25);
            this.tabPosts.Name = "tabPosts";
            this.tabPosts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPosts.Size = new System.Drawing.Size(739, 501);
            this.tabPosts.TabIndex = 0;
            this.tabPosts.Text = "Posts";
            this.tabPosts.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategoryPosts
            // 
            this.comboBoxCategoryPosts.FormattingEnabled = true;
            this.comboBoxCategoryPosts.Location = new System.Drawing.Point(48, 80);
            this.comboBoxCategoryPosts.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCategoryPosts.Name = "comboBoxCategoryPosts";
            this.comboBoxCategoryPosts.Size = new System.Drawing.Size(173, 24);
            this.comboBoxCategoryPosts.TabIndex = 12;
            this.comboBoxCategoryPosts.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoryPosts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Choose category to filter posts";
            // 
            // tabPhotos
            // 
            this.tabPhotos.Controls.Add(this.listView1);
            this.tabPhotos.Controls.Add(this.label3);
            this.tabPhotos.Controls.Add(this.listBoxPhotos);
            this.tabPhotos.Controls.Add(this.label2);
            this.tabPhotos.Controls.Add(this.comboBoxAlbumPrivacy);
            this.tabPhotos.Controls.Add(this.listBoxAlbums);
            this.tabPhotos.Controls.Add(this.labelPrivacyFilter);
            this.tabPhotos.Location = new System.Drawing.Point(4, 25);
            this.tabPhotos.Name = "tabPhotos";
            this.tabPhotos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhotos.Size = new System.Drawing.Size(739, 501);
            this.tabPhotos.TabIndex = 1;
            this.tabPhotos.Text = "Photos";
            this.tabPhotos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Choose Photo:";
            // 
            // listBoxPhotos
            // 
            this.listBoxPhotos.FormattingEnabled = true;
            this.listBoxPhotos.ItemHeight = 16;
            this.listBoxPhotos.Location = new System.Drawing.Point(231, 130);
            this.listBoxPhotos.Name = "listBoxPhotos";
            this.listBoxPhotos.Size = new System.Drawing.Size(120, 84);
            this.listBoxPhotos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Choose Album:";
            // 
            // comboBoxAlbumPrivacy
            // 
            this.comboBoxAlbumPrivacy.FormattingEnabled = true;
            this.comboBoxAlbumPrivacy.Location = new System.Drawing.Point(41, 61);
            this.comboBoxAlbumPrivacy.Name = "comboBoxAlbumPrivacy";
            this.comboBoxAlbumPrivacy.Size = new System.Drawing.Size(121, 24);
            this.comboBoxAlbumPrivacy.TabIndex = 2;
            this.comboBoxAlbumPrivacy.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlbumPrivacy_SelectedIndexChanged);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 16;
            this.listBoxAlbums.Location = new System.Drawing.Point(41, 130);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(120, 84);
            this.listBoxAlbums.TabIndex = 1;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // labelPrivacyFilter
            // 
            this.labelPrivacyFilter.AutoSize = true;
            this.labelPrivacyFilter.Location = new System.Drawing.Point(39, 41);
            this.labelPrivacyFilter.Name = "labelPrivacyFilter";
            this.labelPrivacyFilter.Size = new System.Drawing.Size(111, 17);
            this.labelPrivacyFilter.TabIndex = 0;
            this.labelPrivacyFilter.Text = "Filter by privacy:";
            // 
            // tabFriends
            // 
            this.tabFriends.Location = new System.Drawing.Point(4, 25);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabFriends.Size = new System.Drawing.Size(739, 501);
            this.tabFriends.TabIndex = 2;
            this.tabFriends.Text = "Friends";
            this.tabFriends.UseVisualStyleBackColor = true;
            // 
            // tabEvents
            // 
            this.tabEvents.Location = new System.Drawing.Point(4, 25);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(739, 501);
            this.tabEvents.TabIndex = 3;
            this.tabEvents.Text = "Events";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // tabLikedPhotos
            // 
            this.tabLikedPhotos.Location = new System.Drawing.Point(4, 25);
            this.tabLikedPhotos.Name = "tabLikedPhotos";
            this.tabLikedPhotos.Size = new System.Drawing.Size(739, 501);
            this.tabLikedPhotos.TabIndex = 4;
            this.tabLikedPhotos.Text = "Liked posts";
            this.tabLikedPhotos.UseVisualStyleBackColor = true;
            // 
            // tabGroups
            // 
            this.tabGroups.Location = new System.Drawing.Point(4, 25);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(739, 501);
            this.tabGroups.TabIndex = 5;
            this.tabGroups.Text = "Groups";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // tabFavoriteTeams
            // 
            this.tabFavoriteTeams.Location = new System.Drawing.Point(4, 25);
            this.tabFavoriteTeams.Name = "tabFavoriteTeams";
            this.tabFavoriteTeams.Size = new System.Drawing.Size(739, 501);
            this.tabFavoriteTeams.TabIndex = 6;
            this.tabFavoriteTeams.Text = "Favorite Teams";
            this.tabFavoriteTeams.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(446, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(226, 184);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userNameLabel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.panelPostBody.ResumeLayout(false);
            this.panelPostBody.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panelPost.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPosts.ResumeLayout(false);
            this.tabPosts.PerformLayout();
            this.tabPhotos.ResumeLayout(false);
            this.tabPhotos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label FilterPostsLabel;
        private System.Windows.Forms.Label postNameLabel;
        private System.Windows.Forms.Label postBody;
        private System.Windows.Forms.Panel panelPostBody;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxPost;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Panel panelPost;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPosts;
        private System.Windows.Forms.TabPage tabPhotos;
        private System.Windows.Forms.TabPage tabFriends;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabLikedPhotos;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.TabPage tabFavoriteTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCategoryPosts;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxPhotos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAlbumPrivacy;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Label labelPrivacyFilter;
        private System.Windows.Forms.ListView listView1;
    }
}

