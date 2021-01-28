									/* STORED PROCEDURE PRODUCTINFORMATÝON*/

Use ProductInformation
go

/*Users*/

Create proc SP_UserSelect
as
Select * from Users

go

Create proc SP_UserInsert
(
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UserName nvarchar(30),
	@Password nvarchar(30),
	@Email nvarchar(50),
	@PhoneNumber varchar(15),
	@Gender varchar(5)
	@Photo image
)
as
Insert into Users(FirstName, LastName, UserName, Password, Email, PhoneNumber, Gender, Photo)
values(@FirstName, @LastName, @UserName, @Password, @Email, @PhoneNumber, @Gender, @Photo)

go

Create proc SP_UserUpdate
(
	@UserID int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@UserName nvarchar(30),
	@Password nvarchar(30),
	@Email nvarchar(50),
	@PhoneNumber varchar(15),
	@Gender varchar(5),
	@Photo image
)
as
Update Users set FirstName=@FirstName, LastName=@LastName, UserName=@UserName, Password=@Password, Email=@Email,
PhoneNumber=@PhoneNumber, Gender=@Gender, Photo=@Photo
where UserID=@UserID

go

Create proc SP_UserDelete
(
	@UserID int
)
as
Delete from Users where UserID=@UserID

go

/*Suppliers*/

Create proc SP_SupplierSelect
as
Select * from Suppliers

go

Create proc SP_SupplierInsert
(
	@CompanyName varchar(50),
	@PhoneNumber varchar(15),
	@Address varchar(150),
	@UserID int
)
as
Insert into Suppliers(CompanyName, PhoneNumber, Address, UserID)values(@CompanyName, @PhoneNumber, @Address, @UserID)

go

Create proc SP_SupplierUpdate
(	
	@SupplierID int,
	@CompanyName varchar(50),
	@PhoneNumber varchar(15),
	@Address varchar(150),
	@UserID int
)
as
Update Suppliers set CompanyName=@CompanyName, PhoneNumber=@PhoneNumber, Address=@Address, UserID=@UserID
where SupplierID=@SupplierID

go

Create proc SP_SupplierDelete
(
	@SupplierID int
)
as
Delete from Suppliers where SupplierID=@SupplierID

go

/*Customer*/

Create proc SP_CustomerSelect
as
Select * from Customer

go

Create proc SP_CustomerInsert
(
	@FirstName varchar (50),
	@LastName varchar (50),
	@PhoneNumber varchar (15),
	@Selected nvarchar(300),
	@UserID int
)
as
Insert into Customer(FirstName,LastName,PhoneNumber,Selected,UserID)values(@FirstName,@LastName,@PhoneNumber,@Selected,@UserID)

go

Create proc SP_CustomerUpdate
(
	@CustomerID int,
	@FirstName varchar (50),
	@LastName varchar (50),
	@PhoneNumber varchar (15),
	@Selected nvarchar(300),
	@UserID int
)
as
Update Customer set FirstName=@FirstName,LastName=@LastName,PhoneNumber=@PhoneNumber,Selected=@Selected,UserID=@UserID
where CustomerID=@CustomerID

go

Create proc SP_CustomerDelete
(
	@CustomerID int
)
as
Delete From Customer where CustomerID=@CustomerID

go

/*Credit Cart*/

Create proc SP_CreditCartSelect
as
Select * from CreditCart

go

Create proc SP_CreditCartInsert
(
	@CartOwner nvarchar(40),
	@CardNumber nvarchar(20),
	@Password nvarchar(30),
	@SecurityCode nvarchar(3),
	@CustomerID int
)
as
Insert into CreditCart(CartOwner,CardNumber,Password,SecurityCode,CustomerID)
values(@CartOwner,@CardNumber,@Password,@SecurityCode,@CustomerID)

go

Create proc SP_CreditCartUpdate
(
	@CreditCartID int,
	@CartOwner nvarchar(40),
	@CardNumber nvarchar(20),
	@Password nvarchar(30),
	@SecurityCode nvarchar(3),
	@CustomerID int
)
as
Update CreditCart set CartOwner=@CartOwner,CardNumber=@CardNumber,Password=@Password,SecurityCode=@SecurityCode,CustomerID=@CustomerID
where CreditCartID=@CreditCartID

go

Create proc SP_CreditCartDelete
(
	@CreditCartID int
)
as
Delete from CreditCart where CreditCartID=@CreditCartID

go

/*Employees*/

Create proc SP_EmployeeSelect
as
Select * from Employees

go

Create proc SP_EmployeeInsert
(
	@FirstName varchar(50),
	@LastName varchar(50),
	@RoleOf varchar(50),
	@PhoneNumber nvarchar(15),
	@DateOfBirth datetime,
	@DateOfStart datetime,
	@Address nvarchar(100),
	@Photo image,
	@SupplierID int
)
as
Insert into Employees(FirstName,LastName,RoleOf,PhoneNumber,DateOfBirth,DateOfStart,Address,Photo,SupplierID)
values(@FirstName,@LastName,@RoleOf,@PhoneNumber,@DateOfBirth,@DateOfStart,@Address,@Photo,@SupplierID)

go

Create proc SP_EmployeeUpdate
(
	@EmployeeID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@RoleOf varchar(50),
	@PhoneNumber nvarchar(15),
	@DateOfBirth datetime,
	@DateOfStart datetime,
	@Address nvarchar(100),
	@Photo image,
	@SupplierID int
)
as
Update Employees set FirstName=@FirstName,LastName=@LastName,RoleOf=@RoleOf,PhoneNumber=@PhoneNumber,DateOfBirth=@DateOfBirth,
DateOfStart=@DateOfStart,Address=@Address,Photo=@Photo,SupplierID=@SupplierID
where EmployeeID=@EmployeeID

go

Create proc SP_EmployeeDelete
(
	@EmployeeID int
)
as
Delete from Employees where EmployeeID=@EmployeeID

go

/*Categories*/

Create proc SP_CategorySelect
as
Select * from Categories

go

Create proc SP_CategoryInsert
(
	@CategoryName  Varchar(50)
)
As
Insert Into Categories(CategoryName) Values(@CategoryName)

go

Create proc SP_CategoryUpdate
(    
	@CategoryID Int,
    @CategoryName Varchar(50)
)
As
Update Categories set CategoryName=@CategoryName Where CategoryID=@CategoryID

go

Create Proc SP_CategoryDelete
    @CategoryID Int
As
Delete From Categories Where CategoryID=@CategoryID

go

/*ProductType*/

Create proc SP_TypeSelect
as
Select * from ProductType

go

Create proc SP_TypeInsert
(
	@ProductType varchar(50),
	@CategoryID int
)
as
Insert into ProductType(ProductType,CategoryID)values(@ProductType,@CategoryID)

go

Create proc SP_TypeUpdate
(
	@TypeID int,
	@ProductType varchar(50),
	@CategoryID int
)
as
Update ProductType set ProductType=@ProductType, CategoryID=@CategoryID
where TypeID=@TypeID

go

Create proc SP_TypeDelete
(
	@TypeID int
)
as
Delete from ProductType Where TypeID=@TypeID

go

/*Brands*/

Create proc SP_BrandSelect
as
Select * from Brands

go

Create proc SP_BrandInsert
(
	@Brand nvarchar(50)
)
as
Insert into Brands(Brand)values(@Brand)

go

Create proc SP_BrandUpdate
(
	@BrandID int,
	@Brand nvarchar(50)
)
as
Update Brands set Brand=@Brand where BrandID=@BrandID

go

Create proc SP_BrandDelete
(
	@BrandID int
)
as
Delete from Brands where BrandID=@BrandID

go

/*Models*/

Create proc SP_ModelSelect
as
Select * from Models

go

Create proc SP_ModelInsert
(
	@Model nvarchar(50),
	@BrandID int
)
as
Insert into Models(Model,BrandID)values(@Model,@BrandID)

go

create proc SP_ModelUpdate
(	
	@ModelID int,
	@Model nvarchar(50),
	@BrandID int
)
as
Update Models set Model=@Model, BrandID=@BrandID where ModelID=@ModelID

go

Create proc SP_ModelDelete
(
	@ModelID int
)
as
Delete from Models where ModelID=@ModelID

go

/*Products*/

Create proc SP_ProductSelect
as
Select * from Products

go

Create proc SP_ProductInsert
(
	@ProductType int,
	@Brand int,
	@Model int,
	@Price money,
	@OutputYear varchar(4),
	@Color varchar(20),
	@Stock int,
	@WarrantyPeriod varchar(6),
	@CategoryID int,
	@SupplierID int
)
as
Insert into Products(ProductType,Brand,Model,Price,OutputYear,Color,Stock,WarrantyPeriod,CategoryID,SupplierID)
values(@ProductType,@Brand,@Model,@Price,@OutputYear,@Color,@Stock,@WarrantyPeriod,@CategoryID,@SupplierID)

go

Create proc SP_ProductUpdate
(
	@ProductID int,
	@ProductType int,
	@Brand int,
	@Model int,
	@Price money,
	@OutputYear varchar(4),
	@Color varchar(20),
	@Stock int,
	@WarrantyPeriod varchar(6),
	@CategoryID int,
	@SupplierID int
)
as
Update Products set ProductType=@ProductType, Brand=@Brand, Model=@Model, Price=@Price, OutputYear=@OutputYear, Color=@Color,
Stock=@Stock, WarrantyPeriod=@WarrantyPeriod, CategoryID=@CategoryID, SupplierID=@SupplierID
where ProductID=@ProductID

go

Create proc SP_ProductDelete
(
	@ProductID int
)
as
Delete from Products where ProductID=@ProductID

go

/*Country*/

Create proc SP_CountrySelect
as
Select * from Country

go

Create proc SP_CountryInsert
(
	@CountryName nvarchar(50)
)
as
Insert into Country(CountryName)values(@CountryName)

go

Create proc SP_CountryUpdate
(
	@CountryID int,
	@CountryName nvarchar(50)
)
as
Update Country set CountryName=@CountryName where CountryID=@CountryID

go

Create proc SP_CountryDelete
(
	@CountryID int
)
as
Delete from Country where CountryID=@CountryID

go

/*City*/

Create proc SP_CitySelect
as
Select * from City

go

Create proc SP_CityInsert
(
	@CityName nvarchar(50),
	@CountryID int
)
as
Insert into City(CityName,CountryID)values(@CityName, @CountryID)

go

Create proc SP_CityUpdate
(
	@CityID int,
	@CityName nvarchar(50),
	@CountryID int
)
as
Update City set CityName=@CityName, CountryID=@CountryID where CityID=@CityID

go

create proc SP_CityDelete
(
	@CityID int
)
as
Delete from City where CityID=@CityID

go

/*Shippers*/

create proc SP_ShipperSelect
as
Select * from Shippers

go

Create proc SP_ShipperInsert
(
	@CompanyName nvarchar(50),
	@CompanyPhoneNumber nvarchar(15)	
)
as
Insert into Shippers(CompanyName,CompanyPhoneNumber)values(@CompanyName,@CompanyPhoneNumber)

go

Create proc SP_ShipperUpdate
(
	@ShipperID int,
	@CompanyName nvarchar(50),
	@CompanyPhoneNumber nvarchar(15)
)
as
Update Shippers set CompanyName=@CompanyName, CompanyPhoneNumber=@CompanyPhoneNumber 
where ShipperID=@ShipperID

go

Create proc SP_ShipperDelete
(
	@ShipperID int
)
as
Delete from Shippers where ShipperID=@ShipperID

go

/*Orders*/

Create proc SP_OrderSelect
as
Select * from Orders

go

Create proc SP_OrderInsert
(
	@Address nvarchar(200),
	@ProductCode int,
	@CustomerID int,
	@SupplierID int,
	@CategoryID int,
	@TypeID int,
	@ProductID int,
	@CountryID int,
	@CityID int,
	@ShipperID int
)
as
Insert into Orders(Address, ProductCode, CustomerID, SupplierID, CategoryID, TypeID, ProductID, CountryID, CityID, ShipperID)
values(@Address, @ProductCode, @CustomerID, @ShipperID, @CategoryID, @TypeID, @ProductID, @CountryID, @CityID, @ShipperID)

go

Create proc SP_OrderUpdate
(
	@OrderID int,
	@Address nvarchar(200),
	@ProductCode int,
	@CustomerID int,
	@SupplierID int,
	@CategoryID int,
	@TypeID int,
	@ProductID int,
	@CountryID int,
	@CityID int,
	@ShipperID int
)
as
Update Orders set Address=@Address, ProductCode=@ProductCode, CustomerID=@CustomerID, SupplierID=@SupplierID, 
CategoryID=@CategoryID, TypeID=@TypeID, ProductID=@ProductID, CountryID=@CountryID, CityID=@CityID, ShipperID=@ShipperID

go

Create proc SP_OrderDelete
(
	@OrderID int
)
as
Delete from Orders where OrderID=@OrderID

go

/* MyCart */

Create proc SP_MyCartSelect
as
Select * from MyCart

go

Create proc SP_MyCartInsert
(
	@MyCart nvarchar(400),
	@UnitPrice int,
	@ProductID int,
	@UserID int,
	@OrderID int
)
as
Insert into MyCart(MyCart,UnitPrice,ProductID,UserID,OrderID)
values(@MyCart,@UnitPrice,@ProductID,@UserID,@OrderID)

go

Create proc SP_MyCartUpdate
(
	@MyCartID int,
	@MyCart nvarchar(400),
	@UnitPrice int,
	@ProductID int,
	@UserID int,
	@OrderID int
)
as
Update MyCart set MyCart=@MyCart, UnitPrice=@UnitPrice, ProductID=@ProductID, UserID=@UserID, OrderID=@OrderID
where MyCartID=@MyCartID

go

Create proc SP_MyCartDelete
(
	@MyCartID int
)
as
Delete from MyCart where MyCartID=@MyCartID