using System.Windows.Input;

namespace Orion.main.app.gui;

using System.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        MainFrame.Navigate(new LoginPage());
    }
    
}