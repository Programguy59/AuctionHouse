using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionWPF.SetForSale;

public partial class SetForSalePrivatePersonalCar : UserControl
{
    public static bool _towbar;
    public static decimal _height;
    public static decimal _length;
    public static decimal _width;
    public static decimal _weight;
    public static decimal _depth;
    public static double _engineSize;
    public static ushort _numberOfSeats;
    public static ushort _numberOfSleepingSpaces;
    public static bool _hasToilet;
    public static double _kmPerLiter;
    public static Vehicle.FuelTypeEnum _fuelType = Vehicle.FuelTypeEnum.Unknown;
    public static bool _hasIsoFixFitting;

    public SetForSalePrivatePersonalCar()
    {
        InitializeComponent();
    }

    private void Towbar_OnChecked(object sender, RoutedEventArgs e)
    {
        _towbar = true;
    }

    private void Towbar_OnUnchecked(object sender, RoutedEventArgs e)
    {
        _towbar = false;
    }

    private void HeightTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _height = Convert.ToDecimal(HeightTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void WeightTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _weight = Convert.ToDecimal(WidthTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void EngineTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _engineSize = Convert.ToDouble(EngineTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void NumberOfSeatsTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _numberOfSeats = Convert.ToUInt16(NumberOfSeatTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void KmPerLiterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _kmPerLiter = Convert.ToDouble(KmPerLiterTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void DieselComboBoxItem_OnSelected(object sender, RoutedEventArgs e)
    {
        _fuelType = Vehicle.FuelTypeEnum.Diesel;
    }

    private void BenzinComboBoxItem_OnSelected(object sender, RoutedEventArgs e)
    {
        _fuelType = Vehicle.FuelTypeEnum.Benzin;
    }

    private void ElectricComboBoxItem_OnSelected(object sender, RoutedEventArgs e)
    {
        _fuelType = Vehicle.FuelTypeEnum.Electric;
    }

    private void HydrogenComboBoxItem_OnSelected(object sender, RoutedEventArgs e)
    {
        _fuelType = Vehicle.FuelTypeEnum.Hydrogen;
    }

    private void IsofixFittingsCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        _hasIsoFixFitting = true;
    }

    private void IsofixFittingsCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        _hasIsoFixFitting = false;
    }

    private void WidthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _width = Convert.ToDecimal(WidthTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }

    private void DepthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            _depth = Convert.ToDecimal(DepthTextBox.Text);
        }
        catch (FormatException ex)
        {
            // Handle the format exception (invalid input) here
            // You can log the error or show a user-friendly message
        }
    }
}