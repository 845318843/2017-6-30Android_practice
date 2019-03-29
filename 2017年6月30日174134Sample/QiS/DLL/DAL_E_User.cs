using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    ///  企业用户（会员）表 数据库操作类
    /// </summary>
    public class DAL_E_User
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        E_User e_user1 = new E_User();

        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(e_user1);
        }

        /// <summary>
        ///  信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(E_User E_User_up)
        {
            return dal_base.update(E_User_up);
        }

        /// <summary>
        ///  删除    
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(E_User E_User_del)
        {
            return dal_base.delete(E_User_del);
        }

        /// <summary>
        /// 增加   信息插入记录
        /// </summary>
        /// <param name="E_User_in"></param>
        /// <returns></returns>
        public bool insert(E_User E_User_in)
        {
            return dal_base.insert(E_User_in);
        }

        #endregion


        /// <summary>
        /// 判断  账号  是否重复
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool Re_Account()
        {
            //str = "select * from LabInfo where name='" + no + "'";
            //if (sql.FillDt(str).Rows.Count > 0)
            return true;
        }
 
        /// <summary>
        ///  通过 账号主键 精确查找 会员  2017年6月27日20:56:29      
        /// </summary>
        /// <param name="user_id">用户的主键</param>
        /// <returns></returns>
        public E_User FindE_User_ByAccount(string user_Account)
        {
            str = @"select  user_Id,user_Account,user_Name,
                             user_Address,user_Balance,user_MS_Count,
                              user_Rank,user_Tel
               from E_User where user_Account='" + user_Account + "'  ";
               DataTable table = sql.FillDt(str);
               E_User  dd = new E_User() ;
               dd.user_Id =(int)table.Rows[0]["user_Id"];
                        dd.user_Account = table.Rows[0]["user_Account"].ToString();
                             dd.user_Name =    table.Rows[0]["user_Name"].ToString();
               dd.user_Address = table.Rows[0]["user_Address"].ToString();
                         dd.user_Balance =  table.Rows[0]["user_Balance"].ToString();
                             dd.user_MS_Count = (int)table.Rows[0]["user_MS_Count"];
               dd.user_Rank = (int)table.Rows[0]["user_Rank"];
                         dd.user_Tel = table.Rows[0]["user_Tel"].ToString();
            return dd;
        }



        /// <summary>
        ///  通过 账号 模糊查找 会员
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        public List<E_User> FuzzyFindE_User_ByAccount(string Account)
        {
            //str = "select * from Message where message_Title like '" + message_title + "' and (message_State is null or message_State='') ";
            //return sql.FillDt(str).Rows[0][0].ToString();
            List<E_User> dd = null;
            return dd;
        }


        /// <summary>
        /// 用户登录       2017/5/13 左县委
        /// </summary>
        /// <param name="username">用户帐号</param>
        /// <param name="pwd">用户密码</param>
        /// <returns>登录成功 true</returns>
        public bool Login(E_User users)
        {
            //bool istrue = false;
            //string strsql = "select user_Pw from E_User where user_Account=@username";
            //SqlParameter[] para = { new SqlParameter("@username", users.user_Account) };
            //SqlDataReader sr = sql.GetDataReader(strsql, para);
            ////string uuuu = sr.GetString(0).ToString();
            ////SqlDataReader sr = db.GetDataReader(strsql,para);
            //while (sr.Read())
            //{
            //    if (sr.GetString(0) == users.user_Pw)
            //    {
            //        sr.Close();
            //        istrue = true;
            //        break;
            //    }
            //    else
            //    {
            //        sr.Close();
            //        istrue = false;
            //        break;
            //    }
            //}
            //sr.Close();
            //return istrue;
            str = "select * from E_User where user_Account=@user_Account and user_Pw=@user_Pw";
               SqlParameter[] para = { new SqlParameter("@user_Account", users.user_Account), new SqlParameter("@user_Pw", users.user_Pw) };
            if (sql.FillDt_para(str, para).Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
    }
}
