using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using BLL;


namespace QiS
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            E_User usersin = new E_User();// 传入的用户
            usersin.user_Account = "123456";
            usersin.user_Pw = "123123";
            String aa = Util.Serialize(usersin);
        
            return aa;
        }

        [WebMethod]
        public string DataTableTest()
        {
            DataTable dt = new DataTable("userTable");
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Rows.Add(1, "gary.gu", "guwei4037@sina.com");
            dt.Rows.Add(2, "jinyingying", "345822155@qq.com");
            dt.Rows.Add(3, "jinyingying", "345822155@qq.com");
            dt.Rows.Add(4, "jinyingying", "345822155@qq.com");

           // return Util.CreateJsonParameters(dt);
            return "";
        }

        [WebMethod]
        public string DataTableMessage()
        {/* 待写 */
            DataTable dt = new DataTable("MessageTable");
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Rows.Add(1, "gary.gu", "guwei4037@sina.com");
            dt.Rows.Add(2, "jinyingying", "345822155@qq.com");
            dt.Rows.Add(3, "jinyingying", "345822155@qq.com");
            dt.Rows.Add(4, "jinyingying", "345822155@qq.com");

            return Util.DataTableToJSON(dt,true).ToString();        
        }

        #region  2017年6月26日18:05:07 废除  原因：改用json传 message
        //[WebMethod(Description = "获取符合要求的消息")]
        //public List<MessageEN> EntityMessage(string region, string industry)
        //{
        //    List<MessageEN> list = new List<MessageEN>();
        //    BLL_Message bll_message = new BLL_Message();

        //    list = bll_message.FindMessage_ByRegionOrIndustry(region, industry);
        //    return list;
        //}
        #endregion


        #region 2017年6月29日18:39:39   因为 region 和 industry 不在消息里面，暂时不传入json 后期会修改为 传入json
        [WebMethod(Description = "获取符合要求的消息")]/* 2017年6月27日9:58:18 修改为不传图片 */
        public string EntityMessage(string region, string industry)
        {
            List<MessageLessList> list = new List<MessageLessList>();
            BLL_Message bll_message = new BLL_Message();

            list = bll_message.FindMessage_ByRegionOrIndustry(region, industry);
            return Util.JsonSerializer_to_Json(list);
        }
        #endregion

        /// <summary>
        /// 查找通知函数         传入json(用户的一个实体)  传出也是 json(通知的实体list)
        /// </summary>
        /// <param name="users">实体类</param>
        /// <returns>登录成功 true</returns>
        [WebMethod]
        public string HS_Inform(string jsonuserin)
        {
            string jsoninformlistout = "";
            E_User usersin = new E_User();// 传入的用户
            List<HS_Inform> list = new List<Model.HS_Inform>();// 返回的通知集合
            BLL_HS_Inform bll_hs_inform = new BLL_HS_Inform();
            usersin = Util.Deserialize<E_User>(jsonuserin);

            if (!string.IsNullOrWhiteSpace(usersin.user_Account))
            {
                list = bll_hs_inform.FindHS_Inform_ByAccount(usersin);
                jsoninformlistout = Util.JsonSerializer_to_Json(list);
                return jsoninformlistout;
            }
            else
            {
                return "false7";
            }
        }

        /// <summary>
        /// 登录函数         传入json(用户的一个实体)  传出也是 json(用户的一个实体)
        /// </summary>
        /// <param name="users">实体类</param>
        /// <returns>登录成功 true</returns>
        [WebMethod]
        public string Login(string jsonuserin)
        {
            string jsonuserout = "";
            E_User usersin = new E_User();// 传入的用户
            E_User usersout = new E_User();// 返回的用户
            BLL_E_User bll = new BLL_E_User();
            usersin = Util.Deserialize<E_User>(jsonuserin);
             
            if (  bll.login(usersin)  )
            {
                usersout = bll.FindE_User_ByAccount(usersin);
                jsonuserout = Util.Serialize(usersout);
                return jsonuserout;
            }
            else
            {
                return "false6";
            }
        }

   

        #region  登陆   2017年6月27日16:53:59 废除  改用 传入json  传出也是json


        /// <summary>
        /// 将参数封装成实体类，然后传参
        /// </summary>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功 “true”</returns>
        //[WebMethod]
        //public string ModelLogin(string username, string password)
        //{
        //    E_User users = new E_User();
        //    bool istrue = false;
        //    try
        //    {
        //        users.user_Account = username;
        //        users.user_Pw = password;
        //        if (Login(users))
        //        {
        //            istrue = true;
        //        }
        //        else
        //        {
        //            istrue = false;
        //        }
        //    }
        //    catch
        //    {
        //        istrue = false;
        //    }
        //    if (istrue)
        //    {
        //        return "true";
        //    }
        //    else
        //    {
        //        return "false6";
        //    }
        //}
        #endregion




    }
}
