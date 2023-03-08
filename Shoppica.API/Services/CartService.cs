using Shoppica.API.Models;

namespace Shoppica.API.Services
{
    public class CartService
    {
        ShoppicaDbContext DB = new ShoppicaDbContext();
        public IEnumerable<CartProd> GetAll() => (from c in DB.Carts
                                                  join cp in DB.Products on c.ProductId equals cp.Id
                                                  select new CartProd
                                                  {
                                                      Id = c.Id,
                                                      UnitPrice = (decimal)cp.Discount,
                                                      ProductName = cp.ProductName,
                                                      Quantity = (int)c.Quantity,
                                                      CategoryName = cp.Category.CategoryName,
                                                      Image = cp.Image,
                                                      ProductId = (int)c.ProductId
                                                  }).ToList();
        public void AddToCart(Cart cart)
        {
            Cart cart1 = DB.Carts.Where(x => x.ProductId == cart.ProductId).FirstOrDefault();

            if (cart1 == null)//sepette yoksa!
            {
                DB.Carts.Add(cart);
            }
            else//sepette varsa
            {
                cart1.Quantity += cart.Quantity;
                DB.Update(cart1);
            }
            DB.SaveChanges();  
        }

        public void DeleteToCart(int id)
        {
            Cart cart = DB.Carts.Where(x => x.Id == id).FirstOrDefault();
            DB.Carts.Remove(cart);
            DB.SaveChanges();
        }
    }
}
