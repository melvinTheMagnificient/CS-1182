//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: Monster class inherits from Actor class and adds attack value
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class Monster : Actor, IRepeatable<Monster> {
        #region Fields
        /// <summary>
        /// private variables for any monster object
        /// </summary>
        private int _AttackValue;
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
        public Monster(int attackValue, int maxHP, string name, string title, int attackSpeed)
            : base(maxHP, name, title, attackSpeed) {
            _AttackValue = attackValue;
        }
        #endregion

        #region Properties
        /// <summary>
        /// read and write attack value of monster
        /// </summary>
        public int AttackValue {
            get {
                return _AttackValue;
            }
            set {
                _AttackValue = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates deep copy of monster
        /// </summary>
        /// <returns>Monster</returns>
        public Monster CreateCopy() {
            Monster x = new Monster(this.AttackValue, this.MaxHP, this.Name, this.Title, this.AttackSpeed);
            return x;
        }
        #endregion
    }
}
