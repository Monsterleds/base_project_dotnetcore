using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Course
{
    public class CourseViewModelInput
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
}