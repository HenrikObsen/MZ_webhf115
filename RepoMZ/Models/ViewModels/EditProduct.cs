using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoMZ.Models.ViewModels
{
    public class EditProduct
    {
        public List<Kategori> Kategorier { get; set; }
        public ProduktListe Produktliste { get; set; }
    }
}
