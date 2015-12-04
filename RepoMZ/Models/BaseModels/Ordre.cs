using System;

namespace RepoMZ
{

    public class Ordre
    {
        public int ID { get; set; }

        public DateTime Dato { get; set; }

        public string Status { get; set; }

        public bool Betalt { get; set; }

        public int KundeID { get; set; }

    }

}
