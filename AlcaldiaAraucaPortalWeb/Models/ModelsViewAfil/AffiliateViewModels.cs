using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateViewModels : Affiliate
    {
        [Display(Name = "Imagen")]
        public IFormFile ImagePathNew { get; set; }

    }
}
