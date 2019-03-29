using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_E_User
    {
        DAL_E_User e_user = new DAL_E_User();

        /// <summary>
        /// 用户登录       2017/5/13 左县委
        /// </summary>
        /// <param name="username">用户帐号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns>登录成功 true</returns>
        public bool login(E_User users)
        {
            return e_user.Login(users);
        }

        /// <summary>
        ///   通过 账号 精确查找 会员  2017年6月27日21:12:04
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public E_User FindE_User_ByAccount(E_User find)
        {
            return e_user.FindE_User_ByAccount(find.user_Account.ToString());
        }

        /// <summary>
        ///  添加一个新用户
        /// </summary>
        /// <param name="ins"></param>
        /// <returns></returns>
        public bool Insert(E_User ins)
        {
            return e_user.insert(ins);
        }


        ///// <summary>
        ///// 发布需求消息
        ///// </summary>
        ///// <param name="message">消息对象</param>
        ///// <returns>发布成功 true</returns>
        //public bool addMessage(MessageEN message)
        //{
        //    return message.addMessage(message);
        //}


        //public List<MessageEN> FindMessage_ByRegionOrIndustry(string region, string industry)
        //{
        //    return message.FindMessage_ByRegionOrIndustry(region, industry);
        //}



    }
}

