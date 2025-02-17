# Aplikasi Enkripsi dan Steganografi: Playfair, ElGamal, dan LSB dalam Keamanan Perangkat Lunak
Steganografi adalah seni menyembunyikan informasi rahasia dalam media yang tampak 
biasa atau tidak mencurigakan. Istilah ini berasal dari bahasa Yunani, di mana "steganos" 
berarti tersembunyi, dan "graphein" berarti menulis. Steganografi bertujuan untuk 
menyembunyikan keberadaan pesan itu sendiri, bukan hanya isinya, sehingga hanya 
penerima yang dituju yang bisa mengetahui bahwa ada pesan tersembunyi. Media yang 
sering digunakan dalam steganografi termasuk gambar, audio, video, dan teks.

## 📄 Jurnal: Pengujian dan Analisis Teknik Steganografi Menggunakan Metode Playfair, ElGamal, dan LSB

Pelajari lebih lanjut tentang Pengujian dan Analisis Teknik Steganografi Menggunakan Metode **Playfair**, **ElGamal**, dan **LSB** untuk Penyembunyian Data pada Gambar Digital dalam Aplikasi Modern.

📌 **Baca Jurnal PDF di Repository**  
Anda dapat mengunduh dan membaca jurnal lengkap saya di repository GitHub berikut:  
[🔗 Jurnal: Pengujian dan Analisis Teknik Steganografi](https://github.com/sionpardosi/Pengembangan-Aplikasi-Enkripsi-dan-Steganografi-Playfair-ElGamal-dan-LSB/blob/main/%5BJURNAL%5D%20Pengujian%20dan%20Analisis%20Teknik%20Steganografi%20Menggunakan%20Metode%20Playfair%2C%20ElGamal%2C%20dan%20LSB%20untuk%20Penyembunyian%20Data%20pada%20Gambar%20Digital%20dalam%20Aplikasi%20Modern.pdf)

📖 **Baca Jurnal yang Telah Dipublikasikan**  
Jurnal ini juga telah diterbitkan di **JURNAL QUANCOM: QUANTUM COMPUTER JURNAL**. Anda dapat mengaksesnya melalui tautan berikut:  
[🔗 Pengujian dan Analisis Teknik Steganografi](https://journal.iteba.ac.id/index.php/jurnal_quancom/article/view/422)

---

✍️ *Penulis: Sion Pardosi, Melvayana Manik, dan Irene Mutiara Situmorang*  
📅 *Publikasi: Vol. 2 No. 2 (2024)*

---

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

### <summary><strong>Tools:</strong></summary>
<p>
    <img src="https://img.shields.io/badge/Code-C%23-blue?logo=csharp" />
    <img src="https://img.shields.io/badge/Algorithm-Playfair%20Cipher-orange?logo=csharp" />
    <img src="https://img.shields.io/badge/Algorithm-ElGamal-red?logo=csharp" />
    <img src="https://img.shields.io/badge/Technique-LSB%20Steganography-green?logo=csharp" />
    <img src="https://img.shields.io/badge/Editor-Visual%20Studio-blue?logo=visualstudio" />
    <img src="https://img.shields.io/badge/Library-NET%20Framework-orange?logo=dotnet" />
</p>

# Encryption and Steganography Application: Playfair, ElGamal, and LSB in Software Security

Steganography is the art of concealing secret information within seemingly ordinary or unremarkable media. The term originates from Greek, where "steganos" means hidden, and "graphein" means to write. The goal of steganography is to hide the existence of the message itself, not just its content, so that only the intended recipient can detect the presence of the hidden message. Common media used in steganography include images, audio, video, and text.

## 📜 Project Description
This project is a combined implementation of **cryptography** and **steganography** aimed at hiding secret messages within images. The two encryption methods used are:
- **Playfair Cipher**: A classical matrix-based encryption method.
- **ElGamal**: A modern asymmetric encryption algorithm that offers stronger security.
- **Least Significant Bit (LSB) Steganography**: A steganographic technique that embeds the message in the least significant bits of a digital image.

⚙️ **Primary objectives of the project**:
1. Encrypt the message using **Playfair** and **ElGamal** algorithms.
2. Embed the encrypted message into an image using **LSB Steganography**.
3. Extract and decrypt the message from the embedded image to retrieve the original **plaintext**.

## 🚀 Key Features
- **Playfair Cipher**: A classical encryption method utilizing a 5x5 matrix and a specific key.
- **ElGamal Encryption**: A modern encryption technique that uses public and private keys for enhanced security.
- **LSB Steganography**: A technique to hide data within a digital image without visually altering its appearance.

## 🛠️ How It Works

### 1. 🔒 Encryption & Embedding (Message Insertion)
1. **Generate ElGamal Keys**: Generate a public and private key pair for asymmetric encryption.
2. **Encrypt with Playfair & ElGamal**: 
   - The plaintext is first encrypted using the **Playfair Cipher**.
   - The resulting ciphertext is then further encrypted with **ElGamal**.
3. **Embed into Image**: The final encrypted message is embedded into an image using **LSB Steganography**, modifying the least significant bits of the image’s pixels.

### 2. 🔓 Extraction & Decryption
1. **Extract the Message**: The program extracts the hidden ciphertext from the image.
2. **Decrypt with ElGamal**: The first layer of ciphertext is decrypted using the ElGamal private key.
3. **Decrypt with Playfair**: The ElGamal-decrypted ciphertext is then decrypted using the Playfair Cipher to retrieve the original message.


## License

This project is licensed under the [MIT License](LICENSE).

--- 

# Contribution & Feedback:

We are very open to contributions and feedback from the community. For more information or any questions, feel free to contact us via [spardosi12@gmail.com](mailto:spardosi12@gmail.com) or connect with me on [LinkedIn](https://www.linkedin.com/in/sion-pardosi-961607254/).

