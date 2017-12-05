//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Base actor class. Hero and monster inherit from this.
using System;
using System.Linq;

namespace BaseClasses {

    [Serializable]
    public abstract class Actor {

        #region Fields

        /// <summary>
        /// private variables for any actor object
        /// </summary>
        private string _Name;

        private string _Title;
        private int _AttackSpeed;
        private int _XCoordinate;
        private int _YCoordinate;
        private int _MaxHP;
        private int _HP;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Overloaded constructor for an Actor
        /// </summary>
        /// <param name="HP">actor's current health points (int)</param>
        /// <param name="maxHP">maximum health points actor can have (int)</param>
        /// <param name="name">actor's first name (string)</param>
        /// <param name="title">actor's title (string)</param>
        /// <param name="XCoordinate">actor's starting x coordinate (int)</param>
        /// <param name="YCoordinate">actor's starting y coordinate (int)</param>
        /// <param name="attackSpeed">speed actor attacks at (int)</param>
        public Actor(int maxHP, string name, string title, int attackSpeed,
            int XCoordinate, int YCoordinate) {
            _Name = name;
            _Title = title;
            _AttackSpeed = attackSpeed;
            _MaxHP = maxHP;
            _HP = maxHP;
            _XCoordinate = XCoordinate;
            _YCoordinate = YCoordinate;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// gets actor's name and returns it with only the first letter capitalized
        /// </summary>
        public string Name {
            get {
                return CapitalizeFirstLetter(_Name);
            }
            set {
                _Name = value;
            }
        }

        /// <summary>
        /// reads and writes actor's title
        /// </summary>
        public string Title {
            get {
                return _Title;
            }
            set {
                _Title = value;
            }
        }

        /// <summary>
        /// reads and writes actor's attack speed
        /// </summary>
        virtual public int AttackSpeed {
            get {
                return _AttackSpeed;
            }
        }

        /// <summary>
        /// read only actor's starting x coordinate
        /// </summary>
        public int XCoordinate {
            get {
                return _XCoordinate;
            }
        }

        /// <summary>
        /// read only actor's starting y coordinate
        /// </summary>
        public int YCoordinate {
            get {
                return _YCoordinate;
            }
        }

        /// <summary>
        /// read only actor's max HP possible
        /// </summary>
        public int MaxHP {
            get {
                return _MaxHP;
            }
        }

        /// <summary>
        /// read only actor's current HP
        /// </summary>
        public int HP {
            get {
                return _HP;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Capitalizes the only first letter of a string and makes the the rest lower case.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>string</returns>
        virtual public string CapitalizeFirstLetter(string word) {
            if (word.Length > 0) {
                return (char.ToUpper(word[0]) + word.Substring(1, word.Length - 1)).ToString();
            }
            else {
                return "";
            }
        }

        /// <summary>
        /// Unimportant words of a title are lowercase, first letters of important words are uppercase.
        /// </summary>
        /// <returns>string</returns>
        virtual public string TitleFormat() {
            string formattedTitle = "";
            string[] indvWords = Title.Split().ToArray();
            for (int i = 0; i < indvWords.Length; i++) {
                indvWords[i] = indvWords[i].ToLower();
                if (!(indvWords[i] == "the" || indvWords[i] == "a" || indvWords[i] == "an"
                    || indvWords[i] == "of" || indvWords[i] == "as" || indvWords[i] == "in")) {
                    indvWords[i] = CapitalizeFirstLetter(indvWords[i]);
                }
                formattedTitle += indvWords[i] + " ";
            }
            return formattedTitle;
        }

        /// <summary>
        /// Creates full name with capitalized first name and formatted title.
        /// </summary>
        /// <returns>string</returns>
        /// <source>Created with help from Megan Urban</source>
        virtual public string NameWithTitle() {
            return (CapitalizeFirstLetter(Name) + " " + TitleFormat()).Trim();
        }

        /// <summary>
        /// Increases actor's current HP
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount) {
            _HP += amount;
            if (_HP > _MaxHP) {
                _HP = _MaxHP;
            }
        }

        /// <summary>
        /// Decreases actor's current HP
        /// </summary>
        /// <param name="amount"></param>
        public void Damage(int amount) {
            _HP -= amount;
            if (_HP < 0) {
                _HP = 0;
            }
        }

        /// <summary>
        /// Directions actor can move
        /// </summary>
        public enum Direction {
            Up,
            Down,
            Left,
            Right
        }

        /// <summary>
        /// Moves actor using Direction enums
        /// </summary>
        /// <param name="direction">(int)Actor.Direction.move(up/down/left/right)</param>
        virtual public void Move(Direction direction) {
            if (direction == Direction.Up) {
                _XCoordinate -= 1;
            }
            else if (direction == Direction.Down) {
                _XCoordinate += 1;
            }
            else if (direction == Direction.Left) {
                _YCoordinate -= 1;
            }
            else if (direction == Direction.Right) {
                _YCoordinate += 1;
            }
        }

        #endregion Methods
    }
}