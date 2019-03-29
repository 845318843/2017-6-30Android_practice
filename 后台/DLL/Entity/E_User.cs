using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class E_User
    {
        #region 成员

        private int _user_Id;
        private string _user_Account;
        private string _user_Pw;
        private string _user_Name;
        private string _user_Address;
        private string _user_Tel;
        private string _user_Balance;
        private DateTime _user_Create_Time;
        private int _user_MS_Count;
        private int _user_Rank;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 会员编号
        /// </summary>
        public int user_Id
        {
            get { return _user_Id; }
            set { _user_Id = value; }
        }

        /// <summary>
        /// 会员帐号
        /// </summary>
        public string user_Account
        {
            get { return _user_Account; }
            set { _user_Account = value; }
        }
        /// <summary>
        /// 会员密码
        /// </summary>
        public string user_Pw
        {
            get { return _user_Pw; }
            set { _user_Pw = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string user_Name
        {
            get { return _user_Name; }
            set { _user_Name = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string user_Address
        {
            get { return _user_Address; }
            set { _user_Address = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string user_Tel
        {
            get { return _user_Tel; }
            set { _user_Tel = value; }
        }
        /// <summary>
        /// 余额
        /// </summary>
        public string user_Balance
        {
            get { return _user_Balance; }
            set { _user_Balance = value; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime user_Create_Time
        {
            get { return _user_Create_Time; }
            set { _user_Create_Time = value; }
        }
        /// <summary>
        /// 消息总阅读量
        /// </summary>
        public int user_MS_Count
        {
            get { return _user_MS_Count; }
            set { _user_MS_Count = value; }
        }
        /// <summary>
        /// 用户等级
        /// </summary>
        public int user_Rank
        {
            get { return _user_Rank; }
            set { _user_Rank = value; }
        }
        /// <summary>
        /// 备注一
        /// </summary>
        public string remark1
        {
            get { return _remark1; }
            set { _remark1 = value; }
        }
        /// <summary>
        /// 备注二
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
                case "user_Id": return false;
                case "user_Account": return true;
                case "user_Pw": return true;
                case "user_Name": return true;
                case "user_Address": return true;
                case "user_Tel": return true;
                case "user_Balance": return true;
                case "user_Create_Time": return true;
                case "user_MS_Count": return true;
                case "user_Rank": return true;
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
                case "user_Id": return false;
                case "user_Account": return true;
                case "user_Pw": return true;
                case "user_Name": return true;
                case "user_Address": return true;
                case "user_Tel": return true;
                case "user_Balance": return true;
                case "user_Create_Time": return true;
                case "user_MS_Count": return true;
                case "user_Rank": return true;
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
                case "user_Id": return "会员编号";
                case "user_Account": return "会员帐号";
                case "user_Pw": return "会员密码";
                case "user_Name": return "姓名";
                case "user_Address": return "地址";
                case "user_Tel": return "电话";
                case "user_Balance": return "余额";
                case "user_Create_Time": return "注册时间";
                case "user_MS_Count": return "消息总阅读量";
                case "user_Rank": return "用户等级";
                case "remark1": return "备注一";
                case "remark2": return "备注二";
                default: return null;
            }
        }

        #endregion

    }
}
