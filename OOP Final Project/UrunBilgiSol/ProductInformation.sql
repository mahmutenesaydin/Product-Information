create DataBase ProductInformation
go
use ProductInformation
go

Create table Users
(
	UserID int primary key Identity,
	FirstName varchar(50),
	LastName varchar(50),
	UserName nvarchar(30)unique,
 	Password nvarchar(30),
	Email nvarchar(50)unique,
	PhoneNumber varchar(15)unique,
	Photo nvarchar(100),
	Gender varchar(5)
)

Insert into Users(FirstName,LastName,UserName,Password, Email,PhoneNumber,Gender) 
values('Mahmut', 'Aydýn', 'mhmtens13', '123', 'mahmut@hotmail.com', '534 602 9193','Erkek')

go

create table Suppliers
(
	SupplierID int primary key Identity,
	CompanyName varchar(50),
	PhoneNumber varchar(15)unique,
	Address varchar(150)unique,
	UserID int

	foreign key(UserID)references Users(UserID)	
)

Insert into Suppliers values('BakBakAl', '535 974 3925', 'Baðcýlar Ýstanbul', 1)

go

Create table Country
(
	CountryID int primary key Identity,
	CountryName nvarchar(50),
)

Insert into Country values('Türkiye')

go

Create table City
(
	CityID int primary key Identity,
	CityName nvarchar(50),
	CountryID int
	
	foreign key(CountryID)references Country(CountryID)
)

Insert into City values('Ýstanbul', 1)

go

create table Customer
(
	CustomerID int primary key Identity,
	FirstName varchar (50),
	LastName varchar (50),
	PhoneNumber varchar (15) unique,
	Selected nvarchar(300),
	UserID int,
	CountryID int,
	CityID int,
	Address nvarchar(300)
	
	Foreign key (UserID) references Users(UserID),
	Foreign key (CountryID) references Country(CountryID),
	Foreign key (CityID) references City(CityID)
)

Insert into Customer(FirstName,LastName,PhoneNumber,Selected,UserID,CountryID,CityID,Address)
values('Oguzhan', 'Akduman', 'Taký Kolye', '544 44 4444', 1, 1,1,'Florya')

go

Create table CreditCart
(
	CreditCartID int primary key Identity,
	CartOwner nvarchar(40),
	CardNumber nvarchar(20)unique,
	Password nvarchar(30),
	Limit money,
	SecurityCode nvarchar(3),
	CustomerID int,

	foreign key(CustomerID)references Customer(CustomerID)
)

Insert into CreditCart values ('Ahmet Aydýn', '123456','123', 25000, '258', 1)

go

create table Employees
(
	EmployeeID int primary key Identity,
	FirstName varchar(50),
	LastName varchar(50),
	RoleOf varchar(50),
	PhoneNumber nvarchar(15)unique,
	DateOfBirth datetime,
	DateOfStart datetime,
	Address nvarchar(100),
	Photo nvarchar(100),
	SupplierID int

	foreign key(SupplierID)references Suppliers(SupplierID)
)

Insert into Employees(FirstName, LastName, RoleOf, PhoneNumber, DateOfBirth, DateOfStart, Address, Photo)
values('Ramazan', 'Aydýn', 'Satýþ Sorumlusu', '534 399 9958', '10.10.2010', '12.12.2012', 'Baðcýlar', 'C:\Users\abc\Desktop\ProductInformation')

go

create table Categories
(
	CategoryID int primary key Identity,
	CategoryName nvarchar(50)
)

Insert into Categories values('Telefon')

go

create table ProductTypes
(
	TypeID int primary key Identity,
	ProductType varchar(50),
	CategoryID int
	
	Foreign key(CategoryID)references Categories(CategoryID)
)

Insert into ProductTypes values('Akýllý Telefon', 1)

go

create table Brands
(
	BrandID int primary key Identity,
	Brand nvarchar(50)
)

Insert into Brands values('Samsung')

go

Create table Models
(
	ModelID int primary key identity,
	Model nvarchar(50),
	BrandID int

	foreign key (BrandID) references Brands(BrandID)
)

Insert into Models values('S10', 1)

go

create table Products
(
	ProductID int primary key Identity,	
	ProductTypeID int,
	BrandID int,
	ModelID int,
	Price money,
	OutputYear varchar(4),
	Color varchar(20),
	Stock int,
	WarrantyPeriod varchar(6),
	CategoryID int,
	SupplierID int,
	Photo1 nvarchar(100),
	Photo2 nvarchar(100),
	Photo3 nvarchar(100)

	foreign key(ProductTypeID)references ProductTypes(TypeID),
	foreign key(BrandID)references Brands(BrandID),
	Foreign key(ModelID)references Models(ModelID),
	foreign key(CategoryID)references Categories(CategoryID),
	foreign key(SupplierID)references Suppliers(SupplierID)
)

Insert into Products(ProductTypeID, BrandID, ModelID, Price, OutputYear, Color, Stock, WarrantyPeriod, CategoryID, Photo1, Photo2)
values(1,1,1,5500,'2019','Siyah', 15, '2 Yýl', 1, 'C:\Users\abc\Desktop\ProductInformation\RESÝMLER PROJE', 'C:\Users\abc\Desktop\ProductInformation\RESÝMLER PROJE')

go

Create table Shippers
(
	ShipperID int primary key Identity,
	CompanyName nvarchar(50),
	CompanyPhoneNumber nvarchar(15) unique
)

Insert into Shippers values('Sait Nakliyat', '558 558 5858')

go

create table Orders
(
	OrderID int primary key Identity,
	Address nvarchar(200),
	ProductCode int,
	CustomerID int,
	SupplierID int,
	CategoryID int,
	TypeID int,
	ProductID int,
	BrandID int,
	ModelID int,
	CountryID int,
	CityID int,
	ShipperID int,

	foreign key(CustomerID)references Customer(CustomerID),
	foreign key(SupplierID)references Suppliers(SupplierID),
	foreign key(TypeID)references ProductTypes(TypeID),
	foreign key(CategoryID)references Categories(CategoryID),
	foreign key(ProductID)references Products(ProductID),
	foreign key(BrandID)references Brands(BrandID),
	foreign key(ModelID)references Models(ModelID),
	foreign key(CountryID)references Country(CountryID),
	foreign key(CityID)references City(CityID),
	foreign key(ShipperID)references Shippers(ShipperID)
)

Insert into Orders(Address, ProductCode, CustomerID, CategoryID, TypeID, ProductID, BrandID, ModelID, CountryID, CityID)
values('Sivas Hafik', 123, 1,1,1,1,1,1,1,1)

go

Create table MyCarts
(
	MyCartID int primary key Identity,
	MyCart nvarchar(400),
	UnitPrice int,
	ProductID int,
	UserID int,
	OrderID int

	foreign key(ProductID)references Products(ProductID),
	foreign key(UserID)references Users(UserID),
	foreign key(OrderID)references Orders(OrderID)
)

go

Create proc SP_ProdStockByType
as
Select
	T.ProductType,
	SUM(P.Stock) Stock
from Products P
join ProductTypes T on P.ProductTypeID=T.TypeID
group by T.ProductType


go

Create proc SP_ModelByBrand
as
Select
	M.Model,
	SUM(B.BrandID) Brand
from Brands B
join Models M on B.BrandID=M.BrandID
group by M.Model




go--------------------------------------------------------

