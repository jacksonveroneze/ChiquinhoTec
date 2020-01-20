using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChiquinhoTec.GerenciadorContratacao.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity_audit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
                    rev = table.Column<string>(type: "varchar(3)", nullable: false),
                    entity_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_audit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
                    postal_code = table.Column<string>(type: "varchar(9)", nullable: false),
                    state = table.Column<string>(type: "varchar(2)", nullable: false),
                    city = table.Column<string>(type: "varchar(100)", nullable: false),
                    district = table.Column<string>(type: "varchar(100)", nullable: false),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    street_number = table.Column<int>(type: "integer", nullable: false),
                    complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    primary_address = table.Column<bool>(type: "boolean", nullable: false),
                    person_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "interview",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "null"),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
                    scheduling_date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    squad = table.Column<int>(type: "integer", nullable: false),
                    person_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interview", x => x.id);
                    table.ForeignKey(
                        name: "FK_interview_person_person_id",
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
                name: "IX_person_cpf",
                table: "person",
                column: "cpf");

            migrationBuilder.CreateIndex(
                name: "IX_person_email",
                table: "person",
                column: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "entity_audit");

            migrationBuilder.DropTable(
                name: "interview");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
