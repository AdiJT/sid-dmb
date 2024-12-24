using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "AktivitasDestinasiWisata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitasDestinasiWisata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtefakBudaya",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    LokasiPenyimpanan = table.Column<string>(type: "text", nullable: false),
                    Kondisi = table.Column<int>(type: "integer", nullable: false),
                    Usia = table.Column<string>(type: "text", nullable: false),
                    Bahan = table.Column<string>(type: "text", nullable: false),
                    Dimensi = table.Column<string>(type: "text", nullable: false),
                    Pengelola = table.Column<string>(type: "text", nullable: false),
                    NilaiHistoris = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    Ketersediaan = table.Column<int>(type: "integer", nullable: false),
                    RatingPengunjung = table.Column<double>(type: "double precision", nullable: false),
                    KomentarPengunjung = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtefakBudaya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataRiset",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    JudulPenelitian = table.Column<string>(type: "text", nullable: false),
                    DekripsiPenelitian = table.Column<string>(type: "text", nullable: false),
                    KategoriPenelitian = table.Column<int>(type: "integer", nullable: false),
                    EntitasPenelitian = table.Column<string>(type: "text", nullable: false),
                    TanggalMulaiPenelitian = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalSelesaiPenelitian = table.Column<DateOnly>(type: "date", nullable: false),
                    MetodePengumpulanData = table.Column<string>(type: "text", nullable: false),
                    HasilPenelitian = table.Column<string>(type: "text", nullable: false),
                    DokumenPenelitian = table.Column<string>(type: "text", nullable: false),
                    ManfaatPenelitian = table.Column<string>(type: "text", nullable: false),
                    StatusPenelitian = table.Column<int>(type: "integer", nullable: false),
                    FeedbackKolaborator = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRiset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinasiWisata",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    TitikKoordinat = table.Column<Point>(type: "geography (point)", nullable: false),
                    HargaTiketMasuk = table.Column<double>(type: "double precision", nullable: false),
                    JamOperasional = table.Column<string>(type: "text", nullable: false),
                    InformasiKontak = table.Column<string>(type: "text", nullable: false),
                    PengelolaDestinasi = table.Column<string>(type: "text", nullable: false),
                    StatusOperasional = table.Column<int>(type: "integer", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinasiWisata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    TanggalWaktu = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Lokasi = table.Column<string>(type: "text", nullable: false),
                    Penyelenggara = table.Column<string>(type: "text", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    TargetPeserta = table.Column<int>(type: "integer", nullable: false),
                    JumlahPesertaMaksimal = table.Column<int>(type: "integer", nullable: false),
                    StatusPendaftaran = table.Column<int>(type: "integer", nullable: false),
                    Sponsor = table.Column<string>(type: "text", nullable: false),
                    Anggaran = table.Column<double>(type: "double precision", nullable: false),
                    Pendapatan = table.Column<double>(type: "double precision", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fasilitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fasilitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasDestinasiWisata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasDestinasiWisata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JenisDataRiset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisDataRiset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KalenderAcara",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NamaAcara = table.Column<string>(type: "text", nullable: false),
                    DekripsiAcara = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    TanggalDanWaktu = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LokasiAcara = table.Column<string>(type: "text", nullable: false),
                    PenanggungJawab = table.Column<string>(type: "text", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    HargaTiketAcara = table.Column<double>(type: "double precision", nullable: false),
                    TargetPesertaAcara = table.Column<int>(type: "integer", nullable: false),
                    BatasKuotaPeserta = table.Column<int>(type: "integer", nullable: false),
                    StatusPendaftaran = table.Column<int>(type: "integer", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    SponsorAcara = table.Column<string>(type: "text", nullable: false),
                    TautanPendaftaran = table.Column<string>(type: "text", nullable: false),
                    RatingAcara = table.Column<double>(type: "double precision", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KalenderAcara", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KelompokPrima",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    JumlahAnggota = table.Column<int>(type: "integer", nullable: false),
                    KetuaKelompok = table.Column<string>(type: "text", nullable: false),
                    TahunBerdiri = table.Column<int>(type: "integer", nullable: false),
                    FokusKegiatan = table.Column<int>(type: "integer", nullable: false),
                    ProgramUnggulan = table.Column<string>(type: "text", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    JumlahProgramDilaksanakan = table.Column<int>(type: "integer", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KelompokPrima", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kolaborator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolaborator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorKegiatanPrima",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nama = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorKegiatanPrima", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    JudulMateri = table.Column<string>(type: "text", nullable: false),
                    DekripsiMateri = table.Column<string>(type: "text", nullable: false),
                    KategoriMateri = table.Column<int>(type: "integer", nullable: false),
                    PenyediaMateri = table.Column<string>(type: "text", nullable: false),
                    TargetAudiens = table.Column<int>(type: "integer", nullable: false),
                    TipeMateri = table.Column<int>(type: "integer", nullable: false),
                    LinkUnduhan = table.Column<string>(type: "text", nullable: false),
                    TanggalRilis = table.Column<DateOnly>(type: "date", nullable: false),
                    FeedBackAudiens = table.Column<string>(type: "text", nullable: false),
                    DokumenPendukung = table.Column<string>(type: "text", nullable: false),
                    JumlahPengguna = table.Column<int>(type: "integer", nullable: false),
                    StatusMateri = table.Column<int>(type: "integer", nullable: false),
                    RekomendasiPembaruanMateri = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelatihan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    Penyelenggara = table.Column<string>(type: "text", nullable: false),
                    TanggalPelaksanaan = table.Column<DateOnly>(type: "date", nullable: false),
                    Durasi = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Lokasi = table.Column<string>(type: "text", nullable: false),
                    TargetPeserta = table.Column<int>(type: "integer", nullable: false),
                    JumlahPeserta = table.Column<int>(type: "integer", nullable: false),
                    Fasilitator = table.Column<string>(type: "text", nullable: false),
                    Materi = table.Column<string>(type: "text", nullable: false),
                    EvaluasiPeserta = table.Column<string>(type: "text", nullable: false),
                    DokumenDanMedia = table.Column<string>(type: "text", nullable: false),
                    FeedbackPeserta = table.Column<string>(type: "text", nullable: false),
                    RekomendasiUntukPelatihanBerikutnya = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelatihan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produk",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    UnitUsahaTerkait = table.Column<string>(type: "text", nullable: false),
                    HargaProduk = table.Column<double>(type: "double precision", nullable: false),
                    StokAwal = table.Column<int>(type: "integer", nullable: false),
                    StokSaatIni = table.Column<int>(type: "integer", nullable: false),
                    StatusKetersediaan = table.Column<int>(type: "integer", nullable: false),
                    TanggalProduksiTerakhir = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalKadaluarsa = table.Column<DateOnly>(type: "date", nullable: true),
                    LegalitasProduk = table.Column<string>(type: "text", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeniBudaya",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    NamaPelakuSeni = table.Column<string>(type: "text", nullable: false),
                    LokasiPertunjukan = table.Column<string>(type: "text", nullable: false),
                    WaktuPertunjukan = table.Column<string>(type: "text", nullable: false),
                    DurasiPentunjukan = table.Column<TimeSpan>(type: "interval", nullable: false),
                    HargaTiket = table.Column<double>(type: "double precision", nullable: false),
                    PeraturanKhusus = table.Column<string>(type: "text", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    RatingPenonton = table.Column<double>(type: "double precision", nullable: false),
                    KomentarPenonton = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeniBudaya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SitusBudaya",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    KoordinatLokasi = table.Column<Point>(type: "geometry", nullable: false),
                    HargaTiketMasuk = table.Column<double>(type: "double precision", nullable: false),
                    JamOperasional = table.Column<string>(type: "text", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    FotoPromosi = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    PengelolaSitus = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PeraturanKhusus = table.Column<string>(type: "text", nullable: false),
                    KomentarPengunjung = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitusBudaya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitUsaha",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: false),
                    TitikKoordinat = table.Column<Point>(type: "geometry", nullable: false),
                    PemilikUsaha = table.Column<string>(type: "text", nullable: false),
                    JumlahKaryawan = table.Column<int>(type: "integer", nullable: false),
                    Legalitas = table.Column<int>(type: "integer", nullable: false),
                    TanggalBerdiri = table.Column<DateOnly>(type: "date", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitUsaha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpacaraBudaya",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    LokasiPelaksanaan = table.Column<string>(type: "text", nullable: false),
                    WaktuPelaksanaan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Durasi = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PihakTerlibat = table.Column<string>(type: "text", nullable: false),
                    RangkaianAcara = table.Column<string>(type: "text", nullable: false),
                    JumlahUpacara = table.Column<int>(type: "integer", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    RatingPeserta = table.Column<double>(type: "double precision", nullable: false),
                    KomentarPeserta = table.Column<string>(type: "text", nullable: false),
                    PeraturanKhusus = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpacaraBudaya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AktivitasDestinasiWisataDestinasiWisata",
                columns: table => new
                {
                    DaftarAktivitasId = table.Column<int>(type: "integer", nullable: false),
                    DaftarDestinasiWisataId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitasDestinasiWisataDestinasiWisata", x => new { x.DaftarAktivitasId, x.DaftarDestinasiWisataId });
                    table.ForeignKey(
                        name: "FK_AktivitasDestinasiWisataDestinasiWisata_AktivitasDestinasiW~",
                        column: x => x.DaftarAktivitasId,
                        principalTable: "AktivitasDestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AktivitasDestinasiWisataDestinasiWisata_DestinasiWisata_Daf~",
                        column: x => x.DaftarDestinasiWisataId,
                        principalTable: "DestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaporanKunjungan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TanggalKunjungan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    JumlahWisatawanDomestik = table.Column<int>(type: "integer", nullable: false),
                    JumlahWisatawanInternasional = table.Column<int>(type: "integer", nullable: false),
                    DurasiKunjungan = table.Column<TimeSpan>(type: "interval", nullable: false),
                    TiketTerjual = table.Column<int>(type: "integer", nullable: false),
                    RatingPengunjung = table.Column<double>(type: "double precision", nullable: false),
                    KomentarPengunjung = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DestinasiWisataId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanKunjungan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaporanKunjungan_DestinasiWisata_DestinasiWisataId",
                        column: x => x.DestinasiWisataId,
                        principalTable: "DestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaporanEvent",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TanggalPelaporan = table.Column<DateOnly>(type: "date", nullable: false),
                    PengeluaranEvent = table.Column<double>(type: "double precision", nullable: false),
                    UlasanSingkatEvent = table.Column<string>(type: "text", nullable: false),
                    FeedbackPeserta = table.Column<string>(type: "text", nullable: false),
                    FotoDokumentasi = table.Column<string>(type: "text", nullable: false),
                    VideoDokumentasi = table.Column<string>(type: "text", nullable: false),
                    LaporanDetail = table.Column<string>(type: "text", nullable: false),
                    MasukanKolaborator = table.Column<string>(type: "text", nullable: false),
                    RekomendasiUntukEventBerikutnya = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaporanEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaporanEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DestinasiWisataFasilitasDestinasiWisata",
                columns: table => new
                {
                    DaftarDestinasiWisataId = table.Column<string>(type: "text", nullable: false),
                    DaftarFasilitasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinasiWisataFasilitasDestinasiWisata", x => new { x.DaftarDestinasiWisataId, x.DaftarFasilitasId });
                    table.ForeignKey(
                        name: "FK_DestinasiWisataFasilitasDestinasiWisata_DestinasiWisata_Daf~",
                        column: x => x.DaftarDestinasiWisataId,
                        principalTable: "DestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinasiWisataFasilitasDestinasiWisata_FasilitasDestinasiW~",
                        column: x => x.DaftarFasilitasId,
                        principalTable: "FasilitasDestinasiWisata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataRisetJenisDataRiset",
                columns: table => new
                {
                    DaftarDataRisetId = table.Column<string>(type: "text", nullable: false),
                    DaftarJenisDataRisetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRisetJenisDataRiset", x => new { x.DaftarDataRisetId, x.DaftarJenisDataRisetId });
                    table.ForeignKey(
                        name: "FK_DataRisetJenisDataRiset_DataRiset_DaftarDataRisetId",
                        column: x => x.DaftarDataRisetId,
                        principalTable: "DataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRisetJenisDataRiset_JenisDataRiset_DaftarJenisDataRiset~",
                        column: x => x.DaftarJenisDataRisetId,
                        principalTable: "JenisDataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KegiatanPrima",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    TanggalPelaksanaan = table.Column<DateOnly>(type: "date", nullable: false),
                    Durasi = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Lokasi = table.Column<string>(type: "text", nullable: false),
                    Jenis = table.Column<int>(type: "integer", nullable: false),
                    JumlahPeserta = table.Column<int>(type: "integer", nullable: false),
                    Fasilitator = table.Column<string>(type: "text", nullable: false),
                    AnggaranKegiatan = table.Column<double>(type: "double precision", nullable: false),
                    HasilKegiatan = table.Column<string>(type: "text", nullable: false),
                    DokumentasiKegiatan = table.Column<string>(type: "text", nullable: false),
                    FeedbackPeserta = table.Column<string>(type: "text", nullable: false),
                    RekomendasiUntukKegiatanBerikutnya = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    KelompokPrimaId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KegiatanPrima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KegiatanPrima_KelompokPrima_KelompokPrimaId",
                        column: x => x.KelompokPrimaId,
                        principalTable: "KelompokPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataRisetKolaborator",
                columns: table => new
                {
                    DaftarDataRisetId = table.Column<string>(type: "text", nullable: false),
                    DaftarKolaboratorPenelitianId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRisetKolaborator", x => new { x.DaftarDataRisetId, x.DaftarKolaboratorPenelitianId });
                    table.ForeignKey(
                        name: "FK_DataRisetKolaborator_DataRiset_DaftarDataRisetId",
                        column: x => x.DaftarDataRisetId,
                        principalTable: "DataRiset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataRisetKolaborator_Kolaborator_DaftarKolaboratorPenelitia~",
                        column: x => x.DaftarKolaboratorPenelitianId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventKolaborator",
                columns: table => new
                {
                    DaftarEventId = table.Column<string>(type: "text", nullable: false),
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventKolaborator", x => new { x.DaftarEventId, x.DaftarKolaboratorId });
                    table.ForeignKey(
                        name: "FK_EventKolaborator_Event_DaftarEventId",
                        column: x => x.DaftarEventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventKolaborator_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorMateri",
                columns: table => new
                {
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false),
                    DaftarMateriId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorMateri", x => new { x.DaftarKolaboratorId, x.DaftarMateriId });
                    table.ForeignKey(
                        name: "FK_KolaboratorMateri_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorMateri_Materi_DaftarMateriId",
                        column: x => x.DaftarMateriId,
                        principalTable: "Materi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorPelatihan",
                columns: table => new
                {
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false),
                    DaftarPelatihanId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorPelatihan", x => new { x.DaftarKolaboratorId, x.DaftarPelatihanId });
                    table.ForeignKey(
                        name: "FK_KolaboratorPelatihan_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorPelatihan_Pelatihan_DaftarPelatihanId",
                        column: x => x.DaftarPelatihanId,
                        principalTable: "Pelatihan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distribusi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    JumlahProduk = table.Column<int>(type: "integer", nullable: false),
                    TanggalPengiriman = table.Column<DateOnly>(type: "date", nullable: false),
                    AlamatTujuan = table.Column<string>(type: "text", nullable: false),
                    NamaDistributor = table.Column<string>(type: "text", nullable: false),
                    KontakDistributor = table.Column<string>(type: "text", nullable: false),
                    BiayaPengiriman = table.Column<double>(type: "double precision", nullable: false),
                    DokumenPengiriman = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProdukId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribusi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distribusi_Produk_ProdukId",
                        column: x => x.ProdukId,
                        principalTable: "Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorProduk",
                columns: table => new
                {
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false),
                    DaftarProdukId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorProduk", x => new { x.DaftarKolaboratorId, x.DaftarProdukId });
                    table.ForeignKey(
                        name: "FK_KolaboratorProduk_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorProduk_Produk_DaftarProdukId",
                        column: x => x.DaftarProdukId,
                        principalTable: "Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rekomendasi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Judul = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    TujuanPengembangan = table.Column<string>(type: "text", nullable: false),
                    PemberiRekomendasi = table.Column<string>(type: "text", nullable: false),
                    KategoriPengembangan = table.Column<int>(type: "integer", nullable: false),
                    StrategiYangDirekomendasikan = table.Column<string>(type: "text", nullable: false),
                    TimelineRekomendasi = table.Column<string>(type: "text", nullable: false),
                    Anggaran = table.Column<double>(type: "double precision", nullable: false),
                    HasilYangDiharapkan = table.Column<string>(type: "text", nullable: false),
                    StatusImplementasi = table.Column<int>(type: "integer", nullable: false),
                    FeedbackKolaborator = table.Column<string>(type: "text", nullable: false),
                    DokumenPendukung = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProdukTerkaitId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rekomendasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rekomendasi_Produk_ProdukTerkaitId",
                        column: x => x.ProdukTerkaitId,
                        principalTable: "Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sertifikasi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    JenisSertifikasi = table.Column<int>(type: "integer", nullable: false),
                    NomorSertifikasi = table.Column<string>(type: "text", nullable: false),
                    TanggalPenerbitan = table.Column<DateOnly>(type: "date", nullable: false),
                    TanggalKadaluarsa = table.Column<DateOnly>(type: "date", nullable: false),
                    PemberiSertifikat = table.Column<string>(type: "text", nullable: false),
                    DokumenSertifikat = table.Column<string>(type: "text", nullable: false),
                    ProsesYangDilalui = table.Column<string>(type: "text", nullable: false),
                    StatusSertifikasi = table.Column<int>(type: "integer", nullable: false),
                    Komentar = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProdukId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sertifikasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sertifikasi_Produk_ProdukId",
                        column: x => x.ProdukId,
                        principalTable: "Produk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasSeniBudaya",
                columns: table => new
                {
                    DaftarSeniBudayaId = table.Column<string>(type: "text", nullable: false),
                    FasilitasPertunjukanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasSeniBudaya", x => new { x.DaftarSeniBudayaId, x.FasilitasPertunjukanId });
                    table.ForeignKey(
                        name: "FK_FasilitasSeniBudaya_Fasilitas_FasilitasPertunjukanId",
                        column: x => x.FasilitasPertunjukanId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasSeniBudaya_SeniBudaya_DaftarSeniBudayaId",
                        column: x => x.DaftarSeniBudayaId,
                        principalTable: "SeniBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasSitusBudaya",
                columns: table => new
                {
                    DaftarFasilitasId = table.Column<int>(type: "integer", nullable: false),
                    DaftarSitusBudayaId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasSitusBudaya", x => new { x.DaftarFasilitasId, x.DaftarSitusBudayaId });
                    table.ForeignKey(
                        name: "FK_FasilitasSitusBudaya_Fasilitas_DaftarFasilitasId",
                        column: x => x.DaftarFasilitasId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasSitusBudaya_SitusBudaya_DaftarSitusBudayaId",
                        column: x => x.DaftarSitusBudayaId,
                        principalTable: "SitusBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdukLokal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nama = table.Column<string>(type: "text", nullable: false),
                    Dekripsi = table.Column<string>(type: "text", nullable: false),
                    Kategori = table.Column<int>(type: "integer", nullable: false),
                    Harga = table.Column<double>(type: "double precision", nullable: false),
                    BahanUtama = table.Column<string>(type: "text", nullable: false),
                    StatusKetersediaan = table.Column<int>(type: "integer", nullable: false),
                    TanggalProduksiTerakhir = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalKadaluarsa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LegalitasDanSertifikat = table.Column<string>(type: "text", nullable: false),
                    KontakInformasi = table.Column<string>(type: "text", nullable: false),
                    MediaPromosi = table.Column<string>(type: "text", nullable: false),
                    TanggalDiinputkan = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TanggalPembaruanData = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UnitUsahaId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdukLokal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdukLokal_UnitUsaha_UnitUsahaId",
                        column: x => x.UnitUsahaId,
                        principalTable: "UnitUsaha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FasilitasUpacaraBudaya",
                columns: table => new
                {
                    DaftarUpacaraBudayaId = table.Column<string>(type: "text", nullable: false),
                    FasilitasPendukungId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FasilitasUpacaraBudaya", x => new { x.DaftarUpacaraBudayaId, x.FasilitasPendukungId });
                    table.ForeignKey(
                        name: "FK_FasilitasUpacaraBudaya_Fasilitas_FasilitasPendukungId",
                        column: x => x.FasilitasPendukungId,
                        principalTable: "Fasilitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FasilitasUpacaraBudaya_UpacaraBudaya_DaftarUpacaraBudayaId",
                        column: x => x.DaftarUpacaraBudayaId,
                        principalTable: "UpacaraBudaya",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KegiatanPrimaKolaboratorKegiatanPrima",
                columns: table => new
                {
                    DaftarKegiatanPrimaId = table.Column<string>(type: "text", nullable: false),
                    KolaboratorKegiatanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KegiatanPrimaKolaboratorKegiatanPrima", x => new { x.DaftarKegiatanPrimaId, x.KolaboratorKegiatanId });
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaboratorKegiatanPrima_KegiatanPrima_DaftarK~",
                        column: x => x.DaftarKegiatanPrimaId,
                        principalTable: "KegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KegiatanPrimaKolaboratorKegiatanPrima_KolaboratorKegiatanPr~",
                        column: x => x.KolaboratorKegiatanId,
                        principalTable: "KolaboratorKegiatanPrima",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistribusiKolaborator",
                columns: table => new
                {
                    DaftarDistribusiId = table.Column<string>(type: "text", nullable: false),
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribusiKolaborator", x => new { x.DaftarDistribusiId, x.DaftarKolaboratorId });
                    table.ForeignKey(
                        name: "FK_DistribusiKolaborator_Distribusi_DaftarDistribusiId",
                        column: x => x.DaftarDistribusiId,
                        principalTable: "Distribusi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistribusiKolaborator_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorRekomendasi",
                columns: table => new
                {
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false),
                    DaftarRekomendasiId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorRekomendasi", x => new { x.DaftarKolaboratorId, x.DaftarRekomendasiId });
                    table.ForeignKey(
                        name: "FK_KolaboratorRekomendasi_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorRekomendasi_Rekomendasi_DaftarRekomendasiId",
                        column: x => x.DaftarRekomendasiId,
                        principalTable: "Rekomendasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KolaboratorSertifikasi",
                columns: table => new
                {
                    DaftarKolaboratorId = table.Column<int>(type: "integer", nullable: false),
                    DaftarSertifikasiId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KolaboratorSertifikasi", x => new { x.DaftarKolaboratorId, x.DaftarSertifikasiId });
                    table.ForeignKey(
                        name: "FK_KolaboratorSertifikasi_Kolaborator_DaftarKolaboratorId",
                        column: x => x.DaftarKolaboratorId,
                        principalTable: "Kolaborator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KolaboratorSertifikasi_Sertifikasi_DaftarSertifikasiId",
                        column: x => x.DaftarSertifikasiId,
                        principalTable: "Sertifikasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktivitasDestinasiWisataDestinasiWisata_DaftarDestinasiWisa~",
                table: "AktivitasDestinasiWisataDestinasiWisata",
                column: "DaftarDestinasiWisataId");

            migrationBuilder.CreateIndex(
                name: "IX_DataRisetJenisDataRiset_DaftarJenisDataRisetId",
                table: "DataRisetJenisDataRiset",
                column: "DaftarJenisDataRisetId");

            migrationBuilder.CreateIndex(
                name: "IX_DataRisetKolaborator_DaftarKolaboratorPenelitianId",
                table: "DataRisetKolaborator",
                column: "DaftarKolaboratorPenelitianId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinasiWisataFasilitasDestinasiWisata_DaftarFasilitasId",
                table: "DestinasiWisataFasilitasDestinasiWisata",
                column: "DaftarFasilitasId");

            migrationBuilder.CreateIndex(
                name: "IX_Distribusi_ProdukId",
                table: "Distribusi",
                column: "ProdukId");

            migrationBuilder.CreateIndex(
                name: "IX_DistribusiKolaborator_DaftarKolaboratorId",
                table: "DistribusiKolaborator",
                column: "DaftarKolaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventKolaborator_DaftarKolaboratorId",
                table: "EventKolaborator",
                column: "DaftarKolaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasSeniBudaya_FasilitasPertunjukanId",
                table: "FasilitasSeniBudaya",
                column: "FasilitasPertunjukanId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasSitusBudaya_DaftarSitusBudayaId",
                table: "FasilitasSitusBudaya",
                column: "DaftarSitusBudayaId");

            migrationBuilder.CreateIndex(
                name: "IX_FasilitasUpacaraBudaya_FasilitasPendukungId",
                table: "FasilitasUpacaraBudaya",
                column: "FasilitasPendukungId");

            migrationBuilder.CreateIndex(
                name: "IX_KegiatanPrima_KelompokPrimaId",
                table: "KegiatanPrima",
                column: "KelompokPrimaId");

            migrationBuilder.CreateIndex(
                name: "IX_KegiatanPrimaKolaboratorKegiatanPrima_KolaboratorKegiatanId",
                table: "KegiatanPrimaKolaboratorKegiatanPrima",
                column: "KolaboratorKegiatanId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorMateri_DaftarMateriId",
                table: "KolaboratorMateri",
                column: "DaftarMateriId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorPelatihan_DaftarPelatihanId",
                table: "KolaboratorPelatihan",
                column: "DaftarPelatihanId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorProduk_DaftarProdukId",
                table: "KolaboratorProduk",
                column: "DaftarProdukId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorRekomendasi_DaftarRekomendasiId",
                table: "KolaboratorRekomendasi",
                column: "DaftarRekomendasiId");

            migrationBuilder.CreateIndex(
                name: "IX_KolaboratorSertifikasi_DaftarSertifikasiId",
                table: "KolaboratorSertifikasi",
                column: "DaftarSertifikasiId");

            migrationBuilder.CreateIndex(
                name: "IX_LaporanEvent_EventId",
                table: "LaporanEvent",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaporanKunjungan_DestinasiWisataId",
                table: "LaporanKunjungan",
                column: "DestinasiWisataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdukLokal_UnitUsahaId",
                table: "ProdukLokal",
                column: "UnitUsahaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rekomendasi_ProdukTerkaitId",
                table: "Rekomendasi",
                column: "ProdukTerkaitId");

            migrationBuilder.CreateIndex(
                name: "IX_Sertifikasi_ProdukId",
                table: "Sertifikasi",
                column: "ProdukId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktivitasDestinasiWisataDestinasiWisata");

            migrationBuilder.DropTable(
                name: "ArtefakBudaya");

            migrationBuilder.DropTable(
                name: "DataRisetJenisDataRiset");

            migrationBuilder.DropTable(
                name: "DataRisetKolaborator");

            migrationBuilder.DropTable(
                name: "DestinasiWisataFasilitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "DistribusiKolaborator");

            migrationBuilder.DropTable(
                name: "EventKolaborator");

            migrationBuilder.DropTable(
                name: "FasilitasSeniBudaya");

            migrationBuilder.DropTable(
                name: "FasilitasSitusBudaya");

            migrationBuilder.DropTable(
                name: "FasilitasUpacaraBudaya");

            migrationBuilder.DropTable(
                name: "KalenderAcara");

            migrationBuilder.DropTable(
                name: "KegiatanPrimaKolaboratorKegiatanPrima");

            migrationBuilder.DropTable(
                name: "KolaboratorMateri");

            migrationBuilder.DropTable(
                name: "KolaboratorPelatihan");

            migrationBuilder.DropTable(
                name: "KolaboratorProduk");

            migrationBuilder.DropTable(
                name: "KolaboratorRekomendasi");

            migrationBuilder.DropTable(
                name: "KolaboratorSertifikasi");

            migrationBuilder.DropTable(
                name: "LaporanEvent");

            migrationBuilder.DropTable(
                name: "LaporanKunjungan");

            migrationBuilder.DropTable(
                name: "ProdukLokal");

            migrationBuilder.DropTable(
                name: "AktivitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "JenisDataRiset");

            migrationBuilder.DropTable(
                name: "DataRiset");

            migrationBuilder.DropTable(
                name: "FasilitasDestinasiWisata");

            migrationBuilder.DropTable(
                name: "Distribusi");

            migrationBuilder.DropTable(
                name: "SeniBudaya");

            migrationBuilder.DropTable(
                name: "SitusBudaya");

            migrationBuilder.DropTable(
                name: "Fasilitas");

            migrationBuilder.DropTable(
                name: "UpacaraBudaya");

            migrationBuilder.DropTable(
                name: "KegiatanPrima");

            migrationBuilder.DropTable(
                name: "KolaboratorKegiatanPrima");

            migrationBuilder.DropTable(
                name: "Materi");

            migrationBuilder.DropTable(
                name: "Pelatihan");

            migrationBuilder.DropTable(
                name: "Rekomendasi");

            migrationBuilder.DropTable(
                name: "Kolaborator");

            migrationBuilder.DropTable(
                name: "Sertifikasi");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "DestinasiWisata");

            migrationBuilder.DropTable(
                name: "UnitUsaha");

            migrationBuilder.DropTable(
                name: "KelompokPrima");

            migrationBuilder.DropTable(
                name: "Produk");
        }
    }
}
