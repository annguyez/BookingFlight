USE [AnNguyen_Flight]
GO
/****** Object:  Table [dbo].[Aircrafts]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircrafts](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MakeModel] [nvarchar](10) NULL,
	[TotalSeats] [int] NOT NULL,
	[EconomySeats] [int] NOT NULL,
	[BusinessSeats] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Aircrafts] ([ID], [Name], [MakeModel], [TotalSeats], [EconomySeats], [BusinessSeats]) VALUES (1, N'Airbus', N'Air1', 205, 162, 21)
INSERT [dbo].[Aircrafts] ([ID], [Name], [MakeModel], [TotalSeats], [EconomySeats], [BusinessSeats]) VALUES (2, N'Boeing 777', N'Bo1', 150, 100, 5)
INSERT [dbo].[Aircrafts] ([ID], [Name], [MakeModel], [TotalSeats], [EconomySeats], [BusinessSeats]) VALUES (3, N'Antonov', N'An1', 160, 110, 15)
INSERT [dbo].[Aircrafts] ([ID], [Name], [MakeModel], [TotalSeats], [EconomySeats], [BusinessSeats]) VALUES (4, N'Embraer', N'E1', 170, 120, 25)
INSERT [dbo].[Aircrafts] ([ID], [Name], [MakeModel], [TotalSeats], [EconomySeats], [BusinessSeats]) VALUES (5, N'Bombardier', N'B22', 180, 130, 35)
/****** Object:  Table [dbo].[Countries]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Countries] ON
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (1, N'Viet Nam')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (2, N'Congo')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (3, N'Trung Quoc')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (4, N'Thai Lan')
INSERT [dbo].[Countries] ([ID], [Name]) VALUES (5, N'UAE')
SET IDENTITY_INSERT [dbo].[Countries] OFF
/****** Object:  Table [dbo].[CabinTypes]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CabinTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CabinTypes] ON
INSERT [dbo].[CabinTypes] ([ID], [Name]) VALUES (1, N'Economy')
INSERT [dbo].[CabinTypes] ([ID], [Name]) VALUES (2, N'Business')
INSERT [dbo].[CabinTypes] ([ID], [Name]) VALUES (6, N'Firstclass')
SET IDENTITY_INSERT [dbo].[CabinTypes] OFF
/****** Object:  Table [dbo].[Roles]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (2, N'Admin 1')
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (3, N'Admin 2')
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (4, N'Admin 3')
INSERT [dbo].[Roles] ([ID], [Title]) VALUES (5, N'Admin 34')
/****** Object:  Table [dbo].[Offices]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Contact] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Offices] ON
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (1, 1, N'XYZ', N'113', N'Jack Ma')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (2, 2, N'XYZ1', N'114', N'Auckland (New Zealand')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (3, 3, N'XYZ2', N'115', N'Amsterdam-Hà Lan')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (4, 4, N'XYZ3', N'116', N'Hong Kong. ...')
INSERT [dbo].[Offices] ([ID], [CountryID], [Title], [Phone], [Contact]) VALUES (5, 5, N'XYZ5', N'117', N'Bắc Kinh (Trung Quốc) ')
SET IDENTITY_INSERT [dbo].[Offices] OFF
/****** Object:  Table [dbo].[Airports]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Airports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryID] [int] NOT NULL,
	[IATACode] [varchar](3) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Airports] ON
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (1, 1, N'VNU', N'Noi Bai')
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (2, 1, N'TSN', N'Tan Son Nhat')
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (3, 2, N'ABD', N'Abi Dhu')
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (4, 3, N'CG', N'Changi ')
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (5, 4, N'IC', N'Incheon ')
INSERT [dbo].[Airports] ([ID], [CountryID], [IATACode], [Name]) VALUES (6, 5, N'MU', N'Munich ')
SET IDENTITY_INSERT [dbo].[Airports] OFF
/****** Object:  Table [dbo].[Routes]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartureAirportID] [int] NOT NULL,
	[ArrivalAirportID] [int] NOT NULL,
	[Distance] [int] NOT NULL,
	[FlightTime] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Routes] ON
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (1, 1, 2, 100, 40)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (2, 1, 3, 100, 40)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (3, 1, 4, 100, 40)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (4, 2, 5, 100, 40)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (5, 3, 1, 200, 50)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (6, 3, 2, 200, 25)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (7, 2, 1, 100, 200)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (8, 3, 4, 50, 20)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (10, 4, 5, 100, 200)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (11, 2, 1, 100, 50)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (12, 3, 1, 1000, 50)
INSERT [dbo].[Routes] ([ID], [DepartureAirportID], [ArrivalAirportID], [Distance], [FlightTime]) VALUES (13, 4, 1, 300, 50)
SET IDENTITY_INSERT [dbo].[Routes] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int]  IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[OfficeID] [int] NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Birthdate] [nvarchar](50) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK__Users__3214EC271A14E395] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Users] ([ID], [RoleID], [OfficeID], [Email], [Password], [FirstName], [LastName], [Birthdate], [Active]) VALUES (1, 1, 1, N'annguyen@gmail.com', N'123456', N'An Nguyen', N'Nguyen', N'6/2/1998', 1)
/****** Object:  Table [dbo].[Schedules]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](5) NOT NULL,
	[AircraftID] [int] NOT NULL,
	[RouteID] [int] NOT NULL,
	[EconomyPrice] [money] NOT NULL,
	[Confirmed] [bit] NOT NULL,
	[FlightNumber] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (1, CAST(0x6E400B00 AS Date), CAST(0x0500D2496B000000 AS Time), 1, 3, 500.0000, 0, N'1')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (2, CAST(0x6A400B00 AS Date), CAST(0x05005B41F8010000 AS Time), 1, 2, 400.0000, 1, N'2')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (3, CAST(0x6A400B00 AS Date), CAST(0x0500C686ED010000 AS Time), 1, 4, 300.0000, 1, N'3')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (4, CAST(0x6D400B00 AS Date), CAST(0x0500FCBE80000000 AS Time), 2, 5, 200.0000, 1, N'4')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (11, CAST(0x6D400B00 AS Date), CAST(0x0500FCBE80000000 AS Time), 2, 1, 220.0000, 0, N'5')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (12, CAST(0x6D400B00 AS Date), CAST(0x0500FCBE80000000 AS Time), 4, 7, 550.0000, 1, N'6')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (13, CAST(0x6E400B00 AS Date), CAST(0x0500263496000000 AS Time), 2, 1, 400.0000, 0, N'6')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (14, CAST(0x6D400B00 AS Date), CAST(0x050050A9AB000000 AS Time), 1, 3, 550.0000, 1, N'6')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (15, CAST(0x6D400B00 AS Date), CAST(0x050050A9AB000000 AS Time), 1, 10, 600.0000, 1, N'9')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (16, CAST(0x6D400B00 AS Date), CAST(0x05007A1EC1000000 AS Time), 3, 4, 100.0000, 1, N'7')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (18, CAST(0x6E400B00 AS Date), CAST(0x0500A8D455000000 AS Time), 2, 11, 200.0000, 1, N'4')
INSERT [dbo].[Schedules] ([ID], [Date], [Time], [AircraftID], [RouteID], [EconomyPrice], [Confirmed], [FlightNumber]) VALUES (19, CAST(0x6D400B00 AS Date), CAST(0x05004C682C010000 AS Time), 1, 13, 100.0000, 1, N'10')
SET IDENTITY_INSERT [dbo].[Schedules] OFF
/****** Object:  Table [dbo].[Tickets]    Script Date: 11/25/2019 09:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ScheduleID] [int] NOT NULL,
	[CabinTypeID] [int] NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Lastname] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](14) NOT NULL,
	[PassportNumber] [nvarchar](9) NOT NULL,
	[PassportCountryID] [int] NOT NULL,
	[BookingReference] [nvarchar](6) NOT NULL,
	[Confirmed] [bit] NOT NULL,
 CONSTRAINT [PK__Tickets__3214EC272B3F6F97] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON
INSERT [dbo].[Tickets] ([ID], [UserID], [ScheduleID], [CabinTypeID], [Firstname], [Lastname], [Email], [Phone], [PassportNumber], [PassportCountryID], [BookingReference], [Confirmed]) VALUES (10, 1, 1, 1, N'An ', N'Nguyen', N'annguyen@gmail.com', N'09323331122', N'1151512', 15151, N'1', 1)
INSERT [dbo].[Tickets] ([ID], [UserID], [ScheduleID], [CabinTypeID], [Firstname], [Lastname], [Email], [Phone], [PassportNumber], [PassportCountryID], [BookingReference], [Confirmed]) VALUES (11, 1, 2, 2, N'Be', N'Be', N'bebe2@gmail.com', N'0922255225', N'1515', 1, N'2', 1)
SET IDENTITY_INSERT [dbo].[Tickets] OFF
/****** Object:  ForeignKey [FK_AirPort_Country]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Airports]  WITH CHECK ADD  CONSTRAINT [FK_AirPort_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Airports] CHECK CONSTRAINT [FK_AirPort_Country]
GO
/****** Object:  ForeignKey [FK_Office_Country]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_Office_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_Office_Country]
GO
/****** Object:  ForeignKey [FK_Routes_Airports2]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Routes]  WITH CHECK ADD  CONSTRAINT [FK_Routes_Airports2] FOREIGN KEY([DepartureAirportID])
REFERENCES [dbo].[Airports] ([ID])
GO
ALTER TABLE [dbo].[Routes] CHECK CONSTRAINT [FK_Routes_Airports2]
GO
/****** Object:  ForeignKey [FK_Routes_Airports3]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Routes]  WITH CHECK ADD  CONSTRAINT [FK_Routes_Airports3] FOREIGN KEY([ArrivalAirportID])
REFERENCES [dbo].[Airports] ([ID])
GO
ALTER TABLE [dbo].[Routes] CHECK CONSTRAINT [FK_Routes_Airports3]
GO
/****** Object:  ForeignKey [FK_Schedule_AirCraft]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_AirCraft] FOREIGN KEY([AircraftID])
REFERENCES [dbo].[Aircrafts] ([ID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedule_AirCraft]
GO
/****** Object:  ForeignKey [FK_Schedule_Routes]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Routes] FOREIGN KEY([RouteID])
REFERENCES [dbo].[Routes] ([ID])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedule_Routes]
GO
/****** Object:  ForeignKey [FK_Ticket_Schedule]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Schedule] FOREIGN KEY([ScheduleID])
REFERENCES [dbo].[Schedules] ([ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Ticket_Schedule]
GO
/****** Object:  ForeignKey [FK_Ticket_TravelClass]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_TravelClass] FOREIGN KEY([CabinTypeID])
REFERENCES [dbo].[CabinTypes] ([ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Ticket_TravelClass]
GO
/****** Object:  ForeignKey [FK_Ticket_User]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Ticket_User]
GO
/****** Object:  ForeignKey [FK_Users_Offices]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Offices] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Offices] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Offices]
GO
/****** Object:  ForeignKey [FK_Users_Roles]    Script Date: 11/25/2019 09:44:34 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
