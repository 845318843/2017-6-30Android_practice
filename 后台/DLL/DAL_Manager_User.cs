using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_Manager_User
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        Manager_User Manager_User1 = new Manager_User();

        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(Manager_User1);
        }

        /// <summary>
        ///  信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(Manager_User Manager_User_up)
        {
            return dal_base.update(Manager_User_up);
        }

        /// <summary>
        ///  删除    
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(Manager_User Manager_User_del)
        {
            return dal_base.delete(Manager_User_del);
        }

        /// <summary>
        /// 增加   信息插入记录
        /// </summary>
        /// <param name="Manager_User_in"></param>
        /// <returns></returns>
        public bool insert(Manager_User Manager_User_in)
        {
            return dal_base.insert(Manager_User_in);
        }

        #endregion

        public bool Login(Manager_User Manager_User)
        {
            str = "select * from E_User where manager_Account=@manager_Account and manager_Pw=@manager_Pw";
            SqlParameter[] para = { new SqlParameter("@manager_Account", Manager_User.manager_Account), new SqlParameter("@manager_Pw", Manager_User.manager_Pw) };
            if (sql.FillDt_para(str, para).Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
    }
}
