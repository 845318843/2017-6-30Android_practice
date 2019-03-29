using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    ///  企业用户消费（流水表）表 数据库操作类
    /// </summary>
    public class DAL_Detail
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        Detail detail1 = new Detail();
        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(detail1);
        }

        /// <summary>
        ///  信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(Detail detail_up)
        {
            return dal_base.update(detail_up);
        }

        /// <summary>
        ///  删除    
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(Detail detail_del)
        {
            return dal_base.delete(detail_del);
        }

        /// <summary>
        /// 增加   信息插入记录
        /// </summary>
        /// <param name="detail_in"></param>
        /// <returns></returns>
        public bool insert(Detail detail_in)
        {
            return dal_base.insert(detail_in);
        }

        #endregion



        /// <summary>
        ///  通过 限定时间或限定账号 查找 流水表记录
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        public Detail FindDetails_ByTimeorAccount(string time, string account)
        {

            Detail tt = null;
            return tt;
        }

    }
}
