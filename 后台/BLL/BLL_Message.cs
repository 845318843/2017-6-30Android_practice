using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_Message
    {
        DAL_Message message = new DAL_Message();






        /// <summary>
        /// 根据 地区行业 查找消息集合  2017年6月30日8:17:44
        /// </summary>
        /// <param name="region"></param>
        /// <param name="industry"></param>
        /// <returns></returns>
        public List<MessageLessList> FindMessage_ByRegionOrIndustry(string region, string industry)
        {
            return message.FindMessage_ByRegionOrIndustry(region, industry);
        }


        public bool InsertMessage(MessageEN ins)
        {
            if (ins.message_Pic==null||ins.message_Pic.Length < 10)
            { 
                return message.insert(ins);
            }
            else
            {
                SqlParameter[] pms= new SqlParameter[12];
                pms[0] = new SqlParameter("@message_Id", ins.message_Id);
                pms[1] = new SqlParameter("@message_Region", ins.message_Region);
                pms[2] = new SqlParameter("@message_Industry", ins.message_Industry);
                pms[3] = new SqlParameter("@message_Title", ins.message_Title);
                pms[4] = new SqlParameter("@message_Content", ins.message_Content);
                pms[5] = new SqlParameter("@message_Pic", ins.message_Pic);
                pms[6] = new SqlParameter("@message_Time", ins.message_Time);
                pms[7] = new SqlParameter("@message_State", ins.message_State);
                pms[8] = new SqlParameter("@message_Creator", ins.message_State);
                pms[9] = new SqlParameter("@message_Checker", ins.message_Checker);
                pms[10] = new SqlParameter("@remark1", ins.remark1);
                pms[11] = new SqlParameter("@remark2", ins.remark2);
                
                return message.insert_wpic(ins,pms); 
            }        
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

    }
}
