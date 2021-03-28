using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookDeskAppLogic
{
    public class LikesAndPostsCounter
    {
        private int m_TotalLikes;
        private int m_NumOfPosts;

        public LikesAndPostsCounter()
        {
            m_TotalLikes = 0;
            m_NumOfPosts = 0;
        }

        public double CalcAvgLikesPerPost()
        {
            return (double)m_TotalLikes / m_NumOfPosts;
        }

        public void AddLikesAndIncPosts(int i_NumOfLikes)
        {
            m_TotalLikes += i_NumOfLikes;
            m_NumOfPosts++;
        }

        public int TotalLikes
        {
            get
            {
                return m_TotalLikes;
            }

            set
            {
                m_TotalLikes = value;
            }
        }

        public int NumOfPosts
        {
            get
            {
                return m_NumOfPosts;
            }

            set
            {
                m_NumOfPosts = value;
            }
        }
    }
}
