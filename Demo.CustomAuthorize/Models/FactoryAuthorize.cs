using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Demo.CustomAuthorize.Models
{
    public class FactoryAuthorize : AuthorizeAttribute
    {
        private readonly string[] _allowFactory;

        public FactoryAuthorize(params string[] facotrys)
        {
            this._allowFactory = facotrys;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException();
            if (!httpContext.User.Identity.IsAuthenticated)
                return false;
            FormsIdentity id = httpContext.User.Identity as FormsIdentity;
            string userid = id.Name;

            var users = User.InitData();
            //尋找有無使用者資料
            if (users.Select(q => q.userId).Where(q => q == userid).Count() == 0)
                return false;
            //取得登入者資訊
            var userdata = users.Where(q => q.userId == userid).FirstOrDefault();
            //判斷是否有工廠權限，有權限就回傳true
            foreach (var factroy in _allowFactory)
                if (userdata.factory.Contains(factroy))
                    return true;
            return false;
        }
    }
}