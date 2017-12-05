//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Class for actor with a weapon
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class Hero : Actor {
        #region Fields
        private bool _HasWeapon = false;
        #endregion

        #region Constructors
        public Hero(int HP, int maxHP, string name, string title, int startingXCoordinate, int startingYCoordinate, int attackSpeed)
            : base(HP, maxHP, name, title, startingXCoordinate, startingYCoordinate, attackSpeed) {
        }
        #endregion

        #region Properties
        public bool HasWeapon {
            get {
                return _HasWeapon;
            }
            set {
                _HasWeapon = value;
            }
        }

        public override int AttackSpeed {
            get {
                if (HasWeapon) {
                    return base.AttackSpeed / 2;
                }
                else {
                    return base.AttackSpeed;
                }
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
        #endregion
    }
}
