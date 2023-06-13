create database bank_database;;
go
use bank_database;
go
CREATE TABLE Musteriler(
	MusteriID int NOT NULL PRIMARY KEY Identity(1,1),
	Ad nvarchar(40) NOT NULL,
	Soyad nvarchar(40) NOT NULL,
	Sifre nvarchar(20) NOT NULL,
	KimlikNo nvarchar(10) NOT NULL UNIQUE,
	TelefonNo varchar(14) UNIQUE,
);
Create table Yoneticiler(
	YoneticiID int NOT NULL PRIMARY KEY Identity(1,1),
	Ad nvarchar(40) NOT NULL,
	Soyad nvarchar(40) NOT NULL,
	TelefonNo varchar(14),
);

Create table BolgeMudurlukleri(
	BolgeMudurluguID int NOT NULL PRIMARY KEY Identity(1,1),
	Bolge nvarchar(40) NOT NULL,
	Adres nvarchar(40) NOT NULL,
	TelefonNo varchar(14),
	YoneticiID int UNIQUE NOT NULL  ,
	FOREIGN KEY(YoneticiID) REFERENCES Yoneticiler(YoneticiID),

);

Create table Subeler(
	SubeID int NOT NULL PRIMARY KEY Identity(1,1),
	Adres nvarchar(40) NOT NULL,
	TelefonNo varchar(14),
	Il nvarchar(10) NOT NULL,
	Ilce nvarchar(10) NOT NULL,
	YoneticiID int UNIQUE NOT NULL,
	BolgeMudurluguID int NOT NULL,
	FOREIGN KEY(YoneticiID) REFERENCES Yoneticiler(YoneticiID),
	FOREIGN KEY(BolgeMudurluguID) REFERENCES BolgeMudurlukleri(BolgeMudurluguID)


)
CREATE TABLE Kartlar(
	KartID int NOT NULL PRIMARY KEY Identity(1,1),
	Nakit int,
	KartNo nvarchar(40) NOT NULL,
	SonKullanimTarihi date NOT NULL,
	GuvenlikNo nvarchar(3) NOT NULL,
	IBAN nvarchar(50) NOT NULL,
	MusteriID int NOT NULL,
	SubeID int NOT NULL,
	FOREIGN KEY(MusteriID) REFERENCES Musteriler(MusteriID),
	FOREIGN KEY(SubeID) REFERENCES Subeler(SubeID)

);
create table Harcamalar(
	HarcamadID int NOT NULL PRIMARY KEY Identity(1,1),
	Miktar int,
	Aciklama nvarchar(40),
	KartID int NOT NULL,
	FOREIGN KEY(KartID) REFERENCES Kartlar(KartID) 
);
create table Borsa(
	BorsaID int NOT NULL PRIMARY KEY Identity(1,1),
	DovizCinsi nvarchar(10),
	AlisFiyati int,
	SatisFiyati int,
);

Create table Bolumler(
	BolumID int NOT NULL PRIMARY KEY Identity(1,1),
	BolumAdi nvarchar(40),
);
Create table Calisanlar(
	CalisanID int NOT NULL PRIMARY KEY Identity(1,1),
	Ad nvarchar(40) NOT NULL,
	Soyad nvarchar(40) NOT NULL,
	TelefonNo varchar(14),
	Rol nvarchar(40),
	Maas int NOT NULL,
	SubeID int NOT NULL,
	BolumID int NOT NULL,
	FOREIGN KEY(SubeID) REFERENCES Subeler(SubeID),
	FOREIGN KEY(BolumID) REFERENCES Bolumler(BolumID),

);

insert into Yoneticiler(Ad,Soyad,TelefonNo) Values ('OrnekAd1','OrnekSoyad1','11123334'), ('OrnekAd2','OrnekSoyad2','1133345123') , ('OrnekAd3','OrnekSoyad3','11333322')
insert into BolgeMudurlukleri(Bolge,Adres,TelefonNo,YoneticiID) Values('OrnekBolge1','OrnekAdres1','22323245',1),('OrnekBolge2','OrnekAdres2','22623245',2)

insert into Subeler(Adres,TelefonNo,Il,Ilce,YoneticiID,BolgeMudurluguID) Values ('OrnekAdres1','123232342','Sakarya','Serdivan',1,1),
('OrnekAdres2','123234321','Sakarya','Serdivan',2,1),('OrnekAdres3','1234425568','Sakarya','Sapanca',3,2)
insert into Bolumler(BolumAdi) Values('Bilgisayar Mühendisliði'), ('Ýþletme') , ('Endüstri Mühendisliði') , ('Yazýlým Mühendisliði')
insert into Calisanlar(Ad,Soyad,TelefonNo,Rol,Maas,SubeID,BolumID) Values('OrnekAd1','OrnekSoyad1','2323456','OrnekRol1',15000,1,1), 
('OrnekAd2','OrnekSoyad2','47837462','OrnekRol2',12000,2,2), ('OrnekAd3','OrnekSoyad3','347346873','OrnekRol3',13000,3,2), 
('OrnekAd4','OrnekSoyad4','323827182','OrnekRol4',11000,2,3) , ('OrnekAd5','OrnekSoyad5','23459128','OrnekRol5',17000,1,4) 

insert into Musteriler(Ad,Soyad,Sifre,KimlikNo,TelefonNo) Values('OrnekAd1','OrnekSoyad1','OrnekSifre1','1123424','522332425'),
('OrnekAd2','OrnekSoyad2','OrnekSifre2','422122424','3425678212'), ('OrnekAd3','OrnekSoyad3','OrnekSifre3','52522326','42212556788')

insert into Kartlar(Nakit,KartNo,SonKullanimTarihi,GuvenlikNo,IBAN,MusteriID,SubeID) Values (1000,'234242456','2025-10-11','223','29292932932',1,1), 
(2000,'4242232123','2024-09-12','153','123242042922',1,2), (3000,'8528529321','2028-01-11','421','9492402290232',2,1) ,  (5000,'1429923019','2026-03-10','587','12312312412596',3,2)


insert into Harcamalar(Miktar,Aciklama,KartID) Values (100,'OrnekAciklama1',1), (200,'OrnekAciklama2',1), (400,'OrnekAciklama3',2), (500,'OrnekAciklama4',3)

insert into Borsa(DovizCinsi,AlisFiyati,SatisFiyati) Values ('Dolar',20,20),  ('Euro',21,21), ('Sterlin',24,24)
