// Grafik Bar: Statistik Kunjungan
const visitStatsCtx = document.getElementById('visitStatsChart');
new Chart(visitStatsCtx, {
    type: 'bar',
    data: {
        labels: ['Januari', 'Februari', 'Maret', 'April', 'Mei', 'Juni', 'Juli', 'Agustus', 'September', 'Oktober', 'November', 'Desember'],
        datasets: [{
            label: 'Jumlah Kunjungan',
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
                text: 'Statistik Kunjungan Bulanan'
            }
        },
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});

// Diagram Lingkaran: Komposisi Pendapatan
const incomeCompositionCtx = document.getElementById('incomeCompositionChart');
new Chart(incomeCompositionCtx, {
    type: 'pie',
    data: {
        labels: ['Destinasi', 'Artefak', 'Situs', 'Lainnya'],
        datasets: [{
            data: [40, 25, 20, 15],
            backgroundColor: [
                'rgba(255, 99, 132, 0.5)',
                'rgba(54, 162, 235, 0.5)',
                'rgba(255, 206, 86, 0.5)',
                'rgba(75, 192, 192, 0.5)'
            ],
            borderColor: [
                'rgba(255, 99, 132, 1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)'
            ],
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
                text: 'Komposisi Pendapatan'
            }
        }
    }
});