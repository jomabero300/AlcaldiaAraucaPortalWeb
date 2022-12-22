using System.ComponentModel.DataAnnotations;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class GroupCommunityViewModel
    {
        [Display(Name = "Grupo comunitario")]
        public int GroupCommunityId { get; set; }

        [Display(Name = "Grupo comunitario")]
        public string GroupCommunityName { get; set; }

        public int Total { get; set; }
    }
}
