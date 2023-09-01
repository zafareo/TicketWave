namespace Application.UseCases.Customers.Queries
{
    public class GetAllCustomersQueryResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}