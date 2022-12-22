using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Admi");

            #region Afil Index

            builder.Entity<Affiliate>()
                .HasCheckConstraint("ck_Affiliate_TypeUserId", "TypeUserId='P' OR TypeUserId='E'");

            builder.Entity<AffiliateGroupCommunity>()
                .HasIndex(c => new { c.AffiliateId, c.GroupCommunityId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateGroupCommunity_AffiliateGroupCommunity");

            builder.Entity<AffiliateGroupProductive>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateGroupProductiveId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateGroupProductive_AffiliateGroupProductive");

            builder.Entity<AffiliateProfession>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateProfessionId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateProfession_AffiliateProfession");

            builder.Entity<AffiliateSocialNetwork>()
                .HasIndex(c => new { c.AffiliateId, c.AffiliateSocialNetworkId })
                .IsUnique()
                .HasDatabaseName("IX_AffiliateSocialNetwork_AffiliateSocialNetwork");

            builder.Entity<GroupCommunity>()
                .HasIndex(c => c.GroupCommunityName)
                .IsUnique()
                .HasDatabaseName("IX_GroupCommunity_Name");

            builder.Entity<GroupProductive>()
                .HasIndex(c => c.GroupProductiveName)
                .IsUnique()
                .HasDatabaseName("IX_GroupProductive_Name");

            builder.Entity<Profession>()
                .HasIndex(c => c.ProfessionName)
                .IsUnique()
                .HasDatabaseName("IX_Profession_Name");

            builder.Entity<SocialNetwork>()
                .HasIndex(c => c.SocialNetworkName)
                .IsUnique()
                .HasDatabaseName("IX_SocialNetwork_Name");

            #endregion

            #region Alar Index
            builder.Entity<PqrsStrategicLine>()
                .HasIndex(c => c.PqrsStrategicLineName)
                .IsUnique()
                .HasDatabaseName("IX_PqrsStrategicLine_Name");

            builder.Entity<PqrsStrategicLineSector>()
                .HasIndex(c => new { c.PqrsStrategicLineId, c.PqrsStrategicLineSectorName })
                .IsUnique()
                .HasDatabaseName("IX_PqrsStrategicLineSector_Name");
            #endregion

            #region Gene Index
            builder.Entity<CommuneTownship>()
                .HasIndex(c => new { c.MunicipalityId, c.ZoneId, c.CommuneTownshipName })
                .IsUnique()
                .HasDatabaseName("IX_CommuneTownship_Name");

            builder.Entity<Department>()
                .HasIndex(d => d.DepartmentName)
                .IsUnique()
                .HasDatabaseName("IX_Department_Name");

            builder
                .Entity<DocumentType>()
                .HasIndex(d => d.DocumentTypeName)
                .IsUnique()
                .HasDatabaseName("IX_DocumentType_Name");

            builder
                .Entity<Gender>()
                .HasIndex(g => g.GenderName)
                .IsUnique()
                .HasDatabaseName("IX_Gender_Name");

            builder.Entity<Municipality>()
                .HasIndex(c => new { c.DepartmentId, c.MunicipalityName })
                .IsUnique()
                .HasDatabaseName("IX_Municipality_Name");

            builder.Entity<NeighborhoodSidewalk>()
                .HasIndex(c => new { c.CommuneTownshipId, c.NeighborhoodSidewalkName })
                .IsUnique()
                .HasDatabaseName("IX_NeighborhoodSidewalk_Name");

            builder.Entity<State>()
                .HasIndex(c => new { c.StateName, c.StateType })
                .IsUnique()
                .HasDatabaseName("IX_State_Name");

            builder
                .Entity<Zone>()
                .HasIndex(z => z.ZoneName)
                .IsUnique()
                .HasDatabaseName("IX_Zone_Name");

            #endregion

            #region Subs Index

            builder.Entity<Subscriber>()
                .HasIndex(c => c.email)
                .IsUnique()
                .HasDatabaseName("IX_Subscriber_email");

            builder.Entity<SubscriberSector>()
                .HasIndex(c => new { c.SubscriberId, c.PqrsStrategicLineSectorId })
                .IsUnique()
                .HasDatabaseName("IX_SubscriberSecto_SubscriberId_PqrsStrategicLineSectorId");


            #endregion
        }
        #region Afil DbSet
        public DbSet<Affiliate> Affiliates { get; set; }
        public DbSet<AffiliateGroupCommunity> AffiliateGroupCommunities { get; set; }
        public DbSet<AffiliateGroupProductive> AffiliateGroupProductives { get; set; }
        public DbSet<AffiliateProfession> AffiliateProfessions { get; set; }
        public DbSet<AffiliateSocialNetwork> AffiliateSocialNetworks { get; set; }
        public DbSet<GroupCommunity> GroupCommunities { get; set; }
        public DbSet<GroupProductive> GroupProductives { get; set; }        
        public DbSet<Profession> Professions { get; set; }        
        public DbSet<SocialNetwork> SocialNetworks { get; set; }

        #endregion

        #region Alar DbSet
        public DbSet<PqrsStrategicLine> PqrsStrategicLines { get; set; }
        public DbSet<PqrsStrategicLineSector> PqrsStrategicLineSectors { get; set; }
        public DbSet<PqrsUserStrategicLine> PqrsUserStrategicLines { get; set; }
        #endregion
                
        #region Cont DbSet
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentDetail> ContentDetails { get; set; }
        public DbSet<ContentOds> ContentOds { get; set; }

        #endregion

        #region Gene DbSet
        public DbSet<CommuneTownship> CommuneTownships { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<NeighborhoodSidewalk> NeighborhoodSidewalks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Zone> Zones { get; set; }
        #endregion

        #region Sub SbSet
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<SubscriberSector> SubscriberSectors { get; set; }

        #endregion
    }
}