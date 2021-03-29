using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class PhotoWrapper
    {
        // Private Members
        private Photo m_Photo;
        private int m_Index;
        
        // Constructors
        public PhotoWrapper(Photo i_Photo, int i_Index)
        {
            m_Photo = i_Photo;
            m_Index = i_Index;
        }

        // Public Methods
        public override string ToString()
        {
            return m_Index.ToString();
        }

        // Properties
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
    }
}
