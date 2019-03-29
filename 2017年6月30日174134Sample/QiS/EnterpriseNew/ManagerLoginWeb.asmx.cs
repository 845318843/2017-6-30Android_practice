using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using EnterpriseNewModel;
//using EnterpriseNewBLL;

namespace EnterpriseNew
{
    /// <summary>
    /// ManagerLoginWeb 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class ManagerLoginWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod]
        public string Login(string username, string pwd)
        {
            BLL_Manager_User bll = new BLL_Manager_User();
            Manager_User users = new Manager_User();
            bool istrue = false;
            try
            {
                users.manager_Account = username;
                users.manager_Pw = pwd;
                if (bll.Login(users))
                {
                    istrue = true;
                }
                else
                {
                    istrue = false;
                }
            }
            catch
            {
                istrue = false;
            }
            if (istrue)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
    }
}
