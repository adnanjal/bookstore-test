public class Author {
    public Author(int id, string firstName, string lastName, string pseudonym)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Pseudonym = pseudonym;
    }

    public int Id {get;set;}
    public string FirstName { get;set; }
    public string LastName { get;set; }
    public string Pseudonym { get;set; }    
    public ICollection<Book>? Books { get;set; }
}