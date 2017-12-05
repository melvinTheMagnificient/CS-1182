//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Item with a color
using System;

namespace BaseClasses {

    [Serializable]
    public class Potion : Item, IRepeatable<Potion> {

        #region Fields

        /// <summary>
        /// private fields for any potion object
        /// </summary>
        private PotionColor _PotionColor;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// constructs potion object
        /// </summary>
        /// <param name="color"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Potion(PotionColor color, string name, int value) : base(name, value) {
            _PotionColor = color;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// read and write potion color
        /// </summary>
        public PotionColor PotionsColor {
            get {
                return _PotionColor;
            }
            set {
                _PotionColor = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Creates a deep copy of a potion
        /// </summary>
        /// <returns>Potion</returns>
        public Potion CreateCopy() {
            Potion x = new Potion(this.PotionsColor, this.Name, this.AffectValue);
            return x;
        }

        /// <summary>
        /// Enum for possible potion colors
        /// </summary>
        public enum PotionColor {
            Gold,
            DarkOliveGreen,
            AntiqueWhite,
            RoyalBlue
        }

        #endregion Methods
    }
}