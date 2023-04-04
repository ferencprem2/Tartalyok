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
using Osztalyaim;
using System.IO;
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Tartaly> tartalyLista = new();
        SaveFileDialog saveFile = new();
        public MainWindow()
        {
            InitializeComponent();
            Tartaly nagytartaly = new Tartaly(txtNev.Text, 500, 200, 120);
            Tartaly literes = new Tartaly(txtNev.Text, 10, 10, 10);

        }


        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";
            txtAel.IsEnabled = true;
            txtBel.IsEnabled = true;
            txtCel.IsEnabled = true;
        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";
            txtAel.IsEnabled = false;
            txtBel.IsEnabled = false;
            txtCel.IsEnabled = false;
        }
         private void btnFelvesz_Click(object sender, RoutedEventArgs e)
         {
            if (rdoKocka.IsChecked == true)
            {
                Tartaly newData = new Tartaly(txtNev.Text);
                tartalyLista.Add(newData);
                lbTartalyok.Items.Add(newData.Info());
            }        
            else if (rdoTeglatest.IsChecked == true)
            {
                Tartaly newData = new Tartaly(txtNev.Text, Convert.ToInt32(txtAel.Text), Convert.ToInt32(txtBel.Text), Convert.ToInt32(txtCel.Text));
                tartalyLista.Add(newData);
                lbTartalyok.Items.Add(newData.Info());
            } else
            {
                MessageBox.Show("Válassza ki, hogy téglatestet vagy kockát szeretne megadni");
            }
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (saveFile.ShowDialog() == true)
                {
                    File.WriteAllLines(saveFile.FileName, tartalyLista.Select(lines => lines.Info()));
                }
                else
                {
                    MessageBox.Show("No datas to write");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                throw;
            }

        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbTartalyok.SelectedIndex >= 0)
                {
                    tartalyLista[lbTartalyok.SelectedIndex].DuplazMeretet();
                    lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyLista[lbTartalyok.SelectedIndex].Info();
                }
                else
                {
                    MessageBox.Show("Válasszon ki egy elemet");
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                throw;
            }
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbTartalyok.SelectedIndex >= 0)
                {
                    tartalyLista[lbTartalyok.SelectedIndex].TeljesLeengedes();
                    lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyLista[lbTartalyok.SelectedIndex].Info();
                } 
                else
                {
                    MessageBox.Show("Válasszon ki egy elemet");
                }                
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                throw;
            }
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbTartalyok.SelectedIndex >= 0)
                {
                    tartalyLista[lbTartalyok.SelectedIndex].Tolt(Convert.ToDouble(txtMennyitTolt.Text));
                    lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyLista[lbTartalyok.SelectedIndex].Info();
                }
                else
                {
                    MessageBox.Show("Válasszon ki egy elemet");
                }
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                throw;
            }
        }
    }
}
