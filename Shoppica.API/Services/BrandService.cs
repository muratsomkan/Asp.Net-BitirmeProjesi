using Shoppica.API.Models;

namespace Shoppica.API.Services
{
    public class BrandService
    {
        public IEnumerable<Brand> GetAll()
        {
            ShoppicaDbContext DB = new ShoppicaDbContext();
            return DB.Brands.ToList();
        }
    }
}
