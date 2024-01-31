using System;

namespace Alito.Classes.Entities
{
    [Serializable]
    internal class Pet
    {
        public Pet(string name)
        {
            Name = name;
            MaxHappy = 100;
            Happy = 50;
            Level = 1;
            NeedHappyToLVL = 20;
        }
        public string Name;
        public int MaxHappy;
        public int Happy;
        public int Level;
        public int NeedHappyToLVL;
    }
}
