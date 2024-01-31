using Alito.Classes.Entities.User;
using System;

namespace Alito.Classes.Entities
{
    [Serializable]
    internal class ClassUser
    {
        public ClassUser(long id, string name, string petName)
        {
            chatID = id;
            nickname = name;
            Money = 0;
            Statistic = new UserStatistic();
            Pet = new Pet(petName);
        }
        public Entities.User.SelectedTest _selectedTest;
        public long chatID;
        public string nickname;
        public int Money;
        public UserStatistic Statistic;
        public Pet Pet;
    }
}