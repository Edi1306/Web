using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data;

namespace Web.Models
{
    public class CategorieAntrenamentPageModel : PageModel
    {
        public List<AntrenamentAles> AntrenamentAlesList;
        public void PopulateAntrenamentAles(WebContext context,
        Client client)
        {
            var allCategories = context.Categorie;
            var CategoriiAntrenament = new HashSet<int>(
            client.CategoriiAntrenament.Select(c => c.CategorieID));
            AntrenamentAlesList = new List<AntrenamentAles>();
            foreach (var cat in allCategories)
            {
                AntrenamentAlesList.Add(new AntrenamentAles
                {
                    CategorieID = cat.ID,
                    Name = cat.NumeCategorie,
                    Assigned = CategoriiAntrenament.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategorieAntrenament(WebContext context,
        string[] selectedCategories, Client clientToUpdate)
        {
            if (selectedCategories == null)
            {
                clientToUpdate.CategoriiAntrenament = new List<CategorieAntrenament>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var clientCategories = new HashSet<int>
            (clientToUpdate.CategoriiAntrenament.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!clientCategories.Contains(cat.ID))
                    {
                        clientToUpdate.CategoriiAntrenament.Add(
                        new CategorieAntrenament
                        {
                            ClientID = clientToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (clientCategories.Contains(cat.ID))
                    {
                        CategorieAntrenament courseToRemove
                        = clientToUpdate
                        .CategoriiAntrenament
                       .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}