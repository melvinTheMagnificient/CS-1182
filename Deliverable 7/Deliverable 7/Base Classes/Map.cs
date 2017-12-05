//Deliverable 7
//Melissa Coblentz
//Prof Holmes
//20 April 2017
//Description: Fills map array with map cells
using System;
using System.Collections.Generic;

namespace BaseClasses {

    [Serializable]
    public class Map {

        #region Fields

        /// <summary>
        /// private variables for map object
        /// </summary>
        private MapCell[,] _GameBoard = null;

        private List<Item> _AvailableItems = new List<Item>();
        private List<Monster> _PossibleMonsters = new List<Monster>();
        private Hero _Hero;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Sets size of GameBoard array
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public Map(int col, int row) {
            _GameBoard = new MapCell[row, col];
            FillMonsters();
            FillPotions();
            FillWeapons();
            FillMap();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// read only GameBoard property
        /// </summary>
        public MapCell[,] GameBoard {
            get {
                return _GameBoard;
            }
        }

        /// <summary>
        /// read only PossibleMonsters property
        /// </summary>
        private List<Monster> PossibleMonsters {
            get {
                return _PossibleMonsters;
            }
        }

        /// <summary>
        /// read only hero in current game
        /// </summary>
        public Hero CurrentHero {
            get {
                return _Hero;
            }
            set {
                _Hero = value;
            }
        }

        /// <summary>
        /// Collection of potions and weapons
        /// </summary>
        private List<Item> AvailableItems {
            get {
                return _AvailableItems;
            }

            set {
                if (value.GetType() == typeof(Weapon) || value.GetType() == typeof(Potion)) {
                    _AvailableItems = value;
                }
            }
        }

        /// <summary>
        /// Returns MapCell hero is currently in
        /// </summary>
        public MapCell HerosMapCell {
            get {
                return HeroLocation;
            }
        }

        /// <summary>
        /// Returns number of monsters in current game
        /// </summary>
        public int MonsterCount {
            get {
                int count = 0;
                foreach (MapCell m in GameBoard) {
                    if (m.HasMonster) {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Returns number of items in current game
        /// </summary>
        public int ItemCount {
            get {
                int count = 0;
                foreach (MapCell m in GameBoard) {
                    if (m.HasItem) {
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Returns ratio of gameboard that has been discovered by hero in current game
        /// </summary>
        public decimal MapDiscovered {
            get {
                decimal dcount = 0;
                decimal tcount = 0;
                foreach (MapCell m in GameBoard) {
                    if (m.HasBeenDiscovered) {
                        dcount++;
                    }
                    tcount++;
                }
                return dcount / tcount;
            }
        }

        /// <summary>
        /// Returns MapCell with Hero in it
        /// </summary>
        public MapCell HeroLocation {
            get {
                try {
                    int row = CurrentHero.XCoordinate;
                    int col = CurrentHero.YCoordinate;
                    return GameBoard[row, col];
                }
                catch {
                    return new MapCell();
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// fills list of Possible Monsters with possible monsters
        /// </summary>
        private void FillMonsters() {
            PossibleMonsters.Add(new Monster(2, 10, "Mr. Goldenfold", "", 5, 0, 0));
            PossibleMonsters.Add(new Monster(6, 30, "Evil Rick", "", 15, 0, 0));
            PossibleMonsters.Add(new Monster(3, 15, "a Zigerion", "", 10, 0, 0));
            PossibleMonsters.Add(new Monster(4, 25, "Fart", "", 14, 0, 0));
        }

        /// <summary>
        /// fills list of available potions with available potions
        /// </summary>
        private void FillPotions() {
            AvailableItems.Add(new Potion(Potion.PotionColor.RoyalBlue, "a Plumbus", 20));
            AvailableItems.Add(new Potion(Potion.PotionColor.DarkOliveGreen, "a Love Potion", 10));
            AvailableItems.Add(new Potion(Potion.PotionColor.AntiqueWhite, "Mr. Meeseeks", 5));
            AvailableItems.Add(new Potion(Potion.PotionColor.RoyalBlue, "Eyeholes", 10));
        }

        /// <summary>
        /// fills list of available weapons with available weapons
        /// </summary>
        private void FillWeapons() {
            AvailableItems.Add(new Weapon("a Freeze Ray", 5, 5));
            AvailableItems.Add(new Weapon("a Laser Gun", 10, 10));
            AvailableItems.Add(new Weapon("a Neutrino Bomb", 20, 20));
            AvailableItems.Add(new Weapon("Chris", 9, 9));
        }

        /// <summary>
        /// fills map with random items and monsters
        /// </summary>
        private void FillMap() {
            Random rnd = new Random();
            for (int row = 0; row < GameBoard.GetLength(0); row++) {
                for (int col = 0; col < GameBoard.GetLength(1); col++) {
                    GameBoard[row, col] = new MapCell();
                }
            }

            bool doorKeyPlaced = false;
            bool doorPlaced = false;

            for (int i = 0; i < GameBoard.Length / 3; i++) {
                int row = rnd.Next(0, GameBoard.GetLength(0));
                int col = rnd.Next(0, GameBoard.GetLength(1));
                if (GameBoard[row, col].HasItem == false && GameBoard[row, col].HasMonster == false) {
                    if (doorKeyPlaced == false) {
                        GameBoard[row, col].Item = new DoorKey("Door Key", 1, "dk");
                        doorKeyPlaced = true;
                    }
                    else if (doorPlaced == false) {
                        GameBoard[row, col].Item = new Door("Door", 1, "dk");
                        doorPlaced = true;
                    }
                    else if (row % 2 == 0) {
                        Item a = AvailableItems[rnd.Next(0, AvailableItems.Count)];
                        if (a.GetType() == typeof(Potion)) {
                            GameBoard[row, col].Item =
                            ((Potion)a).CreateCopy();
                        }
                        else if (a.GetType() == typeof(Weapon)) {
                            GameBoard[row, col].Item =
                           ((Weapon)a).CreateCopy();
                        }
                    }
                    else if (row % 2 == 1) {
                        GameBoard[row, col].Monster =
                        PossibleMonsters[rnd.Next(0, PossibleMonsters.Count)].CreateCopy();
                    }
                }
            }
        }

        /// <summary>
        /// Move hero on gameboard and mark new cell as discovered
        /// </summary>
        /// <param name="direction"></param>
        public bool MoveHero(Hero.Direction direction) {
            if (direction == Hero.Direction.Up) {
                if (_Hero.XCoordinate - 1 >= 0) {
                    _Hero.Move(direction);
                    GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasBeenDiscovered = true;
                    if (GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasItem ||
                        GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasMonster) {
                        return true;
                    }
                }
            }
            else if (direction == Hero.Direction.Right) {
                if (_Hero.YCoordinate + 1 <= GameBoard.GetLength(1) - 1) {
                    _Hero.Move(direction);
                    GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasBeenDiscovered = true;
                    if (GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasItem ||
                        GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasMonster) {
                        return true;
                    }
                }
            }
            else if (direction == Hero.Direction.Down) {
                if (_Hero.XCoordinate + 1 <= GameBoard.GetLength(0) - 1) {
                    _Hero.Move(direction);
                    GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasBeenDiscovered = true;
                    if (GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasItem ||
                        GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasMonster) {
                        return true;
                    }
                }
            }
            else if (direction == Hero.Direction.Left) {
                if (_Hero.YCoordinate - 1 >= 0) {
                    _Hero.Move(direction);
                    GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasBeenDiscovered = true;
                    if (GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasItem ||
                        GameBoard[_Hero.XCoordinate, _Hero.YCoordinate].HasMonster) {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion Methods
    }
}