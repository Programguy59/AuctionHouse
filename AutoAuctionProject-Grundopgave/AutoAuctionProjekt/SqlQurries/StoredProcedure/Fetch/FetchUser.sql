alter PROCEDURE FetchUser 
@userName varchar(128) 
AS
BEGIN
declare @CorparateUser bit;

select @CorparateUser = Users.corporateUser from Users where userName = @userName 
		
if @CorparateUser = 0 
begin
	select * from Users 
	left join PrivateUsers on PrivateUsers.userName = Users.userName
	where Users.userName = @userName 
end
else 
begin
	select * from Users 
	left join CorporateUsers on CorporateUsers.userName = Users.userName
	where Users.userName = @userName
end

END