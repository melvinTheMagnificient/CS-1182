//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Class to keep track of what's in a map cell and if it's been discovered
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    class MapCell {
        #region Fields
        /// <summary>
        /// private variables for any map cell object
        /// </summary>
        bool _HasBeenDiscovered;
        bool _HasMonster;
        bool _HasItem;
        #endregion

        #region Properties
        public bool HasBeenDiscovered {
            get {
                return _HasBeenDiscovered;
            }
            set {
                _HasBeenDiscovered = value;
            }
        }

        public bool HasMonster {
            get {
                return _HasMonster;
            }
            set {
                if (!HasItem) {
                    _HasMonster = value;
                }
            }
        }

        public bool HasItem {
            get {
                return _HasItem;
            }
            set {
                if (!HasMonster) {
                    _HasItem = value;
                }
            }
        }
        #endregion
    }
}
