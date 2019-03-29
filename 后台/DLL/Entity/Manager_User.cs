using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Manager_User
    {
        #region 成员

        private int _manager_Id;
        private string _manager_Account;
        private string _manager_Pw;
        private string _manager_Name;
        private int _manager_Rank;
        private string _manager_Address;
        private string _manager_Tel;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 管理员编号
        /// </summary>
        public int manager_Id
        {
            get { return _manager_Id; }
            set { _manager_Id = value; }
        }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string manager_Account
        {
            get { return _manager_Account; }
            set { _manager_Account = value; }
        }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string manager_Pw
        {
            get { return _manager_Pw; }
            set { _manager_Pw = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string manager_Name
        {
            get { return _manager_Name; }
            set { _manager_Name = value; }
        }
        /// <summary>
        /// 管理员等级
        /// </summary>
        public int manager_Rank
        {
            get { return _manager_Rank; }
            set { _manager_Rank = value; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string manager_Address
        {
            get { return _manager_Address; }
            set { _manager_Address = value; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string manager_Tel
        {
            get { return _manager_Tel; }
            set { _manager_Tel = value; }
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
                case "manager_Id": return false;
                case "manager_Account": return true;
                case "manager_Pw": return true;
                case "manager_Name": return true;
                case "manager_Rank": return true;
                case "manager_Address": return true;
                case "manager_Tel": return true;
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
                case "manager_Id": return false;
                case "manager_Account": return true;
                case "manager_Pw": return true;
                case "manager_Name": return true;
                case "manager_Rank": return true;
                case "manager_Address": return true;
                case "manager_Tel": return true;
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
                case "manager_Id": return "管理员编号";
                case "manager_Account": return "管理员账号";
                case "manager_Pw": return "管理员密码";
                case "manager_Name": return "姓名";
                case "manager_Rank": return "管理员等级";
                case "manager_Address": return "地址";
                case "manager_Tel": return "电话";
                case "remark1": return "备注一";
                case "remark2": return "备注二";
                default: return null;
            }
        }

        #endregion

    }
}
