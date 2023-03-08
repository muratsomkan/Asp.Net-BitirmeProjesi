using System;
using System.Collections.Generic;

namespace Shoppica.MVC.ViewModels
{
    public partial class ProductImageVM
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public int? ProductId { get; set; }

        public virtual ProductVM? Product { get; set; }
    }
}
