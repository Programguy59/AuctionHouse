using System;
using System.Windows;
using System.Windows.Controls;
using AutoAuctionProjekt.Classes;

namespace AutoAuctionWPF
{
    public partial class SetForSaleProfessionalPersonalCar : UserControl
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
        public static bool _hasSaftybar;
        public static decimal _loadCapacity;

        public SetForSaleProfessionalPersonalCar()
        {
            InitializeComponent();
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

        private void DepthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (decimal.TryParse(DepthTextBox.Text, out decimal depthValue))
                {
                    _depth = depthValue;
                }
                else
                {
                    // Handle invalid depth input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void WidthTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (decimal.TryParse(WidthTextBox.Text, out decimal widthValue))
                {
                    _width = widthValue;
                }
                else
                {
                    // Handle invalid width input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void HeightTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (decimal.TryParse(HeightTextBox.Text, out decimal heightValue))
                {
                    _height = heightValue;
                }
                else
                {
                    // Handle invalid height input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void EngineTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (double.TryParse(EngineTextBox.Text, out double engineSizeValue))
                {
                    _engineSize = engineSizeValue;
                }
                else
                {
                    // Handle invalid engine size input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void KmPerLiterTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (double.TryParse(KmPerLiterTextBox.Text, out double kmPerLiterValue))
                {
                    _kmPerLiter = kmPerLiterValue;
                }
                else
                {
                    // Handle invalid km per liter input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void NumberOfSeatTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (ushort.TryParse(NumberOfSeatTextBox.Text, out ushort numberOfSeatsValue))
                {
                    _numberOfSeats = numberOfSeatsValue;
                }
                else
                {
                    // Handle invalid number of seats input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
            }
        }

        private void LoadCapacityTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (decimal.TryParse(LoadCapacityTextBox.Text, out decimal loadCapacityValue))
                {
                    _loadCapacity = loadCapacityValue;
                }
                else
                {
                    // Handle invalid load capacity input
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions if needed
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

        private void IsSafetyBar_OnChecked(object sender, RoutedEventArgs e)
        {
            _hasSaftybar = true;
        }

        private void IsSafetyBar_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _hasSaftybar = false;
        }
    }
}
