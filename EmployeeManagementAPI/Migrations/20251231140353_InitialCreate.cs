using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmployeeSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: false),
                    IsOffday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAttendances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[] { 502036, "EMP326", "Selim Reja", 59000m, null });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 181, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 182, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 183, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 184, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 185, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 186, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, true, false, false },
                    { 187, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 188, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 189, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 190, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 191, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 192, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 193, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 194, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 195, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 196, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 197, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 198, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 199, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 200, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 201, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 202, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 203, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 204, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false },
                    { 205, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 206, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, true, false, false },
                    { 207, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 208, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 209, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, false, true },
                    { 210, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502036, false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502030, "EMP320", "Mehedi Hasan", 50000m, 502036 },
                    { 502031, "EMP321", "Ashikur Rahman", 45000m, 502036 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 2, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 3, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 4, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 5, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 6, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 7, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 8, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 9, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 10, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 11, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 12, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 13, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 14, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 15, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 16, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 17, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 18, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 19, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 20, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 21, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 22, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 23, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 24, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 25, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 26, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 27, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 28, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 29, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 30, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, true, false },
                    { 31, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 32, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 33, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 34, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 35, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 36, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, true, false, false },
                    { 37, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 38, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 39, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 40, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 41, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 42, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 43, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 44, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 45, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 46, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 47, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 48, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 49, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 50, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 51, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 52, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 53, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 54, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false },
                    { 55, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 56, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, true, false, false },
                    { 57, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 58, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 59, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true },
                    { 60, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502032, "EMP322", "Rakibul Islam", 52000m, 502030 },
                    { 502033, "EMP323", "Hasan Abdullah", 46000m, 502031 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 61, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 62, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 63, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 64, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 65, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 66, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 67, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 68, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 69, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 70, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 71, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 72, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 73, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 74, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 75, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 76, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 77, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 78, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 79, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 80, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 81, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 82, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 83, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 84, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 85, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 86, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 87, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 88, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 89, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, false, true },
                    { 90, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502032, false, true, false },
                    { 91, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 92, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 93, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 94, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 95, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 96, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, true, false, false },
                    { 97, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 98, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 99, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 100, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 101, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 102, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 103, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 104, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 105, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 106, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 107, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 108, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 109, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 110, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 111, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 112, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 113, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 114, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false },
                    { 115, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 116, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, true, false, false },
                    { 117, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 118, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 119, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, false, true },
                    { 120, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502033, false, true, false }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "EmployeeCode", "EmployeeName", "EmployeeSalary", "SupervisorId" },
                values: new object[,]
                {
                    { 502034, "EMP324", "Akib Khan", 66000m, 502032 },
                    { 502035, "EMP325", "Rasel Shikder", 53500m, 502033 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "Id", "AttendanceDate", "EmployeeId", "IsAbsent", "IsOffday", "IsPresent" },
                values: new object[,]
                {
                    { 121, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 122, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 123, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 124, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 125, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 126, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 127, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 128, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 129, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 130, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 131, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 132, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 133, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 134, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 135, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 136, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 137, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 138, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 139, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 140, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 141, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 142, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 143, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 144, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 145, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 146, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 147, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 148, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 149, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, false, true },
                    { 150, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502034, false, true, false },
                    { 151, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 152, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 153, new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 154, new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 155, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 156, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, true, false, false },
                    { 157, new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 158, new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 159, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 160, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 161, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 162, new DateTime(2023, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 163, new DateTime(2023, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 164, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 165, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 166, new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 167, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 168, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 169, new DateTime(2023, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 170, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 171, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 172, new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 173, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 174, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false },
                    { 175, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 176, new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, true, false, false },
                    { 177, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 178, new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 179, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, false, true },
                    { 180, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 502035, false, true, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAttendances_EmployeeId_AttendanceDate",
                table: "EmployeeAttendances",
                columns: new[] { "EmployeeId", "AttendanceDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeCode",
                table: "Employees",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SupervisorId",
                table: "Employees",
                column: "SupervisorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
