//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: Shows current game
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

namespace Deliverable_5 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        #region Class Variables
        private int _Row = 15;
        private int _Col = 15;
        private int _ButtonClickCount = 0;
        #endregion

        public MainWindow() {
            InitializeComponent();
        }

        /// <summary>
        /// Keep mainWindow size proportional. This still needs some work.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
            this.Width = this.Height;
        }

        #region Game
        /// <summary>
        /// Resets game and shows necessary buttons and textblocks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e) {
            _ButtonClickCount++;
            if (_ButtonClickCount == 1) {
                Game.ResetGame(_Row, _Col);
                btnUp.Visibility = Visibility;
                btnDown.Visibility = Visibility;
                btnLeft.Visibility = Visibility;
                btnRight.Visibility = Visibility;
                MakeMapGrid();
                ShowMapGrid();
                DisplayStats();
            }
            else {
                Game.ResetGame(_Row, _Col);
                ShowMapGrid();
                DisplayStats();
            }
        }
        #endregion

        #region Map
        /// <summary>
        /// Refreshes map without reseting gameboard
        /// </summary>
        private void RefreshMap() {
            DisplayStats();
            ShowMapGrid();
        }

        /// <summary>
        /// Makes map grid based on size of gameboard
        /// </summary>
        private void MakeMapGrid() {
            for (int rowi = 0; rowi < _Row; rowi++)
                grdMap.RowDefinitions.Add(new RowDefinition());
            for (int coli = 0; coli < _Col; coli++)
                grdMap.ColumnDefinitions.Add(new ColumnDefinition());
        }

        /// <summary>
        /// Adds a textblock for each MapCell and shows what's in the MapCell
        /// </summary>
        private void ShowMapGrid() {
            grdMap.ShowGridLines = true;
            for (int rowi = 0; rowi < _Row; rowi++) {
                for (int coli = 0; coli < _Col; coli++) {
                    TextBlock tbMapCell = new TextBlock();
                    tbMapCell.Text = "";
                    tbMapCell.Background = Brushes.White;
                    tbMapCell.TextAlignment = TextAlignment.Center;
                    if (Game.CurrentMap.HasHero != null &&
                        Game.CurrentMap.HasHero.StartingXCoordinate == coli &&
                        Game.CurrentMap.HasHero.StartingYCoordinate == rowi) {
                        tbMapCell.Text = "H";
                        tbMapCell.Background = Brushes.Red;
                    }
                    else if (Game.CurrentMap.GameBoard[rowi, coli].HasItem) {
                        tbMapCell.Text = "P";
                        tbMapCell.Background = Brushes.Blue;
                    }
                    Grid.SetRow(tbMapCell, rowi);
                    Grid.SetColumn(tbMapCell, coli);
                    grdMap.Children.Add(tbMapCell);
                }
            }
        }
        #endregion        

        #region Hero
        /// <summary>
        /// Moves hero up one MapCell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.HasHero.Move(0);
            RefreshMap();
            FoundItem();
        }

        /// <summary>
        /// Moves hero down one MapCell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.HasHero.Move(1);
            RefreshMap();
            FoundItem();
        }

        /// <summary>
        /// Moves hero right one MapCell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.HasHero.Move(3);
            RefreshMap();
            FoundItem();
        }

        /// <summary>
        /// Moves hero left one MapCell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, RoutedEventArgs e) {
            Game.CurrentMap.HasHero.Move(2);
            RefreshMap();
            FoundItem();
        }
        #endregion

        #region Items in Map
        /// <summary>
        /// Tells user they found a potion
        /// </summary>
        private void FoundItem() {
            frmFoundIt f = new frmFoundIt();
            if (Game.CurrentMap.GameBoard[Game.CurrentMap.HasHero.StartingXCoordinate,
                Game.CurrentMap.HasHero.StartingYCoordinate].HasItem) {
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Shows stats for monsters, potions, and weapons in the game
        /// </summary>
        private void DisplayStats() {
            int maxMonsterHitPoints = 0;
            foreach (var monster in Game.CurrentMap.PossibleMonsters) {
                if (monster.AttackValue > maxMonsterHitPoints) {
                    maxMonsterHitPoints = monster.AttackValue;
                }
            }

            double averagePotionHealing = 0.0;
            int count = 0;
            foreach (var potion in Game.CurrentMap.AvailablePotions) {
                averagePotionHealing += potion.Value;
                count++;
            }
            averagePotionHealing = averagePotionHealing / count;

            int minWeaponDamage = int.MaxValue;
            foreach (var weapon in Game.CurrentMap.AvailableWeapons) {
                if (weapon.Value < minWeaponDamage) {
                    minWeaponDamage = weapon.Value;
                }
            }

            tbHeroStats.Text = "Name: " + Game.CurrentMap.HasHero.NameWithTitle() +
                "\r\nX: " + Game.CurrentMap.HasHero.StartingXCoordinate.ToString() + " Y: " +
                Game.CurrentMap.HasHero.StartingYCoordinate.ToString();
            tbMonster.Text = "Maximum Hit Points on a Monster is: \r\n" + maxMonsterHitPoints.ToString();
            tbPotions.Text = "Average Healing from all Potions is: \r\n" + averagePotionHealing.ToString();
            tbWeapon.Text = "Minimum Damage from a Weapon is: \r\n" + minWeaponDamage.ToString();
        }
        #endregion
    }
}
