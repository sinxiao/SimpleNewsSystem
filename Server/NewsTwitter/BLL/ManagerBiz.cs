using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace WoeMobile.BLL
{
    public class ManagerBiz : AdminManager
    {
        public WoeMobile.Model.manager loginWithEmail(String email, String passwd) 
        {
            WoeMobile.Model.manager admin = GetManagerByEmail(email);
            if (admin == null)
            {
                return null;
            }
            else 
            {
                if (admin.pwdword.Equals(passwd))
                {
                     admin.last_login = DateTime.Now;
                     Update(admin);
                    return admin;
                }
                return null;
            }
          
            
        }
        public WoeMobile.Model.manager GetManagerByEmail(String email)
        {
            DataSet ds = dal.GetList("email = '" + email+"'");
            List<WoeMobile.Model.manager> lt = DataTableToList(ds.Tables[0]);
            if (lt == null || lt.Count <= 0)
            {
                return null;
            }
            else {
                return lt[0];
            }
            
        }

        public WoeMobile.Model.manager RegisterManager(Model.manager manager) 
        {
            WoeMobile.Model.manager lt = GetManagerByEmail(manager.email);
            if (lt != null)
            {

            }
            else
            {
                Boolean bl = Add(manager);
                if(bl==true)
                {
                    return GetManagerByEmail(manager.email);
                }
            }
            
            return null;
        }

        public DataSet GetRightByRoleId(int role) 
        {
            //select rolerightreltion.right_type , rights.*  from rolerightreltion left join rights on
            //rights.idRights = rolerightreltion.right_id where rolerightreltion.role_id = 1
            // idRights   parent_r_id  name url right_type
             String sql = "";
             if (role == 1)//1 as the admin role
             {
                 sql = "select *  from rights ";
             }
             else
             {
                 sql = "select rolerightreltion.right_type , rights.*  from rolerightreltion left join rights on rights.idRights = rolerightreltion.right_id where rolerightreltion.role_id = " + role;
             }
             DataSet ds = Maticsoft.DBUtility.DbHelperMySQL.Query(sql);
            return ds;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.manager> getManagerByPage(int page) 
        {

            return null;
        }
    }
}
