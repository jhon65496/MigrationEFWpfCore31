
namespace MigrationEFWpfCore31.DAL.Entities
{
    public class Book 
    {    
        public int BookId { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
    }
}
