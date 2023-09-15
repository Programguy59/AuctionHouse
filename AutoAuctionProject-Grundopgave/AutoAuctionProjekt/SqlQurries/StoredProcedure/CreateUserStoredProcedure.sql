alter PROCEDURE CreateUser
@userName varchar(128),
@password varchar(128),
@corporateUser bit,
@balance decimal 
AS
begin
declare @sqllogin varchar(1023)
set @sqllogin = 'CREATE LOGIN ' + @username + ' WITH PASSWORD = ''' + @password + ''', DEFAULT_DATABASE='+'AuctionHouse'+' , CHECK_POLICY = OFF;'
print @sqllogin;
exec(@sqllogin);

declare @sqluser varchar(1023)
set @sqluser = 'CREATE USER '+ @username +' FROM LOGIN '+ @username +''
print @sqluser;
exec(@sqluser);

end

exec CreateUser 'Bser','Bass',0,10000; 

