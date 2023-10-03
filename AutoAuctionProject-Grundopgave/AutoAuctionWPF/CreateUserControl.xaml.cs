using System;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Util;

namespace AutoAuctionWPF;

public partial class CreateUserControl : UserControl
{
    private MainWindow mainWindow;

    private string userName;
    private string password;
    private bool corporateUser;
    private decimal balance;
    private string zipCode;
    private decimal credit;
    private string CrNumber;

    public CreateUserControl(MainWindow main)
    {
        InitializeComponent();
        this.mainWindow = main;
    }

    private void CreateUserButton_Click(object sender, RoutedEventArgs e)
    {
        // Implementer brugeroprettelses logik her
        bool isUserCreated;  // Placeholder for brugeroprettelse

        if (UsernameTextBox.Text != null) userName = UsernameTextBox.Text;
        if (PasswordBox.Password == ConfirmPasswordBox.Password)
        {
            if (PasswordBox.Password != null) password = PasswordBox.Password;   
        }
        if (balanceTextBox.Text != null) balance = Convert.ToDecimal(balanceTextBox.Text);
        if (zipCodeTextBox != null) zipCode = zipCodeTextBox.Text;
        if (CreditTextBox != null) credit = Convert.ToDecimal(zipCodeTextBox.Text);
        if (CPRNummerTextBox != null) CrNumber = CPRNummerTextBox.Text;

        try
        {
            DatabaseServer.InsertUser(userName, password, corporateUser, balance, zipCode, credit, CrNumber);
            isUserCreated = true;
            mainWindow.ShowLoginScreen();
        }
        catch 
        {
            MessageBox.Show("Unable to create user. Please try again.");
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
     mainWindow.ShowLoginScreen();   
    }


    private void UserRadioButton_Checked(object sender, RoutedEventArgs e)
    {


        CreditLabel.Visibility = Visibility.Visible;
        CreditTextBox.Visibility = Visibility.Visible;

        CRLabel.Content = "CVR Nummer";
        CRLabel.Visibility = Visibility.Visible;
        CPRNummerTextBox.Visibility = Visibility.Visible;
    }

    private void PrivateUserRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        corporateUser = false;

        CreditLabel.Visibility = Visibility.Collapsed;
        CreditTextBox.Visibility = Visibility.Collapsed;


        CRLabel.Content = "CPR Nummer";
        CRLabel.Visibility = Visibility.Visible;
        CPRNummerTextBox.Visibility = Visibility.Visible;
    }
}