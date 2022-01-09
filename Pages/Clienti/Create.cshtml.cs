using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Data;
using Web.Models;

namespace Web.Pages.Clienti
{
    public class CreateModel : CategorieAntrenamentPageModel
    {
        private readonly Web.Data.WebContext _context;

        public CreateModel(Web.Data.WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AntrenorID"] = new SelectList(_context.Set<Antrenor>(), "ID", "NumeAntrenor");
            var Client = new Client();
            Client.CategoriiAntrenament = new List<CategorieAntrenament>();
            PopulateAntrenamentAles(_context, Client);
            return Page();
        }

        [BindProperty]
        public Client Clienti { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newClient = new Client();
            if (selectedCategories != null)
            {
                newClient.CategoriiAntrenament = new List<CategorieAntrenament>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieAntrenament
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newClient.CategoriiAntrenament.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Client>(newClient,
                "Client",
                i => i.Nume, i => i.Prenume,
                i => i.Programare, i => i.AntrenorID))
            {
                _context.Client.Add(newClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAntrenamentAles(_context, newClient);
            return Page();
        }
    }
}
