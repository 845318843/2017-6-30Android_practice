using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
     [DataContract]//序列化  
    public class HS_Inform
    {
        #region 成员

        private int _inform_Id;
        private int _inform_Type;
        private int _inform_Message_Id;
        private string _inform_User_Account;
        private int _inform_Message_Time;
        private int _inform_Message_Total_Time;
        private string _inform_Title;
        private string _inform_Content;
        private string _inform_Time;
        private string _inform_Receive_Time;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 通知编号
        /// </summary>
        [DataMember]
        public int inform_Id
        {
            get { return _inform_Id; }
            set { _inform_Id = value; }
        }
        /// <summary>
        /// 通知类型
        /// </summary>
        [DataMember]
        public int inform_Type
        {
            get { return _inform_Type; }
            set { _inform_Type = value; }
        }
        /// <summary>
        /// 通知(消息类ID)
        /// </summary>
        [DataMember]
        public int inform_Message_Id
        {
            get { return _inform_Message_Id; }
            set { _inform_Message_Id = value; }
        }
        /// <summary>
        /// 通知(用户ID)
        /// </summary>
        [DataMember]
        public string inform_User_Account
        {
            get { return _inform_User_Account; }
            set { _inform_User_Account = value; }
        }
        /// <summary>
        /// 通知已发送次数
        /// </summary>
        [DataMember]
        public int inform_Message_Time
        {
            get { return _inform_Message_Time; }
            set { _inform_Message_Time = value; }
        }
        /// <summary>
        /// 通知需要发送次数
        /// </summary>
        [DataMember]
        public int inform_Message_Total_Time
        {
            get { return _inform_Message_Total_Time; }
            set { _inform_Message_Total_Time = value; }
        }
        /// <summary>
        /// 通知标题
        /// </summary>
        [DataMember]
        public string inform_Title
        {
            get { return _inform_Title; }
            set { _inform_Title = value; }
        }
        /// <summary>
        /// 通知正文内容
        /// </summary>
        [DataMember]
        public string inform_Content
        {
            get { return _inform_Content; }
            set { _inform_Content = value; }
        }
        /// <summary>
        /// 通知发放时间
        /// </summary>
        [DataMember]
        public string inform_Time
        {
            get { return _inform_Time; }
            set { _inform_Time = value; }
        }
        /// <summary>
        /// 通知接收时间
        /// </summary>
        [DataMember]
        public string inform_Receive_Time
        {
            get { return _inform_Receive_Time; }
            set { _inform_Receive_Time = value; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        [DataMember]
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        [DataMember]
        public string remark2
        {
            get { return _remark2; }
            set { _remark2 = value; }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断实体（表）主键，如果是主键返回 false,否则返回true
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public bool primary(string AttributeName)
        {
            switch (AttributeName)
            {
                case "inform_Id": return false;
                case "inform_Type": return true;
                case "inform_Message_Id": return true;
                case "inform_User_Account": return true;
                case "inform_Message_Time": return true;
                case "inform_Message_Total_Time": return true;
                case "inform_Title": return true;
                case "inform_Content": return true;
                case "inform_Time": return true;
                case "inform_Receive_Time": return true;
                case "remark1": return true;
                case "remark2": return true;
                default: return true;
            }
        }
        /// <summary>
        /// 判断实体（表）字段是否自增，如果是自增返回 false,否则返回true
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public bool remind(string AttributeName)
        {
            switch (AttributeName)
            {
                case "inform_Id": return false;
                case "inform_Type": return true;
                case "inform_Message_Id": return true;
                case "inform_User_Account": return true;
                case "inform_Message_Time": return true;
                case "inform_Message_Total_Time": return true;
                case "inform_Title": return true;
                case "inform_Content": return true;
                case "inform_Time": return true;
                case "inform_Receive_Time": return true;
                case "remark1": return true;
                case "remark2": return true;
                default: return true;
            }
        }
        /// <summary>
        ///返回每个字段的的注释
        /// </summary>
        /// <param name=AttributeName>属性名</param>
        /// <returns></returns>
        static public string Note(string AttributeName)
        {
            switch (AttributeName)
            {
                case "inform_Id": return "通知编号";
                case "inform_Type": return "通知类型";
                case "inform_Message_Id": return "通知(消息类ID)";
                case "inform_User_Account": return "通知(用户账号)";
                case "inform_Message_Time": return "通知已发送次数";
                case "inform_Message_Total_Time": return "通知需要发送次数";
                case "inform_Title": return "通知标题";
                case "inform_Content": return "通知正文内容";
                case "inform_Time": return "通知发放时间";
                case "inform_Receive_Time": return "通知接收时间";
                case "remark1": return "备注1";
                case "remark2": return "备注2";
                default: return null;
            }
        }
        #endregion

        /// <summary>
        ///  DataTable转Message    
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<HS_Inform> DataTable2HS_Inform(DataTable table)
        {
            List<HS_Inform> list = new List<HS_Inform>();
            HS_Inform hs_inform = new HS_Inform();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                hs_inform = new HS_Inform();
                hs_inform._inform_Id = int.Parse(table.Rows[i]["inform_Id"].ToString());
                hs_inform._inform_Type = int.Parse(table.Rows[i]["inform_Type"].ToString());
                hs_inform._inform_Message_Id = int.Parse(table.Rows[i]["inform_Message_Id"].ToString());
                hs_inform._inform_User_Account =  table.Rows[i]["inform_User_Account"].ToString();
                hs_inform._inform_Time = table.Rows[i]["inform_Message_Time"].ToString() ;
                hs_inform._inform_Message_Total_Time = int.Parse(table.Rows[i]["inform_Message_Total_Time"].ToString());
                hs_inform.inform_Title = table.Rows[i]["inform_Title"].ToString(); 
                hs_inform._inform_Content = table.Rows[i]["inform_Content"].ToString();
                hs_inform._inform_Time =  table.Rows[i]["inform_Time"].ToString() ;
                hs_inform._inform_Receive_Time = table.Rows[i]["inform_Receive_Time"].ToString() ;
                hs_inform._remark1 =  table.Rows[i]["remark1"].ToString() ;
                hs_inform._remark2 =  table.Rows[i]["remark2"].ToString() ;

                list.Add(hs_inform);
            }
            return list;
        }
 

    }
}
