using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CategorieAntrenament
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }

    }
}
