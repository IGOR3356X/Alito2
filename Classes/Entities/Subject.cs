using Alito.Classes.Entities.Subject;
using System;
using System.Collections.Generic;

namespace Alito.Classes.Entities
{

    [Serializable]
    internal class DBSubject
    {
        public DBSubject(int id, string name)
        {
            ID = id;
            Name = name;
            Tasks = new List<Task>();
        }

        public int ID;
        public string Name;
        public List<Task> Tasks;
    }
}
