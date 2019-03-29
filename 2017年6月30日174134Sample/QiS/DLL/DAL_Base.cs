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
    ///  泛型的数据库操作
    /// </summary>
    public class DAL_Base
    {
        /// <summary>
        /// 数据库SQL语句
        /// </summary>
        string str = "";

        SqlDB sql = new SqlDB();

        /// <summary>
        /// 查找所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public DataTable findAll<T>(T a)
        {
            try
            {
                str = DBOperate.sqlLoadAll(a);           
                return sql.FillDt(str);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool update<T>(T a)
        {
            try
            {
                str = DBOperate.sqlUpdtae(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool delete<T>(T a)
        {
            try
            {
                str = DBOperate.sqlDelete(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///  插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool insert<T>(T a)
        {
            try
            {
                str = DBOperate.sqlInsert(a);
                return sql.ExecSql(str);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///  带参数插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool insertAddSpara<T>(T a, SqlParameter[] pms)
        {
            try
            {
                str = DBOperate.sqlInsertAddSpara(a,out pms);
                return sql.ExecSql(str,pms);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
