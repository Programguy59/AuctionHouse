using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Classes;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Util;
using System.Collections.Generic;
using System;

namespace AutoAuctionWPF;

public partial class BidHistoryControl : UserControl
{
    private MainWindow mainWindow;
    public BidHistoryControl(MainWindow main)
    {
        InitializeComponent();
        mainWindow = main;
        CurrentAuctionsList.Items.Clear();

        ObservableCollection<Auction> auctionList = new ObservableCollection<Auction>();

        List<BidHistory> bids = new List<BidHistory>();

        BidHistory Mybid;
        BidHistory FinalBidbid;
        BidHistory FinalBidbid2;
        foreach (Auction auction in Database.Auctions)
        {
            if(Database.GetHigestBidOnAuctionForUser(Constants.Sql.User, auction.ID) != null)
            {
                Mybid = Database.GetHigestBidOnAuctionForUser(Constants.Sql.User, auction.ID);
                FinalBidbid = Database.GetHigestBidOnAuction( auction.ID);
                if (auction.ID == 2)
                {
                    FinalBidbid2 = Database.GetHigestBidOnAuction(auction.ID);
                }
                auctionList.Add(auction);
                //bids.Add(Database.GetHigestBidOnAuctionForUser(Constants.Sql.User, auction.ID));
            }


        }

        CurrentAuctionsList.ItemsSource = auctionList;
    }

 
    private void Back_Click(object sender, RoutedEventArgs e)
    {
        this.mainWindow.ShowUserProfileScreen();

    }
}

