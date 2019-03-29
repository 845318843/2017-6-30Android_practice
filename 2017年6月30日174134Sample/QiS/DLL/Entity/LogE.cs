using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    /// <summary> 	/// 实体类
    /// </summary>
    public class LogE
    {
        #region 成员

        private int _loge_Id;
        private string _name;
        private string _action;
        private string _remark;

        #endregion

        #region 属性

        /// <summary>
        /// 编号
        /// </summary>
        public int loge_Id
        {
            get { return _loge_Id; }
            set { _loge_Id = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// 行为
        /// </summary>
        public string action
        {
            get { return _action; }
            set { _action = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
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
                case "loge_Id": return false;
                case "name": return true;
                case "action": return true;
                case "remark": return true;
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
                case "loge_Id": return false;
                case "name": return true;
                case "action": return true;
                case "remark": return true;
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
                case "loge_Id": return "编号";
                case "name": return "姓名";
                case "action": return "行为";
                case "remark": return "备注";
                default: return null;
            }
        }

        #endregion

    }
}
