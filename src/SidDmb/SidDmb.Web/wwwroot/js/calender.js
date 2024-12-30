document.addEventListener('DOMContentLoaded', async function () {
    const response = await fetch('/kalender-acaras');

    let daftarAcara = [];
    if (response.ok) {
        daftarAcara = await response.json();
    }

    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: daftarAcara,
        eventDidMount: function (info) {
            const start = new Date(info.event.start);
            const end = new Date(info.event.end);

            // Format tanggal (DD MMM YYYY)
            const startDate = start.toLocaleDateString('id-ID', {
                day: '2-digit',
                month: 'short',
                year: 'numeric'
            });
            const endDate = end.toLocaleDateString('id-ID', {
                day: '2-digit',
                month: 'short',
                year: 'numeric'
            });

            // Format waktu (HH:mm)
            const startTime = start.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
            const endTime = end
                ? end.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                : 'Selesai';

            // Tentukan apakah acara memiliki rentang tanggal
            const dateRange = startDate === endDate
                ? `${startDate}` // Jika tanggal mulai dan selesai sama
                : `${startDate} - ${endDate}`; // Jika berbeda

            // Konten tooltip dengan rentang tanggal dan waktu
            const tooltipContent = `
                <strong>${info.event.title}</strong><br>
                ${dateRange}<br>
                ${startTime} - ${endTime}
            `;

            // Pasang tooltip menggunakan Tippy.js
            tippy(info.el, {
                content: tooltipContent,
                placement: 'top',
                theme: 'light',
                allowHTML: true // Izinkan HTML di dalam tooltip
            });
        }
    });
    calendar.render();
});