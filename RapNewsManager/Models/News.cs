using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RapNewsManager.Models
{
    public class News
    {
        [Key]
        public int id_news { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(8000)]
        public string content { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public int id_type_news { get; set; }

        public int id_user { get; set; }

        public Models.News GetUsersNews(int iIdUser, string sStatus)
        {
            using (var cn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RapNewsManagerBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                Models.News objNews = new News();
                string _sql = string.Format("SELECT {0},{1},{2},{3},{4} FROM [dbo].[News] ",
                                            Defines.NewsDefines.column_title,
                                            Defines.NewsDefines.column_content,
                                            Defines.NewsDefines.column_id_type_news,
                                            Defines.NewsDefines.column_status,
                                            Defines.NewsDefines.column_id_user) +
                       @"WHERE [id_user] = @u AND [status] = @s";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.Int))
                    .Value = iIdUser;
                cmd.Parameters
                    .Add(new SqlParameter("@s", SqlDbType.NVarChar))
                    .Value = sStatus; // D pour Drafts, A pour Archived
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objNews.title = dr[Defines.NewsDefines.column_title].ToString();
                            objNews.content = dr[Defines.NewsDefines.column_content].ToString();
                            objNews.status = dr[Defines.NewsDefines.column_status].ToString();
                            objNews.id_type_news = Convert.ToInt32(dr[Defines.NewsDefines.column_id_type_news]);
                            objNews.id_user = Convert.ToInt32(dr[Defines.NewsDefines.column_id_user]);                            
                        }
                        dr.Dispose();
                        cmd.Dispose();
                        return objNews;
                    }
                    else
                    {
                        dr.Dispose();
                        cmd.Dispose();
                        return null;
                    }
                }
            }
        }
    }
}