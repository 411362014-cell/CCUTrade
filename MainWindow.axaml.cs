using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CCUTrade.ViewModels; 

namespace CCUTrade;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);

        DataContext = new MainViewModel();
    }
}