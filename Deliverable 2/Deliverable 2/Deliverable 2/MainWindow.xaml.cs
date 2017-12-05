//Deliverable 2
//Melissa Coblentz
//Prof Holmes
//9 February 2017
//Description: Test run for classes/objects created in Deliverable 1.
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

namespace Deliverable_2 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }
        #region Class Level Variables
        Actor a;
        Item i;
        MapCell m;
        #endregion

        #region Actor
        /// <summary>
        /// Constructs actor instantiated in MainWindow class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateActor_Click(object sender, RoutedEventArgs e) {
            //instantiate actor variables with values
            string actorName = txtActorName.Text;
            string actorTitle = txtActorTitle.Text;
            int maxHP = 0;
            int HP = 0;
            int attackSpeed = 0;
            int xPosition = 0;
            int yPosition = 0;

            int.TryParse(txtActorHP.Text, out maxHP);
            int.TryParse(txtActorHP.Text, out HP);
            int.TryParse(txtActorAttackSpeed.Text, out attackSpeed);
            int.TryParse(txtActorXPosition.Text, out xPosition);
            int.TryParse(txtActorYPostion.Text, out yPosition);

            //give class level object values and show in label
            a = new Actor(HP, maxHP, actorName, actorTitle, xPosition, yPosition, attackSpeed);
            PrintActorLabel();
        }

        /// <summary>
        /// Shows actor's properties in label
        /// </summary>
        private void PrintActorLabel() {
            lblActorValues.Content = " Name: " + a.Name + "\r\n Name with Title: " + a.NameWithTitle()
                + "\r\n HP: " + a.HP + "/" + a.MaxHP + "\r\n Attack Speed: " + a.AttackSpeed + "\r\n X Position: "
                + a.StartingXCoordinate + "\r\n Y Position: " + a.StartingYCoordinate;
        }

        #region Move Actor
        /// <summary>
        /// Subtracts 1 from actor's x position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveActorLeft_Click(object sender, RoutedEventArgs e) {
            int left = (int)Actor.Direction.moveLeft;
            a.Move(left);
            PrintActorLabel();
        }

        /// <summary>
        /// Subtracts 1 from actor's y position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveActorUp_Click(object sender, RoutedEventArgs e) {
            int up = (int)Actor.Direction.moveUp;
            a.Move(up);
            PrintActorLabel();
        }

        /// <summary>
        /// Adds 1 to actor's y position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveActorDown_Click(object sender, RoutedEventArgs e) {
            int down = (int)Actor.Direction.moveDown;
            a.Move(down);
            PrintActorLabel();
        }

        /// <summary>
        /// Adds 1 to actor's x position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveActorRight_Click(object sender, RoutedEventArgs e) {
            int right = (int)Actor.Direction.moveRight;
            a.Move(right);
            PrintActorLabel();
        }
        #endregion

        #region Actor HP
        /// <summary>
        /// Subtracts 10 from actor's current HP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDamageActor_Click(object sender, RoutedEventArgs e) {
            a.DecreaseHP(10);
            PrintActorLabel();
        }

        /// <summary>
        /// Adds 5 to actor's current HP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHealActor_Click(object sender, RoutedEventArgs e) {
            a.IncreaseHP(5);
            PrintActorLabel();
        }
        #endregion

        #endregion

        #region Item
        /// <summary>
        /// Constructs item instantiated in MainWindow class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateItem_Click(object sender, RoutedEventArgs e) {
            string name = txtItemName.Text.Trim().ToLower();
            int value = 0;

            int.TryParse(txtItemAffectValue.Text, out value);

            i = new Item(name, value);

            lblItemValues.Content = "Name: " + i.Name + "\r\nAffect: " + i.Value;
        }
        #endregion

        #region Map Cell
        /// <summary>
        /// Constructs map cell instantiated in MainWindow class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateCellMap_Click(object sender, RoutedEventArgs e) {
            //m = new MapCell(false, (bool)rbMapCellHasMonster.IsChecked, (bool)rbMapCellHasItems.IsChecked);
            PrintMapCellLabel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMarkCellDiscovered_Click(object sender, RoutedEventArgs e) {
            m.HasBeenDiscovered = true;
            PrintMapCellLabel();
        }

        /// <summary>
        /// Shows map cell's properties in a label
        /// </summary>
        private void PrintMapCellLabel() {
            lblMapCellValues.Content = "Is Discovered: " + m.HasBeenDiscovered + "\r\nHasMonster: " + m.HasMonster +
                "\r\nHas Item: " + m.HasItem;
        }
        #endregion
    }
}
