using System;

namespace Alito.Classes.Entities
{

    [Serializable]
    internal class AllExams
    {
        public AllExams()
        {
            OGE = new Exam();
            EGE = new Exam();
        }

        public Exam OGE;
        public Exam EGE;
    }
}
