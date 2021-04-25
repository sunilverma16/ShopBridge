CREATE TABLE Product(
	[ProductId] int Identity(1,1) primary key,
	[Name] varchar(100),
	[Description] varchar(500),
	[Price] money,
	[ProductCode] varchar(20),
	[IsDeleted] bit,
	[CreatedOn] datetime,
	[Brand] varchar(20),
	[CountryOfOrigin] varchar(50)
	
)

---  Proc

Create Proc GetAllProduct
As 
Begin

	Select 
	ProductId,
	[Name],
	[Description],
	[Price],
	[ProductCode],
	[Brand],
	[CountryOfOrigin]
	from Product
	Where isDeleted <> 0 

End


Create Proc InsertProduct(
	@Name varchar(100),
	@Description varchar(500),
	@Price money,
	@ProductCode varchar(20),
	@Brand varchar(20),
	@CountryOfOrigin varchar(50)
)
AS 
Begin
	Insert into Product ([Name], [Description], [Price], [ProductCode], [IsDeleted], [CreatedOn],[Brand],[CountryOfOrigin]) values
	(@Name, @Description, @Price,@ProductCode,0,GETDATE(),@Brand,@CountryOfOrigin)

	select @@IDENTITY;
End

Create Proc UpdateProduct(
	@productId int,
	@Name varchar(100),
	@Description varchar(500),
	@Price money,
	@ProductCode varchar(20),
	@Brand varchar(20),
	@CountryOfOrigin varchar(50)
)
AS 
Begin
	Update Product 
	set [Name] = @Name,
		[Description] = @Description,
		[Price] = @Price,
		ProductCode = @ProductCode,
		[Brand] = @Brand,
		[CountryOfOrigin] = @CountryOfOrigin
	Where [ProductId] = @productId

	select @productId;
End