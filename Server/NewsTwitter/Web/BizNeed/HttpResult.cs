using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WoeMobile.Web.BizNeed
{
    public class HttpResult
    {
        private int result_status;

        public int Result_status
        {
            get { return result_status; }
            set { result_status = value; }
        }
        private int method_id;

        public int Method_id
        {
            get { return method_id; }
            set { method_id = value; }
        }
        private List<Model.images> rt;

        public List<Model.images> Rt
        {
            get { return rt; }
            set { rt = value; }
        }
    }
}