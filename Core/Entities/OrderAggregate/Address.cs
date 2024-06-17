namespace Core.Entities.OrderAggregate
{
    public class Address 
    {
        public Address()
        {
        }

        public Address(string firstName,string lastName,string town)
        {
            FirstName = firstName;
            LastName = lastName;
            Town = town;
        }
             public int Id{ get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Town { get; set; }   
    }
}