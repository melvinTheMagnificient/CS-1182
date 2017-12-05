//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: hero is an actor with a weapon
using System;

namespace BaseClasses {

    [Serializable]
    public class Hero : Actor {

        #region Fields

        /// <summary>
        /// private variables for hero object
        /// </summary>
        private Weapon _Weapon;

        private bool _IsRunningAway = false;
        private bool _DoorKeyFound = false;
        private DoorKey _doorKey;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// constructs a hero
        /// </summary>
        /// <param name="maxHP">actor's max HP possible (int)</param>
        /// <param name="name">actor's name (string)</param>
        /// <param name="title">actor's title (string)</param>
        /// <param name="attackSpeed">actor's attack speed (int)</param>
        public Hero(int maxHP, string name, string title, int attackSpeed, int XCoordinate,
            int YCoordinate) : base(maxHP, name, title, attackSpeed, XCoordinate,
            YCoordinate) {
            Weapon = null;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// returns true if actor has a weapon, false if otherwise
        /// </summary>
        public bool HasWeapon {
            get {
                return _Weapon != null;
            }
        }

        /// <summary>
        /// returns weapon actor has
        /// </summary>
        public Weapon Weapon {
            get {
                return _Weapon;
            }

            set {
                _Weapon = value;
            }
        }

        /// <summary>
        /// Speed at which Hero attacks. Affected by Hero's weapon.
        /// </summary>
        public override int AttackSpeed {
            get {
                if (!HasWeapon) {
                    return base.AttackSpeed;
                }
                return base.AttackSpeed + Weapon.SpeedModifier;
            }
        }

        /// <summary>
        /// returns actor's attack speed - weapon's value if hero has weapon, returns base attack speed if otherwise
        /// </summary>
        public int AttackDamage {
            get {
                if (_Weapon == null) {
                    return 1;
                }
                else {
                    return Weapon.AffectValue;
                }
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
        /// Returns true if hero is alive. False if otherwise.
        /// </summary>
        public bool HeroIsAlive {
            get {
                return this.HP > 0;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns formatted actor name and title together
        /// </summary>
        /// <returns></returns>
        public override string NameWithTitle() {
            return (CapitalizeFirstLetter(Name) + " " + TitleFormat()).Trim();
        }

        /// <summary>
        /// Overridden move method from actor. Doesn't do anything yet.
        /// </summary>
        /// <param name="direction"></param>
        public override void Move(Direction direction) {
            base.Move(direction);
        }

        /// <summary>
        /// Returns name of weapon or "none" if hero doesn't have a weapon
        /// </summary>
        /// <returns>string</returns>
        public string WeaponOutput() {
            if (this.Weapon == null) {
                return "none";
            }
            else {
                return this.Weapon.Name;
            }
        }

        /// <summary>
        /// Applies item's properties to hero
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Item GiveHeroItem(Item i) {
            if (i.GetType() == typeof(Potion)) {
                this.Heal(i.AffectValue);
                return null;
            }
            else if (i.GetType() == typeof(Weapon)) {
                Weapon oldWeapon;
                if (this.Weapon != null) {
                    oldWeapon = this.Weapon;
                }
                else {
                    oldWeapon = null;
                }
                this.Weapon = (Weapon)i;
                return oldWeapon;
            }
            else if (i.GetType() == typeof(DoorKey)) {
                DoorKey oldDoorKey;
                if (this.DoorKey != null) {
                    oldDoorKey = this.DoorKey;
                }
                else {
                    oldDoorKey = null;
                }
                _doorKey = new DoorKey("dk", 0, "dk");
                return oldDoorKey;
            }
            return i;
        }

        /// <summary>
        /// Changes hero and monster's HP based on their attack speeds and attack damages
        /// </summary>
        /// <param name="h"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool operator +(Hero h, Monster m) {
            if (!h.IsRunningAway) {
                if (h.AttackSpeed > m.AttackSpeed) {
                    m.Damage(h.AttackDamage);
                    if (m.HP != 0) {
                        h.Damage(m.AttackDamage);
                    }
                }
                else if (m.AttackSpeed > h.AttackSpeed) {
                    h.Damage(m.AttackDamage);
                    if (h.HP != 0) {
                        m.Damage(h.AttackDamage);
                    }
                }
                else if (m.AttackSpeed == h.AttackSpeed) {
                    m.Damage(h.AttackDamage);
                    h.Damage(m.AttackDamage);
                }
            }
            else {
                if (h.AttackSpeed < m.AttackSpeed) {
                    h.Damage(m.AttackDamage);
                }
            }
            if (h.HeroIsAlive) {
                h.IsRunningAway = false;
                return true;
            }
            h.IsRunningAway = false;
            return false;
        }

        #endregion Methods
    }
}