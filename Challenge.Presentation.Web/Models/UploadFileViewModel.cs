using System.ComponentModel.DataAnnotations;

namespace Challenge.Presentation.Web.Models
{
    public class UploadFileViewModel
    {

        [Required]
        public IFormFile File { get; set; } = null!;

    }
}
