namespace Shoppica.MVC.ViewModels
{
    public class CartProdVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Image { get; set; }

        public string? CategoryName { get; set; }

        public decimal Total { get { return this.UnitPrice * this.Quantity; } }
    }

}
