//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: Test form for classes
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

namespace Deliverable_4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Map map = new Map(5, 5);

        public MainWindow() {
            InitializeComponent();
            TestPotions();
            TestMonsters();
            TestHero();
            TestWeapons();
            TestMap();
        }

        #region Potions
        /// <summary>
        /// Creates button that shows all available potions and their values
        /// </summary>
        private void TestPotions() {
            Button btnShowPotions = new Button();
            btnShowPotions.Content = "Show Potions";
            stkPotions.Children.Add(btnShowPotions);
            btnShowPotions.Click += new RoutedEventHandler(btnShowPotions_Click);
        }

        /// <summary>
        /// Hides btnShowPotions and shows all available potions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPotions_Click(object sender, EventArgs e) {
            stkPotions.Children[0].Visibility = System.Windows.Visibility.Collapsed;
            TextBlock tbLabel = new TextBlock();
            tbLabel.Text = "Potions:";
            stkPotions.Children.Add(tbLabel);
            for (int i = 0; i < map.AvailablePotions.Count; i++) {
                TextBlock tbPotion = new TextBlock();
                stkPotions.Children.Add(tbPotion);
                tbPotion.Text = map.AvailablePotions[i].Name + " (" + map.AvailablePotions[i].Value + ")";
                tbPotion.Foreground = new SolidColorBrush(map.AvailablePotions[i].PotionColor);
            }
        }
        #endregion

        #region Monsters
        /// <summary>
        /// Creates button to show all possible monsters
        /// </summary>
        private void TestMonsters() {
            Button btnShowMonsters = new Button();
            btnShowMonsters.Content = "Show Monsters";
            stkMonsters.Children.Add(btnShowMonsters);
            btnShowMonsters.Click += new RoutedEventHandler(btnShowMonsters_Click);
        }

        /// <summary>
        /// Hides btnShowMonsters and shows all possible monsters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowMonsters_Click(object sender, EventArgs e) {
            stkMonsters.Children[0].Visibility = System.Windows.Visibility.Collapsed;
            TextBlock tbLabel = new TextBlock();
            tbLabel.Text = "Monsters:";
            stkMonsters.Children.Add(tbLabel);
            for (int i = 0; i < map.PossibleMonsters.Count; i++) {
                TextBlock tbMonster = new TextBlock();
                stkMonsters.Children.Add(tbMonster);
                tbMonster.Text = map.PossibleMonsters[i].Name;
                tbMonster.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        #endregion

        //Still needs work. Buttons are all created on top of each other.
        #region Map
        /// <summary>
        /// Shows random potions and their values
        /// </summary>
        private void TestMap() {
            Button btnTestMap = new Button();
            btnTestMap.Content = "Fill Grid with Items";            
            stkMapButton.Children.Add(btnTestMap);
            btnTestMap.Click += new RoutedEventHandler(btnTestMap_Clicked);            
        }

        /// <summary>
        /// Fills each grdMap with a button that represents a potion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestMap_Clicked(object sender, EventArgs e) {
            for (int row = 0; row < map.GetLength(0); row++) {
                grdMap.RowDefinitions.Add(new RowDefinition());
                for (int col = 0; col < map.GetLength(1); col++) {
                    grdMap.ColumnDefinitions.Add(new ColumnDefinition());
                    Button btnMapCell = new Button();
                    btnMapCell.Content = 
                        map.GameBoard[row, col].EquippedItem.Name.ToString() + " (" +
                        map.GameBoard[row, col].EquippedItem.Value.ToString() + ")";
                    //btnMapCell.Background = new SolidColorBrush(map.GameBoard[row, col].EquippedItem.);
                    grdMap.Children.Add(btnMapCell);                                       
                    
                }
            }
        }
        #endregion

        //Weapon doesn't change when selected yet, but everything else works
        #region Hero
        /// <summary>
        /// Shows hero's fields through map class
        /// </summary>
        private void TestHero() {
            Hero harry = new Hero(500, "Harry Potter", "The Boy Who Lived", 1000);
            map.HasHero = harry;
            TextBlock tbHero = new TextBlock();
            tbHero.Text =
                "Name: " + map.HasHero.NameWithTitle() + "\r\n" +
                "Has a Weapon: " + map.HasHero.WeaponOutput() + "\r\n" +
                "HP: " + map.HasHero.HP + "/" + map.HasHero.MaxHP + "\r\n" +
                "Attack Speed: " + map.HasHero.AttackSpeed;
            stkHero.Children.Add(tbHero);
        }
        #endregion

        //Hero's weapon doesn't change when selected yet
        #region Weapons
        /// <summary>
        /// Creates a button that shows all avaliable weapons
        /// </summary>
        private void TestWeapons() {
            Button btnShowWeapons = new Button();
            btnShowWeapons.Content = "Show Weapons";
            stkWeapon.Children.Add(btnShowWeapons);
            btnShowWeapons.Click += new RoutedEventHandler(btnShowWeapons_Click);
        }

        /// <summary>
        /// Shows all available weapons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowWeapons_Click(object sender, EventArgs e) {
            stkWeapon.Children[0].Visibility = System.Windows.Visibility.Collapsed;
            for (int i = 0; i < map.AvailableWeapons.Count; i++) {
                Button btnWeapon = new Button();
                stkWeapon.Children.Add(btnWeapon);
                btnWeapon.Content = map.AvailableWeapons[i].Name;
                //btnWeapon.Click += new RoutedEventHandler(btnWeapon_Click);
            }
        }

        /// <summary>
        /// Changes hero's weapon to whatever is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnWeapon_Click(object sender, EventArgs e) {
        //    map.HasHero.EquippedWeapon = map.AvailableWeapons[0];
        //}
        #endregion
    }
}
