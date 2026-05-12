using System.Windows.Controls;
using System.Windows.Media;

namespace Orion.main.app.gui;
using System.Windows;

public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private void DarkTheme(object sender, RoutedEventArgs e)
    {
        MainGrid.Background = new SolidColorBrush(Color.FromRgb(30,30,30));
    }
}