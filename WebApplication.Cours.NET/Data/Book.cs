using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Cours.NET.Data
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public String Name { get; set; }
        public String Content { get; set; }
        public float Price { get; set; }
    }
}
