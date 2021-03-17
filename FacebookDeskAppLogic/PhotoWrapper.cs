using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class PhotoWrapper
    {
        private Photo m_Photo;
        private int m_Index;
        public PhotoWrapper(Photo i_Photo, int i_Index)
        {
            m_Photo = i_Photo;
            m_Index = i_Index;
        }

        public Photo Photo
        {
            get
            {
                return m_Photo;
            }
            set
            {
                m_Photo = value;
            }
        }

        public override string ToString()
        {
            return m_Index.ToString();
        }
    }
}
