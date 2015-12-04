using System;
using System.Data.SqlClient;

namespace RepoMZ
{
    
	 public class OrdreFac:AutoFac<Ordre>
	 {
        
	     public void Betalt(bool betalt, int ordreID)
	     {
	         using (var cmd = new SqlCommand("UPDATE Ordre SET Betalt=@Betalt WHERE ID=@ID", Conn.CreateConnection()))
	         {
                 cmd.Parameters.AddWithValue("@Betalt", betalt);
                 cmd.Parameters.AddWithValue("@ID", ordreID);

	             cmd.ExecuteNonQuery();
                 cmd.Connection.Close();
	         }
	     }
        
         public int AddOrdre(Ordre o)
         {
             int ID = 0;
             using (var cmd = new SqlCommand("INSERT INTO Ordre (Dato, Status, Betalt, KundeID) VALUES(@Dato, @Status, @Betalt, @KundeID);SELECT SCOPE_IDENTITY() AS curID", Conn.CreateConnection()))
             {
                 cmd.Parameters.AddWithValue("@Dato", o.Dato);
                 cmd.Parameters.AddWithValue("@Status", o.Status);
                 cmd.Parameters.AddWithValue("@Betalt", o.Betalt);
                 cmd.Parameters.AddWithValue("@KundeID", o.KundeID);

                 var r = cmd.ExecuteReader();

                 if (r.Read())
                 {
                     ID = int.Parse(r["curID"].ToString());

                 }

                 cmd.Connection.Close();
                 r.Close();

                 return ID;
             }

         }
	 }

}
