using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdvocacyPro.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeGrouping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeGrouping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BondType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocketType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocketType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ethnicity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ethnicity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireCause",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireCause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewDocumentationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewDocumentationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewerPosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewerPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    LogLevel = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectVersion",
                columns: table => new
                {
                    Type = table.Column<string>(maxLength: 250, nullable: false),
                    Version = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectVersion", x => x.Type);
                });

            migrationBuilder.CreateTable(
                name: "OffenseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicePopulation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePopulation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider });
                });

            migrationBuilder.CreateTable(
                name: "VictimType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictimType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZipCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 5, nullable: false),
                    FIPS = table.Column<string>(maxLength: 2, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offense",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CleryReport = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offense_OffenseType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OffenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Fax = table.Column<string>(maxLength: 20, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: true),
                    Logo = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(maxLength: 75, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    PrimaryContact = table.Column<string>(maxLength: 50, nullable: true),
                    Product = table.Column<int>(nullable: false),
                    State = table.Column<string>(maxLength: 30, nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProgram_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationFeature_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Address1 = table.Column<string>(maxLength: 50, nullable: true),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true),
                    Address3 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    DayPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    EveningPhone = table.Column<string>(maxLength: 20, nullable: true),
                    Fax = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true),
                    Initials = table.Column<string>(maxLength: 5, nullable: true),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 30, nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Archived = table.Column<bool>(nullable: false),
                    CaseDate = table.Column<DateTime>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    RaceId = table.Column<int>(nullable: true),
                    StaffUserId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Case_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Ethnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_User_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Case_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fire",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Archived = table.Column<bool>(nullable: false),
                    CauseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    Disposition = table.Column<string>(maxLength: 100, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    LocationTypeId = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OccurrenceDate = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: true),
                    StaffUserId = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fire_FireCause_CauseId",
                        column: x => x.CauseId,
                        principalTable: "FireCause",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_User_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fire_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    ContactDate = table.Column<DateTime>(nullable: false),
                    ContactTypeId = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseContact_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseContact_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseContact_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseContact_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseCourtDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArrestDate = table.Column<DateTime>(nullable: true),
                    BondAmount = table.Column<decimal>(nullable: false),
                    BondTypeId = table.Column<int>(nullable: false),
                    CaseId = table.Column<int>(nullable: false),
                    Court = table.Column<string>(maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DocketNumber = table.Column<string>(maxLength: 100, nullable: true),
                    DocketTypeId = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Police = table.Column<string>(maxLength: 250, nullable: true),
                    Purpose = table.Column<string>(nullable: true),
                    Reason = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCourtDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseCourtDate_BondType_BondTypeId",
                        column: x => x.BondTypeId,
                        principalTable: "BondType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCourtDate_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCourtDate_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCourtDate_DocketType_DocketTypeId",
                        column: x => x.DocketTypeId,
                        principalTable: "DocketType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCourtDate_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseCVCApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationStatusId = table.Column<int>(nullable: false),
                    CVCDate = table.Column<DateTime>(nullable: true),
                    CVCNumber = table.Column<string>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    Defendant = table.Column<string>(maxLength: 100, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OffenseTypeId = table.Column<int>(nullable: false),
                    ReferralOther = table.Column<string>(maxLength: 50, nullable: true),
                    ReferralTypeId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseCVCApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_ApplicationStatus_ApplicationStatusId",
                        column: x => x.ApplicationStatusId,
                        principalTable: "ApplicationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_OffenseType_OffenseTypeId",
                        column: x => x.OffenseTypeId,
                        principalTable: "OffenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_ReferralType_ReferralTypeId",
                        column: x => x.ReferralTypeId,
                        principalTable: "ReferralType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseCVCApplication_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DocumentTypeId = table.Column<int>(nullable: true),
                    File = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseDocument_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseDocument_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseDocument_DocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseDocument_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseEmergencyContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    RaceId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_Ethnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseEmergencyContact_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseIncident",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    Disposition = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    LocationTypeId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    OccurrenceDate = table.Column<DateTime>(nullable: false),
                    OffenseId = table.Column<int>(nullable: false),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    StaffUserId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseIncident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseIncident_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_Offense_OffenseId",
                        column: x => x.OffenseId,
                        principalTable: "Offense",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_User_StaffUserId",
                        column: x => x.StaffUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseIncident_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseInterview",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    InterviewDate = table.Column<DateTime>(nullable: false),
                    InterviewerName = table.Column<string>(maxLength: 250, nullable: true),
                    InterviewerPositionId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Observers = table.Column<string>(nullable: true),
                    OnSite = table.Column<bool>(nullable: false),
                    Planned = table.Column<bool>(nullable: false),
                    ProtocolFollowed = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInterview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseInterview_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseInterview_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseInterview_InterviewerPosition_InterviewerPositionId",
                        column: x => x.InterviewerPositionId,
                        principalTable: "InterviewerPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseInterview_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseLetter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    LetterTypeId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseLetter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseLetter_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseLetter_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseLetter_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseLetter_LetterType_LetterTypeId",
                        column: x => x.LetterTypeId,
                        principalTable: "LetterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseLetter_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseNote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseNote_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseNote_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseNote_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseOffender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    AgeGroupingId = table.Column<int>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 20, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    NumberOfOffenses = table.Column<int>(nullable: true),
                    PriorOffenses = table.Column<bool>(nullable: false),
                    RaceId = table.Column<int>(nullable: true),
                    RelationshipTypeId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseOffender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseOffender_AgeGrouping_AgeGroupingId",
                        column: x => x.AgeGroupingId,
                        principalTable: "AgeGrouping",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_Ethnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_RelationshipType_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalTable: "RelationshipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseOffender_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasePayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountApproved = table.Column<decimal>(nullable: true),
                    AmountSubmitted = table.Column<decimal>(nullable: true),
                    ApprovedById = table.Column<int>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    ClaimId = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    PaymentCategoryId = table.Column<int>(nullable: true),
                    PayorId = table.Column<int>(nullable: true),
                    SubmittedById = table.Column<int>(nullable: true),
                    SubmittedDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasePayment_User_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_PaymentCategory_PaymentCategoryId",
                        column: x => x.PaymentCategoryId,
                        principalTable: "PaymentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_Payor_PayorId",
                        column: x => x.PayorId,
                        principalTable: "Payor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_User_SubmittedById",
                        column: x => x.SubmittedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePayment_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CasePolice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PoliceCaseNo = table.Column<string>(maxLength: 50, nullable: false),
                    PoliceClosedDate = table.Column<DateTime>(nullable: true),
                    PoliceDepartment = table.Column<string>(maxLength: 100, nullable: true),
                    PoliceOutcome = table.Column<string>(nullable: true),
                    PoliceSequenceNo = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasePolice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasePolice_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePolice_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasePolice_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseProtectiveOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    OrderStatusId = table.Column<int>(nullable: false),
                    OrderTypeId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseProtectiveOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseProtectiveOrder_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseProtectiveOrder_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseProtectiveOrder_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseProtectiveOrder_OrderType_OrderTypeId",
                        column: x => x.OrderTypeId,
                        principalTable: "OrderType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseProtectiveOrder_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseReferral",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(maxLength: 100, nullable: false),
                    ContactDate = table.Column<DateTime>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    FollowupDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Source = table.Column<string>(maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseReferral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseReferral_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseReferral_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseReferral_ReferralType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ReferralType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseReferral_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseService",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PopulationId = table.Column<int>(nullable: true),
                    ProgramId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseService_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseService_ServiceCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ServiceCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseService_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseService_ServicePopulation_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "ServicePopulation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseService_ServiceProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "ServiceProgram",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseService_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseVictimization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaseId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    ReportDetails = table.Column<string>(nullable: true),
                    ReportNumber = table.Column<string>(maxLength: 100, nullable: true),
                    ReportingAgency = table.Column<string>(maxLength: 100, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    VictimTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseVictimization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseVictimization_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseVictimization_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseVictimization_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseVictimization_VictimType_VictimTypeId",
                        column: x => x.VictimTypeId,
                        principalTable: "VictimType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseWitness",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 50, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    CaseId = table.Column<int>(nullable: false),
                    CellPhone = table.Column<string>(maxLength: 20, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getutcdate()"),
                    CreatedById = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    GenderId = table.Column<int>(nullable: true),
                    HomePhone = table.Column<string>(maxLength: 20, nullable: true),
                    InterviewDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    RaceId = table.Column<int>(nullable: true),
                    RelationshipTypeId = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdatedById = table.Column<int>(nullable: true),
                    WorkPhone = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseWitness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseWitness_Case_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Case",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_Ethnicity_EthnicityId",
                        column: x => x.EthnicityId,
                        principalTable: "Ethnicity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_RelationshipType_RelationshipTypeId",
                        column: x => x.RelationshipTypeId,
                        principalTable: "RelationshipType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseWitness_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaseInterviewDocumentationType",
                columns: table => new
                {
                    CaseInterviewId = table.Column<int>(nullable: false),
                    InterviewDocumentationTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseInterviewDocumentationType", x => new { x.CaseInterviewId, x.InterviewDocumentationTypeId });
                    table.ForeignKey(
                        name: "FK_CaseInterviewDocumentationType_CaseInterview_CaseInterviewId",
                        column: x => x.CaseInterviewId,
                        principalTable: "CaseInterview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaseInterviewDocumentationType_InterviewDocumentationType_InterviewDocumentationTypeId",
                        column: x => x.InterviewDocumentationTypeId,
                        principalTable: "InterviewDocumentationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Case_CreatedById",
                table: "Case",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Case_EthnicityId",
                table: "Case",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_GenderId",
                table: "Case",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_OrganizationId",
                table: "Case",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_RaceId",
                table: "Case",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_StaffUserId",
                table: "Case",
                column: "StaffUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_StateId",
                table: "Case",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_StatusId",
                table: "Case",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Case_UpdatedById",
                table: "Case",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseContact_CaseId",
                table: "CaseContact",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseContact_ContactTypeId",
                table: "CaseContact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseContact_CreatedById",
                table: "CaseContact",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseContact_UpdatedById",
                table: "CaseContact",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourtDate_BondTypeId",
                table: "CaseCourtDate",
                column: "BondTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourtDate_CaseId",
                table: "CaseCourtDate",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourtDate_CreatedById",
                table: "CaseCourtDate",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourtDate_DocketTypeId",
                table: "CaseCourtDate",
                column: "DocketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCourtDate_UpdatedById",
                table: "CaseCourtDate",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_ApplicationStatusId",
                table: "CaseCVCApplication",
                column: "ApplicationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_CaseId",
                table: "CaseCVCApplication",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_CreatedById",
                table: "CaseCVCApplication",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_OffenseTypeId",
                table: "CaseCVCApplication",
                column: "OffenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_ReferralTypeId",
                table: "CaseCVCApplication",
                column: "ReferralTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseCVCApplication_UpdatedById",
                table: "CaseCVCApplication",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_CaseId",
                table: "CaseDocument",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_CreatedById",
                table: "CaseDocument",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_DocumentTypeId",
                table: "CaseDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_UpdatedById",
                table: "CaseDocument",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_CaseId",
                table: "CaseEmergencyContact",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_CreatedById",
                table: "CaseEmergencyContact",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_EthnicityId",
                table: "CaseEmergencyContact",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_GenderId",
                table: "CaseEmergencyContact",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_RaceId",
                table: "CaseEmergencyContact",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_StateId",
                table: "CaseEmergencyContact",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEmergencyContact_UpdatedById",
                table: "CaseEmergencyContact",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_CaseId",
                table: "CaseIncident",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_CreatedById",
                table: "CaseIncident",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_LocationTypeId",
                table: "CaseIncident",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_OffenseId",
                table: "CaseIncident",
                column: "OffenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_StaffUserId",
                table: "CaseIncident",
                column: "StaffUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_StatusId",
                table: "CaseIncident",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseIncident_UpdatedById",
                table: "CaseIncident",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInterview_CaseId",
                table: "CaseInterview",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInterview_CreatedById",
                table: "CaseInterview",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInterview_InterviewerPositionId",
                table: "CaseInterview",
                column: "InterviewerPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInterview_UpdatedById",
                table: "CaseInterview",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseInterviewDocumentationType_InterviewDocumentationTypeId",
                table: "CaseInterviewDocumentationType",
                column: "InterviewDocumentationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLetter_CaseId",
                table: "CaseLetter",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLetter_CreatedById",
                table: "CaseLetter",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLetter_LanguageId",
                table: "CaseLetter",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLetter_LetterTypeId",
                table: "CaseLetter",
                column: "LetterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseLetter_UpdatedById",
                table: "CaseLetter",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNote_CaseId",
                table: "CaseNote",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNote_CreatedById",
                table: "CaseNote",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNote_UpdatedById",
                table: "CaseNote",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_AgeGroupingId",
                table: "CaseOffender",
                column: "AgeGroupingId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_CaseId",
                table: "CaseOffender",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_CreatedById",
                table: "CaseOffender",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_EthnicityId",
                table: "CaseOffender",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_GenderId",
                table: "CaseOffender",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_RaceId",
                table: "CaseOffender",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_RelationshipTypeId",
                table: "CaseOffender",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_StateId",
                table: "CaseOffender",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseOffender_UpdatedById",
                table: "CaseOffender",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_ApprovedById",
                table: "CasePayment",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_CaseId",
                table: "CasePayment",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_CreatedById",
                table: "CasePayment",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_PaymentCategoryId",
                table: "CasePayment",
                column: "PaymentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_PayorId",
                table: "CasePayment",
                column: "PayorId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_SubmittedById",
                table: "CasePayment",
                column: "SubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePayment_UpdatedById",
                table: "CasePayment",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePolice_CaseId",
                table: "CasePolice",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CasePolice_CreatedById",
                table: "CasePolice",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CasePolice_UpdatedById",
                table: "CasePolice",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseProtectiveOrder_CaseId",
                table: "CaseProtectiveOrder",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseProtectiveOrder_CreatedById",
                table: "CaseProtectiveOrder",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseProtectiveOrder_OrderStatusId",
                table: "CaseProtectiveOrder",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseProtectiveOrder_OrderTypeId",
                table: "CaseProtectiveOrder",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseProtectiveOrder_UpdatedById",
                table: "CaseProtectiveOrder",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseReferral_CaseId",
                table: "CaseReferral",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseReferral_CreatedById",
                table: "CaseReferral",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseReferral_TypeId",
                table: "CaseReferral",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseReferral_UpdatedById",
                table: "CaseReferral",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_CaseId",
                table: "CaseService",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_CategoryId",
                table: "CaseService",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_CreatedById",
                table: "CaseService",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_PopulationId",
                table: "CaseService",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_ProgramId",
                table: "CaseService",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseService_UpdatedById",
                table: "CaseService",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVictimization_CaseId",
                table: "CaseVictimization",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVictimization_CreatedById",
                table: "CaseVictimization",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVictimization_UpdatedById",
                table: "CaseVictimization",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseVictimization_VictimTypeId",
                table: "CaseVictimization",
                column: "VictimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_CaseId",
                table: "CaseWitness",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_CreatedById",
                table: "CaseWitness",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_EthnicityId",
                table: "CaseWitness",
                column: "EthnicityId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_GenderId",
                table: "CaseWitness",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_RaceId",
                table: "CaseWitness",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_RelationshipTypeId",
                table: "CaseWitness",
                column: "RelationshipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_StateId",
                table: "CaseWitness",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWitness_UpdatedById",
                table: "CaseWitness",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_CauseId",
                table: "Fire",
                column: "CauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_CreatedById",
                table: "Fire",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_LocationTypeId",
                table: "Fire",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_OrganizationId",
                table: "Fire",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_StaffUserId",
                table: "Fire",
                column: "StaffUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_StatusId",
                table: "Fire",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Fire_UpdatedById",
                table: "Fire",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Offense_TypeId",
                table: "Offense",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_TypeId",
                table: "Organization",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFeature_OrganizationId",
                table: "OrganizationFeature",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProgram_CategoryId",
                table: "ServiceProgram",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_OrganizationId",
                table: "User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCode_Code",
                table: "ZipCode",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseContact");

            migrationBuilder.DropTable(
                name: "CaseCourtDate");

            migrationBuilder.DropTable(
                name: "CaseCVCApplication");

            migrationBuilder.DropTable(
                name: "CaseDocument");

            migrationBuilder.DropTable(
                name: "CaseEmergencyContact");

            migrationBuilder.DropTable(
                name: "CaseIncident");

            migrationBuilder.DropTable(
                name: "CaseInterviewDocumentationType");

            migrationBuilder.DropTable(
                name: "CaseLetter");

            migrationBuilder.DropTable(
                name: "CaseNote");

            migrationBuilder.DropTable(
                name: "CaseOffender");

            migrationBuilder.DropTable(
                name: "CasePayment");

            migrationBuilder.DropTable(
                name: "CasePolice");

            migrationBuilder.DropTable(
                name: "CaseProtectiveOrder");

            migrationBuilder.DropTable(
                name: "CaseReferral");

            migrationBuilder.DropTable(
                name: "CaseService");

            migrationBuilder.DropTable(
                name: "CaseVictimization");

            migrationBuilder.DropTable(
                name: "CaseWitness");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Fire");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "ObjectVersion");

            migrationBuilder.DropTable(
                name: "OrganizationFeature");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ZipCode");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "BondType");

            migrationBuilder.DropTable(
                name: "DocketType");

            migrationBuilder.DropTable(
                name: "ApplicationStatus");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "Offense");

            migrationBuilder.DropTable(
                name: "CaseInterview");

            migrationBuilder.DropTable(
                name: "InterviewDocumentationType");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "LetterType");

            migrationBuilder.DropTable(
                name: "AgeGrouping");

            migrationBuilder.DropTable(
                name: "PaymentCategory");

            migrationBuilder.DropTable(
                name: "Payor");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "ReferralType");

            migrationBuilder.DropTable(
                name: "ServicePopulation");

            migrationBuilder.DropTable(
                name: "ServiceProgram");

            migrationBuilder.DropTable(
                name: "VictimType");

            migrationBuilder.DropTable(
                name: "RelationshipType");

            migrationBuilder.DropTable(
                name: "FireCause");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "OffenseType");

            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "InterviewerPosition");

            migrationBuilder.DropTable(
                name: "ServiceCategory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Ethnicity");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationType");
        }
    }
}
