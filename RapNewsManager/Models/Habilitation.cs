using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RapNewsManager.Models
{
    [Table("Habilitation")]
    public class Habilitation
    {
        [Key]
        public int id_habilitation { get; set; }

        [StringLength(255)]
        public string function_name { get; set; }
    }
}
