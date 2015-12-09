using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Cache;

namespace RepoMZ
{

    public class Kategori
    {
        public int ID { get; set; }

        [Required]
        public string Navn { get; set; }

        [Required]
        [Range(0, 9999)]
        public int Sortering { get; set; }

    }

}
