using CCUTrade.Models; 
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CCUTrade.ViewModels
{
    public class MarketViewModel : ObservableObject
    {
  
        public ObservableCollection<Product> GraduationItems { get; set; } = new();
        public ObservableCollection<Product> RecommendedItems { get; set; } = new();
        public ObservableCollection<Product> DormItems { get; set; } = new();

        public MarketViewModel()
        {
            LoadMarketData();
        }

        private void LoadMarketData()
        {
            // 測試用的假資料
            var allItems = new List<Product>
            {
                new Product { Name = "大四二手原文書", Price = 250, Category = "Graduation", Tag = "管理學" },
                new Product { Name = "中正特約機車行安全帽", Price = 500, Category = "Recommend", Tag = "學長姐推薦" },
                new Product { Name = "加厚宿舍打包紙箱", Price = 150, Category = "Dorm", Tag = "搬家必備" }
            };

            // 依照分類篩選，塞進各自的清單
            foreach (var item in allItems.Where(i => i.Category == "Graduation")) GraduationItems.Add(item);
            foreach (var item in allItems.Where(i => i.Category == "Recommend")) RecommendedItems.Add(item);
            foreach (var item in allItems.Where(i => i.Category == "Dorm")) DormItems.Add(item);
        }
    }
}