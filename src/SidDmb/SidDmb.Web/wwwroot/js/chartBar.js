// Grafik Tahunan: Statistik Kunjungan Tahunan
const yearlyVisitStatsCtx = document.getElementById('yearlyVisitStatsChart');
new Chart(yearlyVisitStatsCtx, {
    type: 'bar',
    data: {
        labels: ['2024', '2025', '2026', '2027', '2028'],
        datasets: [{
            label: 'Jumlah Kunjungan Tahunan',
            data: [2500, 0, 0, 0, 0],
            backgroundColor: 'rgba(255, 99, 132, 0.5)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'top'
            },
            title: {
                display: true,
                text: 'Statistik Kunjungan Tahunan'
            }
        },
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

// Grafik Bulanan: Statistik Kunjungan Bulanan 2024
const monthlyVisitStatsCtx = document.getElementById('monthlyVisitStatsChart');
new Chart(monthlyVisitStatsCtx, {
    type: 'bar',
    data: {
        labels: ['Januari', 'Februari', 'Maret', 'April', 'Mei', 'Juni', 'Juli', 'Agustus', 'September', 'Oktober', 'November', 'Desember'],
        datasets: [{
            label: 'Jumlah Kunjungan Bulanan',
            data: [150, 200, 180, 250, 300, 400, 250, 130, 200, 150, 145, 150],
            backgroundColor: 'rgba(54, 162, 235, 0.5)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'top'
            },
            title: {
                display: true,
                text: 'Statistik Kunjungan Bulanan di Tahun 2024'
            }
        },
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

// Grafik Mingguan: Statistik Kunjungan Mingguan (4 Minggu Terakhir)
const weeklyVisitStatsCtx = document.getElementById('weeklyVisitStatsChart');
new Chart(weeklyVisitStatsCtx, {
    type: 'bar',
    data: {
        labels: ['1-7 Januari', '8-14 Januari', '15-21 Januari', '22-28 Januari'],
        datasets: [{
            label: 'Jumlah Kunjungan Mingguan',
            data: [50, 70, 60, 80],
            backgroundColor: 'rgba(75, 192, 192, 0.5)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'top'
            },
            title: {
                display: true,
                text: 'Statistik Kunjungan 4 Minggu Terakhir'
            }
        },
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});