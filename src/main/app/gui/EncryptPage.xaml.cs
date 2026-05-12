using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Orion.main.domain.model;
using Orion.main.domain.service;

namespace Orion.main.app.gui;

public partial class EncryptPage : Page
{
    public EncryptPage()
    {
        InitializeComponent();
    }
    private void EnterInput(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            Encrypting(sender, e);
        }
    }

    private void Encrypting(object sender, RoutedEventArgs e)
    {
        ErrorsChecker errors = new ErrorsChecker();
        
        string mes = EncryptBox.Text;
        string key1 = FirstKey.Text;
        string key2 = SecondKey.Text;
        
        long val1 = Convert(key1);
        long val2 = Convert(key2);
        
        EncryptData data = new EncryptData(mes,val1,val2);
        AfinEncryptor encryptor = new AfinEncryptor(data);
        
        string encrypted = encryptor.Encryption();

        if (errors.Verify(mes, key1, key2, encrypted, data.getConverted()))
        {
            Result.Text = errors.GetOutput();
        }
        else
        {
            Result.Text = errors.GetOutput() + encrypted;
        }

        Result.Visibility = Visibility.Visible;
        
    }
    
    private void Changed(object sender, TextChangedEventArgs e)
    {
        EncryptBt.Visibility = Visibility.Visible;
        if(EncryptBox.Text == "")
            EncryptBt.Visibility = Visibility.Collapsed;
    }

    private static long Convert(string str)
    {
        char[] key = str.ToCharArray();
        long nr = 0;
        for (int i = 0; i < key.Length; i++)
        {
            int cifra = key[i] - '0';
            nr = nr * 10 + cifra;
        }

        return nr;
        
    }
}