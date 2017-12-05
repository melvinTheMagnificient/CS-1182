//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Subform tells player what item their hero has discovered
using System.Windows;

namespace Deliverable_7 {

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
            tbMessage.Text = "You found \r\n" + Game.CurrentMap.HeroLocation.Item.Name +
                "\r\nDo you want to use it?";
        }

        /// <summary>
        /// Gives item in mapcell to hero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.HeroLocation.Item = Game.CurrentMap.CurrentHero.GiveHeroItem(Game.CurrentMap.HeroLocation.Item);
            this.Close();
        }

        /// <summary>
        /// Hero leaves item in map cell and keeps current one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}