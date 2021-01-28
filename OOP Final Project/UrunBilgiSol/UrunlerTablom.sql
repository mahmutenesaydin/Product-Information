Create Database UrunBilgi
go
use UrunBilgi
go

Create table Kullanici
(
	KullaniciID int primary key Identity,
	Ad varchar(50),
	Soyad varchar(50),
	KullaniciAdi nvarchar(20),
	KullaniciSifre nvarchar(20),
	Eposta nvarchar(50),
	CepTelefonu varchar(15),
	Cinsiyet varchar(5)
)

go

create table Tedarikci
(
	TedarikciID int primary key Identity,
	KullaniciADi varchar(50),
	Adresi varchar(150)unique,
	KullaniciID int

	foreign key(KullaniciID)references Kullanici(KullaniciID)	
)

go

create table Musteri
(
	MusteriId int primary key Identity,
	MusteriAdi varchar (50),
	MusteriSoyadi varchar (50),
	TelefonNumarasi varchar (15) unique,
	Sectikleri nvarchar(300),
	KullaniciID int,
	
	Foreign key (KullaniciID) references Kullanici(KullaniciID)
)

go

Create table KrediKarti
(
	KrediKartiID int primary key Identity,
	KartSahibi nvarchar(40),
	KartNumarasi nvarchar(20)unique,
	GuvenlikKodu nvarchar(3),
	MusteriID int,

	foreign key(MusteriID)references Musteri(MusteriID)
)

go

create table Personeller
(
	PersonelID int primary key Identity,
	Ad varchar(50),
	Soyad varchar(50),
	Rolu varchar(50),
	TelefonNumarasi nvarchar(15)unique,
	DogumTarihi datetime,
	IseBaslamaTarihi datetime,
	Adres nvarchar(100),
	Resmi image,
	TedarikciID int

	foreign key(TedarikciID)references Tedarikci(TedarikciID)
)

go

create table Kategoriler
(
	KategoriID int primary key Identity,
	Kategori nvarchar(50),
)

go

create table UrunTuru
(
	UrunTuruID int primary key,
	UrunTuru varchar(50),
	KategoriID int
	
	Foreign key(KategoriID)references Kategoriler(KategoriID)
)

go


create table Markalar
(
	MarkaID int primary key Identity,
	Marka nvarchar(50)
)

go

Create table Modeller
(
	ModelID int primary key identity,
	Model nvarchar(50),
	MarkaId int

	foreign key (MarkaId) references Markalar (MarkaId)
)

go

Create table Urunler
(
	UrunID int primary key Identity,
	UrunTuruID int,
	Marka int,
	Model int,
	Fiyatý money,
	CikisYili varchar(4),
	Rengi varchar(20),
	Stok int,
	GarantiSuresi varchar(6),
	KategoriID int,
	TedarikciID int

	foreign key(UrunTuruID)references UrunTuru(UrunTuruID),
	foreign key(Marka)references Markalar(MarkaID),
	Foreign key(Model)references Modeller(ModelID),
	foreign key(KategoriID)references Kategoriler(KategoriID),
	foreign key(TedarikciID)references Tedarikci(TedarikciID)
)

go

Create table Ulke
(
	UlkeID int primary key Identity,
	UlkeAdi nvarchar(50),
)

go

Create table Sehir
(
	SehirID int primary key Identity,
	SehirAdi nvarchar(50),
	UlkeID int
	
	foreign key(UlkeID)references Ulke(UlkeID)
)

go

Create table Nakliyeciler
(
	NakliyeciID int primary key Identity,
	SirketAdi nvarchar(50),
	SirketTelefonu nvarchar(15)
)

go


create table Siparisler
(
	SiparisID int primary key Identity,
	UrunKodu int,
	MusteriID int,
	TedarikciID int,
	KategoriID int,
	UrunID int,
	SehirID int,
	NakliyeciID int,

	foreign key(MusteriID)references Musteri(MusteriID),
	foreign key(TedarikciID)references Tedarikci(TedarikciID),
	foreign key(KategoriID)references Kategoriler(KategoriID),
	foreign key(UrunID)references Urunler(UrunID),
	foreign key(SehirID)references Sehir(SehirID),
	foreign key(NakliyeciID)references Nakliyeciler(NakliyeciID),
)

go

Create table Sepetim
(
	SectiklerimID int primary key Identity,
	Sectiklerim nvarchar(400),
	ToplamFiyat int,
	UrunID int,
	KullaniciID int,
	SiparisID int

	foreign key(UrunID)references Urunler(UrunID),
	foreign key(KullaniciID)references Kullanici(KullaniciID),
	foreign key(SiparisID)references Siparisler(SiparisID)
)