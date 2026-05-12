using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Orion.main.app.gui;

public partial class LoginPage : Page
{
    private const string password = "1";
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Validate()
    {
        string currentGuess = PasswordField.Password;
        if (currentGuess == password)
        {
            NavigationService.Navigate(new EncryptPage());
            PassError.Visibility = Visibility.Collapsed;
            PasswordField.Clear();
        }

        if(currentGuess !=password)
            PassError.Visibility = Visibility.Visible;
    }

    private void Verify(object sender, RoutedEventArgs e)
    {
        Validate();
    }

    private void Changed(object sender, DependencyPropertyChangedEventArgs e)
    {
        //string text = PasswordField.Password;
    }

    private void EnterInput(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Validate();
        }

    }

    private void SettingsButton(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new SettingsPage());
    }

    private void CurrentFrame(object sender, NavigationEventArgs e)
    {
        if (e.Content is LoginPage)
        {
            PassError.Visibility = Visibility.Collapsed;
        }
    }
}