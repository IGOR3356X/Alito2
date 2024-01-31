using System;
using System.Collections.Generic;

namespace Alito.Classes.Entities
{

    [Serializable]
    internal class DBJSON
    {
        public DBJSON()
        {
            Exams = new AllExams();
            Users = new List<ClassUser>();
        }
        public DBJSON(AllExams exams, List<ClassUser> users)
        {
            Exams = exams;
            Users = users;
        }

        public AllExams Exams;
        public List<ClassUser> Users;
    }
}
