using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class AlbumWrapper
    {
        private Album m_Album;

        public AlbumWrapper(Album i_Album)
        {
            m_Album = i_Album;
        }

        public Album Album
        {
            get
            {
                return m_Album;
            }
            set
            {
                m_Album = value;
            }
        }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(m_Album.Name))
            {
                return string.Format("Unnamed Album");
            }
            else
            {
                return m_Album.Name;
            }
        }
    }
}
