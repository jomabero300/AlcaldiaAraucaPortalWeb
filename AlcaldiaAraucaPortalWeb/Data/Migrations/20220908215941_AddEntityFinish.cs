using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlcaldiaAraucaPortalWeb.Data.Migrations
{
    public partial class AddEntityFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.EnsureSchema(
                name: "Afil");

            migrationBuilder.EnsureSchema(
                name: "Admi");

            migrationBuilder.EnsureSchema(
                name: "Gene");

            migrationBuilder.EnsureSchema(
                name: "Cont");

            migrationBuilder.EnsureSchema(
                name: "Alar");

            migrationBuilder.EnsureSchema(
                name: "Subs");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Admi");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Admi");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admi",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Admi",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirdDarte",
                schema: "Admi",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Document",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                schema: "Admi",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Admi",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Admi",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Affiliates",
                schema: "Afil",
                columns: table => new
                {
                    AffiliateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TypeUserId = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Nit = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Address = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    CellPhone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliates", x => x.AffiliateId);
                    table.CheckConstraint("ck_Affiliate_TypeUserId", "TypeUserId='P' OR TypeUserId='E'");
                    table.ForeignKey(
                        name: "FK_Affiliates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Gene",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "Gene",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentTypeName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "Gene",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "PqrsStrategicLines",
                schema: "Alar",
                columns: table => new
                {
                    PqrsStrategicLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsStrategicLineName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsStrategicLines", x => x.PqrsStrategicLineId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Gene",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateType = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    StateName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    StateB = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                schema: "Gene",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.ZoneId);
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                schema: "Gene",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MunicipalityName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipalities", x => x.MunicipalityId);
                    table.ForeignKey(
                        name: "FK_Municipalities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Gene",
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsStrategicLineSectors",
                schema: "Alar",
                columns: table => new
                {
                    PqrsStrategicLineSectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsStrategicLineId = table.Column<int>(type: "int", nullable: false),
                    PqrsStrategicLineSectorName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsStrategicLineSectors", x => x.PqrsStrategicLineSectorId);
                    table.ForeignKey(
                        name: "FK_PqrsStrategicLineSectors_PqrsStrategicLines_PqrsStrategicLineId",
                        column: x => x.PqrsStrategicLineId,
                        principalSchema: "Alar",
                        principalTable: "PqrsStrategicLines",
                        principalColumn: "PqrsStrategicLineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupCommunities",
                schema: "Afil",
                columns: table => new
                {
                    GroupCommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupCommunityName = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCommunities", x => x.GroupCommunityId);
                    table.ForeignKey(
                        name: "FK_GroupCommunities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupProductives",
                schema: "Afil",
                columns: table => new
                {
                    GroupProductiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupProductiveName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProductives", x => x.GroupProductiveId);
                    table.ForeignKey(
                        name: "FK_GroupProductives_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PqrsUserStrategicLines",
                schema: "Alar",
                columns: table => new
                {
                    PqrsUserStrategicLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    PqrsStrategicLineId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PqrsUserStrategicLines", x => x.PqrsUserStrategicLineId);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_PqrsStrategicLines_PqrsStrategicLineId",
                        column: x => x.PqrsStrategicLineId,
                        principalSchema: "Alar",
                        principalTable: "PqrsStrategicLines",
                        principalColumn: "PqrsStrategicLineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PqrsUserStrategicLines_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                schema: "Afil",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                    table.ForeignKey(
                        name: "FK_Professions_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworks",
                schema: "Afil",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialNetworkName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworks", x => x.SocialNetworkId);
                    table.ForeignKey(
                        name: "FK_SocialNetworks_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                schema: "Subs",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.SubscriberId);
                    table.ForeignKey(
                        name: "FK_Subscriber_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommuneTownships",
                schema: "Gene",
                columns: table => new
                {
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    CommuneTownshipName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommuneTownships", x => x.CommuneTownshipId);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalSchema: "Gene",
                        principalTable: "Municipalities",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommuneTownships_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Gene",
                        principalTable: "Zones",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentOds",
                schema: "Cont",
                columns: table => new
                {
                    ContentOdsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsStrategicLineSectorId = table.Column<int>(type: "int", nullable: false),
                    ContentOdsText = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    ContentOdsImg = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    ContentOdsUrl = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentOds", x => x.ContentOdsId);
                    table.ForeignKey(
                        name: "FK_ContentOds_PqrsStrategicLineSectors_PqrsStrategicLineSectorId",
                        column: x => x.PqrsStrategicLineSectorId,
                        principalSchema: "Alar",
                        principalTable: "PqrsStrategicLineSectors",
                        principalColumn: "PqrsStrategicLineSectorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                schema: "Cont",
                columns: table => new
                {
                    ContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PqrsStrategicLineSectorId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ContentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContentTitle = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    ContentText = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    ContentUrlImg = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.ContentId);
                    table.ForeignKey(
                        name: "FK_Contents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Admi",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_PqrsStrategicLineSectors_PqrsStrategicLineSectorId",
                        column: x => x.PqrsStrategicLineSectorId,
                        principalSchema: "Alar",
                        principalTable: "PqrsStrategicLineSectors",
                        principalColumn: "PqrsStrategicLineSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contents_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateGroupCommunities",
                schema: "Afil",
                columns: table => new
                {
                    AffiliateGroupCommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    GroupCommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateGroupCommunities", x => x.AffiliateGroupCommunityId);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupCommunities_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Afil",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupCommunities_GroupCommunities_GroupCommunityId",
                        column: x => x.GroupCommunityId,
                        principalSchema: "Afil",
                        principalTable: "GroupCommunities",
                        principalColumn: "GroupCommunityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateGroupProductives",
                schema: "Afil",
                columns: table => new
                {
                    AffiliateGroupProductiveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    GroupProductiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateGroupProductives", x => x.AffiliateGroupProductiveId);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupProductives_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Afil",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateGroupProductives_GroupProductives_GroupProductiveId",
                        column: x => x.GroupProductiveId,
                        principalSchema: "Afil",
                        principalTable: "GroupProductives",
                        principalColumn: "GroupProductiveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateProfessions",
                schema: "Afil",
                columns: table => new
                {
                    AffiliateProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Concept = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DocumentoPath = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateProfessions", x => x.AffiliateProfessionId);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessions_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Afil",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalSchema: "Afil",
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AffiliateSocialNetworks",
                schema: "Afil",
                columns: table => new
                {
                    AffiliateSocialNetworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliateId = table.Column<int>(type: "int", nullable: false),
                    SocialNetworkId = table.Column<int>(type: "int", nullable: false),
                    AffiliateSocialNetworURL = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffiliateSocialNetworks", x => x.AffiliateSocialNetworkId);
                    table.ForeignKey(
                        name: "FK_AffiliateSocialNetworks_Affiliates_AffiliateId",
                        column: x => x.AffiliateId,
                        principalSchema: "Afil",
                        principalTable: "Affiliates",
                        principalColumn: "AffiliateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AffiliateSocialNetworks_SocialNetworks_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalSchema: "Afil",
                        principalTable: "SocialNetworks",
                        principalColumn: "SocialNetworkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberSector",
                schema: "Subs",
                columns: table => new
                {
                    SubscriberSectorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    PqrsStrategicLineSectorId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    SendUrl = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberSector", x => x.SubscriberSectorId);
                    table.ForeignKey(
                        name: "FK_SubscriberSector_PqrsStrategicLineSectors_PqrsStrategicLineSectorId",
                        column: x => x.PqrsStrategicLineSectorId,
                        principalSchema: "Alar",
                        principalTable: "PqrsStrategicLineSectors",
                        principalColumn: "PqrsStrategicLineSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriberSector_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubscriberSector_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalSchema: "Subs",
                        principalTable: "Subscriber",
                        principalColumn: "SubscriberId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene",
                columns: table => new
                {
                    NeighborhoodSidewalkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommuneTownshipId = table.Column<int>(type: "int", nullable: false),
                    NeighborhoodSidewalkName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeighborhoodSidewalks", x => x.NeighborhoodSidewalkId);
                    table.ForeignKey(
                        name: "FK_NeighborhoodSidewalks_CommuneTownships_CommuneTownshipId",
                        column: x => x.CommuneTownshipId,
                        principalSchema: "Gene",
                        principalTable: "CommuneTownships",
                        principalColumn: "CommuneTownshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContentDetails",
                schema: "Cont",
                columns: table => new
                {
                    ContentDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    ContentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ContentTitle = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    ContentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentUrlImg = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentDetails", x => x.ContentDetailsId);
                    table.ForeignKey(
                        name: "FK_ContentDetails_Contents_ContentId",
                        column: x => x.ContentId,
                        principalSchema: "Cont",
                        principalTable: "Contents",
                        principalColumn: "ContentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentDetails_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Gene",
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupCommunities_GroupCommunityId",
                schema: "Afil",
                table: "AffiliateGroupCommunities",
                column: "GroupCommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupCommunity_AffiliateGroupCommunity",
                schema: "Afil",
                table: "AffiliateGroupCommunities",
                columns: new[] { "AffiliateId", "GroupCommunityId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupProductive_AffiliateGroupProductive",
                schema: "Afil",
                table: "AffiliateGroupProductives",
                columns: new[] { "AffiliateId", "AffiliateGroupProductiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateGroupProductives_GroupProductiveId",
                schema: "Afil",
                table: "AffiliateGroupProductives",
                column: "GroupProductiveId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfession_AffiliateProfession",
                schema: "Afil",
                table: "AffiliateProfessions",
                columns: new[] { "AffiliateId", "AffiliateProfessionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateProfessions_ProfessionId",
                schema: "Afil",
                table: "AffiliateProfessions",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Affiliates_UserId",
                schema: "Afil",
                table: "Affiliates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateSocialNetwork_AffiliateSocialNetwork",
                schema: "Afil",
                table: "AffiliateSocialNetworks",
                columns: new[] { "AffiliateId", "AffiliateSocialNetworkId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AffiliateSocialNetworks_SocialNetworkId",
                schema: "Afil",
                table: "AffiliateSocialNetworks",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownship_Name",
                schema: "Gene",
                table: "CommuneTownships",
                columns: new[] { "MunicipalityId", "ZoneId", "CommuneTownshipName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommuneTownships_ZoneId",
                schema: "Gene",
                table: "CommuneTownships",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_ContentId",
                schema: "Cont",
                table: "ContentDetails",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentDetails_StateId",
                schema: "Cont",
                table: "ContentDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentOds_PqrsStrategicLineSectorId",
                schema: "Cont",
                table: "ContentOds",
                column: "PqrsStrategicLineSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_PqrsStrategicLineSectorId",
                schema: "Cont",
                table: "Contents",
                column: "PqrsStrategicLineSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_StateId",
                schema: "Cont",
                table: "Contents",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                schema: "Cont",
                table: "Contents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Name",
                schema: "Gene",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_Name",
                schema: "Gene",
                table: "DocumentTypes",
                column: "DocumentTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gender_Name",
                schema: "Gene",
                table: "Genders",
                column: "GenderName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupCommunities_StateId",
                schema: "Afil",
                table: "GroupCommunities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupCommunity_Name",
                schema: "Afil",
                table: "GroupCommunities",
                column: "GroupCommunityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProductive_Name",
                schema: "Afil",
                table: "GroupProductives",
                column: "GroupProductiveName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupProductives_StateId",
                schema: "Afil",
                table: "GroupProductives",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_Name",
                schema: "Gene",
                table: "Municipalities",
                columns: new[] { "DepartmentId", "MunicipalityName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NeighborhoodSidewalk_Name",
                schema: "Gene",
                table: "NeighborhoodSidewalks",
                columns: new[] { "CommuneTownshipId", "NeighborhoodSidewalkName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PqrsStrategicLine_Name",
                schema: "Alar",
                table: "PqrsStrategicLines",
                column: "PqrsStrategicLineName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PqrsStrategicLineSector_Name",
                schema: "Alar",
                table: "PqrsStrategicLineSectors",
                columns: new[] { "PqrsStrategicLineId", "PqrsStrategicLineSectorName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_PqrsStrategicLineId",
                schema: "Alar",
                table: "PqrsUserStrategicLines",
                column: "PqrsStrategicLineId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_StateId",
                schema: "Alar",
                table: "PqrsUserStrategicLines",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_PqrsUserStrategicLines_UserId",
                schema: "Alar",
                table: "PqrsUserStrategicLines",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profession_Name",
                schema: "Afil",
                table: "Professions",
                column: "ProfessionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_StateId",
                schema: "Afil",
                table: "Professions",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetwork_Name",
                schema: "Afil",
                table: "SocialNetworks",
                column: "SocialNetworkName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_StateId",
                schema: "Afil",
                table: "SocialNetworks",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                schema: "Gene",
                table: "States",
                columns: new[] { "StateName", "StateType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_email",
                schema: "Subs",
                table: "Subscriber",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_StateId",
                schema: "Subs",
                table: "Subscriber",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberSecto_SubscriberId_PqrsStrategicLineSectorId",
                schema: "Subs",
                table: "SubscriberSector",
                columns: new[] { "SubscriberId", "PqrsStrategicLineSectorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberSector_PqrsStrategicLineSectorId",
                schema: "Subs",
                table: "SubscriberSector",
                column: "PqrsStrategicLineSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberSector_StateId",
                schema: "Subs",
                table: "SubscriberSector",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Zone_Name",
                schema: "Gene",
                table: "Zones",
                column: "ZoneName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Admi",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalSchema: "Gene",
                principalTable: "DocumentTypes",
                principalColumn: "DocumentTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "GenderId",
                principalSchema: "Gene",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers",
                column: "NeighborhoodSidewalkId",
                principalSchema: "Gene",
                principalTable: "NeighborhoodSidewalks",
                principalColumn: "NeighborhoodSidewalkId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Admi",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Genders_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_NeighborhoodSidewalks_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Admi",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AffiliateGroupCommunities",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "AffiliateGroupProductives",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "AffiliateProfessions",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "AffiliateSocialNetworks",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "ContentDetails",
                schema: "Cont");

            migrationBuilder.DropTable(
                name: "ContentOds",
                schema: "Cont");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "NeighborhoodSidewalks",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsUserStrategicLines",
                schema: "Alar");

            migrationBuilder.DropTable(
                name: "SubscriberSector",
                schema: "Subs");

            migrationBuilder.DropTable(
                name: "GroupCommunities",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "GroupProductives",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "Professions",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "Affiliates",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "SocialNetworks",
                schema: "Afil");

            migrationBuilder.DropTable(
                name: "Contents",
                schema: "Cont");

            migrationBuilder.DropTable(
                name: "CommuneTownships",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Subscriber",
                schema: "Subs");

            migrationBuilder.DropTable(
                name: "PqrsStrategicLineSectors",
                schema: "Alar");

            migrationBuilder.DropTable(
                name: "Municipalities",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Gene");

            migrationBuilder.DropTable(
                name: "PqrsStrategicLines",
                schema: "Alar");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Gene");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirdDarte",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Document",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NeighborhoodSidewalkId",
                schema: "Admi",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Admi",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Admi",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Admi",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Admi",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Admi",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Admi",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Admi",
                newName: "AspNetRoleClaims");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
