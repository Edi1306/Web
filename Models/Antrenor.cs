using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Antrenor
    {
        public int ID { get; set; }
        public string NumeAntrenor { get; set; }
        public ICollection<Client> Clienti { get; set; }
    }
}