﻿//Deliverable 5
//Melissa Coblentz
//Prof Holmes
//16 March 2017
//Description: Fills map array with map cells
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseClasses {
    public class Map {
        #region Fields
        /// <summary>
        /// private variables for map object
        /// </summary>
        private MapCell[,] _GameBoard = null;
        private List<Potion> _AvailablePotions = new List<Potion>();
        private List<Weapon> _AvailableWeapons = new List<Weapon>();
        private List<Monster> _PossibleMonsters = new List<Monster>();
        private Hero _Hero;
        #endregion

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
        #endregion

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
        /// read only AvailablePotions property
        /// </summary>
        public List<Potion> AvailablePotions {
            get {
                return _AvailablePotions;
            }
        }

        /// <summary>
        /// read only AvailableWeapons property
        /// </summary>
        public List<Weapon> AvailableWeapons {
            get {
                return _AvailableWeapons;
            }
        }

        /// <summary>
        /// read only PossibleMonsters property
        /// </summary>
        public List<Monster> PossibleMonsters {
            get {
                return _PossibleMonsters;
            }
        }

        /// <summary>
        /// read only HasHero property
        /// </summary>
        public Hero HasHero {
            get {
                return _Hero;
            }
            set {
                _Hero = value;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// fills list of Possible Monsters with possible monsters
        /// </summary>
        private void FillMonsters() {
            PossibleMonsters.Add(new Monster(50, 100, "Dementor", "", 25, 0, 0));
            PossibleMonsters.Add(new Monster(15, 20, "Basilisk", "", 15, 0, 0));
            PossibleMonsters.Add(new Monster(10, 10, "Spider", "", 35, 0, 0));
            PossibleMonsters.Add(new Monster(40, 40, "Death Eater", "", 10, 0, 0));
        }

        /// <summary>
        /// fills list of available potions with available potions
        /// </summary>
        private void FillPotions() {
            AvailablePotions.Add(new Potion(Potion.PotionColor.Gold, "Felix Felicis", 50));
            AvailablePotions.Add(new Potion(Potion.PotionColor.DarkOliveGreen, "Polyjuice Potion", 35));
            AvailablePotions.Add(new Potion(Potion.PotionColor.AntiqueWhite, "Skele-Grow", 20));
            AvailablePotions.Add(new Potion(Potion.PotionColor.RoyalBlue, "Veritaserum", 15));
        }

        /// <summary>
        /// fills list of available weapons with available weapons
        /// </summary>
        private void FillWeapons() {
            AvailableWeapons.Add(new Weapon("Wand", 100, 100));
            AvailableWeapons.Add(new Weapon("Elder Wand", 200, 75));
            AvailableWeapons.Add(new Weapon("Godric Gryffindor's Sword", 75, 150));
            AvailableWeapons.Add(new Weapon("Hagrid's Crossbow", 20, 150));
        }

        /// <summary>
        /// fills map with random potions from available potions list
        /// </summary>
        private void FillMap() {
            Random rnd = new Random();
            for (int row = 0; row < GameBoard.GetLength(0); row++) {
                for (int col = 0; col < GameBoard.GetLength(1); col++) {
                    GameBoard[row, col] = new MapCell();
                }
            }

            for (int i = 0; i < GameBoard.Length / 3; i++) {
                int row = rnd.Next(0, GameBoard.GetLength(0));
                int col = rnd.Next(0, GameBoard.GetLength(1));
                if (GameBoard[row, col].HasItem == false) {
                    GameBoard[row, col].EquippedItem =
                        AvailablePotions[rnd.Next(0, AvailablePotions.Count)].CreateCopy();
                }
            }
        }

        /// <summary>
        /// Returns MapCell with Hero in it
        /// </summary>
        /// <returns></returns>
        private MapCell HeroLocation() {
            try {
                int row = HasHero.StartingXCoordinate;
                int col = HasHero.StartingXCoordinate;
                return GameBoard[row, col];
            }
            catch {
                return new MapCell();
            }
        }
        #endregion
    }
}
