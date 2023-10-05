using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionWPF.SetForSale
{
    public partial class SetForSaleTruck : UserControl
    {
        public static bool _towbar;
        public static decimal _height;
        public static decimal _length;
        public static decimal _width;
        public static decimal _weight;
        public static double _engineSize;
        public static decimal _loadCapacity;
        public static double _kmPerLiter;
        public static Vehicle.FuelTypeEnum _fuelType = Vehicle.FuelTypeEnum.Unknown;
        
        public SetForSaleTruck()
        {
            InitializeComponent();
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
    
        private void LengthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _length = Convert.ToDecimal(LengthTextBox.Text);
            }
            catch (FormatException ex)
            {
                // Handle the format exception (invalid input) here
                // You can log the error or show a user-friendly message
            }
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
    
        private void WeightTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _weight = Convert.ToDecimal(WeightTextBox.Text);
            }
            catch (FormatException ex)
            {
                // Handle the format exception (invalid input) here
                // You can log the error or show a user-friendly message
            }
        }
    
        private void EngineSizeTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
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
    
        private void LoadCapacityTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _loadCapacity = Convert.ToDecimal(LoadCapacityTextBox.Text);
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
    
        private void Towbar_OnChecked(object sender, RoutedEventArgs e)
        {
            _towbar = true;
        }
    
        private void Towbar_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _towbar = false;
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
}
