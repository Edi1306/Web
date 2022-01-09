using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly Web.Data.WebContext _context;

        public IndexModel(Web.Data.WebContext context)
        {
            _context = context;
        }

        public IList<Client> Clienti { get; set; }
        public ClientData ClientD { get; set; }
        public int ClientID { get; set; }
        public int CategorieID { get; set; }


        public async Task OnGetAsync(int? id, int? CategorieID)
        {
            ClientD = new ClientData();

            ClientD.Clienti = await _context.Client
            .Include(b => b.Antrenor)
            .Include(b => b.CategoriiAntrenament)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();

            if (id != null)
            {
                ClientID = id.Value;
                Client Client = ClientD.Clienti
                .Where(i => i.ID == id.Value).Single();
                ClientD.Categorii = Client.CategoriiAntrenament.Select(s => s.Categorie);
            }

        }
    }
}
