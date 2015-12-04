using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepoMZ
{
	 public class ProduktFac:AutoFac<Produkt>
	 {
         Mapper<Produkt> mapper = new Mapper<Produkt>();
	    
         
         public List<Produkt> Search(string KeyWord)
	     {
	         using (var cmd = new SqlCommand("SELECT * FROM Produkt WHERE Navn Like @Key OR Tekst Like @Key", Conn.CreateConnection()))
	         {
	             cmd.Parameters.AddWithValue("@Key", "%" + KeyWord + "%");
	             return mapper.MapList(cmd.ExecuteReader());
	         }
	     }




	 }

}
