using System;
using System.Collections.Generic;

namespace Shoppica.MVC.ViewModels
{
    public partial class ProductVM
    {
        public ProductVM()
        {
            Carts = new HashSet<CartVM>();
            ProductImages = new HashSet<ProductImageVM>();
        }

        public int Id { get; set; }
        public string? ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public bool? IsSpecial { get; set; }

        public virtual BrandVM? Brand { get; set; }
        public virtual CategoryVM? Category { get; set; }
        public virtual ICollection<CartVM> Carts { get; set; }
        public virtual ICollection<ProductImageVM> ProductImages { get; set; }
    }
}
