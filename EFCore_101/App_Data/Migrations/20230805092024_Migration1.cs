using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_101.App_Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ilceler",
                columns: table => new
                {
                    IlceKod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ilce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlKod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.IlceKod);
                });

            migrationBuilder.CreateTable(
                name: "Iller",
                columns: table => new
                {
                    IlKod = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Il = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.IlKod);
                });

            migrationBuilder.CreateTable(
                name: "Mahalleler",
                columns: table => new
                {
                    MahalleKod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mahalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostaKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlceKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SbbKod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalleler", x => x.MahalleKod);
                });

            migrationBuilder.CreateTable(
                name: "SBBler",
                columns: table => new
                {
                    SbbKod = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SemtBucakBelde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlKod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IlceKod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SBBler", x => x.SbbKod);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Area = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { 1, "Baden-Wurttemberg" },
                    { 2, "Bavaria" },
                    { 3, "Berlin" },
                    { 4, "Brandenburg" },
                    { 5, "Bremen" },
                    { 6, "Hamburg" },
                    { 7, "Hesse" },
                    { 8, "Lower Saxony" },
                    { 9, "Mecklenburg-Vorpommern" },
                    { 10, "North Rhine-Westphalia" },
                    { 11, "Rhineland-Palatinate" },
                    { 12, "Saarland" },
                    { 13, "Saxony" },
                    { 14, "Saxony-Anhalt" },
                    { 15, "Schleswig-Holstein" },
                    { 16, "Thuringia" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Area", "CityName", "Population", "StateId" },
                values: new object[,]
                {
                    { 1, 887.7m, "Berlin", 3460725m, 3 },
                    { 2, 755.16m, "Hamburg", 1786448m, 6 },
                    { 3, 310.69m, "Munich / Munchen", 1353186m, 2 },
                    { 4, 405.17m, "Cologne / Koln", 1007119m, 10 },
                    { 5, 248.31m, "Frankfurt am Main", 679664m, 7 },
                    { 6, 207.35m, "Stuttgart", 606588m, 1 },
                    { 7, 217.22m, "Dusseldorf", 588735m, 10 },
                    { 8, 280.71m, "Dortmund", 580444m, 10 },
                    { 9, 210.32m, "Essen", 574635m, 10 },
                    { 10, 325.42m, "Bremen", 547340m, 5 },
                    { 11, 328.31m, "Dresden", 523058m, 13 },
                    { 12, 297.36m, "Leipzig", 522883m, 13 },
                    { 13, 204.14m, "Hanover / Hannover", 522686m, 8 },
                    { 14, 186.38m, "Nuremberg / Nurnberg", 505664m, 2 },
                    { 15, 232.83m, "Duisburg", 489599m, 10 },
                    { 16, 145.66m, "Bochum", 374737m, 10 },
                    { 17, 168.39m, "Wuppertal", 349721m, 10 },
                    { 18, 141.22m, "Bonn", 324899m, 10 },
                    { 19, 257.92m, "Bielefeld", 323270m, 10 },
                    { 20, 144.96m, "Mannheim", 313174m, 1 },
                    { 21, 173.46m, "Karlsruhe", 294761m, 1 },
                    { 22, 302.96m, "Munster", 279803m, 10 },
                    { 23, 203.93m, "Wiesbaden", 275976m, 7 },
                    { 24, 146.84m, "Augsburg", 264708m, 2 },
                    { 25, 160.84m, "Aachen", 258664m, 10 },
                    { 26, 170.45m, "Monchengladbach", 257993m, 10 },
                    { 27, 104.94m, "Gelsenkirchen", 257981m, 10 },
                    { 28, 192.15m, "Brunswick / Braunschweig", 248867m, 8 },
                    { 29, 220.84m, "Chemnitz", 243248m, 13 },
                    { 30, 118.65m, "Kiel", 239526m, 15 },
                    { 31, 137.75m, "Krefeld", 235076m, 10 },
                    { 32, 135.02m, "Halle", 232963m, 14 },
                    { 33, 200.99m, "Magdeburg", 231549m, 14 },
                    { 34, 153.06m, "Freiburg", 224191m, 1 },
                    { 35, 77.11m, "Oberhausen", 212945m, 10 },
                    { 36, 214.21m, "Lübeck", 210232m, 15 },
                    { 37, 269.14m, "Erfurt", 204994m, 16 },
                    { 38, 181.26m, "Rostock", 202735m, 9 },
                    { 39, 97.74m, "Mainz", 199237m, 11 },
                    { 40, 106.78m, "Kassel", 195530m, 7 },
                    { 41, 160.35m, "Hagen", 188529m, 10 },
                    { 42, 226.25m, "Hamm", 181783m, 10 },
                    { 43, 167.09m, "Saarbrucken", 175741m, 12 },
                    { 44, 91.29m, "Mulheim", 167344m, 10 },
                    { 45, 51.41m, "Herne", 164762m, 10 },
                    { 46, 77.55m, "Ludwigshafen", 164177m, 11 },
                    { 47, 119.8m, "Osnabruck", 164119m, 8 },
                    { 48, 102.98m, "Oldenburg", 162173m, 8 },
                    { 49, 78.87m, "Leverkusen", 160772m, 10 },
                    { 50, 89.54m, "Solingen", 159927m, 10 },
                    { 51, 187.53m, "Potsdam", 156906m, 4 },
                    { 52, 99.53m, "Neuss", 151388m, 10 },
                    { 53, 108.83m, "Heidelberg", 147312m, 1 },
                    { 54, 179.51m, "Paderborn", 146283m, 10 },
                    { 55, 122.09m, "Darmstadt", 144402m, 7 },
                    { 56, 80.7m, "Regensburg", 135520m, 2 },
                    { 57, 87.63m, "Wurzburg", 133799m, 2 },
                    { 58, 133.37m, "Ingolstadt", 125088m, 2 },
                    { 59, 99.88m, "Heilbronn", 122879m, 1 },
                    { 60, 118.69m, "Ulm", 122801m, 1 },
                    { 61, 204.05m, "Wolfsburg", 121451m, 8 },
                    { 62, 116.89m, "Gottingen", 121060m, 8 },
                    { 63, 44.89m, "Offenbach", 120435m, 7 },
                    { 64, 98m, "Pforzheim", 119781m, 1 },
                    { 65, 66.43m, "Recklinghausen", 118365m, 10 },
                    { 66, 100.61m, "Bottrop", 116771m, 10 },
                    { 67, 63.35m, "Furth", 114628m, 2 },
                    { 68, 93.82m, "Bremerhaven", 113366m, 5 },
                    { 69, 87.06m, "Reutlingen", 112484m, 1 },
                    { 70, 74.6m, "Remscheid", 110563m, 10 },
                    { 71, 105.05m, "Koblenz", 106417m, 11 },
                    { 72, 83.11m, "Bergisch Gladbach", 105723m, 10 },
                    { 73, 76.95m, "Erlangen", 105629m, 2 },
                    { 74, 67.69m, "Moers", 105506m, 10 },
                    { 75, 117.13m, "Trier", 105260m, 11 },
                    { 76, 114.47m, "Jena", 105129m, 16 },
                    { 77, 114.67m, "Siegen", 103424m, 10 },
                    { 78, 92.18m, "Hildesheim", 102794m, 8 },
                    { 79, 223.91m, "Salzgitter", 102394m, 8 },
                    { 80, 164.29m, "Cottbus", 102091m, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Iller_IlKod",
                table: "Iller",
                column: "IlKod",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Ilceler");

            migrationBuilder.DropTable(
                name: "Iller");

            migrationBuilder.DropTable(
                name: "Mahalleler");

            migrationBuilder.DropTable(
                name: "SBBler");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
