using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Pages.Clienti
{
    public class EditModel : CategorieAntrenamentPageModel
    {
        private readonly Web.Data.WebContext _context;

        public EditModel(Web.Data.WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Clienti { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Clienti = await _context.Client
            .Include(b => b.Antrenor)
            .Include(b => b.CategoriiAntrenament).ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Clienti == null)
            {
                return NotFound();
            }
            PopulateAntrenamentAles(_context, Clienti);

            ViewData["AntrenorID"] = new SelectList(_context.Set<Antrenor>(), "ID", "NumeAntrenor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ClientToUpdate = await _context.Client
            .Include(i => i.Antrenor)
            .Include(i => i.CategoriiAntrenament)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);


            if (await TryUpdateModelAsync<Client>(
            ClientToUpdate,
            "Client",
            i => i.Nume, i => i.Prenume,
            i => i.Programare, i => i.Antrenor))
            {
                UpdateCategorieAntrenament(_context, selectedCategories, ClientToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateCategorieAntrenament pentru a aplica informatiile din checkboxuri la entitatea Clienti care
            //este editata
            UpdateCategorieAntrenament(_context, selectedCategories, ClientToUpdate);
            PopulateAntrenamentAles(_context, ClientToUpdate);
            return Page();
        }
        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ID == id);
        }
    }
}