using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }

            
            
            if (double.TryParse(priceTextBox.Text, out double price) &&
                int.TryParse(quantityTextBox.Text, out int quantity))
            {
 
                double totalPayment = price * quantity;
                double totalCharge = totalPayment + 25.00 + 5.00;
                double totalGST = totalPayment * 1.1;

                totalPaymentTextBlock.Text = $"{totalPayment:F2}";
                TotalChargeWrapTextBox.Text = $"{totalCharge:F2}";
                TotalChargeGSTTextBox.Text = $"{totalGST:F2}";
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for price and quantity.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
