using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class PostWrapper
    {
        private Post m_Post;

        public PostWrapper(Post i_Post)
        {
            m_Post = i_Post;
        }

        public Post Post
        {
            get
            {
                return m_Post;
            }

            set
            {
                m_Post = value;
            }
        }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(m_Post.Name))
            {
                return string.Format("Unnamed Post");
            }
            else
            {
                return m_Post.Name;
            }
        }
    }
}
