using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
//using EnterpriseNewModel;
//using EnterpriseNewBLL;
using Model;
using BLL;

namespace EnterpriseNew
{
    /// <summary>
    /// ShowNeedWeb 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class ShowNeedWeb : System.Web.Services.WebService
    {
        BLL_Message bll = new BLL_Message();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 将参数转成对象 传参
        /// </summary>
        /// <param name="region">地理区域</param>
        /// <param name="industry">行业</param>
        /// <param name="time">发布时间</param>
        /// <param name="content">内容</param>
        /// <param name="name">发布者</param>
        /// <param name="tel">电话</param>
        /// <param name="email">邮箱</param>
        /// <returns> 发布成功 “true”</returns>
        [WebMethod]
        public string share(string region, string industry, string time, string content, string name, string tel, string email)
        {
            bool istrue = false;
            MessageEN message = new MessageEN();
            try
            {
                message.message_Region = region;
                message.message_Industry = industry;
                
                message.message_Content = content;
                message.message_Creator = name;
                message.remark1 = tel;
                message.remark2 = email;
                message.message_Time = Convert.ToDateTime("2017/5/14");
                if (bll.InsertMessage(message))
                    istrue = true;
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            if (istrue)
                return "true";
            else
                return "false";
        }
    }
}
