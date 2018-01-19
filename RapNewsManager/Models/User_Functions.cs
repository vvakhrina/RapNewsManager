using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RapNewsManager.Models
{
    public class User_Functions
    {
        [Key]
        public int Id_function { get; set; }

        public int? id_role { get; set; }

        public int? id_habilitation { get; set; }
    }
}
