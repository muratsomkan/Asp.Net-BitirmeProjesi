using Microsoft.EntityFrameworkCore;
using Shoppica.API.Models;
using System.Runtime.CompilerServices;

namespace Shoppica.API.Services
{
    public class ProductService
    {
        ShoppicaDbContext DB = new ShoppicaDbContext();
        
        public IEnumerable<Product> GetProducts(int id)
        {
            Category category = DB.Categories.Find(id);
            List<Product> liste;

            if (category.TopId == null) // ana kategori
            {
                liste = (from p in DB.Products 
                         join c in DB.Categories on p.CategoryId equals c.Id
                      where c.TopId == id select new Product
                      {
                          Brand = p.Brand,
                          BrandId = p.BrandId,
                          Carts = p.Carts,
                          Category = p.Category,
                          CategoryId = p.CategoryId,
                          CreatedDate = p.CreatedDate,
                          Description = p.Description,
                          Discount = p.Discount,
                          Id = p.Id,
                          Image = p.Image,
                          IsSpecial = p.IsSpecial,
                          ProductImages = p.ProductImages,
                          ProductName = p.ProductName,
                          UnitPrice = p.UnitPrice
                      }).ToList();
            }
            else
            {
                liste = (from p in DB.Products where p.CategoryId == id select p).ToList();
            }
            return liste;


        }

        public IEnumerable<Product> GetContentProducts(int x)
        {
            if (x == 1) // slider products
            {
                //return (DB.Products.OrderBy(x => Guid.NewGuid()).Take(5)).ToList();
                return (from p in DB.Products
                        select new Product
                        {
                            Brand = p.Brand,
                            BrandId = p.BrandId,
                            Carts = p.Carts,
                            Category = p.Category,
                            CategoryId = p.CategoryId,
                            CreatedDate = p.CreatedDate,
                            Description = p.Description,
                            Discount = p.Discount,
                            Id = p.Id,
                            Image = p.Image,
                            IsSpecial = p.IsSpecial,
                            ProductImages = p.ProductImages,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice
                        }).OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            }
            else if (x == 2) // special products
            {
                return (from p in DB.Products.Where(x => x.IsSpecial == true)
                        select new Product
                        {
                            Brand = p.Brand,
                            BrandId = p.BrandId,
                            Carts = p.Carts,
                            Category = p.Category,
                            CategoryId = p.CategoryId,
                            CreatedDate = p.CreatedDate,
                            Description = p.Description,
                            Discount = p.Discount,
                            Id = p.Id,
                            Image = p.Image,
                            IsSpecial = p.IsSpecial,
                            ProductImages = p.ProductImages,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice
                        }).OrderBy(x => Guid.NewGuid()).Take(6).ToList();
            }
            else // latest products
            {

                return (from p in DB.Products
                        select new Product
                        {
                            Brand = p.Brand,
                            BrandId = p.BrandId,
                            Carts = p.Carts,
                            Category = p.Category,
                            CategoryId = p.CategoryId,
                            CreatedDate = p.CreatedDate,
                            Description = p.Description,
                            Discount = p.Discount,
                            Id = p.Id,
                            Image = p.Image,
                            IsSpecial = p.IsSpecial,
                            ProductImages = p.ProductImages,
                            ProductName = p.ProductName,
                            UnitPrice = p.UnitPrice
                        }).OrderByDescending(x => x.CreatedDate).Take(6).ToList();
            }
        }

        public Product GetDetails(int id) => (from p in DB.Products
                                              where p.Id == id
                                              select new Product
                                              {
                                                  Brand = p.Brand,
                                                  BrandId = p.BrandId,
                                                  Carts = p.Carts,
                                                  Category = p.Category,
                                                  CategoryId = p.CategoryId,
                                                  CreatedDate = p.CreatedDate,
                                                  Description = p.Description,
                                                  Discount = p.Discount,
                                                  Id = p.Id,
                                                  Image = p.Image,
                                                  IsSpecial = p.IsSpecial,
                                                  ProductImages = p.ProductImages,
                                                  ProductName = p.ProductName,
                                                  UnitPrice = p.UnitPrice
                                              }).FirstOrDefault() ?? new Product();

        public IEnumerable<Product> SearchProducts(string text)
        {
            #region MyRegion-1
            //var liste = (from p  in DB.Products.Where(x => x.ProductName.Contains(text))
            //             select new Product()
            //             {
            //                 Brand = p.Brand,
            //                 BrandId = p.BrandId,
            //                 Carts = p.Carts,
            //                 Category = p.Category,
            //                 CategoryId = p.CategoryId,
            //                 CreatedDate = p.CreatedDate,
            //                 Description = p.Description,
            //                 Discount = p.Discount,
            //                 Id = p.Id,
            //                 Image = p.Image,
            //                 IsSpecial = p.IsSpecial,
            //                 ProductImages = p.ProductImages,
            //                 ProductName = p.ProductName,
            //                 UnitPrice = p.UnitPrice
            //             }); 


            #endregion

            #region MyRegion-2
            string sql = $"SELECT * FROM PRODUCT WHERE PRODUCTNAME LIKE '%{text}%'";
            var liste = (from p in DB.Products.FromSqlRaw(sql)
                         select new Product()
                         {
                             Brand = p.Brand,
                             BrandId = p.BrandId,
                             Carts = p.Carts,
                             Category = p.Category,
                             CategoryId = p.CategoryId,
                             CreatedDate = p.CreatedDate,
                             Description = p.Description,
                             Discount = p.Discount,
                             Id = p.Id,
                             Image = p.Image,
                             IsSpecial = p.IsSpecial,
                             ProductImages = p.ProductImages,
                             ProductName = p.ProductName,
                             UnitPrice = p.UnitPrice
                         });
            #endregion

            // Store procedure
            #region MyRegion-3
            //string sql = $"EXEC sp_UrunAra " + text;
            //List<Product> liste = (from p in DB.Products.FromSqlRaw(sql) select p).ToList();

            //return liste;
            #endregion
            return liste.ToList();
        }
    }
}
