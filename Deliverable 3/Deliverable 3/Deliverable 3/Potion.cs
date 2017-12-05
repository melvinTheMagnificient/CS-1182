//Deliverable 3
//Melissa Coblentz
//Prof Holmes
//16 February 2017
//Description: Item with a color
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Deliverable_4 {
    class Potion : Item, IRepeatable {
        #region Fields
        /// <summary>
        /// private fields for any potion object
        /// </summary>
        private Color _PotionColor;
        #endregion

        #region Constructor
        public Potion(Color color, string name, int value) : base(name, value) {
            _PotionColor = color;
        }
        #endregion

        #region Properties
        public Color PotionColor {
            get {
                return _PotionColor;
            }
            set {
                _PotionColor = value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a deep copy of a potion
        /// </summary>
        /// <returns></returns>
        public object CreateCopy() {
            object x = new Potion(this.PotionColor, this.Name, this.Value);
            return x;
        }
        #endregion
    }
}
