using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace apirestcore31.Repository.Models
{
    public partial class Student
    {
        [Key]
        public decimal? Secuencia { get; set; }
        [Column(TypeName = "numeric(18, 0)")]
        public Guid StudentId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string RollNumber { get; set; }
        public Guid ProfessorId { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Fees { get; set; }

        [ForeignKey(nameof(ProfessorId))]
        [InverseProperty("Students")]
        public virtual Professor Professor { get; set; }
    }
}
