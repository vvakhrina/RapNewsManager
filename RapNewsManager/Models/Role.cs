using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RapNewsManager.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int id_role { get; set; }

        [StringLength(10)]
        public string role_name { get; set; }

        public int? id_habilitation { get; set; }
    }
}
