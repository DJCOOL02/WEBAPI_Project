namespace WEBAPI.Models
{
    public class AddContactRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public long Number { get; set; }

        public string Address { get; set; }
    }
}
