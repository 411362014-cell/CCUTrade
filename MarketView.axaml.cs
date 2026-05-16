using Avalonia.Controls;
using Avalonia.Markup.Xaml; 
namespace CCUTrade;

public partial class MarketView : UserControl
{
    public MarketView()
    { 
        AvaloniaXamlLoader.Load(this);
    }
}