﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CcsSso.Core.DbMigrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CcsAccessRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_CcsAccessRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CcsService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    TimeOutLength = table.Column<long>(type: "bigint", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcsService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    table.PrimaryKey("PK_ContactDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPointReason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_ContactPointReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnterpriseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_EnterpriseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityProvider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_IdentityProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_PartyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSettingType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_UserSettingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VirtualAddressType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_VirtualAddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServicePermissionName = table.Column<string>(type: "text", nullable: true),
                    CcsServiceId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePermission_CcsService_CcsServiceId",
                        column: x => x.CcsServiceId,
                        principalTable: "CcsService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StreetAddress = table.Column<string>(type: "text", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_PhysicalAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalAddress_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Party",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_Party", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Party_PartyType_PartyTypeId",
                        column: x => x.PartyTypeId,
                        principalTable: "PartyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_VirtualAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualAddress_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualAddress_VirtualAddressType_VirtualAddressTypeId",
                        column: x => x.VirtualAddressTypeId,
                        principalTable: "VirtualAddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServicePermissionId = table.Column<int>(type: "integer", nullable: false),
                    CcsAccessRoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRolePermission_CcsAccessRole_CcsAccessRoleId",
                        column: x => x.CcsAccessRoleId,
                        principalTable: "CcsAccessRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRolePermission_ServicePermission_ServicePermissionId",
                        column: x => x.ServicePermissionId,
                        principalTable: "ServicePermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    PartyTypeId = table.Column<int>(type: "integer", nullable: false),
                    ContactDetailId = table.Column<int>(type: "integer", nullable: false),
                    ContactPointReasonId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPoint_ContactDetail_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPoint_ContactPointReason_ContactPointReasonId",
                        column: x => x.ContactPointReasonId,
                        principalTable: "ContactPointReason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPoint_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactPoint_PartyType_PartyTypeId",
                        column: x => x.PartyTypeId,
                        principalTable: "PartyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CiiOrganisationId = table.Column<string>(type: "text", nullable: true),
                    LegalName = table.Column<string>(type: "text", nullable: true),
                    OrganisationUri = table.Column<string>(type: "text", nullable: true),
                    RightToBuy = table.Column<bool>(type: "boolean", nullable: false),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    IsActivated = table.Column<bool>(type: "boolean", nullable: false),
                    IsSme = table.Column<bool>(type: "boolean", nullable: false),
                    IsVcse = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organisation_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    UserTitle = table.Column<int>(type: "integer", nullable: false),
                    PartyId = table.Column<int>(type: "integer", nullable: false),
                    IdentityProviderId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_IdentityProvider_IdentityProviderId",
                        column: x => x.IdentityProviderId,
                        principalTable: "IdentityProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationAccessRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_OrganisationAccessRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationAccessRole_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationEnterpriseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_OrganisationEnterpriseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationEnterpriseType_EnterpriseType_EnterpriseTypeId",
                        column: x => x.EnterpriseTypeId,
                        principalTable: "EnterpriseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganisationEnterpriseType_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationUserGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_OrganisationUserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganisationUserGroup_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_Party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcurementGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_ProcurementGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcurementGroup_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TradingOrganisation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_TradingOrganisation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingOrganisation_Organisation_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdamUserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IdentityProviderId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    ClientDevice = table.Column<string>(type: "text", nullable: true),
                    CcsLoginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CcsLogoutDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LoginSuccessful = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdamUserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdamUserLogin_IdentityProvider_IdentityProviderId",
                        column: x => x.IdentityProviderId,
                        principalTable: "IdentityProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdamUserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_UserSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSetting_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSetting_UserSettingType_UserSettingTypeId",
                        column: x => x.UserSettingTypeId,
                        principalTable: "UserSettingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccessRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_UserAccessRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_CcsAccessRole_CcsAccessRoleId",
                        column: x => x.CcsAccessRoleId,
                        principalTable: "CcsAccessRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_OrganisationAccessRole_OrganisationAccessRol~",
                        column: x => x.OrganisationAccessRoleId,
                        principalTable: "OrganisationAccessRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccessRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAccess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationUserGroupId = table.Column<int>(type: "integer", nullable: false),
                    CcsAccessRoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupAccess_CcsAccessRole_CcsAccessRoleId",
                        column: x => x.CcsAccessRoleId,
                        principalTable: "CcsAccessRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAccess_OrganisationUserGroup_OrganisationUserGroupId",
                        column: x => x.OrganisationUserGroupId,
                        principalTable: "OrganisationUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupMembership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganisationUserGroupId = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_UserGroupMembership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroupMembership_OrganisationUserGroup_OrganisationUserG~",
                        column: x => x.OrganisationUserGroupId,
                        principalTable: "OrganisationUserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupMembership_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CcsServiceLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CcsServiceId = table.Column<int>(type: "integer", nullable: false),
                    IdamUserLoginId = table.Column<int>(type: "integer", nullable: false),
                    TimedOut = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CcsServiceLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CcsServiceLogin_CcsService_CcsServiceId",
                        column: x => x.CcsServiceId,
                        principalTable: "CcsService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CcsServiceLogin_IdamUserLogin_IdamUserLoginId",
                        column: x => x.IdamUserLoginId,
                        principalTable: "IdamUserLogin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdamUserLoginRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CcsAccessRoleId = table.Column<int>(type: "integer", nullable: false),
                    IdamUserLoginId = table.Column<int>(type: "integer", nullable: true),
                    CreatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    LastUpdatedPartyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdatedOnUtc = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyKey = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdamUserLoginRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdamUserLoginRole_CcsAccessRole_CcsAccessRoleId",
                        column: x => x.CcsAccessRoleId,
                        principalTable: "CcsAccessRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdamUserLoginRole_IdamUserLogin_IdamUserLoginId",
                        column: x => x.IdamUserLoginId,
                        principalTable: "IdamUserLogin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdamUserLoginRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CcsServiceLogin_CcsServiceId",
                table: "CcsServiceLogin",
                column: "CcsServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CcsServiceLogin_IdamUserLoginId",
                table: "CcsServiceLogin",
                column: "IdamUserLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_ContactDetailId",
                table: "ContactPoint",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_ContactPointReasonId",
                table: "ContactPoint",
                column: "ContactPointReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_PartyId",
                table: "ContactPoint",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPoint_PartyTypeId",
                table: "ContactPoint",
                column: "PartyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAccess_CcsAccessRoleId",
                table: "GroupAccess",
                column: "CcsAccessRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAccess_OrganisationUserGroupId",
                table: "GroupAccess",
                column: "OrganisationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_IdamUserLogin_IdentityProviderId",
                table: "IdamUserLogin",
                column: "IdentityProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_IdamUserLogin_UserId",
                table: "IdamUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdamUserLoginRole_CcsAccessRoleId",
                table: "IdamUserLoginRole",
                column: "CcsAccessRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdamUserLoginRole_IdamUserLoginId",
                table: "IdamUserLoginRole",
                column: "IdamUserLoginId");

            migrationBuilder.CreateIndex(
                name: "IX_IdamUserLoginRole_UserId",
                table: "IdamUserLoginRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_CiiOrganisationId",
                table: "Organisation",
                column: "CiiOrganisationId");

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
                name: "IX_OrganisationUserGroup_OrganisationId",
                table: "OrganisationUserGroup",
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
                name: "IX_ServicePermission_CcsServiceId",
                table: "ServicePermission",
                column: "CcsServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRolePermission_CcsAccessRoleId",
                table: "ServiceRolePermission",
                column: "CcsAccessRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRolePermission_ServicePermissionId",
                table: "ServiceRolePermission",
                column: "ServicePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingOrganisation_OrganisationId",
                table: "TradingOrganisation",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityProviderId",
                table: "User",
                column: "IdentityProviderId");

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
                name: "IX_UserGroupMembership_OrganisationUserGroupId",
                table: "UserGroupMembership",
                column: "OrganisationUserGroupId");

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
                name: "CcsServiceLogin");

            migrationBuilder.DropTable(
                name: "ContactPoint");

            migrationBuilder.DropTable(
                name: "GroupAccess");

            migrationBuilder.DropTable(
                name: "IdamUserLoginRole");

            migrationBuilder.DropTable(
                name: "OrganisationEnterpriseType");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PhysicalAddress");

            migrationBuilder.DropTable(
                name: "ProcurementGroup");

            migrationBuilder.DropTable(
                name: "ServiceRolePermission");

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
                name: "ContactPointReason");

            migrationBuilder.DropTable(
                name: "IdamUserLogin");

            migrationBuilder.DropTable(
                name: "EnterpriseType");

            migrationBuilder.DropTable(
                name: "ServicePermission");

            migrationBuilder.DropTable(
                name: "CcsAccessRole");

            migrationBuilder.DropTable(
                name: "OrganisationAccessRole");

            migrationBuilder.DropTable(
                name: "OrganisationUserGroup");

            migrationBuilder.DropTable(
                name: "UserSettingType");

            migrationBuilder.DropTable(
                name: "ContactDetail");

            migrationBuilder.DropTable(
                name: "VirtualAddressType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CcsService");

            migrationBuilder.DropTable(
                name: "Organisation");

            migrationBuilder.DropTable(
                name: "IdentityProvider");

            migrationBuilder.DropTable(
                name: "Party");

            migrationBuilder.DropTable(
                name: "PartyType");
        }
    }
}
