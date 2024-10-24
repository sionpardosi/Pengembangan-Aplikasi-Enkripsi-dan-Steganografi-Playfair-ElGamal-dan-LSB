# 🔐 Pengembangan Aplikasi Enkripsi dan Steganografi: Playfair, ElGamal, dan LSB

## 📜 Deskripsi Proyek
Proyek ini merupakan implementasi gabungan dari **kriptografi** dan **steganografi** untuk menyembunyikan pesan rahasia di dalam gambar. Dua metode enkripsi yang digunakan adalah:
- **Playfair Cipher**: Kriptografi klasik berbasis matriks.
- **ElGamal**: Kriptografi modern yang lebih kuat dengan enkripsi asimetris.
- **Least Significant Bit (LSB) Steganography**: Teknik steganografi yang menyisipkan pesan di dalam bit paling tidak signifikan dari gambar digital.

⚙️ **Tujuan utama proyek**:
1. Mengenkripsi pesan menggunakan algoritma **Playfair** dan **ElGamal**.
2. Menyisipkan pesan yang telah dienkripsi ke dalam gambar dengan **LSB Steganography**.
3. Mengekstrak dan mendekripsi pesan dari gambar yang tersisipkan untuk mengembalikan **plaintext** asli.

## 🚀 Fitur Utama
- **Playfair Cipher**: Metode enkripsi klasik yang menggunakan matriks 5x5 dan kunci khusus.
- **ElGamal Encryption**: Metode enkripsi modern yang mengandalkan kunci publik dan privat untuk keamanan ekstra.
- **LSB Steganography**: Teknik untuk menyembunyikan data di dalam gambar digital tanpa mengubah tampilannya secara kasat mata.

## 🛠️ Cara Kerja

### 1. 🔒 Enkripsi & Embedding (Sisipan Pesan)
1. **Generate Kunci ElGamal**: Pembangkit kunci publik dan privat untuk enkripsi asimetris.
2. **Enkripsi dengan Playfair & ElGamal**: 
   - Teks asli dienkripsi menggunakan **Playfair Cipher**.
   - Ciphertext Playfair kemudian dienkripsi kembali dengan **ElGamal**.
3. **Embed ke Gambar**: Hasil enkripsi disisipkan ke dalam gambar melalui teknik **LSB Steganography**, memodifikasi bit paling tidak signifikan dari piksel gambar.

### 2. 🔓 Ekstraksi & Dekripsi
1. **Ekstraksi Pesan**: Program mengekstrak ciphertext tersembunyi dari gambar.
2. **Dekripsi ElGamal**: Ciphertext pertama didekripsi menggunakan kunci privat ElGamal.
3. **Dekripsi Playfair**: Ciphertext hasil ElGamal didekripsi menggunakan Playfair Cipher untuk mendapatkan pesan asli.


