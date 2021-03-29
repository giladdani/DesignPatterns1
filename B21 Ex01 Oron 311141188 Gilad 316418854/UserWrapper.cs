using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class UserWrapper
    {
        // Private Members
        private User m_User;

        // Constructors
        public UserWrapper(User i_User)
        {
            m_User = i_User;
        }

        // Public Methods
        public override string ToString()
        {
            if(string.IsNullOrEmpty(m_User.Name))
            {
                return string.Format("Unnamed User");
            }
            else
            {
                return m_User.Name;
            }
        }

        // Properties
        public User User
        {
            get
            {
                return m_User;
            }

            set
            {
                m_User = value;
            }
        }
    }
}
