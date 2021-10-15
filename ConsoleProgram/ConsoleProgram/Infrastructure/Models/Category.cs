

namespace ConsoleProgram.Infrastructure.Models
{
    public class Category
    {
        static int counter = 1;
        public Category()
        {
            this.Id = counter++;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
