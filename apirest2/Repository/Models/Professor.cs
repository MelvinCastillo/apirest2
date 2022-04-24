using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.EntityFrameworkCore;



namespace apirestcore31.Repository.Models
{
    public partial class Professor
    {
        public Professor()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public Guid ProfessorId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Doj { get; set; }
        [StringLength(100)]
        public string Teaches { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? Salary { get; set; }
        public bool? IsPhd { get; set; }

        [InverseProperty(nameof(Student.Professor))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
