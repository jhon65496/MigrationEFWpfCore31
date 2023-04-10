using System.Collections.Generic;


namespace MigrationEFWpfCore31.DAL.Entities
{
    public class Author 
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> Books { get; set; }
    }
}
