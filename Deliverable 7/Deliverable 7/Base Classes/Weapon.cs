//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: weapon is an item that effects an actor's attack speed
using System;

namespace BaseClasses {

    [Serializable]
    public class Weapon : Item, IRepeatable<Weapon> {

        #region Fields

        /// <summary>
        /// private variable for weapon objects
        /// </summary>
        private int _SpeedModifier;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// constructs a weapon
        /// </summary>
        /// <param name="name">weapon's name (string)</param>
        /// <param name="value">weapon's effect on monster's health (int)</param>
        /// <param name="attackSpeed">weapon's effect on actor's attackSpeed (int)</param>
        public Weapon(string name, int value, int attackSpeed) : base(name, value) {
            _SpeedModifier = attackSpeed;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// read only weapon's attack speed
        /// </summary>
        public int SpeedModifier {
            get {
                return _SpeedModifier;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a deep copy of a weapon
        /// </summary>
        /// <returns>Weapon</returns>
        public Weapon CreateCopy() {
            Weapon x = new Weapon(this.Name, this.AffectValue, this.SpeedModifier);
            return x;
        }

        #endregion Methods
    }
}