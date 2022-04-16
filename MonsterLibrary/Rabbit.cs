using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary; //Added for access to the Monster class

namespace MonsterLibrary
{
    public class Rabbit : Monster
    {
        //Created this class as a CHILD class of Monster
        //It will extend the info in Monster with its own unique properties.

        public bool IsFluffy { get; set; }

        public Rabbit(string name, int life, int maxLife, int hitChance, int block, int maxDamage, string description, int minDamage, bool isFluffy) : base(name, life, maxLife, hitChance, block, maxDamage, description, minDamage)
        {
            IsFluffy = isFluffy;

        }

        //This is a CTOR that creates a Rabbit object with default values.
        public Rabbit()
        {
            MaxLife = 6;
            MaxDamage = 3;
            //The above 2 are set first because other properties depend on them for their business rules.
            Name = "Baby Rabbit";
            Life = 6;
            HitChance = 20;
            Block = 20;
            MinDamage = 1;
            Description = "It's just a cute baby bunny...why would you hurt it?";
            IsFluffy = false;
        }

        //METHODS

        public override string ToString()
        {
            return base.ToString() + (IsFluffy ? "Fluffiness: Fluffy" : "Fluffiness: Not Fluffy");
        }

        //We will override CalcBlock() to give a 50% increase if fluffy
        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsFluffy)
            {
                calculatedBlock += calculatedBlock / 2;

            }

            return calculatedBlock;

        }
    }
}
