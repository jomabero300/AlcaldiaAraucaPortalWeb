using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;

namespace AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil
{
    public class AffiliateSocialNetworkViewModelsFilter
    {
        public int RowsFilterTotal { get; set; }

        public List<SocialNetwork> SocialNetworks { get; set; }
    }
}
