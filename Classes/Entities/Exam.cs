using System;
using System.Collections.Generic;

namespace Alito.Classes.Entities
{

    [Serializable]
    internal class Exam
    {
        public Exam()
        {
            Subjects = new List<DBSubject>();
        }

        public List<DBSubject> Subjects;
    }
}
