create database MyDataBases
create table Phones (
	BranName VARCHAR(50) not null,
	ModelName VARCHAR(50) not null,
	Cost INT,
	OS VARCHAR(50),
	Color VARCHAR(50),
	Count INT
);
insert into Phones (BranName, ModelName, Cost, OS, Color, Count) values ('Realme', 'Realme 7 5G', 1317, 'Android 10, Realme UI', 'Turquoise', 4)
,('Siemens', 'Siemens SP65', 2318, 'Feature phone', 'Green', 98)
,('Celkon', 'Celkon A7', 1805, 'Feature phone', 'Goldenrod', 76)
,('Lenovo', 'Lenovo Tab3 8 Plus', 2394, 'Android 6.0.1', 'Indigo', 68)
,('vivo', 'vivo S6 5G', 1707, 'Android 10, Funtouch 10.0', 'Khaki', 85)
,('QMobile', 'QMobile A1', 900, 'Android 5.1, up to 6.0', 'Mauv', 97)
,('ZTE', 'ZTE Style Messanger', 1522, 'Feature phone', 'Purple', 39)
,('vivo', 'vivo X9s', 887, 'Android 7.1, up to Android 8.0, Funtouch 3.1', 'Pink', 10)
,('Micromax', 'Micromax Canvas Xpress 2 E313', 1133, 'Android 4.4.2', 'Teal', 79)
,('Samsung', 'Samsung A817 Solstice II', 531, 'Feature phone', 'Aquamarine', 80)
,('Eten', 'Eten glofiish M800', 900, 'Microsoft Windows Mobile 6.0', 'Green', 77)
,('Karbonn', 'Karbonn A15', 686, 'Android 4.0.4', 'Aquamarine', 13)
,('ZTE', 'ZTE V889M', 1486, 'Android 4.0', 'Khaki', 92)
,('T-Mobile', 'T-Mobile Garminfone', 1256, 'Android 2.1', 'Fuscia', 3)
,('ZTE', 'ZTE nubia Red Magic 3s', 1365, 'Android 9.0, Redmagic 2.0', 'Indigo', 36)
,('Blackview', 'Blackview P6000', 501, 'Android 7.1.1', 'Pink', 0)
,('Tel.Me.', 'Tel.Me. T939', 1489, 'Microsoft Windows PocketPC 2003 Phone edition', 'Turquoise', 31)
,('LG', 'LG P7200', 1474, 'Feature phone', 'Pink', 48)
,('LG', 'LG G5310', 817, 'Feature phone', 'Crimson', 54)
,('Motorola', 'Motorola E378i', 892, 'Feature phone', 'Fuscia', 12)
,('Philips', 'Philips 868', 2037, 'Feature phone', 'Goldenrod', 9)
,('BenQ-Siemens', 'BenQ-Siemens EF81', 2258, 'Feature phone', 'Yellow', 33)
,('Spice', 'Spice Mi-436 Stellar Glamour', 631, 'Android 4.2', 'Teal', 27)
,('Yezz', 'Yezz Zenior YZ888', 1938, 'Feature phone', 'Orange', 88)
,('Sagem', 'Sagem MY V-55', 2475, 'Feature phone', 'Maroon', 99)
,('Nokia', 'Nokia 1101', 1040, 'Feature phone', 'Blue', 98)
,('Acer', 'Acer Liquid Z2', 2272, 'Android 4.1.1', 'Turquoise', 95)
,('LG', 'LG Spirit', 2374, 'Android 5.0.1, up to 6.0.1', 'Aquamarine', 96)
,('Sharp', 'Sharp TM200', 807, 'Feature phone', 'Yellow', 89)
,('Motorola', 'Motorola A732', 1789, 'Feature phone', 'Fuscia', 68)
 select *
 from Phones