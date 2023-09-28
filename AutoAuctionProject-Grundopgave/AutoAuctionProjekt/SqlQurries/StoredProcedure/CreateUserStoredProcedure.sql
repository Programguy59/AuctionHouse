ALTER PROCEDURE CreateUser
@userName varchar(128),
@password varchar(128),
@corporateUser bit,
@balance decimal, 
@CRNumber varchar(10)
AS
begin
declare @sqllogin varchar(1023)
set @sqllogin = 'CREATE LOGIN ' + @username + ' WITH PASSWORD = ''' + @password + ''', DEFAULT_DATABASE='+'AuctionHouse'+' , CHECK_POLICY = OFF;'
print @sqllogin;
exec(@sqllogin);


declare @sqluser varchar(1023)
set @sqluser = 'USE AuctionHouse; CREATE USER '+ @username +' FROM LOGIN '+ @username +''
print @sqluser;
exec(@sqluser);

declare @sqlGiveReaderRole varchar(1023)
set @sqlGiveReaderRole = 'USE AuctionHouse; ALTER ROLE db_datareader ADD MEMBER ' + @username + ' ;' 
print(@sqlGiveReaderRole)
exec(@sqlGiveReaderRole);

declare @sqlGiveWriterRole varchar(1023)
set @sqlGiveWriterRole = 'USE AuctionHouse; ALTER ROLE db_datawriter ADD MEMBER ' + @username + ' ;' 
print(@sqlGiveWriterRole)
exec(@sqlGiveWriterRole);

Insert into AuctionHouse.dbo.Users
(
	userName, CorporateUser, Balance , zipCode
)
Values 
(
	@userName, @corporateUser, @balance, @zipCode
)
IF @corporateUser = 0 Insert into AuctionHouse.dbo.PrivateUsers
(
	CPR,userName
)
Values 
(
	@CRNumber, @userName
)
ELSE Insert into AuctionHouse.dbo.CorporateUsers
(
	CVR,userName
)
Values 
(
	@CRNumber,@userName
)
end


