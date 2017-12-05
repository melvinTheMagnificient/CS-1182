//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: map cell can have a monster or a potion. Can be discovered by actor or not discovered.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class MapCell {
        #region Fields
        /// <summary>
        /// private variables for any map cell object
        /// </summary>
        private bool _HasBeenDiscovered;
        private Monster _MonsterIsHere;
        private Item _EquippedItem;
        #endregion

        #region Properties
        /// <summary>
        /// returns true if map cell has been discovered by actor, false if otherwise
        /// </summary>
        public bool HasBeenDiscovered {
            get {
                return _HasBeenDiscovered;
            }
            set {
                _HasBeenDiscovered = value;
            }
        }

        /// <summary>
        /// reads and writes monster in mapcell
        /// </summary>
        internal Monster MonsterIsHere {
            get {
                return _MonsterIsHere;
            }

            set {
                _MonsterIsHere = value;
            }
        }

        /// <summary>
        /// reads and writes item in mapcell
        /// </summary>
        internal Item EquippedItem {
            get {
                return _EquippedItem;
            }

            set {
                _EquippedItem = value;
            }
        }

        /// <summary>
        /// returns true if monster is in mapcell, false if otherwise
        /// </summary>
        public bool HasMonster {
            get {
                if (MonsterIsHere == null) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        /// <summary>
        /// returns true if item is in mapcell, false if otherwise
        /// </summary>
        public bool HasItem {
            get {
                if (EquippedItem == null) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        #endregion
    }
}
