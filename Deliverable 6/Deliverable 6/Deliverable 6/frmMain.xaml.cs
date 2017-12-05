//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
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
using BaseClasses;

namespace Deliverable_6 {
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window {
        #region Class Variables
        /// <summary>
        /// private variables for the current game
        /// </summary>
        private int _Row = 10;
        private int _Col = 10;
        private int _ButtonClickCount = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// constructor for main form. Creates new game and shows map.
        /// </summary>      
        public frmMain() {
            InitializeComponent();

            _ButtonClickCount++;
            Game.ResetGame(_Row, _Col);
            MakeMapGrid();
            DrawMap();
        }
        #endregion

        #region Methods
        #region Map
        /// <summary>
        /// Creates grid in form for map
        /// </summary>
        private void MakeMapGrid() {
            for (int row = 0; row < _Row; row++) {
                grdMap.RowDefinitions.Add(new RowDefinition());
            }
            for (int col = 0; col < _Col; col++) {
                grdMap.ColumnDefinitions.Add(new ColumnDefinition());
            }
            //grdMap.ShowGridLines = true;
        }

        /// <summary>
        /// Shows location of everything in map of current game
        /// </summary>
        private void DrawMap() {
            for (int row = 0; row < _Row; row++) {
                for (int col = 0; col < _Col; col++) {

                    Label lblMapCell = new Label();
                    lblMapCell.Foreground = Brushes.White;
                    lblMapCell.Background = Brushes.Black;
                    lblMapCell.BorderBrush = Brushes.Black;
                    lblMapCell.HorizontalAlignment = HorizontalAlignment.Stretch;
                    lblMapCell.VerticalAlignment = VerticalAlignment.Stretch;
                    lblMapCell.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lblMapCell.VerticalContentAlignment = VerticalAlignment.Center;

                    Grid.SetRow(lblMapCell, row);
                    Grid.SetColumn(lblMapCell, col);
                    grdMap.Children.Add(lblMapCell);
                    MapCell cell = Game.CurrentMap.GameBoard[row, col];

                    if (cell.HasBeenDiscovered) {
                        lblMapCell.Content = "X";
                    }
                    if (cell.HasItem) {
                        if (cell.Item.GetType() == typeof(Potion)) {
                            lblMapCell.Background = Brushes.DarkBlue;
                            lblMapCell.Content = cell.Item.Name;
                        }
                        else if (cell.Item.GetType() == typeof(Weapon)) {
                            lblMapCell.Background = Brushes.Blue;
                            lblMapCell.Content = cell.Item.Name;
                        }
                        else if (cell.Item.GetType() == typeof(Door)) {
                            lblMapCell.Background = Brushes.IndianRed;
                            lblMapCell.Content = cell.Item.Name;
                        }
                        else if (cell.Item.GetType() == typeof(DoorKey)) {
                            lblMapCell.Background = Brushes.Red;
                            lblMapCell.Content = cell.Item.Name;
                        }
                    }
                    else if (cell.HasMonster) {
                        lblMapCell.Background = Brushes.Purple;
                        lblMapCell.Content = cell.Monster.Name;
                    }
                    if (Game.CurrentMap.HeroLocation == cell) {
                        lblMapCell.Background = Brushes.LimeGreen;
                        lblMapCell.Content = Game.CurrentMap.CurrentHero.NameWithTitle();
                        Game.CurrentMap.HeroLocation.HasBeenDiscovered = true;
                    }
                }
            }
            UpdateMapStats();
        }
        #endregion

        #region Move Hero
        /// <summary>
        /// Moves hero one cell up and tells user if anything has been discovered
        /// </summary>
        private void Up() {
            Game.CurrentMap.MoveHero(Actor.Direction.Up);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                frmItem f = new frmItem();
                f.ShowDialog();
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Moves hero one cell down and tells user if anything has been discovered
        /// </summary>
        private void Down() {
            Game.CurrentMap.MoveHero(Actor.Direction.Down);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                frmItem f = new frmItem();
                f.ShowDialog();
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Moves hero one cell left and tells user if anything has been discovered
        /// </summary>
        private void Left() {
            Game.CurrentMap.MoveHero(Actor.Direction.Left);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                frmItem f = new frmItem();
                f.ShowDialog();
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Moves hero one cell right and tells user if anything has been discovered
        /// </summary>
        private void Right() {
            Game.CurrentMap.MoveHero(Actor.Direction.Right);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                frmItem f = new frmItem();
                f.ShowDialog();
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
        }

        /// <summary>
        /// Keyboard shorcuts for moving hero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Up) {
                Up();
            }
            else if (e.Key == Key.Down) {
                Down();
            }
            else if (e.Key == Key.Left) {
                Left();
            }
            else if (e.Key == Key.Right) {
                Right();
            }
        }

        /// <summary>
        /// Moves hero one cell right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRight_Click(object sender, RoutedEventArgs e) {
            Right();
        }

        /// <summary>
        /// Moves hero one cell left
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLeft_Click(object sender, RoutedEventArgs e) {
            Left();
        }

        /// <summary>
        /// Moves hero one cell down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDown_Click(object sender, RoutedEventArgs e) {
            Down();
        }

        /// <summary>
        /// Moves hero one cell up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUp_Click(object sender, RoutedEventArgs e) {
            Up();
        }
        #endregion

        /// <summary>
        /// Shows how many monsters/items are in current game and percentage of map discovered
        /// </summary>
        private void UpdateMapStats() {
            tbStats.Text = "Monsters on Map: " + Game.CurrentMap.MonsterCount +
            "\r\nItems on Map: " + Game.CurrentMap.ItemCount +
            "\r\nPercentage Found: " + Game.CurrentMap.MapDiscovered.ToString("p");
        }

        /// <summary>
        /// Creates new map without creating new grid in form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnResetGame_Click(object sender, RoutedEventArgs e) {
            _ButtonClickCount++;
            Game.ResetGame(_Row, _Col);
            DrawMap();
            UpdateMapStats();
        }
        #endregion
    }
}
