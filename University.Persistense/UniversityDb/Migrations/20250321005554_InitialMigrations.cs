using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Persistence.UniversityDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "university");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                schema: "university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                schema: "university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyDepartments",
                schema: "university",
                columns: table => new
                {
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyDepartments", x => new { x.FacultyId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_FacultyDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "university",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyDepartments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalSchema: "university",
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentGroups",
                schema: "university",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentGroups", x => new { x.DepartmentId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_DepartmentGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "university",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupStudents",
                schema: "university",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStudents", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupStudents_Groups_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "university",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "university",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "university",
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentGroups_GroupId",
                schema: "university",
                table: "DepartmentGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDepartments_DepartmentId",
                schema: "university",
                table: "FacultyDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStudents_StudentId",
                schema: "university",
                table: "GroupStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                schema: "university",
                table: "Students",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentGroups",
                schema: "university");

            migrationBuilder.DropTable(
                name: "FacultyDepartments",
                schema: "university");

            migrationBuilder.DropTable(
                name: "GroupStudents",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Faculties",
                schema: "university");

            migrationBuilder.DropTable(
                name: "Groups",
                schema: "university");
        }
    }
}
