using System.ComponentModel.DataAnnotations;

namespace FlightApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}