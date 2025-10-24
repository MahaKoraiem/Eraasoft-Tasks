namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new TestRepository();
            var mediator = new ExamMediator(repository);
            var ui = new ExamUi(mediator);
            ui.Run();
        }
    }
}
