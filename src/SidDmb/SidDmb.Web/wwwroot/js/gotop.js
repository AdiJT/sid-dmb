// Ambil elemen tombol
var mybutton = document.getElementById("goToTopBtn");

// Reset visibilitas tombol saat halaman dimuat
window.onload = function () {
    mybutton.style.display = "none"; // Tombol tidak terlihat
    mybutton.classList.add('hidden'); // Tombol memiliki kelas 'hidden'
};

// Ketika pengguna menggulir ke bawah 20px dari atas, tampilkan tombol
window.onscroll = function () {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
        mybutton.classList.remove('hidden'); // Menampilkan dengan animasi
    } else {
        mybutton.classList.add('hidden'); // Menyembunyikan dengan animasi
    }
};

// Ketika tombol diklik, scroll ke atas
mybutton.onclick = function () {
    window.scrollTo({
        top: 0,
        behavior: 'smooth' // Menggunakan scroll halus
    });
};