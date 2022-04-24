using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apirestcore31.Repository.Models
{
    [Table("Usuarios1")]
    public partial class Usuarios1
    {
        [Column("success")]
        public bool? Success { get; set; }
        [Key]
        [Column("usuarioid")]
        [StringLength(50)]
        public string Usuarioid { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("apellido")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Column("tipo")]
        [StringLength(50)]
        public string Tipo { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
