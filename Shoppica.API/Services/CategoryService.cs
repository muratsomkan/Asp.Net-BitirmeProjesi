using Shoppica.API.Models;

namespace Shoppica.API.Services
{
    public class CategoryService
    {
        ShoppicaDbContext DB = new ShoppicaDbContext();

        public IEnumerable<Category> GetMainCategories()
        {
            IEnumerable<Category> liste = (from c in DB.Categories.Where(x => x.TopId == null) // db'de Category olarak isimlendirdik neden burda Categories dedik ?????????????????
                                           select new Category
                                           {
                                               CategoryName = c.CategoryName,
                                               Id = c.Id,
                                               Products = c.Products,
                                               TopId = c.TopId,
                                               InverseTop = c.InverseTop,
                                               Top = c.Top
                                           });
            return liste;
        }

        public IEnumerable<Category> GetByID(int id)
        {
            IEnumerable<Category> liste;
            Category category = DB.Categories.Find(id);

            if (category.TopId == null) // ana kategori
            {
                liste = (from c in DB.Categories.Where(x => x.TopId == id) select c).ToList(); // Buradaki hatayı düzeltmek için Newtonsoftjson indirdik.
            }
            else // alt kategori
            {
                liste = (from c in DB.Categories.Where(x => x.TopId == category.TopId) select c).ToList();
            }
            return liste;
        }

	}
    
}
