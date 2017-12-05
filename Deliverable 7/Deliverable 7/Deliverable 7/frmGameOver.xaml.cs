//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Subform for end of game
using BaseClasses;
using System;
using System.Windows;

namespace Deliverable_7 {

    /// <summary>
    /// Interaction logic for frmGameOver.xaml
    /// </summary>
    public partial class frmGameOver : Window {

        public frmGameOver() {
            InitializeComponent();

            if (Game.CurrentMap.HeroLocation.HasItem &&
                Game.CurrentMap.HeroLocation.Item.GetType() ==
                typeof(Door) && Game.CurrentMap.CurrentHero.DoorKeyFound) {
                if (Game.CurrentMap.CurrentHero.DoorKeyFound &&
                    ((Door)Game.CurrentMap.HeroLocation.Item).DoorKeyMatch(Game.CurrentMap.CurrentHero.DoorKey)) {
                    Game.GameState = Game.State.won;
                    tbMessage.Text = "Your key unlocked the door!";
                }
                else {
                    tbMessage.Text = "Your key can't unlock the door";
                }
            }
            else {
                tbMessage.Text = "You need a key to unlock the door";
            }

            if (Game.GameState == Game.State.won) {
                tbMessage.Text += "\r\nYou won!";
                btnExit.Visibility = Visibility.Visible;
                btnRestart.Visibility = Visibility.Visible;
            }
            else if (Game.GameState == Game.State.lost) {
                tbMessage.Text = "\r\nYou lost";
                btnExit.Visibility = Visibility.Visible;
                btnRestart.Visibility = Visibility.Visible;
            }
            else {
                btnOK.Visibility = Visibility.Visible;
            }
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e) {
            Game.ResetGame();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            Environment.Exit(0);
        }
    }
}