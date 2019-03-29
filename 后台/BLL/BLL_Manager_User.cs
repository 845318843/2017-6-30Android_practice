using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Manager_User
    {
        DAL_Manager_User muser = new DAL_Manager_User();
        public bool Login(Manager_User Manager_User)
        {
            return muser.Login(Manager_User);
        }
    }
}
