namespace Crudapi.Models
{
    public class UpdateContactRequest
    {
        public string token { get; set; }
        public string? empcode { get; set; }

        public string? empname { get; set; }

      //  public DateOnly doj { get; set; }
    }
}
