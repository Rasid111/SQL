create database Academy
use Academy
create table Groups(
	Id int primary key identity not null,
	[Name] nvarchar(100) not null check([Name] <> '') unique,
	Rating int not null check(Rating >= 0 and Rating <= 5),
	[Year] int not null check([Year] > 0 and [Year] <= 5),
)
create table Departments(
	Id int primary key identity not null,
	Financing money not null check(Financing >= 0) default 0,
	[Name] nvarchar(100) not null check([Name] <> '') unique
)
create table Faculties(
	Id int primary key identity not null,
	[Name] nvarchar(100) not null check([Name] <> '') unique
)
create table Teachers(
	Id int primary key identity not null,
	EmploymentDate date, check(EmploymentDate > '01.01.1990'),
	[Name] nvarchar(max) check([Name] <> '') not null,
	Premium money default 0 check(Premium >= 0) not null,
	Salary money check(Salary > 0) not null,
	Surname nvarchar(max) check([Surname] <> '') not null
)