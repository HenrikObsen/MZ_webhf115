using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RepoMZ.Models.ViewModels;

namespace RepoMZ
{
	 public class ProduktFac:AutoFac<Produkt>
	 {
        KategoriFac katFac = new KategoriFac();

	     public ProduktListe GetProduktListe(int katID)
	     {
	         ProduktListe pl = new ProduktListe();
	         pl.Kategori = katFac.Get(katID);
	         pl.Produkter = GetBy("KatID", katID);
	         return pl;
	     }

	 }

}
