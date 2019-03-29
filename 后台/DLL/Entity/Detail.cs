using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Detail
    {
        #region 成员

        private int _detail_Id;
        private string _detail_Message_Id;
        private string _detail_Account;
        private DateTime _detail_Time;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 流水编号
        /// </summary>
        public int detail_Id
        {
            get { return _detail_Id; }
            set { _detail_Id = value; }
        }
        /// <summary>
        /// 管理员
        /// </summary>
        public string detail_Message_Id
        {
            get { return _detail_Message_Id; }
            set { _detail_Message_Id = value; }
        }
        /// <summary>
        /// 浏览账号
        /// </summary>
        public string detail_Account
        {
            get { return _detail_Account; }
            set { _detail_Account = value; }
        }
        /// <summary>
        /// 浏览的时间
        /// </summary>
        public DateTime detail_Time
        {
            get { return _detail_Time; }
            set { _detail_Time = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
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
                case "detail_Id": return false;
                case "detail_Message_Id": return true;
                case "detail_Account": return true;
                case "detail_Time": return true;
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
                case "detail_Id": return false;
                case "detail_Message_Id": return true;
                case "detail_Account": return true;
                case "detail_Time": return true;
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
                case "detail_Id": return "流水编号";
                case "detail_Message_Id": return "管理员";
                case "detail_Account": return "浏览账号";
                case "detail_Time": return "浏览的时间";
                case "remark1": return "备注";
                case "remark2": return "备注";
                default: return null;
            }
        }

        #endregion

    }
}
