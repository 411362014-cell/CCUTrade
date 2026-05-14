using System;
using Avalonia.Controls;
using CCUTrade.Models;

using Avalonia.Controls;
using CCUTrade.Data;
using CCUTrade.Models;
using System.Linq;

namespace CCUTrade;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        using var db = new AppDbContext();

        // 如果沒有商品才新增
        if (!db.Products.Any())
        {
            db.Products.Add(new Product
            {
                Name = "MacBook Air",
                Description = "二手筆電",
                Price = 25000,
                Category = "電子產品",
                IsSold = false,
                CreatedAt = DateTime.Now
            });

            db.SaveChanges();
        }

        // 讀取資料
        var products = db.Products
            .Select(p => $"{p.Name} - ${p.Price}")
            .ToList();

        // 顯示到 ListBox
        ProductList.ItemsSource = products;
    }
}
