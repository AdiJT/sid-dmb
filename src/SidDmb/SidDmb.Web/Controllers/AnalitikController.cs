using Microsoft.AspNetCore.Mvc;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;
using System.Globalization;

namespace SidDmb.Web.Controllers;

public class AnalitikController : Controller
{
    private readonly IRepositoriLaporanKunjungan _repositoriLaporanKunjungan;

    public AnalitikController(IRepositoriLaporanKunjungan repositoriLaporanKunjungan)
    {
        _repositoriLaporanKunjungan = repositoriLaporanKunjungan;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/analitik/kunjungan-per-jenis")]
    public async Task<IActionResult> KunjunganPerJenis()
    {
        var daftarKunjungan = await _repositoriLaporanKunjungan.GetAll();
        var dictionary = new Dictionary<KategoriDestinasi, int>();

        foreach (var kategori in Enum.GetValues<KategoriDestinasi>())
        {
            dictionary[kategori] = daftarKunjungan.Where(x => x.DestinasiWisata.Kategori == kategori).Sum(x => x.JumlahWisatawanDomestik + x.JumlahWisatawanInternasional);
        }

        return Json(dictionary);
    }

    [HttpGet("/analitik/kunjungan-per-tahun")]
    public async Task<IActionResult> KunjunganPerTahun()
    {
        var daftarKunjungan = await _repositoriLaporanKunjungan.GetAll();
        var dictionary = new Dictionary<int, int>(
            daftarKunjungan
                .GroupBy(x => x.TanggalKunjungan.Year)
                .OrderBy(x => x.Key)
                .Select(x => new KeyValuePair<int, int>(x.Key, x.Sum(x => x.JumlahWisatawanDomestik + x.JumlahWisatawanInternasional)))
        );

        return Json(dictionary);
    }

    [HttpGet("/analitik/kunjungan-per-bulan")]
    public async Task<IActionResult> KunjunganPerBulan()
    {
        var year = DateTime.Now.Year;
        var cultureInfo = new CultureInfo("id-ID");

        var daftarKunjungan = await _repositoriLaporanKunjungan.GetAll();
        var dictionary = new Dictionary<string, int>();

        for (int i = 1; i <= 12; i++)
        {
            var jumlahKunjungan = daftarKunjungan.Where(x => x.TanggalKunjungan.Month == i).Sum(x => x.JumlahWisatawanDomestik + x.JumlahWisatawanInternasional);
            dictionary[cultureInfo.DateTimeFormat.GetMonthName(i)] = jumlahKunjungan;
        }

        return Json(dictionary);
    }

    [HttpGet("/analitik/kunjungan-per-minggu")]
    public async Task<IActionResult> KunjunganPerMinggu()
    {
        var daftarKunjungan = await _repositoriLaporanKunjungan.GetAll();
        var dictionary = new Dictionary<string, int>();
        var now = DateTime.Now;
        var cultureInfo = new CultureInfo("id-ID");
        var start = new DateOnly(now.Year, now.Month, 1);

        while(start.Month == now.Month)
        {
            var end = start.AddDays(6);
            if (end.Month != now.Month) break;

            var jumlahKunjungan = daftarKunjungan
                .Where(x => x.TanggalKunjungan >= start && x.TanggalKunjungan <= end)
                .Sum(x => x.JumlahWisatawanDomestik + x.JumlahWisatawanInternasional);

            dictionary.Add($"{start.Day}-{end.Day} {cultureInfo.DateTimeFormat.GetMonthName(now.Month)}", jumlahKunjungan);
            start = end.AddDays(1);
        }

        return Json(dictionary);
    }
}