public class Author {

    public int Id {get;set;}
    public string FirstName { get;set; }
    public string LastName { get;set; }
    public string Pseudonym { get;set; }    
    public ICollection<Book> Books { get;set; }
}