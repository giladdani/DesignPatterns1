using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookDeskAppLogic
{
    public class GroupWrapper
    {
        private Group m_Group;

        public GroupWrapper(Group i_Group)
        {
            m_Group = i_Group;
        }

        public Group Group
        {
            get
            {
                return m_Group;
            }
            set
            {
                m_Group = value;
            }
        }

        public override string ToString()
        {
            if(string.IsNullOrEmpty(m_Group.Name))
            {
                return string.Format("Unnamed Group");
            }
            else
            {
                return m_Group.Name;
            }
        }
    }
}
