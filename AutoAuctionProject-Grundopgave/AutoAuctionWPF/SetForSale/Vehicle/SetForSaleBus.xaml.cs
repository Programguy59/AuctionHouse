using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionWPF;

public partial class SetForSaleBus : UserControl
{
    public static bool _towbar;
    public static decimal _height;
    public static decimal _length;
    public static decimal _width;
    public static decimal _weight;
    public static double _engineSize;
    public static ushort _numberOfSeats;
    public static ushort _numberOfSleepingSpaces;
    public static bool _hasToilet;
    public static double _kmPerLiter;
    public static Vehicle.FuelTypeEnum _fuelType = Vehicle.FuelTypeEnum.Unknown;
    
    
    public SetForSaleBus()
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
        // Handle the case where the input is not a valid decimal
        // You might want to display an error message to the user
    }
}

private void LengthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
{
    try
    {
        _length = Convert.ToDecimal(LengthTextBox.Text);
    }
    catch (FormatException ex)
    {
        // Handle the case where the input is not a valid decimal
        // You might want to display an error message to the user
    }
}

private void WeightTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
{
    try
    {
        _weight = Convert.ToDecimal(WeightTextBox.Text);
    }
    catch (FormatException ex)
    {
        // Handle the case where the input is not a valid decimal
        // You might want to display an error message to the user
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
        // Handle the case where the input is not a valid double
        // You might want to display an error message to the user
    }
}

private void NumberOfSeatsTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
{
    try
    {
        _numberOfSeats = Convert.ToUInt16(NumberOfSeatsTextBox.Text);
    }
    catch (FormatException ex)
    {
        // Handle the case where the input is not a valid ushort
        // You might want to display an error message to the user
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
        // Handle the case where the input is not a valid double
        // You might want to display an error message to the user
    }
}

private void NumberOfSleepingSpacesTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
{
    try
    {
        _numberOfSleepingSpaces = Convert.ToUInt16(NumberOfSleepingSpacesTextBox.Text);
    }
    catch (FormatException ex)
    {
        // Handle the case where the input is not a valid ushort
        // You might want to display an error message to the user
    }
}


    private void HasToilet_OnChecked(object sender, RoutedEventArgs e)
    {
        _hasToilet = true;
    }

    private void HasToilet_OnUnchecked(object sender, RoutedEventArgs e)
    {
        _hasToilet = false;
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
}
