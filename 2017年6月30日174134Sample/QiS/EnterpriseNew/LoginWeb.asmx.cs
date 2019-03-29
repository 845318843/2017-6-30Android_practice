using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using EnterpriseNewBLL;
//using EnterpriseNewModel;
using BLL;
using Model;

namespace EnterpriseNew
{
    /// <summary>
    /// LoginWeb 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class LoginWeb : System.Web.Services.WebService
    {
        BLL_E_User bll = new BLL_E_User();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 登录函数
        /// </summary>
        /// <param name="users">实体类</param>
        /// <returns>登录成功 true</returns>
        [WebMethod]
        public bool Login(E_User users)
        {
           
            if (bll.login(users))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 将参数封装成实体类，然后传参
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录成功 “true”</returns>
        [WebMethod]
        public string ModelLogin(string username, string pwd)
        {
            E_User users = new E_User();
            bool istrue=false;
            try
            {
                users.user_Account = username;
                users.user_Pw = pwd;
                if (Login(users))
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
