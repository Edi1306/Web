using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 1)]
        public string Nume { get; set; }
        [Required, StringLength(150, MinimumLength = 1)]
        public string Prenume { get; set; }
        public DateTime Programare { get; set; }
        public int AntrenorID { get; internal set; }
        public Antrenor Antrenor { get; set; }
        public ICollection<CategorieAntrenament> CategoriiAntrenament { get; set; }
    }
}