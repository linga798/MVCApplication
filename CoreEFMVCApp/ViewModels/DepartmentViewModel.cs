using System.ComponentModel.DataAnnotations;

namespace CoreEFMVCApp.ViewModels
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Name field is required.")]
        public string Name { get; set; }
    }
}
