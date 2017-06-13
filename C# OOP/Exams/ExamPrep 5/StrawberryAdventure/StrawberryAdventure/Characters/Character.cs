using StrawberryAdventure.Contracts;
using System.Collections.Generic;
using System;
using StrawberryAdventure.Utils;

namespace StrawberryAdventure.Characters
{
    public abstract class Character : ICharacter
    {
        private string name;
        private int attack;
        private int defense;
        private int hitPoints;

        public Character(string name,int attack,int defense, int hitPoints)
        {
            this.Name = name;
            this.Attack = attack;
            this.Defense = defense;
            this.HitPoints = hitPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateString(value);
                this.name = value;
            }
        }

        public int Attack
        {
            get
            {
                return this.attack;
            }
            protected set
            {
                Validator.ValidateGameIntValue(value);
                this.attack = value;
            }
        }

        public int Defense
        {
            get
            {
               return this.defense;
            }
            protected set
            {
                Validator.ValidateGameIntValue(value);
                this.defense = value;
            }
        }

        public int HitPoints
        {
            get
            {
                return this.hitPoints;
            }
             set
            {
                Validator.ValidateGameIntValue(value);
                this.hitPoints = value;
            }
        }        
       
    }
}
