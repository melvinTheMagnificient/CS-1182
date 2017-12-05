//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: hero is an actor with a weapon
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class Hero : Actor {
        #region Fields
        /// <summary>
        /// private variables for hero object
        /// </summary>
        private Weapon _EquippedWeapon;
        #endregion

        #region Constructors
        /// <summary>
        /// constructs a hero
        /// </summary>
        /// <param name="maxHP">actor's max HP possible (int)</param>
        /// <param name="name">actor's name (string)</param>
        /// <param name="title">actor's title (string)</param>
        /// <param name="attackSpeed">actor's attack speed (int)</param>
        public Hero(int maxHP, string name, string title, int attackSpeed)
            : base(maxHP, name, title, attackSpeed) {
        }
        #endregion

        #region Properties
        /// <summary>
        /// returns true if actor has a weapon, false if otherwise
        /// </summary>
        public bool HasWeapon {
            get {
                if (EquippedWeapon == null) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        /// <summary>
        /// returns actor's attack speed - weapon's value if hero has weapon, returns base attack speed if otherwise
        /// </summary>
        public override int AttackSpeed {
            get {
                if (!HasWeapon) {
                    return base.AttackSpeed;
                }
                else {
                    int newAttackSpeed = base.AttackSpeed - EquippedWeapon.AttackSpeed;
                    return newAttackSpeed;
                }
            }
        }

        /// <summary>
        /// returns weapon actor has
        /// </summary>
        public Weapon EquippedWeapon {
            get {
                return _EquippedWeapon;
            }

            set {
                _EquippedWeapon = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns formatted actor name and title together
        /// </summary>
        /// <returns></returns>
        public override string NameWithTitle() {
            return (CapitalizeFirstLetter(Name) + " " + TitleFormat()).Trim();
        }

        /// <summary>
        /// Overriden move method from actor. Doesn't do anything yet.
        /// </summary>
        /// <param name="direction"></param>
        public override void Move(int direction) {
            base.Move(direction);
        }

        /// <summary>
        /// Returns name of weapon or "none" if hero doesn't have a weapon
        /// </summary>
        /// <returns>string</returns>
        public string WeaponOutput() {
            if(this.EquippedWeapon == null) {
                return "none";
            }
            else {
                return this.EquippedWeapon.Name;
            }
        }
        #endregion
    }
}
