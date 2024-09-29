# MVC Kütüphane Yönetim Projesi

Bu proje, bir kütüphane yönetim sistemi örneğidir. Kullanıcılar kitap ekleyebilir, yazarları yönetebilir ve üye kaydı yaparak giriş yapabilirler. Proje, ASP.NET Core MVC kullanarak geliştirilmiştir ve çeşitli CRUD işlemlerini içermektedir.

## Özellikler

- **Kayıt Ol ve Giriş Yap**: Kullanıcılar üye olabilir ve sisteme giriş yapabilir.
- **Kitap Yönetimi**: Kullanıcılar kitap ekleyebilir, düzenleyebilir, silebilir ve listeleyebilir.
- **Yazar Yönetimi**: Yazar ekleyebilir, düzenleyebilir, silebilir ve yazarların listesini görebilirsiniz.
- **Doğrulama**: Kullanıcı ve kitap formlarında gerekli alan doğrulamaları yapılmıştır.
- **Partial Views ve Layout**: Sayfa düzeni ve ortak bölümler için `Partial View` ve `Layout` kullanımı.
- **Bootstrap ile Tasarım**: Bootstrap kullanılarak responsive ve modern bir arayüz tasarlandı.
- **Footer**: Sabit bir footer bölümü sayfanın alt kısmında bulunur.

## Proje Yapısı

### Modeller

1. **Book (Kitap Modeli)**:
    - `Id` (int): Benzersiz kimlik.
    - `Title` (string): Kitap başlığı.
    - `AuthorId` (int): Yazar kimliği, **Author** modeline referans.
    - `Genre` (string): Kitap türü.
    - `PublishDate` (DateTime): Yayın tarihi.
    - `ISBN` (string): ISBN numarası.
    - `CopiesAvailable` (int): Mevcut kopya sayısı.

2. **Author (Yazar Modeli)**:
    - `Id` (int): Benzersiz kimlik.
    - `FirstName` (string): Yazarın adı.
    - `LastName` (string): Yazarın soyadı.
    - `DateOfBirth` (DateTime): Doğum tarihi.

3. **User (Üye Modeli)**:
    - `Id` (int): Benzersiz kimlik.
    - `FullName` (string): Üyenin tam adı.
    - `Email` (string): Üyenin e-posta adresi.
    - `Password` (string): Üyenin şifresi.
    - `PhoneNumber` (string): Üyenin telefon numarası.
    - `JoinDate` (DateTime): Kayıt tarihi.

### Controller'lar

1. **AuthController**: 
   - `SignUp()`: Üye kaydı işlemi.
   - `Login()`: Giriş işlemi.

2. **BookController**:
   - `List()`: Kitapların listesini gösterir.
   - `Details(id)`: Seçilen kitabın detaylarını gösterir.
   - `Create()`: Yeni kitap eklemek için form sağlar.
   - `Edit(id)`: Kitap düzenleme formu sağlar.
   - `Delete(id)`: Kitabı silme işlemi için onay sayfası.

3. **AuthorController**:
   - `List()`: Yazarların listesini gösterir.
   - `Details(id)`: Seçilen yazarın detaylarını gösterir.
   - `Create()`: Yeni yazar eklemek için form sağlar.
   - `Edit(id)`: Yazar düzenleme formu sağlar.
   - `Delete(id)`: Yazarı silme işlemi için onay sayfası.

### Görünümler (Views)

#### Kitap Görünümleri:
- **List**: Kitapların listesini gösterir.
- **Details**: Seçili kitabın detaylarını gösterir.
- **Create**: Yeni kitap ekleme formu.
- **Edit**: Var olan kitabı düzenleme formu.

#### Yazar Görünümleri:
- **List**: Yazarların listesini gösterir.
- **Details**: Seçili yazarın detaylarını gösterir.
- **Create**: Yeni yazar ekleme formu.
- **Edit**: Var olan yazarı düzenleme formu.

#### Kullanıcı Görünümleri:
- **SignUp**: Üye kayıt formu.
- **Login**: Giriş formu.

### Partial Views

- **_navPartial.cshtml**: Navigasyon menüsü.
- **_footerPartial.cshtml**: Footer alanı.

## Kurulum ve Kullanım


### Adımlar:

1. Bu projeyi klonlayın veya indirin:
    ```bash
    git clone https://github.com/kullanici-adi/mvc-library-project.git
    ```

2. Projeyi bir IDE (örneğin Visual Studio) ile açın.

3. Gerekli bağımlılıkları yükleyin:
    - NuGet paketlerini yükleyin (örneğin `jquery.validate` ve `bootstrap`).
  
4. Veritabanını yapılandırın:
    - `appsettings.json` dosyasındaki bağlantı dizesini (`ConnectionString`) ihtiyaçlarınıza göre düzenleyin.

5. Projeyi başlatın:
    - Visual Studio'da `Ctrl + F5` tuşlarına basarak uygulamayı çalıştırın.

## Proje Hakkında

Bu proje, ASP.NET Core MVC mimarisini ve temel CRUD işlemlerini öğrenmek ve geliştirmek amacıyla oluşturulmuştur. Bootstrap ve jQuery gibi modern frontend teknolojilerini kullanarak arayüz oluşturulmuş ve kullanıcı dostu hale getirilmiştir.


