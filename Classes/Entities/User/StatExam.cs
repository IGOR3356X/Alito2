using System;
using System.Collections.Generic;

namespace Alito.Classes.Entities
{
    [Serializable]
    internal class StatExam
    {
        public StatExam()
        {
            Subjects = new List<StatSubject>();
        }

        public List<StatSubject> Subjects;
    }
}
