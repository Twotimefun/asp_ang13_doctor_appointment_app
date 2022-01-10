using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web_app_asp.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    AppointmentTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.AppointmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Sex = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Comments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                        column: x => x.AppointmentTypeId,
                        principalTable: "AppointmentTypes",
                        principalColumn: "AppointmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "Type" },
                values: new object[] { 1, "General Check Up" });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "Type" },
                values: new object[] { 2, "Covid Check" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 1, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 2, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 3, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 4, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 5, new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 6, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 7, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "SessionId", "EndTime", "StartTime" },
                values: new object[] { 8, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Type" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Type" },
                values: new object[] { 2, "Staff" });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Type" },
                values: new object[] { 3, "Client" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Sex", "UserTypeId" },
                values: new object[] { 1, new DateTime(2002, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "First Name 1", "Last Name 1", "password", "1231231231", "Male", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Sex", "UserTypeId" },
                values: new object[] { 2, new DateTime(2000, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@staff.com", "First Name 2", "Last Name 2", "password", "1234567890", "Male", 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Sex", "UserTypeId" },
                values: new object[] { 3, new DateTime(1996, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "email@gmail.com", "First Name 3", "Last Name 3", "password", "0987654321", "Female", 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "AppointmentTypeId", "Comments", "SessionId", "UserId" },
                values: new object[] { 1, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Client may have contagious sickness", 3, 3 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "AppointmentTypeId", "Comments", "SessionId", "UserId" },
                values: new object[] { 2, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "", 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SessionId",
                table: "Appointments",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
