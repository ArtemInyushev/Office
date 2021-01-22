using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models {
    [Table("Workers")]
    public class Worker {
        [Ignore]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool Married { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required]
        public double Salary { get; set; }
    }
}
