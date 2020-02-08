create table Transactions(
TransactionID int identity(1,1) primary key,
UserID varchar(50),
Narration varchar(250),
ValueDate date,
InitialBalance decimal,
Withdrawal decimal,
Deposit decimal,
ClosingBalance decimal,
FundTransferToAccount varchar(50),
)
drop table Transactions

Insert into Transactions values(
'TestCust1',
'First',
'2000-01-01',
'75000',
'0',
'0',
'75000',
'')
Insert into Transactions values(
'TestCust1',
'First',
'2001-01-01',
'75000',
'0',
'0',
'75000',
'')
Insert into Transactions values(
'TestCust1',
'First',
'1998-01-01',
'75000',
'0',
'0',
'75000',
'')
Insert into Transactions values(
'TestCust1',
'First',
'2000-08-01',
'75000',
'0',
'0',
'75000',
'')
Insert into Transactions values(
'TestCust1',
'First',
'2000-08-05',
'75000',
'0',
'0',
'75000',
'')
Insert into Transactions values(
'TestCust1',
'Relience Fresh',
'2000-08-09',
'75000',
'0',
'0',
'75000',
'')
select * from Transactions order by ValueDate desc