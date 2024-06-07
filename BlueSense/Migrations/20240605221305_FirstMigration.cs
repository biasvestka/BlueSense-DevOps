using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueSense.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Navios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IMO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Navios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Rotas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Origem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Destino = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Rotas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Sensores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NavioID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Sensores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_Sensores_Tb_Navios_NavioID",
                        column: x => x.NavioID,
                        principalTable: "Tb_Navios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tb_LeiturasSensores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Protocolo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Local = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NavioID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RotaID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_LeiturasSensores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_LeiturasSensores_Tb_Navios_NavioID",
                        column: x => x.NavioID,
                        principalTable: "Tb_Navios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tb_LeiturasSensores_Tb_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Tb_Rotas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tb_NavioRotas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NavioID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RotaID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_NavioRotas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_NavioRotas_Tb_Navios_NavioID",
                        column: x => x.NavioID,
                        principalTable: "Tb_Navios",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tb_NavioRotas_Tb_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Tb_Rotas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tb_UsuariosAutoridade",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Departamento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_UsuariosAutoridade", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_UsuariosAutoridade_Tb_Usuarios_ID",
                        column: x => x.ID,
                        principalTable: "Tb_Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Notificacoes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UsuarioAutoridadeID = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LeituraSensorID = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Notificacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tb_Notificacoes_Tb_LeiturasSensores_LeituraSensorID",
                        column: x => x.LeituraSensorID,
                        principalTable: "Tb_LeiturasSensores",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tb_Notificacoes_Tb_UsuariosAutoridade_UsuarioAutoridadeID",
                        column: x => x.UsuarioAutoridadeID,
                        principalTable: "Tb_UsuariosAutoridade",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_LeiturasSensores_NavioID",
                table: "Tb_LeiturasSensores",
                column: "NavioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_LeiturasSensores_RotaID",
                table: "Tb_LeiturasSensores",
                column: "RotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_NavioRotas_NavioID",
                table: "Tb_NavioRotas",
                column: "NavioID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_NavioRotas_RotaID",
                table: "Tb_NavioRotas",
                column: "RotaID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Notificacoes_LeituraSensorID",
                table: "Tb_Notificacoes",
                column: "LeituraSensorID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Notificacoes_UsuarioAutoridadeID",
                table: "Tb_Notificacoes",
                column: "UsuarioAutoridadeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Sensores_NavioID",
                table: "Tb_Sensores",
                column: "NavioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_NavioRotas");

            migrationBuilder.DropTable(
                name: "Tb_Notificacoes");

            migrationBuilder.DropTable(
                name: "Tb_Sensores");

            migrationBuilder.DropTable(
                name: "Tb_LeiturasSensores");

            migrationBuilder.DropTable(
                name: "Tb_UsuariosAutoridade");

            migrationBuilder.DropTable(
                name: "Tb_Navios");

            migrationBuilder.DropTable(
                name: "Tb_Rotas");

            migrationBuilder.DropTable(
                name: "Tb_Usuarios");
        }
    }
}
