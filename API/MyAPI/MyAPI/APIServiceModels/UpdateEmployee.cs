namespace MyAPI.APIServiceModels
{
    public class UpdateEmployee
    {
        public Guid EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Username { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }
}
