using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepoMZ
{


    public class KategoriFac : AutoFac<Kategori>
    {
        Mapper<Kategori> mapper = new Mapper<Kategori>();

        public List<Kategori> GetAllOrderList()
        {
            using (var cmd = new SqlCommand("SELECT * FROM Kategori ORDER BY Sortering", Conn.CreateConnection()))
            {
                return mapper.MapList(cmd.ExecuteReader());
            }
        }

    }

}
