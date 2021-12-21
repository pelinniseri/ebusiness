using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public static class SeedCatagory
    {
        public static void Seed()
        {
            var context = new Context();
            
            if (context.Database.GetPendingMigrations().Count() != 0)
            {
                System.Diagnostics.Trace.WriteLine("no pending migration");
                if (context.Categories.Count() == 0) context.Categories.AddRange(My_Categories);
                context.SaveChanges();
                //    if (context.Products.Count() == 0) context.Products.UpdateRange(My_Products);
                //   context.SaveChanges();
                if (context.Products.Count() == 0) context.Products.UpdateRange(My_Products());
                System.Diagnostics.Trace.WriteLine(context.Products.Count());
                System.Diagnostics.Trace.WriteLine(value: context.Categories.Count());
                context.SaveChanges();
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("found a pending migration");
                context.Database.Migrate();
                if (context.Categories.Count() == 0) context.Categories.AddRange(My_Categories);
                if (context.Products.Count() == 0) context.Products.AddRange(My_Products());
                context.SaveChanges();

            }

        }
        private static Category[] My_Categories =
        {
            new Category(){ 
                CategoryName = "Mobil",
                CategoryDescription="Mobil telefonlar",
                Status=true
            },
            new Category(){
               
                CategoryName = "Bilgisayar",
                CategoryDescription="Dizustu ve PC ",
                Status=true

            },
            new Category(){
              
                CategoryName = "Bulasik Makineleri",
                CategoryDescription="Bulasik makineleri ",
                Status=true

            },
            new Category(){
                CategoryName = "Elektrik Supurgeler",
                CategoryDescription="Torbali ve Torbasiz",
                Status=true

            }
           
        };
        private static Product[] My_Products()
        {
            var context = new Context();
            return new Product[] {
            new Product()
            {
                ProductName = "Samsung S8",
                Description = "Samsung Turkiyeden garantili Samsung S8 ",
                Price = 2000,
                ImageUrl = "",
                Stock = 9,
                Category = context.Categories.Single<Category>(C => C.CategoryName == "Mobil")
            },
            new Product()
            {
                ProductName = "Samsung S20",
                Description = "Samsung Turkiyeden garantili Samsung S20 ",
                Price = 20000,
                ImageUrl = "",
                Stock = 999,
                Category = context.Categories.Single<Category>(C => C.CategoryName == "Mobil")
            },
            new Product()
            {
                ProductName = "Samsung S10",
                Description = "Samsung Turkiyeden garantili Samsung S10 ",
                Price = 8000,
                ImageUrl = "",
                Stock = 999,
                Category = context.Categories.Single<Category>(C => C.CategoryName == "Mobil")
            },
            new Product()
            {
                ProductName = "Samsung S21",
                Description = "Samsung Turkiyeden garantili Samsung S21 ",
                Price = 10000,
                ImageUrl = "",
                Stock = 9999,
                Category = context.Categories.Single<Category>(C => C.CategoryName == "Mobil")
            }

            };

        }


    }
}
