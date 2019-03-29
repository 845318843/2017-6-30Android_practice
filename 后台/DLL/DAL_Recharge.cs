using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    ///  充值表 数据库操作类
    /// </summary>
    public class DAL_Recharge
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        Recharge recharge1 = new Recharge();

        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(recharge1);
        }

        /// <summary>
        ///  实验室信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(Recharge recharge_up)
        {
            return dal_base.update(recharge_up);
        }

        /// <summary>
        ///  删除     5-11前参数是传string id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(Recharge recharge_del)
        {
            return dal_base.delete(recharge_del);
        }

        /// <summary>
        /// 增加  实验室信息插入记录
        /// </summary>
        /// <param name="message_in"></param>
        /// <returns></returns>
        public bool insert(Recharge recharge_in)
        {
            return dal_base.insert(recharge_in);
        }

        #endregion

      

        /// <summary>
        ///  通过 充值时间或账号 查找 充值记录
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        public List<Recharge> FindRecharge_ByTime(string stime, string etime,string account)
        {
            //str = "select * from Message where message_Title like '" + message_title + "' and (message_State is null or message_State='') ";
            //return sql.FillDt(str).Rows[0][0].ToString();

            List<Recharge> list = null;
            return list;
        }


    }
}
