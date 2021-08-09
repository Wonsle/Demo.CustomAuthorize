using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.CustomAuthorize.Models
{
    public class User
    {
        public string userId { get; set; }
        public string[] factory { get; set; }

        //初始化使用者資料
        public static List<User> InitData()
        {
            var users = new List<User>();
            users.Add(new User { userId = "T0User", factory = new string[] { "T1", "T2" } });
            users.Add(new User { userId = "T1User", factory = new string[] { "T1" } });
            users.Add(new User { userId = "T2User", factory = new string[] { "T2" } });
            return users;
        }
    }
}