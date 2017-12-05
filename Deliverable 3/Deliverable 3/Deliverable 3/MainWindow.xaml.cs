//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Used to test classes on form
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

namespace Deliverable_3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        Hero a;
        Potion[] potions = new Potion[5];
        Monster[] monsters = new Monster[5];

        #region Hero
        /// <summary>
        /// Creates a new hero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateHero_Click(object sender, RoutedEventArgs e) {
            a = new Hero(200, 200, "Bob", "the Awesome", 20, 20, 2);
            PrintHero();
        }

        /// <summary>
        /// Shows hero properties in textblock
        /// </summary>
        private void PrintHero() {
            tbHero.Text =
                "Name: " + a.Name + "\r\n" +
                "Name with Title: " + a.NameWithTitle() + "\r\n" +
                "Has a weapon: " + WeaponOutput() + "\r\n" +
                "HP: " + a.HP + "/" + a.MaxHP + "\r\n" +
                "Attack Speed: " + a.AttackSpeed + "\r\n" +
                "X: " + a.StartingXCoordinate + "\r\n" +
                "Y: " + a.StartingYCoordinate + "\r\n";
        }

        /// <summary>
        /// Returns weapon output in format easier for user to understand
        /// </summary>
        /// <returns></returns>
        private string WeaponOutput() {
            if (a.HasWeapon) {
                return "Yes";
            }
            else {
                return "No";
            }
        }

        /// <summary>
        /// Changes hero's properties based on weapon status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWeapon_Click(object sender, RoutedEventArgs e) {
            if (a.HasWeapon == false) {
                a.HasWeapon = true;
                btnWeapon.Content = "Un-Equip Weapon";
            }
            else if (a.HasWeapon == true) {
                a.HasWeapon = false;
                btnWeapon.Content = "Equip Weapon";
            }
            PrintHero();
        }
        #endregion

        #region Potion
        /// <summary>
        /// Creates a new potion in global potions array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePotion_Click(object sender, RoutedEventArgs e) {
            Potion a = new Potion(Colors.Black, "Basic Potion", 20);
            for (int i = 0; i < potions.Length; i++) {
                if (potions[i] == null) {
                    potions[i] = (Potion)a.CreateCopy();
                    break;
                }
            }
            PrintPotion();
        }

        /// <summary>
        /// Prints potion properties from global potions array
        /// </summary>
        private void PrintPotion() {
            tbPotion.Text = "";
            for (int i = 0; i < potions.Length; i++) {
                if (potions[i] != null) {
                    tbPotion.Text +=
                    "Name: " + potions[i].Name + "\r\n" +
                    "Affect: " + potions[i].Value + "\r\n";
                }
            }
            if (potions[potions.Length - 1] != null) {
                MessageBox.Show("Sorry, you cannot create any more potions");
            }
        }

        /// <summary>
        /// Makes first potion of global potions array a new potion without changing others
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePotionOne_Click(object sender, RoutedEventArgs e) {
            //((Potion)potions[0]).Name = "Bob"; 
            potions[0].Name = "Gooey Potion";
            potions[0].Value = 100;
            potions[0].PotionColor = Colors.Blue;
            PrintPotion();
        }
        #endregion

        #region Monster
        /// <summary>
        /// Creates a new monster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateMonster_Click(object sender, RoutedEventArgs e) {
            Monster d = new Monster(15, 500, 500, "Cyclos", "of Doom", 50, 50, 3);
            for (int i = 0; i < potions.Length; i++) {
                if (monsters[i] == null) {
                    monsters[i] = (Monster)d.CreateCopy();
                    break;
                }
            }
            PrintMonster();
        }

        /// <summary>
        /// Prints monster properties
        /// </summary>
        /// <param name="d"></param>
        private void PrintMonster() {
            tbMonster.Text = "";
            for (int i = 0; i < monsters.Length; i++) {
                if (monsters[i] != null) {
                    tbMonster.Text =
                        "Name: " + monsters[i].Name + "\r\n" +
                        "Name with Title: " + monsters[i].NameWithTitle() + "\r\n" +
                        "Attack Value: " + monsters[i].AttackValue + "\r\n" +
                        "HP: " + monsters[i].HP + "/" + monsters[i].MaxHP + "\r\n" +
                        "Attack Speed: " + monsters[i].AttackSpeed + "\r\n" +
                        "X: " + monsters[i].StartingXCoordinate + "\r\n" +
                        "Y: " + monsters[i].StartingYCoordinate;
                }
            }
            if (monsters[monsters.Length - 1] != null) {
                MessageBox.Show("Sorry, you cannot create any more monsters");
            }
        }
        #endregion        
    }
}
