using System;
using System.Collections.Generic;

namespace Shoppica.MVC.ViewModels
{
    public partial class BrandVM
    {
        public BrandVM()
        {
            Products = new HashSet<ProductVM>();
        }

        public int Id { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<ProductVM> Products { get; set; }
    }
}
