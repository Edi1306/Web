using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ClientData
    {
        public IEnumerable<Client> Clienti { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieAntrenament> CategoriiAntrenament { get; set; }
    }
}
