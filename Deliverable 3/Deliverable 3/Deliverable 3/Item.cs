//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Abstract class of items. Inherited class is potion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deliverable_4 {
    abstract class Item {
        #region Fields
        /// <summary>
        /// private fields for any item object
        /// </summary>
        private string _Name;
        private int _Value;
        #endregion

        #region Constructor
        public Item(string name, int value) {
            _Name = name;
            _Value = value;
        }
        #endregion

        #region Properties
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        public int Value {
            get {
                return _Value;
            }
            set {
                _Value = value;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// all possible items
        /// </summary>
        public enum ItemNames {
            sword,
            healingPotion,
            axe,
            extremeHealingPotion
        }
        #endregion
    }
}
