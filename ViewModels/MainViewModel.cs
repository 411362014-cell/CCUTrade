using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CCUTrade.Models;
using CCUTrade.Services;

namespace CCUTrade.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ProductService _productService = new();

    [ObservableProperty]
    private string title = "";

    [ObservableProperty]
    private string description = "";

    [ObservableProperty]
    private string category = "課本";

    [ObservableProperty]
    private decimal price;

    [ObservableProperty]
    private string searchText = "";

    [ObservableProperty]
    private string selectedCategory = "全部";

    public ObservableCollection<Product> Products { get; set; } = new();

    public ObservableCollection<Product> FilteredProducts { get; set; } = new();

    public ObservableCollection<string> Categories { get; set; } = new()
    {
        "全部",
        "課本",
        "宿舍用品",
        "腳踏車",
        "電子產品"
    };

    public MainViewModel()
    {
        LoadProducts();
    }

    [RelayCommand]
    public async Task AddProduct()
    {
        var product = new Product
        {
            Name = Title,
            Description = Description,
            Category = Category,
            Price = Price,
            IsSold = false
        };

        await _productService.AddProduct(product);

        Products.Add(product);

        FilterProducts();

        Title = "";
        Description = "";
        Category = "課本";
        Price = 0;
    }

    public async void LoadProducts()
    {
        var products = await _productService.GetAllProducts();

        Products.Clear();

        foreach (var product in products)
        {
            Products.Add(product);
        }

        FilterProducts();
    }

    partial void OnSearchTextChanged(string value)
    {
        FilterProducts();
    }

    partial void OnSelectedCategoryChanged(string value)
    {
        FilterProducts();
    }

    private void FilterProducts()
    {
        FilteredProducts.Clear();

        var filtered = Products.Where(p =>
        {
            bool matchSearch =
                string.IsNullOrWhiteSpace(SearchText) ||
                p.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase);

            bool matchCategory =
                SelectedCategory == "全部" ||
                p.Category == SelectedCategory;

            return matchSearch && matchCategory;
        });

        foreach (var product in filtered)
        {
            FilteredProducts.Add(product);
        }
    }
}