create table CustomerInfo(
UserID varchar(50) Primary Key,
UserName  varchar(50) Not null,
Gender varchar(10) NOT NULL CHECK (Gender IN ('Male', 'Female','Others')),
DOB date,
AddressLine varchar(500) Not null,
City varchar(50) Not null,
StateDetails varchar(50) Not null,
Country varchar(50) Not null,
Pincode varchar(50)Not null,
Email varchar(150) Not null ,
PrimaryPhoneNumber varchar(50) Not null,
AccountNumber varchar(50) Not null,
BalanceAvailable numeric(9,2),
Password varchar(50) not null,
Status varchar(10) NOT NULL CHECK (Status IN ('Active', 'Freeze'))
)

alter table CustomerInfo add BalanceAvailable decimal;

DROP TABLE CustomerInfo