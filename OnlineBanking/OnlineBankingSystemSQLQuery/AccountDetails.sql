create table AccountDetails(
UserID varchar(50),
UserName  varchar(50),
AccountNumber varchar(50) ,
BalanceAvailable numeric(9,2),
Status varchar(10) 
)

Insert into AccountDetails values
(
'TestCust1',
'Test Customer',
'7894567523789',
'75000',
'Active'
)