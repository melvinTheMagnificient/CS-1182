﻿//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: base class item. Potion and weapon inherit from this class
using System;

namespace BaseClasses {

    [Serializable]
    public abstract class Item {

        #region Fields

        /// <summary>
        /// private fields for any item object
        /// </summary>
        private string _Name;

        private int _AffectValue;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// constructs an item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Item(string name, int value) {
            _Name = name;
            _AffectValue = value;
        }

        #endregion Constructor

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
        public int AffectValue {
            get {
                return _AffectValue;
            }
            set {
                _AffectValue = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// all possible items
        /// </summary>
        public enum ItemNames {
            sword,
            healingPotion,
            axe,
            extremeHealingPotion
        }

        #endregion Methods
    }
}