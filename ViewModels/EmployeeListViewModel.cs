namespace OmniSystem.ViewModels
{
    public class EmployeeListViewModel
    {
        public required string Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PositionName { get; set; }
        public decimal Salary { get; set; }
        public double Rating { get; set; }
        public required string UserName { get; set; }
        public required string Initials { get; set; } // للحروف الأولى (الأفاتار)
    }
}