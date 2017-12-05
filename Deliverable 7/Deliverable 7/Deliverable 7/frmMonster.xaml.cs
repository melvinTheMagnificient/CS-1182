//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Subform tells player what monster their hero has discovered
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace Deliverable_7 {

    /// <summary>
    /// Interaction logic for frmMonster.xaml
    /// </summary>
    public partial class frmMonster : Window {

        public frmMonster() {
            InitializeComponent();
            FillSubform();
        }

        /// <summary>
        /// Adds image to a textblock
        /// Help from Nick Harrison and Megan Urban
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="tb"></param>
        private void AddImage(string filename, TextBlock tb) {
            Image pic = new Image();
            pic.Source = new BitmapImage(new Uri(filename, UriKind.Relative));
            pic.Visibility = Visibility.Visible;
            pic.Height = tb.Height;
            pic.Width = tb.Width;
            InlineUIContainer c = new InlineUIContainer(pic);
            tb.Inlines.Add(c);
        }

        /// <summary>
        /// Shows player what they've found on map
        /// </summary>
        public void FillSubform() {
            tbMessage.Text = "It's " + Game.CurrentMap.HeroLocation.Monster.Name + "!\r\n";
            tbHeroStats.Text = Game.CurrentMap.CurrentHero.NameWithTitle() + "\r\n"
                + "HP: " + Game.CurrentMap.CurrentHero.HP.ToString() + "/" + Game.CurrentMap.CurrentHero.MaxHP.ToString();
            tbMonsterStats.Text = Game.CurrentMap.HeroLocation.Monster.NameWithTitle() + "\r\n" +
                "HP: " + Game.CurrentMap.HeroLocation.Monster.HP.ToString() + "/" + Game.CurrentMap.HeroLocation.Monster.MaxHP.ToString();
        }

        /// <summary>
        /// Hero fights monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFight_Click(object sender, RoutedEventArgs e) {
            bool x = Game.CurrentMap.CurrentHero + Game.CurrentMap.HeroLocation.Monster;
            FillSubform();
            if (!x) {
                Game.GameState = Game.State.lost;
                this.Close();
            }
            else if (Game.CurrentMap.HeroLocation.Monster.HP == 0) {
                Game.CurrentMap.HeroLocation.Monster = null;
                this.Close();
            }
        }

        /// <summary>
        /// Hero runs away from monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRunAway_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.CurrentHero.IsRunningAway = true;
            bool x = Game.CurrentMap.CurrentHero + Game.CurrentMap.HeroLocation.Monster;
            FillSubform();
            if (!x) {
                Game.GameState = Game.State.lost;
            }
            this.Close();
        }
    }
}