# Bütçe Takip Sistemi 💰

Bu proje, kullanıcıların günlük harcamalarını kategorize ederek kaydetmelerini, bütçe yönetimlerini grafiksel olarak analiz etmelerini ve kullanıcı bilgilerini güvenle güncellemelerini sağlayan bir **Masaüstü Uygulamasıdır.**

## 🛠️ Temel Özellikler
* **Kullanıcı Yönetimi:** Kayıt olma, giriş yapma ve şifre/kullanıcı adı güncelleme işlemleri.
* **Harcama Takibi:** Harcamaları türüne (Gıda, Kira, Fatura vb.) göre ekleyebilme.
* **Grafiksel Analiz:** Yapılan harcamaların çubuk grafik (bar chart) ile görselleştirilmesi.
* **Yönetici Paneli:** Tüm kullanıcıları ve yapılan işlemleri tek bir merkezden görüntüleme ve yönetme.
* **Raporlama:** Harcama geçmişini raporlama ve okunabilir formatta sunma.

## 💻 Kullanılan Teknolojiler
* **Dil:** C# (.NET Framework / WinForms)
* **Veritabanı:** SQLite
* **Görselleştirme:** Windows Forms Charting API

## 🖼️ Ekran Görüntüleri

| Giriş Ekranı | Harcama Takibi |
| :---: | :---: |
| ![Giriş](butcetakipanaekran.png) | ![Harcama](butcetakipharcama.png) |

| Grafik Analizi | Yönetici Paneli |
| :---: | :---: |
| ![Grafik](butcetakipgrafik.png) | ![Admin](butcetakipadmin.png) |

## 🚀 Kurulum
**1. Repoyu klonlayın:**
   ```bash
   git clone https://github.com/ikbaltorun/ButceTakipSistemi.git
   ```
**2. Projeyi Çalıştırın:**
Projeyi çalıştırmak için aşağıdaki iki yöntemden birini kullanabilirsiniz:

Yöntem 1 (Klasik): İndirdiğiniz klasöre gidin, .sln uzantılı dosyayı bulun ve çift tıklayarak Visual Studio ile açın. Ardından F5 tuşuna basarak başlatın.

Yöntem 2 (Terminal): Terminal üzerinden proje klasörüne girdikten sonra şu komutla Visual Studio'yu otomatik başlatın:
   ```bash
   cd ButceTakipSistemi
   ```
   ```bash
   start ButceTakipSistemi.sln
   ```

---
*İkbal Torun | 2026*
