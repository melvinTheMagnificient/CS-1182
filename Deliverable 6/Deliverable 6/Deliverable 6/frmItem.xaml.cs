//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Subform tells player what item their hero has discovered
using System.Windows;
using System.Windows.Controls;

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for frmItem.xaml
    /// </summary>
    public partial class frmItem : Window {
        public frmItem() {
            InitializeComponent();
            FillSubform();
        }

        /// <summary>
        /// Tells user what they've discovered
        /// </summary>
        public void FillSubform() {
            StackPanel stkMain = new StackPanel();
            Grid.SetRow(stkMain, 1);
            Grid.SetColumn(stkMain, 1);
            grdMain.Children.Add(stkMain);

            Label lblItem = new Label();
            lblItem.HorizontalAlignment = HorizontalAlignment.Center;
            lblItem.VerticalAlignment = VerticalAlignment.Center;
            lblItem.Content = "You have found a \r\n" + Game.CurrentMap.HeroLocation.Item.Name;
            stkMain.Children.Add(lblItem);

            Button btnOK = new Button();
            btnOK.Content = "OK";
            stkMain.Children.Add(btnOK);
            btnOK.Click += BtnOK_Click;
            btnOK.Focus();
        }

        /// <summary>
        /// Closes subform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
