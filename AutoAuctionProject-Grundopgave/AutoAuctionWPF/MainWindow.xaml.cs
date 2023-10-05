using AutoAuctionProjekt.Classes;
using AutoAuctionProjekt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AutoAuctionWPF.UserControlLogin;

namespace AutoAuctionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatabaseServer.Initialize(0);

            ShowLoginScreen(); // Start med at vise Login-skærmen
        }

        public void ShowLoginScreen()
        {
            contentControl.Content = new UserControlLogin(this);
        }

        public void ShowHomeScreen()
        {
            contentControl.Content = new UserControlHomepage(this);
        }
        
        public void ShowCreateUserScreen()
        {
            contentControl.Content = new CreateUserControl(this);
        }
        
        public void ShowSetForSaleScreen()
        {
            contentControl.Content = new SetForSaleControl(this);
        }
        
        public void ShowBuyerOfAuctionScreen(Auction auction)
        {
            contentControl.Content = new BuyerOfAuctionControl(this, auction);
        }
        
        public void ShowSellerOfAuctionScreen(Auction auction)
        {
            contentControl.Content = new SellerOfAuctionControl(this, auction);
        }
        
        public void ShowUserProfileScreen()
        {
            contentControl.Content = new UserProfileControl(this);
        }
        
        public void BidHistoryControl()
        {
            contentControl.Content = new BidHistoryControl(this);
        }
    }
}