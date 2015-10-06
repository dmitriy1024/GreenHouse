use GreenHouseDb

CREATE TABLE Rooms
(
	[RoomId] INT IDENTITY (1, 1) NOT NULL,
	[Number] NVARCHAR(20) NOT NULL,
	[Floor]  INT NOT NULL,
	[Capacity] INT NOT NULL,

)
GO

ALTER TABLE Rooms
ADD CONSTRAINT PK_Rooms_RoomId PRIMARY KEY CLUSTERED (RoomId)
GO

ALTER TABLE Rooms
ADD CONSTRAINT UQ_Rooms UNIQUE (Number, Floor)
GO

CREATE TABLE Users
(
	[UserId] INT IDENTITY (1, 1) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[FName] NVARCHAR(50) NOT NULL,
	[SName] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[IsAdmin] BIT NOT NULL
)
GO

ALTER TABLE Users
ADD CONSTRAINT PK_Users_UserId PRIMARY KEY CLUSTERED (UserId)
GO

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_Email UNIQUE (Email)
GO

CREATE TABLE Reservations
(
	[UserId] INT NOT NULL,
	[RoomId] INT NOT NULL,
	[BeginTime] DATETIME NOT NULL,
	[EndTime] DATETIME NOT NULL,
	[Purpose] NVARCHAR(50) NOT NULL
)
GO

ALTER TABLE Reservations
ADD CONSTRAINT PK_Reservations PRIMARY KEY CLUSTERED (UserId, RoomId, BeginTime, EndTime)
GO

ALTER TABLE Reservations
ADD CONSTRAINT FR_Reservations_UserId FOREIGN KEY (UserId) REFERENCES Users (UserId)
GO

ALTER TABLE Reservations
ADD CONSTRAINT FR_Reservations_RoomId FOREIGN KEY (UserId) REFERENCES Rooms (RoomId)
GO

CREATE TABLE Blocks
(
	[UserId] INT NOT NULL,
	[RoomId] INT NOT NULL,
	[BeginTime] DATETIME NOT NULL,
	[EndTime] DATETIME NULL,
	CONSTRAINT PK_Blocks PRIMARY KEY CLUSTERED (UserId, RoomId, BeginTime),
	CONSTRAINT FR_Blocks_UserId FOREIGN KEY (UserId) REFERENCES Users (UserId),
	CONSTRAINT FR_Blocks_RoomId FOREIGN KEY (RoomId) REFERENCES Rooms (RoomId)
)

CREATE TABLE AdditEquipments
(
	[EquipId] INT IDENTITY (1, 1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_AdditEquipments_EquipId PRIMARY KEY CLUSTERED (EquipId),
	CONSTRAINT UQ_AdditEquipment_Name UNIQUE(Name)	
)

CREATE TABLE AdditEquipmentsRooms
(
	[RoomId] INT NOT NULL,
	[EquipId] INT NOT NULL,
	CONSTRAINT PK_AdditEquipmentsRooms PRIMARY KEY CLUSTERED (RoomId,EquipId),
	CONSTRAINT FK_AdditEquipmentsRooms_RoomId FOREIGN KEY (RoomId) REFERENCES Rooms (RoomId),
	CONSTRAINT FK_AdditEquipmentsRooms_EquipId FOREIGN KEY (EquipId) REFERENCES AdditEquipments (EquipId)
)
