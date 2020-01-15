using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    version = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    profile = table.Column<string>(type: "varchar(100)", nullable: false),
                    professional_description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    version = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "1"),
                    postal_code = table.Column<string>(type: "varchar(9)", nullable: false),
                    state = table.Column<string>(type: "varchar(2)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    district = table.Column<string>(type: "varchar(100)", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    street_number = table.Column<int>(type: "integer", nullable: false),
                    complement = table.Column<string>(type: "varchar(100)", nullable: false),
                    primary_address = table.Column<bool>(type: "boolean", nullable: false),
                    person_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "fk_adress_person",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamptz", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValueSql: "true"),
                    version = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "1"),
                    date = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "null"),
                    schedule = table.Column<TimeSpan>(type: "time", nullable: false, defaultValueSql: "null"),
                    squad = table.Column<string>(type: "varchar(100)", nullable: false),
                    person_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interview", x => x.id);
                    table.ForeignKey(
                        name: "fk_interview_person",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_person_id",
                table: "address",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_interview_person_id",
                table: "interview",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "uk_person_cpf",
                table: "person",
                column: "cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "uk_person_email",
                table: "person",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "interview");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
