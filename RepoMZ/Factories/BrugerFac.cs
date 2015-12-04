using System;
using System.Data.SqlClient;

namespace RepoMZ
{


    public class BrugerFac : AutoFac<Bruger>
    {

        Mapper<Bruger> mapper = new Mapper<Bruger>();
        public Bruger Login(string email, string password)
        {

            using (var CMD = new SqlCommand("SELECT * FROM Bruger WHERE Email=@Email AND Adgangskode=@Adgangskode", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@Email", email.Trim());
                CMD.Parameters.AddWithValue("@Adgangskode", password.Trim());

                var r = CMD.ExecuteReader();
                Bruger per = new Bruger();

                if (r.Read())
                {
                   per = mapper.Map(r); 
                }
                
                r.Close();
                CMD.Connection.Close();

                return per;

            }
        }

        public bool UserExists(string email)
        {
            using (var cmd = new SqlCommand("SELECT ID FROM Bruger WHERE Email=@Email", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Email", email);

                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


    }

}
