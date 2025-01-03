﻿using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

public class LaporanEvent : Entity<IdLaporanEvent>, IAuditableEntity
{
    public required DateOnly TanggalPelaporan { get; set; }
    public required double PendapatanEvent { get; set; }
    public required double PengeluaranEvent { get; set; }
    public required int JumlahPeserta { get; set; }
    public required string UlasanSingkatEvent { get; set; }
    public required string FeedbackPeserta { get; set; }
    public required Uri FotoDokumentasi { get; set; }
    public required Uri VideoDokumentasi { get; set; }
    public required Uri LaporanDetail { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public Event Event { get; set; }
}