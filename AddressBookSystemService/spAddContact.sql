CREATE PROCEDURE spAddContact  
(  
@FirstName varchar(100),
@LastName varchar(100),
@Address varchar(250),
@City varchar(100),
@State varchar(100),
@Zip BigInt,
@PhoneNumber BigInt,
@Email varchar(200),
@AddressBookName VARCHAR(50),
@RelationType varchar(50)
)  
as  
begin  
        insert into AddressBookTable values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email,@AddressBookName,@RelationType)
		insert into Contact values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,GETDATE())
        insert into Contact_Type values(@FirstName,@RelationType)
        insert into Contact_BookName values(@FirstName,@AddressBookName)  
end 