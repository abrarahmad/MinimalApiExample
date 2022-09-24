namespace Contract.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; } = null!;
    }
}
