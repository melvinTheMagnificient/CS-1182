//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: hero is an actor with a weapon
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class Hero : Actor {
        #region Fields
        /// <summary>
        /// private variables for hero object
        /// </summary>
        private Weapon _EquippedWeapon;
        private bool _IsRunningAway = false;
        private bool _DoorKeyFound = false;
        private DoorKey _doorKey;
        #endregion

        #region Constructors
        /// <summary>
        /// constructs a hero
        /// </summary>
        /// <param name="maxHP">actor's max HP possible (int)</param>
        /// <param name="name">actor's name (string)</param>
        /// <param name="title">actor's title (string)</param>
        /// <param name="attackSpeed">actor's attack speed (int)</param>
        public Hero(int maxHP, string name, string title, int attackSpeed, int startingXCoordinate,
            int startingYCoordinate) : base(maxHP, name, title, attackSpeed, startingXCoordinate,
            startingXCoordinate) {
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
                    return 1;
                }
                else {
                    int newAttackSpeed = EquippedWeapon.AttackSpeed;
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

        /// <summary>
        /// Returns true if hero is running away. False if otherwise.
        /// </summary>
        public bool IsRunningAway {
            get {
                return _IsRunningAway;
            }

            set {
                _IsRunningAway = value;
            }
        }

        /// <summary>
        /// Returns true if doorkey exists
        /// </summary>
        public bool DoorKeyFound {
            get {
                return DoorKey == null ? false : true;
            }
        }

        /// <summary>
        /// Returns doorkey the hero has
        /// </summary>
        public DoorKey DoorKey {
            get {
                return _doorKey;
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
            if (this.EquippedWeapon == null) {
                return "none";
            }
            else {
                return this.EquippedWeapon.Name;
            }
        }
        #endregion
    }
}
