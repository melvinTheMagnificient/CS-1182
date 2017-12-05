///Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: map cell can have a monster or a potion. Can be discovered by actor or not discovered.
using System;

namespace BaseClasses {

    [Serializable]
    public class MapCell {

        #region Fields

        /// <summary>
        /// private variables for any map cell object
        /// </summary>
        private bool _HasBeenDiscovered = false;

        private Monster _MonsterIsHere;
        private Item _EquippedItem;

        #endregion Fields

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
        public Monster Monster {
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
        public Item Item {
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
                if (Monster == null) {
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
                if (Item == null) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }

        #endregion Properties
    }
}