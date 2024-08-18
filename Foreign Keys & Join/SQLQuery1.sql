create database Academy
use Academy

create table Teachers (
	[Id] int identity not null primary key,
	[Name] nvarchar(50) not null check([Name] <> ''),
	[Surname] nvarchar(50) not null check([Surname] <> '')
)

create table Assistants (
	[Id] int identity not null primary key,
	[TeacherId] int not null foreign key references Teachers([Id])
)

create table Curators (
	[Id] int identity not null primary key,
	[TeacherId] int not null foreign key references Teachers([Id])
)

create table Deans (
	[Id] int identity not null primary key,
	[TeacherId] int not null foreign key references Teachers([Id])
)

create table Faculties (
	[Id] int identity not null primary key,
	[Building] int not null check([Building] > 0 and [Building] < 6),
	[Name] nvarchar(100) not null check([Name] <> '') unique,
	[DeanId] int not null foreign key references Deans([Id])
)

create table Heads(
	[Id] int identity not null primary key,
	[TeacherId] int not null foreign key references Teachers([Id])
)

create table Departments (
	[Id] int identity not null primary key,
	[Building] int not null check([Building] > 0 and [Building] < 6),
	[Name] nvarchar(100) not null check([Name] <> '') unique,
	[FacultyId] int not null foreign key references Faculties([Id]),
	[HeadId] int not null foreign key references Heads([Id])
)

create table Groups(
	[Id] int identity not null primary key,
	[Name] nvarchar(10) not null check([Name] <> '') unique,
	[Year] int not null check([Year] > 0 and [Year] < 6),
	[DepartmentId] int not null foreign key references Departments([Id])
)

create table GroupsCurators(
	[Id] int identity not null primary key,
	[CuratorId] int not null foreign key references Curators([Id]),
	[GroupId] int not null foreign key references Groups([Id])
)

create table Subjects(
	[Id] int identity not null primary key,
	[Name] nvarchar(100) not null check([Name] <> '') unique,
)

create table Lectures(
	[Id] int identity not null primary key,
	[SubjectId] int not null foreign key references Subjects([Id]),
	[TeacherId] int not null foreign key references Teachers([Id])
)

create table GroupsLectures(
	[Id] int identity not null primary key,
	[GroupId] int not null foreign key references Groups([Id]),
	[LectureId] int not null foreign key references Lectures([Id])
)

create table LectureRooms(
	[Id] int identity not null primary key,
	[Building] int not null check([Building] > 0 and [Building] < 6),
	[Name] nvarchar(10) not null check([Name] <> '') unique
)

create table Schedules(
	[Id] int identity not null primary key,
	[Class] int not null check([Class] > 0 and [Class] < 9),
	[DayOfWeek] int not null check([DayOfWeek] > 0 and [DayOfWeek] < 8),
	[Week] int not null check([Week] > 0 and [Week] < 53),
	[LectureId] int not null foreign key references Lectures([Id]),
	[LectureRoomId] int not null foreign key references LectureRooms([Id]),
)

select lr.[Name]
from LectureRooms lr
join Schedules s on s.[LectureRoomId] = lr.Id
join Lectures l on l.[Id] = s.[LectureId]
join Teachers t on t.[id] = l.[TeacherId]
where t.[Name] = 'Edward' and t.[Surname] = 'Hopper'

select t.[Surname]
from Teachers t
join Assistants a on a.[TeacherId] = t.[Id]
join Lectures l on l.[TeacherId] = t.[Id]
join GroupsLectures gl on gl.[LectureId] = l.[Id]
join Groups g on g.[Id] = gl.[GroupId]
where g.[Name] = 'F505'

select s.[Name]
from Subjects s
join Lectures l on l.[SubjectId] = s.[Id]
join Teachers t on t.[Id] = l.[TeacherId]
join GroupsLectures gl on gl.[LectureId] = l.[Id]
join Groups g on g.[Id] = gl.[GroupId]
where t.[Name] = 'Alex' and t.[Surname] = 'Carmack' and g.[Year] = 5

select t.[Surname]
from Teachers t
join Lectures l on l.[TeacherId] = t.[Id]
join Schedules s on s.LectureId = l.[Id]
where s.[DayOfWeek] <> 1

select lr.[Name], lr.[Building]
from LectureRooms lr
join Schedules s on s.[LectureRoomId] = lr.[Id]
where s.[DayOfWeek] <> 3 and s.[Week] <> 2 and s.[Class] <> 3

-- 6

select f.Building, d.Building, lr.Building
from Faculties f
join Departments d on 1 <> 2
join LectureRooms lr on 1 <> 2