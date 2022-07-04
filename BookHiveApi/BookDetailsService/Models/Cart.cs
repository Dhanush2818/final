using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHiveService.Models
{
    public class Cart
    {
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float TotalBill { get; set; }
        public string Address { get; set; }



    }
}
