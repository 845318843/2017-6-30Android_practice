using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data;

namespace Model
{
      /// <summary>  专门为传消息列表的   实体类
     /// </summary>
     [DataContract]//序列化  
    public  class MessageLessList
    {
        #region 成员
        private int _message_Id;
        private string _message_Region;
        private string _message_Industry;
        private string _message_Title;
        private string _message_Content;
        //private byte[] _message_Pic;
        //private DateTime _message_Time;
        private string _message_State;
        private string _message_Creator;
        private string _message_Checker;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 消息编号
        /// </summary>
        [DataMember]
        public int message_Id
        {
            get { return _message_Id; }
            set { _message_Id = value; }
        }
        /// <summary>
        /// 地理区域
        /// </summary>
        [DataMember]
        public string message_Region
        {
            get { return _message_Region; }
            set { _message_Region = value; }
        }
        /// <summary>
        /// 行业区域
        /// </summary>
        [DataMember]
        public string message_Industry
        {
            get { return _message_Industry; }
            set { _message_Industry = value; }
        }
        /// <summary>
        /// 消息标题
        /// </summary>
        [DataMember]
        public string message_Title
        {
            get { return _message_Title; }
            set { _message_Title = value; }
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        [DataMember]
        public string message_Content
        {
            get { return _message_Content; }
            set { _message_Content = value; }
        }
        ///// <summary>
        ///// 消息图片    没有图片
        ///// </summary>
        //[DataMember]
        //public byte[] message_Pic
        //{
        //    get { return _message_Pic; }
        //    set { _message_Pic = value; }
        //}
        ///// <summary>
        ///// 发布时间     没有发布时间
        ///// </summary>
        //[DataMember]
        //public DateTime message_Time
        //{
        //    get { return _message_Time; }
        //    set { _message_Time = value; }
        //}
        /// <summary>
        /// （空）用户名
        /// </summary>
        [DataMember]
        public string message_State
        {
            get { return _message_State; }
            set { _message_State = value; }
        }
        /// <summary>
        /// 发布人
        /// </summary>
        [DataMember]
        public string message_Creator
        {
            get { return _message_Creator; }
            set { _message_Creator = value; }
        }
        /// <summary>
        /// 审核的管理员
        /// </summary>
        [DataMember]
        public string message_Checker
        {
            get { return _message_Checker; }
            set { _message_Checker = value; }
        }
        /// <summary>
        /// 备注一
        /// </summary>
        [DataMember]
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }
        /// <summary>
        /// 备注二
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
                case "message_Id": return false;
                case "message_Region": return true;
                case "message_Industry": return true;
                case "message_Title": return true;
                case "message_Content": return true;
                case "message_Pic": return true;
                case "message_Time": return true;
                case "message_State": return true;
                case "message_Creator": return true;
                case "message_Checker": return true;
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
                case "message_Id": return false;
                case "message_Region": return true;
                case "message_Industry": return true;
                case "message_Title": return true;
                case "message_Content": return true;
                case "message_Pic": return true;
                case "message_Time": return true;
                case "message_State": return true;
                case "message_Creator": return true;
                case "message_Checker": return true;
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
                case "message_Id": return "消息编号";
                case "message_Region": return "地理区域";
                case "message_Industry": return "行业区域";
                case "message_Title": return "消息标题";
                case "message_Content": return "消息内容";
                case "message_Pic": return "消息图片";
                case "message_Time": return "发布时间";
                case "message_State": return "（空）用户名";
                case "message_Creator": return "发布人";
                case "message_Checker": return "审核的管理员";
                case "remark1": return "备注一";
                case "remark2": return "备注二";
                default: return null;
            }
        }

        #endregion

        /// <summary>
        ///  DataTable转Message    
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<MessageLessList> DataTable2Message(DataTable table)
        {
            List<MessageLessList> list = new List<MessageLessList>();
            MessageLessList ms = new MessageLessList();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ms = new MessageLessList();
                    ms._message_Id =int.Parse(  table.Rows[i]["message_Id"].ToString()  );
                    ms._message_Region = table.Rows[i]["message_Region"].ToString();
                    ms._message_Industry = table.Rows[i]["message_Industry"].ToString();
                    ms._message_Title = table.Rows[i]["message_Title"].ToString();
                    ms._message_Content = table.Rows[i]["message_Content"].ToString();
                    //if (table.Rows[i]["message_Pic"].ToString().Length > 10)
                    //{ ms._message_Pic = (Byte[])table.Rows[i]["message_Pic"]; }  
                    //else {  };    2017年6月27日9:56:11 修改  获取消息数组时不传图片，待获取具体某条消息时根据id再传图片
                    //ms._message_Time = (DateTime)table.Rows[i]["message_Time"];            
                    ms._message_State = table.Rows[i]["message_State"].ToString();
                    ms._message_Creator = table.Rows[i]["message_Creator"].ToString();
                    ms._message_Checker = table.Rows[i]["message_Checker"].ToString();
                    ms._remark1 = table.Rows[i]["remark1"].ToString();
                    ms._remark2 = table.Rows[i]["remark2"].ToString();
                    list.Add(ms);
            }
            return list;
        }
    }
}




 