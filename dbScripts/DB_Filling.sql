use GreenHouseDb

INSERT INTO Users(Email, FName, SName, Password, IsAdmin)
VALUES ('alex.rahuba@gmail.com', 'Alex','Rahuba','123456789',1);

INSERT INTO Rooms(Number, Floor, Capacity)
VALUES ('301', 5, 100),
       ('302', 5, 80),
	   ('303', 5, 50);

INSERT INTO AdditEquipments(Name)
VALUES ('WIFI'),
		('Projector'),
		('Monitor'),
		('Microphone');

INSERT INTO Reservations(UserId, RoomId, BeginTime, EndTime, Purpose)
VALUES (1,1,'2015-9-1 12:00:00.000','2015-9-1 12:00:00.000','Lection'),
		(1,2,'2015-9-1 10:00:00.000','2015-9-1 12:00:00.000','Seminar'),
		(1,1,'2015-9-2 10:00:00.000','2015-9-2 12:00:00.000','Seminar');

INSERT INTO Blocks(UserId, RoomId, BeginTime, EndTime)
VALUES (1,1,'2015-9-2 15:00:00.000','2015-9-2 16:00:00.000');

INSERT INTO AdditEquipmentsRooms (RoomId, EquipId)
VALUES (1,1),(1,2),(1,4),
		(2,1),(2,2),(2,3),(2,4),
		 (3,1),(3,2);
