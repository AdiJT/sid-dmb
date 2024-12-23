document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: [
            {
                title: 'Seren Taun Kasepuhan Cisungsang',
                start: '2024-12-02T10:00:00',
                end: '2024-12-02T12:00:00'
            },
            {
                title: 'Festival Kota Lama Semarang',
                start: '2024-12-05T14:00:00',
                end: '2024-12-06T16:00:00'
            },
            {
                title: 'Sawahlunto International Songket Carnival',
                start: '2024-12-24T19:00:00',
                end: '2024-12-26T21:00:00'
            }
        ],
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
