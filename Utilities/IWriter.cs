namespace SimpleInventoryManagementSystem.Utilities
{
    public interface IWriter
    {
        void Write(string text);
    }
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}

