using Avalonia.Controls;
using Avalonia.Controls;
using CCUTrade.Data;
using CCUTrade.Models;
using CCUTrade.Models;
using Avalonia.Controls;
using CCUTrade.ViewModels; 

namespace CCUTrade;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel();
    }
}