create database Diary
use Diary

create table Groups(
	Id int primary key identity,
	[Name] nvarchar(50) not null)

create table Students(
	Id int primary key identity,
	[Name] nvarchar(50) not null,
	GroupId int foreign key references Groups(Id))

create table Marks(
	Id int primary key identity,
	[Value] int not null check(value >= 1 and value <= 12),
	StudentId int foreign key references Students(Id))



--insert'ы из гпт



-- Вставка данных в таблицу Groups
INSERT INTO Groups ([Name])
VALUES ('Group A'), ('Group B'), ('Group C');

-- Вставка данных в таблицу Students
INSERT INTO Students ([Name], GroupId)
VALUES ('John Doe', 1), ('Jane Smith', 2), ('Michael Johnson', 3), ('Emily Davis', 1), ('David Brown', 2);

-- Вставка данных в таблицу Marks
INSERT INTO Marks ([Value], StudentId)
VALUES (10, 1), (8, 2), (12, 3), (6, 4), (9, 5);

select * from Groups