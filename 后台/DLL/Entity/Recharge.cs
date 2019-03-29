using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class Recharge
    {
        #region 成员

        private int _recharge_Id;
        private string _recharge_Amount;
        private DateTime _recharge_Time;
        private int _recharge_State;
        private string _remark1;
        private string _remark2;

        #endregion

        #region 属性

        /// <summary>
        /// 充值编号
        /// </summary>
        public int recharge_Id
        {
            get { return _recharge_Id; }
            set { _recharge_Id = value; }
        }
        /// <summary>
        /// 充值金额
        /// </summary>
        public string recharge_Amount
        {
            get { return _recharge_Amount; }
            set { _recharge_Amount = value; }
        }
        /// <summary>
        /// 充值时间
        /// </summary>
        public DateTime recharge_Time
        {
            get { return _recharge_Time; }
            set { _recharge_Time = value; }
        }
        /// <summary>
        /// （0,1）
        /// </summary>
        public int recharge_State
        {
            get { return _recharge_State; }
            set { _recharge_State = value; }
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
                case "recharge_Id": return false;
                case "recharge_Amount": return true;
                case "recharge_Time": return true;
                case "recharge_State": return true;
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
                case "recharge_Id": return false;
                case "recharge_Amount": return true;
                case "recharge_Time": return true;
                case "recharge_State": return true;
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
                case "recharge_Id": return "充值编号";
                case "recharge_Amount": return "充值金额";
                case "recharge_Time": return "充值时间";
                case "recharge_State": return "（0,1）";
                case "remark1": return "备注一";
                case "remark2": return "备注二";
                default: return null;
            }
        }

        #endregion

    }
}
