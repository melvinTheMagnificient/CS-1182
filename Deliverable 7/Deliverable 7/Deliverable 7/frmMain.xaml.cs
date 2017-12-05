//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Shows current game
using BaseClasses;
using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Deliverable_7 {

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

        #endregion Class Variables

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

        #endregion Constructors

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
        }

        /// <summary>
        /// Shows location of everything in map of current game
        /// </summary>
        public void DrawMap() {
            for (int row = 0; row < _Row; row++) {
                for (int col = 0; col < _Col; col++) {
                    TextBlock tbMapCell = new TextBlock();
                    tbMapCell.Foreground = Brushes.White;
                    tbMapCell.Background = Brushes.Black;
                    tbMapCell.HorizontalAlignment = HorizontalAlignment.Stretch;
                    tbMapCell.VerticalAlignment = VerticalAlignment.Stretch;
                    tbMapCell.TextAlignment = TextAlignment.Center;

                    Grid.SetRow(tbMapCell, row);
                    Grid.SetColumn(tbMapCell, col);
                    grdMap.Children.Add(tbMapCell);
                    MapCell cell = Game.CurrentMap.GameBoard[row, col];

                    if (cell.HasBeenDiscovered) {
                        tbMapCell.Background = Brushes.DarkGray;

                        if (cell.HasItem) {
                            if (cell.Item.GetType() == typeof(Potion)) {
                                if (cell.Item.Name == "a Plumbus") {
                                    AddImage("Plumbus.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "a Love Potion") {
                                    AddImage("Love Potion.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "Mr. Meeseeks") {
                                    AddImage("Mr. Meeseeks.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "Eyeholes") {
                                    AddImage("Eyeholes.png", tbMapCell);
                                }
                            }
                            else if (cell.Item.GetType() == typeof(Weapon)) {
                                if (cell.Item.Name == "a Freeze Ray") {
                                    AddImage("Freeze Gun.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "a Laser Gun") {
                                    AddImage("Laser Gun.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "a Neutrino Bomb") {
                                    AddImage("Neutrino Bomb.png", tbMapCell);
                                }
                                else if (cell.Item.Name == "Chris") {
                                    AddImage("Chris.png", tbMapCell);
                                }
                            }
                            else if (cell.Item.GetType() == typeof(Door)) {
                                AddImage("Portal.jpg", tbMapCell);
                            }
                            else if (cell.Item.GetType() == typeof(DoorKey)) {
                                AddImage("Portal Gun.png", tbMapCell);
                            }
                        }
                        else if (cell.HasMonster) {
                            if (cell.Monster.Name == "Mr. Goldenfold") {
                                AddImage("Mr. Goldenfold.png", tbMapCell);
                            }
                            else if (cell.Monster.Name == "Evil Rick") {
                                AddImage("Evil Rick.png", tbMapCell);
                            }
                            else if (cell.Monster.Name == "A Zigerion") {
                                AddImage("Zigerion.png", tbMapCell);
                            }
                            else if (cell.Monster.Name == "Fart") {
                                AddImage("Fart.png", tbMapCell);
                            }
                        }
                        if (Game.CurrentMap.HeroLocation == cell) {
                            AddImage("Rick.png", tbMapCell);
                            Game.CurrentMap.HeroLocation.HasBeenDiscovered = true;
                        }
                    }
                    if (!cell.HasBeenDiscovered) {
                        tbMapCell.Background = Brushes.Black;
                    }
                }
            }
            UpdateMapStats();
            UpdateHeroStats();
        }

        /// <summary>
        /// Add an image to a textblock
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

        #endregion Map

        #region Move Hero

        /// <summary>
        /// Changes game status based on Hero's hp
        /// </summary>
        private void UpdateGameStatus() {
            if (Game.CurrentMap.CurrentHero.DoorKeyFound &&
               Game.CurrentMap.HeroLocation.HasItem &&
               Game.CurrentMap.HeroLocation.Item.GetType() == typeof(Door) &&
               ((DoorKey)Game.CurrentMap.CurrentHero.DoorKey).Code ==
               ((Door)Game.CurrentMap.HeroLocation.Item).Code) {
                Game.GameState = Game.State.won;
                frmGameOver f = new frmGameOver();
                f.ShowDialog();
            }
            else if (Game.CurrentMap.CurrentHero.HP == 0) {
                Game.GameState = Game.State.lost;
                frmGameOver f = new frmGameOver();
                f.ShowDialog();
            }
            else {
                Game.GameState = Game.State.running;
            }
        }

        /// <summary>
        /// Moves hero one cell up and tells user if anything has been discovered
        /// </summary>
        private void Up() {
            Game.CurrentMap.MoveHero(Actor.Direction.Up);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                if (Game.CurrentMap.HeroLocation.Item.GetType() == typeof(Door)) {
                    frmGameOver g = new frmGameOver();
                    g.ShowDialog();
                }
                else {
                    frmItem f = new frmItem();
                    f.ShowDialog();
                }
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
            UpdateHeroStats();
            UpdateGameStatus();
        }

        /// <summary>
        /// Moves hero one cell down and tells user if anything has been discovered
        /// </summary>
        private void Down() {
            Game.CurrentMap.MoveHero(Actor.Direction.Down);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                if (Game.CurrentMap.HeroLocation.Item.GetType() == typeof(Door)) {
                    frmGameOver g = new frmGameOver();
                    g.ShowDialog();
                }
                else {
                    frmItem f = new frmItem();
                    f.ShowDialog();
                }
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
            UpdateHeroStats();
            UpdateGameStatus();
        }

        /// <summary>
        /// Moves hero one cell left and tells user if anything has been discovered
        /// </summary>
        private void Left() {
            Game.CurrentMap.MoveHero(Actor.Direction.Left);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                if (Game.CurrentMap.HeroLocation.Item.GetType() == typeof(Door)) {
                    frmGameOver g = new frmGameOver();
                    g.ShowDialog();
                }
                else {
                    frmItem f = new frmItem();
                    f.ShowDialog();
                }
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
            UpdateHeroStats();
            UpdateGameStatus();
        }

        /// <summary>
        /// Moves hero one cell right and tells user if anything has been discovered
        /// </summary>
        private void Right() {
            Game.CurrentMap.MoveHero(Actor.Direction.Right);
            DrawMap();
            if (Game.CurrentMap.HeroLocation.HasItem) {
                if (Game.CurrentMap.HeroLocation.Item.GetType() == typeof(Door)) {
                    frmGameOver g = new frmGameOver();
                    g.ShowDialog();
                }
                else {
                    frmItem f = new frmItem();
                    f.ShowDialog();
                }
            }
            else if (Game.CurrentMap.HeroLocation.HasMonster) {
                frmMonster f = new frmMonster();
                f.ShowDialog();
            }
            UpdateHeroStats();
            UpdateGameStatus();
        }

        /// <summary>
        /// Keyboard shortcuts for moving hero
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

        #endregion Move Hero

        /// <summary>
        /// Shows how many monsters/items are in current game and percentage of map discovered
        /// </summary>
        public void UpdateMapStats() {
            tbMapStats.Text = "Monsters on Map: " + Game.CurrentMap.MonsterCount +
            "\r\nItems on Map: " + Game.CurrentMap.ItemCount +
            "\r\nPercentage Found: " + Game.CurrentMap.MapDiscovered.ToString("p");
        }

        /// <summary>
        /// Updates form to show hero's stats
        /// </summary>
        public void UpdateHeroStats() {
            string name = Game.CurrentMap.CurrentHero.NameWithTitle();
            string currentHP = Game.CurrentMap.CurrentHero.HP.ToString();
            string maxHP = Game.CurrentMap.CurrentHero.MaxHP.ToString();
            string equippedWeapon;
            if (Game.CurrentMap.CurrentHero.HasWeapon) {
                equippedWeapon = Game.CurrentMap.CurrentHero.Weapon.Name.ToString();
            }
            else {
                equippedWeapon = "none";
            }
            string currentKey;
            if (Game.CurrentMap.CurrentHero.DoorKeyFound) {
                currentKey = Game.CurrentMap.CurrentHero.DoorKey.Name.ToString();
            }
            else {
                currentKey = "none";
            }

            tbHeroStats.Text = name + "\r\nHP: " + currentHP
                 + "/" + maxHP
                + "\r\nWeapon: " + equippedWeapon + "\r\nKey: " + currentKey;
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
            UpdateHeroStats();
        }

        #endregion Methods

        /// <summary>
        /// Saves current game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miSave_Click(object sender, RoutedEventArgs e) {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Binary File |*.map";
            bool? x = file.ShowDialog();
            if (x == true) {
                string saveFile = file.FileName;

                BinaryFormatter b = new BinaryFormatter();
                FileStream f = new FileStream(saveFile, FileMode.OpenOrCreate);
                b.Serialize(f, Game.CurrentMap);
                f.Close();
            }
        }

        /// <summary>
        /// Loads game that has been saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miLoad_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Binary File |*.map";
            BinaryFormatter b = new BinaryFormatter();
            bool? x = o.ShowDialog();
            FileStream f = null;

            if (x == true && o.CheckFileExists) {
                try {
                    f = new FileStream(o.FileName, FileMode.Open);
                    Game.CurrentMap = (Map)b.Deserialize(f);
                }
                catch {
                    MessageBox.Show("File could not be found. Please try again");
                }
                finally {
                    if (f != null) {
                        f.Close();
                        DrawMap();
                    }
                }
            }
            else {
                MessageBox.Show("Please load a game");
            }
        }
    }
}