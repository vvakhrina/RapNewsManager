using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapNewsManager
{
    public class Defines
    {
        public class UserDefines
        {
            public static readonly string column_id_user = "Id_user";
            public static readonly string column_name_user= "Name_user";
            public static readonly string column_email = "Email";
            public static readonly string column_password = "Password";
            public static readonly string column_id_role = "id_role";
            public static readonly string column_nickname = "Nickname";
            public static readonly string column_id_city = "id_city";
            public static readonly string column_fanpage= "Fanpage";
            public static readonly string column_other = "Other";
            public static readonly string column_nb_patronat = "nb_patronat";
            public static readonly string column_nb_top_news = "nb_top_news";
            public static readonly string column_birthday_date = "Birthday_date";
        }

        public class NewsDefines
        {
            public static readonly string column_id_news = "id_news";            
            public static readonly string column_title = "title";
            public static readonly string column_content = "content";
            public static readonly string column_status = "status";
            public static readonly string column_id_type_news = "id_type_news";
            public static readonly string column_id_user = "id_user";
        }
    }
}