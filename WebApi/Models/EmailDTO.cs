using System;
namespace WebApi.Models
{
    public class EmailDTO
    {
        public string To { get; set; }
        public List<string> notes { get; set; }

        public string EmailBody()
        {
            var heading = $"<h3 style='text-align: center;'>Daily Notes</h3>";
            var noteList = notes.Select(note => $"<li>{note}</li>");
            return $"<div style='width:350px; height:200px; border: 1px solid black; padding:10px 15px 10px 15px;'>" +
                $"<h3>{heading}</h3>" +
                $"<ul>{String.Join("", noteList)}</ul> " +
                $"</div>";


        }

    }

}
