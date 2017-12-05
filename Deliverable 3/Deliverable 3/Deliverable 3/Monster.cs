//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Class for actor with attack value
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class Monster : Actor, IRepeatable {
        #region Fields
        /// <summary>
        /// private variables for any monster object
        /// </summary>
        private int _AttackValue;
        #endregion

        #region Constructors
        public Monster(int attackValue, int HP, int maxHP, string name, string title, int startingXCoordinate, int startingYCoordinate, int attackSpeed)
            : base(HP, maxHP, name, title, startingXCoordinate, startingYCoordinate, attackSpeed) {
            _AttackValue = attackValue;
        }
        #endregion

        #region Properties
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
        /// <returns></returns>
        public object CreateCopy() {
            object x = new Monster(this.AttackValue, this.HP, this.MaxHP, this.Name, this.Title, this.StartingXCoordinate, this.StartingYCoordinate, this.AttackSpeed);
            return x;
        }
        #endregion
    }
}
