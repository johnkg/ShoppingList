using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList.Models
{
    public class ShoppingItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public decimal Quantity { get; set; }
    }
}
