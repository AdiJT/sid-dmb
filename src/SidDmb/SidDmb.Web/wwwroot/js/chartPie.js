const incomeCompositionCtx = document.getElementById('incomeCompositionChart');
new Chart(incomeCompositionCtx, {
    type: 'pie',
    data: {
        labels: ['Alam', 'Budaya', 'Sejarah', 'Lainnya'],
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
                position: 'left'
            },
            title: {
                display: true,
                text: 'Komposisi Pendapatan Kunjungan',              
            }
        }
    }
});