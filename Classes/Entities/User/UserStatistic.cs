using System;

namespace Alito.Classes.Entities
{
    [Serializable]
    internal class UserStatistic
    {
        public UserStatistic()
        {
            OGE = new StatExam();
            EGE = new StatExam();
        }

        public StatExam OGE;
        public StatExam EGE;
    }
}
