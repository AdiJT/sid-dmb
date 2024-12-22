document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        events: [
            {
                title: 'Seren Taun Kasepuhan Cisungsang',
                start: '2024-09-02T10:00:00',
                end: '2024-09-02T12:00:00',
                description: 'Acara tahunan di Kasepuhan Cisungsang.'
            },
            {
                title: 'Festival Kota Lama Semarang',
                start: '2024-09-05T14:00:00',
                end: '2024-09-05T16:00:00',
                description: 'Perayaan seni dan budaya di Kota Lama Semarang.'
            },
            {
                title: 'Jelajah Pesona Jalur Rempah',
                start: '2024-09-06T09:30:00',
                end: '2024-09-06T11:30:00',
                description: 'Ekspedisi rempah di jalur sejarah Nusantara.'
            },
            {
                title: 'Sawahlunto International Songket Carnival',
                start: '2024-12-24T19:00:00',
                end: '2024-12-26T21:00:00',
                description: 'Pameran kain songket internasional di Sawahlunto.'
            }
        ],
        eventDidMount: function (info) {
            // Format waktu (HH:mm)
            const startTime = new Date(info.event.start).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
            const endTime = info.event.end
                ? new Date(info.event.end).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                : 'Selesai';

            // Konten tooltip dengan informasi jam dan deskripsi
            const tooltipContent = `
        <strong>${info.event.title}</strong><br>
        ${startTime} - ${endTime}<br>
        ${info.event.extendedProps.description}
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
