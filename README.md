# 📥✨ Inboxly – Modern Messaging Platform ✨📥

**Inboxly**, .NET 8.0 MVC mimarisi kullanılarak geliştirilmiş; SOLID prensiplerine uygun katmanlı yapısı, OTP (Tek Kullanımlık Şifre) güvenliği ve gelişmiş mesaj yönetimi özellikleriyle öne çıkan modern bir mesajlaşma platformudur.

---

## 🎯🚀 Projenin Amacı
Kullanıcıların güvenli bir ortamda birbirleriyle iletişim kurmasını sağlamak, mesaj trafiğini kategorize ederek (İş, Ticari, Aile vb.) yönetmek ve tüm bu süreci kullanıcı dostu, analitik bir arayüz üzerinden sunmaktır.

---

## 🧱⚙️ Mimari Yapı (N-Tier Architecture)
Proje, sürdürülebilir kod ilkesiyle katmanlı mimari ve **DTO (Data Transfer Object)** desenleri kullanılarak inşa edilmiştir:

* **📁 Context:** Veritabanı yapılandırmaları ve DbContext yönetimi.
* **📁 Controllers:** Uygulama akışını ve HTTP isteklerini yöneten katman.
* **📁 Entities:** Veritabanı nesneleri (`AppUser`, `Message`, `Category`, `MessageStatus`).
* **📁 Dtos:** Veri taşıma nesneleri (Giriş, Kayıt, Mesaj oluşturma süreçleri için).
* **📁 Mapping:** AutoMapper ile nesne dönüşümleri.
* **📁 Validator:** FluentValidation ile sunucu taraflı form doğrulamaları.
* **📁 Views:** Bootstrap tabanlı responsive arayüz katmanı.

---

## 🚀✨ Özellikler
* **🧱 .NET 8.0 MVC:** En güncel .NET sürümü ile performanslı çalışma.
* **🔐 Identity & OTP Güvenliği:**
    * **ASP.NET Core Identity** ile profesyonel kullanıcı yönetimi.
    * **MailKit** entegrasyonu ile e-posta üzerinden 6 haneli giriş doğrulama kodu (OTP).
* **✉️ Gelişmiş Mesajlaşma Deneyimi:**
    * **Zengin Metin Editörü:** HTML destekli mesaj yazma imkanı.
    * **Klasörleme:** Gelen Kutusu, Gönderilenler, Taslaklar, Yıldızlılar ve Çöp Kutusu.
    * **Etiketleme:** Mesajları kategorilere ayırarak hızlı filtreleme.
* **📊 Analitik Dashboard:**
    * Toplam mesaj istatistikleri ve kategori bazlı dağılım grafikleri.
    * Kayıtlı üyelerin lokasyon ve iletişim bilgilerini içeren hızlı erişim paneli.
* **🧑‍💼 Profil Yönetimi:** Kullanıcı bilgilerini güncelleme, fotoğraf yükleme ve özgeçmiş alanı.

---

## 🔐🛡️ Authentication & Authorization
* **Identity:** Rol bazlı yetkilendirme (AppRole).
* **OTP:** Giriş güvenliği için e-posta doğrulaması.
* **Cookie:** Güvenli oturum ve kullanıcı takibi.

---

## 🧪🧠 Teknik Detaylar
* **Entity Framework Core:** Veritabanı işlemleri için Code-First yaklaşımı.
* **MSSQL:** İlişkisel veri depolama.
* **AutoMapper:** Entity-DTO arası hızlı eşleme.
* **FluentValidation:** Dinamik ve güvenli form kontrolleri.
* **MailKit / MimeKit:** SMTP üzerinden gerçek zamanlı e-posta gönderimi.

---

## 🛠️ Kullanılan Teknolojiler
* **Framework:** .NET 8.0 MVC
* **Dil:** C#
* **Veritabanı:** MS SQL Server
* **UI:** HTML5, CSS3, JavaScript, Bootstrap
* **Kütüphaneler:** Identity Core, MailKit, AutoMapper, FluentValidation

---

## 📸 Ekran Görüntüleri

### 🔐 Güvenlik & Profil

<img width="1267" height="591" alt="StartPage" src="https://github.com/user-attachments/assets/6348ce0f-b195-42ba-8add-35b4b0528947" />

---

<img width="1075" height="583" alt="SignInPage" src="https://github.com/user-attachments/assets/b59ef47d-df97-4def-81df-e2fb5a110027" />

---

<img width="1618" height="825" alt="SignUpPage" src="https://github.com/user-attachments/assets/525b2f3c-a4ba-49e1-b369-b382d1b7d521" />

---

<img width="929" height="521" alt="GizlilikPolitikasi" src="https://github.com/user-attachments/assets/0c13dff2-d30f-4a8b-b758-61905e1375ec" />

---

<img width="1026" height="228" alt="DogrulamaKodu" src="https://github.com/user-attachments/assets/6493ad64-5c05-4571-88f3-e9c221f88105" />

### ✉️ Mesajlaşma Arayüzü

<img width="1848" height="658" alt="InboxPage" src="https://github.com/user-attachments/assets/c9a87420-8e69-46db-a34f-5863476cc085" />

---

<img width="1867" height="687" alt="StarsMessagePage" src="https://github.com/user-attachments/assets/83c9c869-fa74-47a0-a7da-c7c1b1683f18" />

---

<img width="1842" height="749" alt="SendMessagePage" src="https://github.com/user-attachments/assets/03221713-c3d1-42de-8e32-969416b5d08b" />

---

<img width="1285" height="337" alt="MessageDetailsPage" src="https://github.com/user-attachments/assets/09d9fdac-4400-46ef-a8b3-16751b6d8c17" />

---

<img width="1830" height="380" alt="DraftPage" src="https://github.com/user-attachments/assets/933a3b4a-d076-4853-b495-44eb15139606" />


### 📊 Dashboard & Analiz

<img width="1215" height="841" alt="dashboard1" src="https://github.com/user-attachments/assets/65f54f46-9428-47ae-ab7e-54be52bc87a4" />

---

<img width="1196" height="499" alt="dashboard2" src="https://github.com/user-attachments/assets/c9eb8da7-46ba-4b57-8d76-43bf8e7b9187" />

---

<img width="1477" height="557" alt="ProfilePage" src="https://github.com/user-attachments/assets/21b0db19-0b53-4e41-a696-d5fdf612fc23" />

---

<img width="1877" height="862" alt="UpdateProfile" src="https://github.com/user-attachments/assets/2e54a6f1-b4ef-4c9b-b4fe-d414123a034f" />
