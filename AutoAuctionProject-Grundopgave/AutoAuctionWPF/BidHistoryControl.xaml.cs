using AutoAuctionProjekt.Classes.Vehicles.Database;
using AutoAuctionProjekt.Classes;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Util;
using System.Collections.Generic;
using System;
using static AutoAuctionWPF.BidHistoryControl;

namespace AutoAuctionWPF;

public partial class BidHistoryControl : UserControl
{
    private MainWindow mainWindow;

    public struct BidStruct
    {
        public BidStruct(Vehicle vehicle, BidHistory mybid,BidHistory finalBid,bool iWon)
        {
            Vehicle = vehicle;
            MyBid = mybid;
            FinalBid = finalBid;
            IWON = iWon;
        }

        public Vehicle Vehicle {get; set;}
        public BidHistory MyBid { get; set; }
        public BidHistory FinalBid { get; set; }
        public bool IWON { get; set; }
    }
    public BidHistoryControl(MainWindow main)
    {
        InitializeComponent();
        mainWindow = main;
        CurrentAuctionsList.Items.Clear();

      

        ObservableCollection<BidStruct> bidStructs = new();

        BidHistory Mybid;
        BidHistory FinalBid;
        bool IWon;
        foreach (Auction auction in Database.Auctions)
        {
            if (Database.GetHigestBidOnAuctionForUser(Constants.Sql.User, auction.ID) != null && auction.isDone == true)
            {
                Mybid = Database.GetHigestBidOnAuctionForUser(Constants.Sql.User, auction.ID);
                FinalBid = Database.GetHigestBidOnAuction( auction.ID);
                if(FinalBid.UserName == Constants.Sql.User)
                {
                    IWon = true;
                }
                else
                {
                    IWon = false;
                }
                BidStruct bidStruct = new(auction.Vehicle,Mybid, FinalBid, IWon);

                bidStructs.Add(bidStruct);
            }
        }

        CurrentAuctionsList.ItemsSource = bidStructs;
    }

 
    private void Back_Click(object sender, RoutedEventArgs e)
    {
        this.mainWindow.ShowUserProfileScreen();

    }
}

