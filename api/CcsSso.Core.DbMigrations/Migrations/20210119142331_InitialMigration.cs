using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CcsSso.DbMigrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CcsAccessRole",
                columns: table => new
                {
                    CcsAccessRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CcsAccessRoleName = table.Column<string>(type: "text", nullable: true),
                    CcsAccessRoleDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcsAccessRole", x => x.CcsAccessRoleId);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseType",
                columns: table => new
                {
                    EnterpriseTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnterpriseTypeName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnterpriseType", x => x.EnterpriseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProvider",
                columns: table => new
                {
                    IdpId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdpUri = table.Column<string>(type: "text", nullable: true),
                    IdpName = table.Column<string>(type: "text", nullable: true),
                    ExternalIdpFlag = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProvider", x => x.IdpId);
                });

            migrationBuilder.CreateTable(
                name: "PartyType",
                columns: table => new
                {
                    PartyTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartyTypeName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyType", x => x.PartyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserSettingType",
                columns: table => new
                {
                    UserSettingTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserSettingName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettingType", x => x.UserSettingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "VirtualAddressType",
                columns: table => new
                {
                    VirtualAddressTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAddressType", x => x.VirtualAddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartyTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Party", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Party_PartyType_PartyTypeId",
                        column: x => x.PartyTypeId,
                        principalTable: "PartyType",
                        principalColumn: "PartyTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoint",
                columns: table => new
                {
                    ContactPointId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoint", x => x.ContactPointId);
                    table.ForeignKey(
                        name: "FK_ContactPoint_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationUri = table.Column<string>(type: "text", nullable: true),
                    RightToBuy = table.Column<bool>(type: "boolean", nullable: false),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.OrganisationId);
                    table.ForeignKey(
                        name: "FK_Organisation_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SurName = table.Column<string>(type: "text", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    UserTitle = table.Column<int>(type: "integer", nullable: false),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    IdentityProviderIdpId = table.Column<int>(type: "integer", nullable: true),
                    IdpId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_IdentityProvider_IdentityProviderIdpId",
                        column: x => x.IdentityProviderIdpId,
                        principalTable: "IdentityProvider",
                        principalColumn: "IdpId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    ContactDetailId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactPointId = table.Column<int>(type: "integer", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetail", x => x.ContactDetailId);
                    table.ForeignKey(
                        name: "FK_ContactDetail_ContactPoint_ContactPointId",
                        column: x => x.ContactPointId,
                        principalTable: "ContactPoint",
                        principalColumn: "ContactPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationAccessRole",
                columns: table => new
                {
                    OrganisationAccessRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    OrganisationAccessRoleName = table.Column<string>(type: "text", nullable: true),
                    OrganisationAccessRoleDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationAccessRole", x => x.OrganisationAccessRoleId);
                    table.ForeignKey(
                        name: "FK_OrganisationAccessRole_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationEnterpriseType",
                columns: table => new
                {
                    OrganisationEnterpriseTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationEnterpriseType", x => x.OrganisationEnterpriseTypeId);
                    table.ForeignKey(
                        name: "FK_OrganisationEnterpriseType_EnterpriseType_EnterpriseTypeId",
                        column: x => x.EnterpriseTypeId,
                        principalTable: "EnterpriseType",
                        principalColumn: "EnterpriseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationEnterpriseType_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcurementGroup",
                columns: table => new
                {
                    ProcurementGroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcurementGroup", x => x.ProcurementGroupId);
                    table.ForeignKey(
                        name: "FK_ProcurementGroup_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradingOrganisation",
                columns: table => new
                {
                    TradingOrganisationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    TradingName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingOrganisation", x => x.TradingOrganisationId);
                    table.ForeignKey(
                        name: "FK_TradingOrganisation_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    UserGroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false),
                    UserGroupName = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.UserGroupId);
                    table.ForeignKey(
                        name: "FK_UserGroup_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                columns: table => new
                {
                    UserSettingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserSettingTypeId = table.Column<int>(type: "integer", nullable: false),
                    UserSettingValue = table.Column<string>(type: "text", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetting", x => x.UserSettingId);
                    table.ForeignKey(
                        name: "FK_UserSetting_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSetting_UserSettingType_UserSettingTypeId",
                        column: x => x.UserSettingTypeId,
                        principalTable: "UserSettingType",
                        principalColumn: "UserSettingTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    PhysicalAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false),
                    Uprn = table.Column<string>(type: "text", nullable: true),
                    ContactDetailId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAddress", x => x.PhysicalAddressId);
                    table.ForeignKey(
                        name: "FK_PhysicalAddress_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualAddress",
                columns: table => new
                {
                    VirtualAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VirtualAddressValue = table.Column<string>(type: "text", nullable: true),
                    VirtualAddressTypeId = table.Column<int>(type: "integer", nullable: false),
                    ContactDetailId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAddress", x => x.VirtualAddressId);
                    table.ForeignKey(
                        name: "FK_VirtualAddress_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualAddress_VirtualAddressType_VirtualAddressTypeId",
                        column: x => x.VirtualAddressTypeId,
                        principalTable: "VirtualAddressType",
                        principalColumn: "VirtualAddressTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessRole",
                columns: table => new
                {
                    UserAccessRoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CcsAccessRoleId = table.Column<int>(type: "integer", nullable: false),
                    OrganisationAccessRoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccessRole", x => x.UserAccessRoleId);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_CcsAccessRole_CcsAccessRoleId",
                        column: x => x.CcsAccessRoleId,
                        principalTable: "CcsAccessRole",
                        principalColumn: "CcsAccessRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_OrganisationAccessRole_OrganisationAccessRol~",
                        column: x => x.OrganisationAccessRoleId,
                        principalTable: "OrganisationAccessRole",
                        principalColumn: "OrganisationAccessRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupMembership",
                columns: table => new
                {
                    UserGroupMembershipId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserGroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MembershipStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    MembershipEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupMembership", x => x.UserGroupMembershipId);
                    table.ForeignKey(
                        name: "FK_UserGroupMembership_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupMembership_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "UserGroup",
                        principalColumn: "UserGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetail_ContactPointId",
                table: "ContactDetail",
                column: "ContactPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_PartyId",
                table: "ContactPoint",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_PartyId",
                table: "Organisation",
                column: "PartyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationAccessRole_OrganisationId",
                table: "OrganisationAccessRole",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationEnterpriseType_EnterpriseTypeId",
                table: "OrganisationEnterpriseType",
                column: "EnterpriseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationEnterpriseType_OrganisationId",
                table: "OrganisationEnterpriseType",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Party_PartyTypeId",
                table: "Party",
                column: "PartyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OrganisationId",
                table: "Person",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PartyId",
                table: "Person",
                column: "PartyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalAddress_ContactDetailId",
                table: "PhysicalAddress",
                column: "ContactDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementGroup_OrganisationId",
                table: "ProcurementGroup",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingOrganisation_OrganisationId",
                table: "TradingOrganisation",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityProviderIdpId",
                table: "User",
                column: "IdentityProviderIdpId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PartyId",
                table: "User",
                column: "PartyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessRole_CcsAccessRoleId",
                table: "UserAccessRole",
                column: "CcsAccessRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessRole_OrganisationAccessRoleId",
                table: "UserAccessRole",
                column: "OrganisationAccessRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccessRole_UserId",
                table: "UserAccessRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_OrganisationId",
                table: "UserGroup",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMembership_UserGroupId",
                table: "UserGroupMembership",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupMembership_UserId",
                table: "UserGroupMembership",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_UserId",
                table: "UserSetting",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_UserSettingTypeId",
                table: "UserSetting",
                column: "UserSettingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAddress_ContactDetailId",
                table: "VirtualAddress",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualAddress_VirtualAddressTypeId",
                table: "VirtualAddress",
                column: "VirtualAddressTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganisationEnterpriseType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PhysicalAddress");

            migrationBuilder.DropTable(
                name: "ProcurementGroup");

            migrationBuilder.DropTable(
                name: "TradingOrganisation");

            migrationBuilder.DropTable(
                name: "UserAccessRole");

            migrationBuilder.DropTable(
                name: "UserGroupMembership");

            migrationBuilder.DropTable(
                name: "UserSetting");

            migrationBuilder.DropTable(
                name: "VirtualAddress");

            migrationBuilder.DropTable(
                name: "EnterpriseType");

            migrationBuilder.DropTable(
                name: "CcsAccessRole");

            migrationBuilder.DropTable(
                name: "OrganisationAccessRole");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserSettingType");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "VirtualAddressType");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "IdentityProvider");

            migrationBuilder.DropTable(
                name: "ContactPoint");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "PartyType");
        }
    }
}
