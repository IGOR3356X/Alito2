namespace Alito.Classes.Entities.User
{
    internal class SelectedTest
    {
        public SelectedTest(int id, int subjectId, bool isOge)
        {
            Id = id;
            SubjectId = subjectId;
            isOGE= isOge;
        }
        public int Id { get; set; }
        public int SubjectId;
        public bool isOGE;
    }
}
