using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodInventory.Data.Models.DTOs
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalesPrice { get; set; }
        public Nullable<System.DateTime> SpoilDate { get; set; }
        public int UnitsAvailable { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
