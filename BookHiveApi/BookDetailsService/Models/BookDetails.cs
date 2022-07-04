using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHiveService.Models
{
    public class BookDetails
    {
        public string BookName { get; set; }
        public int BookId { get; set; }
        public string Gerner { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Photo { get; set; }

    }
}
