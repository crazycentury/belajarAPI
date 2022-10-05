using System;
namespace WebApi.Models
{
    public class EmailDTO
    {
        public string To { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        //public List<Notes>? notes { get; set; };
    }
    //public class Notes
    //{
    //    public string? notes { get; set; };

    //}

}
