using Alito.Classes.Entities.Tasks;
using System;
using System.Collections.Generic;

namespace Alito.Classes.Entities
{
    [Serializable]
    internal class StatSubject
    {
        public StatSubject(int id)
        {
            SubjectID = id;
            CompleteTasks = new List<CompleteTask>();
        }
        public int SubjectID;
        public List<CompleteTask> CompleteTasks;
    }
}
