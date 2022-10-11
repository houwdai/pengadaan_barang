using Microsoft.EntityFrameworkCore.Migrations;

namespace Client.Migrations
{
    public partial class Seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "divisi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    AnggaraanTetap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "satuan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_satuan", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    alamat = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    kota = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telepon = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namaProduk = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    idSatuan = table.Column<int>(nullable: true),
                    hargaProduct = table.Column<int>(nullable: true),
                    stockProduct = table.Column<int>(nullable: true),
                    idSupplier = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK__Product__idSatua__37A5467C",
                        column: x => x.idSatuan,
                        principalTable: "satuan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Product__idSuppl__38996AB5",
                        column: x => x.idSupplier,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pengadaan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pengaadan_GUID = table.Column<string>(unicode: false, maxLength: 9, nullable: true, computedColumnSql: "('SPB-'+right(replicate('0',(8))+CONVERT([varchar],[id]),(5)))"),
                    idBarang = table.Column<int>(nullable: true),
                    idSupplier = table.Column<int>(nullable: true),
                    kuantitas = table.Column<int>(nullable: true),
                    totals = table.Column<int>(nullable: true),
                    idDivisi = table.Column<int>(nullable: true),
                    idStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pengadaan", x => x.id);
                    table.ForeignKey(
                        name: "FK__pengadaan__idBar__3C69FB99",
                        column: x => x.idBarang,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__pengadaan__idDiv__3B75D760",
                        column: x => x.idDivisi,
                        principalTable: "divisi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__pengadaan__idSta__3E52440B",
                        column: x => x.idStatus,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__pengadaan__idSup__3D5E1FD2",
                        column: x => x.idSupplier,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "satuan",
                columns: new[] { "id", "nama" },
                values: new object[,]
                {
                    { 1, "Pack" },
                    { 2, "Pcs" },
                    { 3, "Lusin" },
                    { 4, "Set" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Awaiting" },
                    { 2, "Accepted by Manajer Bagian" },
                    { 3, "Accepted by Manajer Keuangan" },
                    { 4, "Reject" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pengadaan_idBarang",
                table: "pengadaan",
                column: "idBarang");

            migrationBuilder.CreateIndex(
                name: "IX_pengadaan_idDivisi",
                table: "pengadaan",
                column: "idDivisi");

            migrationBuilder.CreateIndex(
                name: "IX_pengadaan_idStatus",
                table: "pengadaan",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "IX_pengadaan_idSupplier",
                table: "pengadaan",
                column: "idSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idSatuan",
                table: "Product",
                column: "idSatuan");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idSupplier",
                table: "Product",
                column: "idSupplier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pengadaan");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "divisi");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "satuan");

            migrationBuilder.DropTable(
                name: "supplier");
        }
    }
}
