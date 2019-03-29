using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLL_HS_Inform
    {
        DAL_HS_Inform hs_imform = new DAL_HS_Inform();

        /// <summary>
        ///   根据 账号 查找 通知集合     2017年6月27日21:12:04
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public List<HS_Inform> FindHS_Inform_ByAccount(E_User find)
        {
            return hs_imform.FindHS_Inform_ByAccount(find);
        }

    }
}
