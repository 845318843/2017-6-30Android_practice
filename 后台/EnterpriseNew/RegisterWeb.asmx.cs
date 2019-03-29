using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using EnterpriseNewBLL;
//using EnterpriseNewModel;

namespace EnterpriseNew
{
    /// <summary>
    /// RegisterWeb 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class RegisterWeb : System.Web.Services.WebService
    {
        BLL_E_User bll = new BLL_E_User();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string register(string account, string pwd, string name, string address, string tel, string time, string email, string gender)
        {
            E_User euser = new E_User();
            bool istrue = false;
            try
            {
                euser.user_Account = account;
                euser.user_Pw = pwd;
                euser.user_Name = name;
                euser.user_Address = address;
                euser.user_Tel = tel;
                euser.user_Create_Time = Convert.ToDateTime(time);
                euser.remark1 = email;
                euser.remark2 = gender;
                istrue = bll.Insert(euser);
            }
            catch
            {

            }
            if (istrue)
                return "true";
            else
                return "false";
        }
    }
}
