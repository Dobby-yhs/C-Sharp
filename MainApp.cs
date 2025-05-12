using System;
using System.Linq;

namespace OuterJoin
{ 
    class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Category[] arrCategory =
            {
                new Category(){ ID = 1, Name = "전자제품" },
                new Category(){ ID = 2, Name = "도서" },
                new Category(){ ID = 3, Name = "의류" },
                new Category(){ ID = 4, Name = "생필품" }
            };

            Product[] arrProduct =
            {
                new Product(){ ID = 101, Name = "노트북", CategoryID = 1 },
                new Product(){ ID = 102, Name = "키보드", CategoryID = 1 },
                new Product(){ ID = 103, Name = "C# 프로그래밍", CategoryID = 2 },
                new Product(){ ID = 104, Name = "C++ 프로그래밍", CategoryID = 2 },
                new Product(){ ID = 105, Name = "청바지", CategoryID = 3 },
                new Product(){ ID = 106, Name = "티셔츠", CategoryID = 3 },
                new Product(){ ID = 107, Name = "알 수 없는 상품", CategoryID = 99 }
            };

            var listCategory = from category in arrCategory
                               join product in arrProduct on category.ID equals product.CategoryID into ps
                               from product in ps.DefaultIfEmpty(new Product() { Name = "해당 없음" , ID = 999 })
                               select new
                               {
                                   Name = category.Name,
                                   ProductName = product.Name,
                                   Id = product.ID
                               };

            foreach (var category in listCategory)
            {
                Console.WriteLine("카테고리 분류 : {0} / 제품 이름 : {1} / 제품 ID : {2}",
                                   category.Name, category.ProductName, category.Id);
            }
        }
    }
}



