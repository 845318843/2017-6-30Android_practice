using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DAL_HS_Inform
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        HS_Inform inform = new HS_Inform();


        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(inform);
        }

        /// <summary>
        ///  信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(HS_Inform inform_up)
        {
            return dal_base.update(inform_up);
        }

        /// <summary>
        ///  删除     5-11前参数是传string id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(HS_Inform inform_del)
        {
            return dal_base.delete(inform_del);
        }

        /// <summary>
        /// 增加  信息插入记录
        /// </summary>
        /// <param name="inform_in"></param>
        /// <returns></returns>
        public bool insert(HS_Inform inform_in)
        {
            return dal_base.insert(inform_in);
        }
 
        #endregion


        /// <summary>
        ///   根据 账号 查找 通知集合     2017年6月27日21:12:04
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public List<HS_Inform> FindHS_Inform_ByAccount(E_User find)
        {
            string ss = "";
            ss = @"select * from HS_Inform where  ( inform_Message_Time < inform_Message_Total_Time   )";
            if (!string.IsNullOrWhiteSpace(find.user_Account)  )
            {
                ss += " and inform_User_Account = '" + find.user_Account + "'";
            }
            str = ss + "  order by inform_Id desc ";
            DataTable table = sql.FillDt(str);
            List<HS_Inform> list = HS_Inform.DataTable2HS_Inform(table);
            return list;
        }
    }
}
