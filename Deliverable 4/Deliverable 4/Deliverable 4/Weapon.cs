//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: weapon is an item that effects an actor's attack speed
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class Weapon : Item, IRepeatable<Weapon> {
        #region Fields
        /// <summary>
        /// private variable for weapon objects
        /// </summary>
        private int _AttackSpeed;
        #endregion

        #region Constructor
        /// <summary>
        /// constructs a weapon
        /// </summary>
        /// <param name="name">weapon's name (string)</param>
        /// <param name="value">weapon's effect on monster's health (int)</param>
        /// <param name="attackSpeed">weapon's effect on actor's attackSpeed (int)</param>
        public Weapon(string name, int value, int attackSpeed) : base(name, value) {
            _AttackSpeed = attackSpeed;
        }
        #endregion

        #region Properties
        /// <summary>
        /// read only weapon's attack speed
        /// </summary>
        public int AttackSpeed {
            get {
                return _AttackSpeed;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a deep copy of a weapon
        /// </summary>
        /// <returns>Weapon</returns>
        public Weapon CreateCopy() {
            Weapon x = new Weapon(this.Name, this.Value, this.AttackSpeed);
            return x;
        }
        #endregion
    }
}
