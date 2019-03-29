using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    ///  消息表 数据库操作类
    /// </summary>
    public class DAL_Message
    {
        DAL_Base dal_base = new DAL_Base();
        SqlDB sql = new SqlDB();
        string str = "";
        MessageEN message1 = new MessageEN();


        #region   基于  DAL_Base 的 简单增删查改

        /// <summary>
        /// 查找  返回所有数据
        /// </summary>
        /// <returns></returns>
        public DataTable findAll()
        {
            return dal_base.findAll(message1);
        }

        /// <summary>
        ///  信息更新记录
        /// </summary>
        /// <param name="ll"></param>
        /// <returns></returns>
        public bool update(MessageEN message_up)
        {
            return dal_base.update(message_up);
        }

        /// <summary>
        ///  删除     5-11前参数是传string id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool delete(MessageEN message_del)
        {
            return dal_base.delete(message_del);
        }

        /// <summary>
        /// 增加  信息插入记录
        /// </summary>
        /// <param name="message_in"></param>
        /// <returns></returns>
        public bool insert(MessageEN message_in)
        {
            return dal_base.insert(message_in);
        }

        /// <summary>
        /// 增加  带图片信息插入记录  待测试
        /// </summary>
        /// <param name="message_in"></param>
        /// <returns></returns>
        public bool insert_wpic(MessageEN message_in,SqlParameter[] pms)
        {
            return dal_base.insertAddSpara(message_in,pms);
        }

        #endregion


        #region  2017年6月27日11:47:25 废除   原因不合理：图片过多时会缓慢
        /// <summary>
        ///  通过 地区或行业 模糊查找 消息
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        //public List<MessageEN> FindMessage_ByRegionOrIndustry(string region, string industry)
        //{

        //    string ss = "";
        //    ss = "select * from MessageEN where (message_State is null or message_State='')  ";
        //    if (!string.IsNullOrWhiteSpace(region) && !region.Equals("undefined"))
        //    {            
        //        ss += " and message_Region like '%" + region + "%'";
        //    }
        //    if (!string.IsNullOrWhiteSpace(industry) && !industry.Equals("undefined"))
        //    {
        //        ss += " and message_Industry like '%" + industry + "%'";
        //    }
        //    str = ss + "  order by message_Id desc ";
        //    DataTable table = sql.FillDt(str);
        //    List<MessageEN> list = MessageEN.DataTable2Message(table);      
        //    return list;
        //}
        #endregion


        /// <summary>
        ///  通过 地区或行业 模糊查找 消息
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        public List<MessageLessList> FindMessage_ByRegionOrIndustry(string region, string industry)
        {

            string ss = "";
            ss = @"select message_Id,message_Region,message_Industry,
                         message_Title,message_Content,message_State,
                          message_Creator,message_Checker,remark1,remark2
                             from MessageEN where (message_State is null or message_State='')  ";
            if (!string.IsNullOrWhiteSpace(region) && !region.Equals("undefined"))
            {
                ss += " and message_Region like '%" + region + "%'";
            }
            if (!string.IsNullOrWhiteSpace(industry) && !industry.Equals("undefined"))
            {
                ss += " and message_Industry like '%" + industry + "%'";
            }
            str = ss + "  order by message_Id desc ";
            DataTable table = sql.FillDt(str);
            List<MessageLessList> list = MessageLessList.DataTable2Message(table);
            return list;
        }




        /// <summary>
        /// 判断  消息标题  是否重复
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool ReTitle()
        {
            //str = "select * from LabInfo where name='" + no + "'";
            //if (sql.FillDt(str).Rows.Count > 0)
            return true;
        }

        /// <summary>
        ///  通过消息标题 模糊查找 消息
        /// </summary>
        /// <param name="message_title"></param>
        /// <returns></returns>
        public List<MessageEN> FindMessageByTitle(string message_title)
        {
            List<MessageEN> list = null;
            return list;
        }


     


    }
}

