using System.ComponentModel.DataAnnotations;

namespace WebAppMonfIntensive.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
