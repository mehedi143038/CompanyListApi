namespace CompanyListApi
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
    }
}
