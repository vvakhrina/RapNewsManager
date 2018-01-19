using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data;
using System.Data.SqlClient;

namespace RapNewsManager.Models
{

    [Table("User")]
    public class User
    {
        [Key]
        public int Id_user { get; set; }

        [StringLength(30)]
        public string Name_user { get; set; }

        [Column("E-mail")]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        public int? id_role { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        [StringLength(255)]
        public string Nickname { get; set; }

        public int id_city { get; set; }

        [StringLength(255)]
        public string Fanpage { get; set; }

        [StringLength(8000)]
        public string Other { get; set; }

        public int nb_patronat { get; set; }

        public int nb_top_news { get; set; }

        public DateTime Birthday_date { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_email">User email</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _email, string _password, ref Models.User objUser)
        {
            using (var cn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RapNewsManagerBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

                string _sql = string.Format("SELECT {0},{1},{2},{3},{4},{5},{6},{7},{8} FROM [dbo].[User] ",
                                            Defines.UserDefines.column_name_user,
                                            Defines.UserDefines.column_email,
                                            Defines.UserDefines.column_password,
                                            Defines.UserDefines.column_nickname,
                                            Defines.UserDefines.column_birthday_date,
                                            Defines.UserDefines.column_nb_patronat,
                                            Defines.UserDefines.column_nb_top_news,
                                            Defines.UserDefines.column_fanpage,
                                            Defines.UserDefines.column_other) +
                       @"WHERE [Email] = @u AND [Password] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _email;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = _password;
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objUser.Name_user = dr[Defines.UserDefines.column_name_user].ToString();
                            objUser.Email = dr[Defines.UserDefines.column_email].ToString();
                            objUser.Password = dr[Defines.UserDefines.column_password].ToString();
                            objUser.Nickname = dr[Defines.UserDefines.column_nickname].ToString();
                            objUser.Birthday_date = Convert.ToDateTime(dr[Defines.UserDefines.column_birthday_date]);
                            objUser.nb_patronat = Convert.ToInt32(dr[Defines.UserDefines.column_nb_patronat]);
                            objUser.nb_top_news = Convert.ToInt32(dr[Defines.UserDefines.column_nb_top_news]);
                            objUser.Fanpage = dr[Defines.UserDefines.column_fanpage].ToString();
                            objUser.Other = dr[Defines.UserDefines.column_other].ToString();
                        }
                        dr.Dispose();
                        cmd.Dispose();
                        return true;
                    }
                    else
                    {
                        dr.Dispose();
                        cmd.Dispose();
                        return false;
                    }
                }
            }
        }
    }
}
