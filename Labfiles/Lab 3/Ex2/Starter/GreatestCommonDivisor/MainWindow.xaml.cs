﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Do the GCD calculations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindGCD_Click(object sender, RoutedEventArgs e)
        {
            int firstNumber;
            int secondNumber;
            int thirdNumber;
            int fourthNumber;
            int fifthNumber;

            if (!GetPostiveIntegerFromTextBox(integer1, out firstNumber)) return;
            if (!GetPostiveIntegerFromTextBox(integer2, out secondNumber)) return;
            if (!GetPostiveIntegerFromTextBox(integer3, out thirdNumber)) return;
            if (!GetPostiveIntegerFromTextBox(integer4, out fourthNumber)) return;
            if (!GetPostiveIntegerFromTextBox(integer5, out fifthNumber)) return;

            if (sender == findGCD) // Euclid for two integers 
            {
                // Do the calculations
                this.resultEuclid.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber));
                this.resultStein.Content = "N/A";
            }
            // Call the overloaded methods for 3, 4 and 5 integers
            else if (sender == findGCD3) // Euclid for three integers
            {
                this.resultEuclid.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber));
                this.resultStein.Content = "N/A";
            }
            else if (sender == findGCD4) // Euclid for four integers
            {
                this.resultEuclid.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber));
                this.resultStein.Content = "N/A";
            }
            else if (sender == findGCD5) // Euclid for five integers
            {
                this.resultEuclid.Content = String.Format("Euclid: {0}", GCDAlgorithms.FindGCDEuclid(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber));
                this.resultStein.Content = "N/A";
            }
        }

        /// <summary>
        /// Read a postive integer from a TextBox
        /// Displays a message box with the data if the text can't be parsed.
        /// </summary>
        /// <param name="textBox">TextBox to read</param>
        /// <param name="i">Postive integer (out parameter)</param>
        /// <returns>True if success, false otherwise</returns>
        private bool GetPostiveIntegerFromTextBox(TextBox textBox, out int i)
        {
            i = -1;
            if (int.TryParse(textBox.Text, out i))
            {
                if (i >= 0) return true;
            }
            MessageBox.Show("Not a positive integer value: " + textBox.Text);
            return false;
        }
    }
}
