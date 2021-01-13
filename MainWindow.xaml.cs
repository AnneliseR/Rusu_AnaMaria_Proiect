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

namespace Rusu_AnaMaria_Proiect
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

        private int mDressingChocolate = 0;
        private int mDressingSourCherry = 0;
        private int mFilledMango = 0;
        private int mFilledBanana = 0;
        private int mFilledPomegranate = 0;
        private double Total = 0;
        private PancakeType selectedPancake;

        private void chocolateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDressingChocolate++;
            txtDressingChocolate.Text = mDressingChocolate.ToString();
        }
        private void sourCherryMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mDressingSourCherry++;
            txtDressingSourCherry.Text = mDressingSourCherry.ToString();
        }
        private void mangoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFilledMango++;
            txtMangoFilled.Text = mFilledMango.ToString();
        }
        private void bananaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFilledBanana++;
            txtBananaFilled.Text = mFilledBanana.ToString();
        }
        private void pomegranateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mFilledPomegranate++;
            txtPomegranateFilled.Text = mFilledPomegranate.ToString();
        }

        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " pancakes are being cooked!";
            this.Title = mesaj;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        KeyValuePair<PancakeType, double>[] PriceList =
        {
            new KeyValuePair<PancakeType, double>(PancakeType.Chocolate, 2.5),
            new KeyValuePair<PancakeType, double>(PancakeType.SourCherry, 3),
            new KeyValuePair<PancakeType, double>(PancakeType.Banana, 4.5),
            new KeyValuePair<PancakeType, double>(PancakeType.Mango, 4),
            new KeyValuePair<PancakeType, double>(PancakeType.Pomegranate, 3.5)
        };

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }

        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<PancakeType, double> selectedEntry =
           (KeyValuePair<PancakeType, double>)cmbType.SelectedItem;
            selectedPancake = selectedEntry.Key;
        }
        private int ValidateQuantity(PancakeType selectedDoughnut)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedDoughnut)
            {
                case PancakeType.Chocolate:
                    if (q > mDressingChocolate)
                        r = 0;
                    break;
                case PancakeType.SourCherry:
                    if (q > mDressingSourCherry)
                        r = 0;
                    break;
                case PancakeType.Banana:
                    if (q > mFilledBanana)
                        r = 0;
                    break;
                case PancakeType.Mango:
                    if (q > mFilledMango)
                        r = 0;
                    break;
                case PancakeType.Pomegranate:
                    if (q > mFilledPomegranate)
                        r = 0;
                    break;
            }
            return r;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedPancake) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedPancake.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Chocolate":
                        mDressingChocolate = mDressingChocolate - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtDressingChocolate.Text = mDressingChocolate.ToString();
                        break;
                    case "SourCherry":
                        mDressingChocolate = mDressingChocolate - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtDressingSourCherry.Text = mDressingChocolate.ToString();
                        break;
                    case "Banana":
                        mFilledBanana = mFilledBanana - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBananaFilled.Text = mFilledBanana.ToString();
                        break;
                    case "Mango":
                        mFilledMango = mFilledMango - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtMangoFilled.Text = mFilledMango.ToString();
                        break;
                    case "Pomegranate":
                        mFilledPomegranate = mFilledPomegranate - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtPomegranateFilled.Text = mFilledPomegranate.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();
        }
        private void txtQuantity_KeyPress(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}