Create Database test1
use test1

Create  Table TblTest
(
Id int primary key identity,
Name Varchar(100),
City Varchar(50),
Age int
)
Select * From TblTest
Go

Create OR ALter Proc InsertData
(
@Name Varchar(50),
@City Varchar(50),
@Age Int
)
As
Begin
Insert into TblTest (Name,City,Age)Values(@Name,@City,@Age)
End
Go

Create OR Alter Proc GetSp
As
 Begin
   Select * from TblTest
 End
Go

Create OR Alter Proc GetSpById
(
@Id int
)
As
 Begin
   Select * from TblTest Where Id=@Id
 End
Go


Create OR Alter Proc GetUpdate
(
@Id int,
@Name Varchar(50),
@City Varchar(50),
@Age Int
)
As
 Begin
   Update TblTest set Name=@Name,City=@City,Age=@Age Where Id=@Id
 End
Go

Create OR Alter Proc DeleteById
(
@Id int
)
As
 Begin
   Delete From TblTest Where Id=@Id
 End
Go
