//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: Tell user if an item on the board has been found
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
using System.Windows.Shapes;
using BaseClasses;

namespace Deliverable_5 {
    /// <summary>
    /// Interaction logic for frmFoundIt.xaml
    /// </summary>
    public partial class frmFoundIt : Window {
        public frmFoundIt() {
            InitializeComponent();
            ItemFound();
        }

        private void ItemFound() {
            tbItemFound.Text = "You have found an item!";
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
