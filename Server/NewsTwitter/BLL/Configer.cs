using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoeMobile.BLL
{
    public class Configer
    {
        public static int MYSQL = 1;
        public static int MSSQL = 2;
        public static int ORACLE = 3;

        private int db_type = MYSQL;

        public int DB_TYPE
        {
            get { return db_type; }
            set { db_type = value; }
        }

     

    }
}
