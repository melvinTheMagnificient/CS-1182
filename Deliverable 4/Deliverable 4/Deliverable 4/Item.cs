//Deliverable 4
//Melissa Coblentz
//Prof Holmes
//2 March 2017
//Description: base class item. Potion and weapon inherit from this class
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
        /// <summary>
        /// constructs an item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Item(string name, int value) {
            _Name = name;
            _Value = value;
        }
        #endregion

        #region Properties
        /// <summary>
        /// read and write item's name
        /// </summary>
        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
            }
        }

        /// <summary>
        /// read and write item's affect on health
        /// </summary>
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
