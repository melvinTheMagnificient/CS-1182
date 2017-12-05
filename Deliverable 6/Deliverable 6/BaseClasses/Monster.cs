//Deliverable 6
//Melissa Coblentz
//Prof Holmes
//6 April 2017
//Description: Monster class inherits from Actor class and adds attack value
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class Monster : Actor, IRepeatable<Monster> {
        #region Fields
        /// <summary>
        /// private variables for any monster object
        /// </summary>
        private int _AttackDamage;
        #endregion

        #region Constructors
        /// <summary>
        /// constructs Monster object
        /// </summary>
        /// <param name="attackValue">attack value of monster (int)</param>
        /// <param name="maxHP">maximum HP possible for monster (int)</param>
        /// <param name="name">monster's name (string)</param>
        /// <param name="title">monster's title (string)</param>
        /// <param name="attackSpeed">monster's attack speed (int)</param>
        public Monster(int attackValue, int maxHP, string name, string title, int attackSpeed,
            int XCoordinate, int YCoordinate)
            : base(maxHP, name, title, attackSpeed, XCoordinate, YCoordinate) {
            _AttackDamage = attackValue;
        }
        #endregion

        #region Properties
        /// <summary>
        /// read and write attack value of monster
        /// </summary>
        public int AttackDamage {
            get {
                return _AttackDamage;
            }
            set {
                _AttackDamage = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates deep copy of monster
        /// </summary>
        /// <returns>Monster</returns>
        public Monster CreateCopy() {
            Monster x = new Monster(this.AttackDamage, this.MaxHP, this.Name, this.Title,
                this.AttackSpeed, this.XCoordinate, this.YCoordinate);
            return x;
        }
        #endregion
    }
}
