//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Subform tells player what monster their hero has discovered
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

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for frmMonster.xaml
    /// </summary>
    public partial class frmMonster : Window {
        public frmMonster() {
            InitializeComponent();
            FillSubform();
        }

        public void FillSubform() {
            StackPanel stkMain = new StackPanel();
            Grid.SetRow(stkMain, 1);
            Grid.SetColumn(stkMain, 1);
            grdMain.Children.Add(stkMain);

            Label lblItem = new Label();
            lblItem.Content = "You have found a \r\n" + Game.CurrentMap.HeroLocation.Monster.Name;
            stkMain.Children.Add(lblItem);

            Button btnOK = new Button();
            btnOK.Content = "OK";
            stkMain.Children.Add(btnOK);
            btnOK.Click += BtnOK_Click;
            btnOK.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
