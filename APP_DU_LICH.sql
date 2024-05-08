CREATE DATABASE Explora
GO
USE Explora
GO

-- =========================== TABLE ===================================

--1
CREATE TABLE t_USER(
    User_Id             INT             IDENTITY(1,1)    PRIMARY KEY ,
    Phone_Number	    varchar(15)     NOT NULL,
    User_Name           nvarchar(50)    NOT NULL,
    Email		        varchar(50)     NOT NULL,
    Password_User       varchar(50)     NOT NULL,
    Date_Of_Birth       DATETIME        NOT NULL,
    Url_Avatar         NVARCHAR(300)   NOT NULL,
    Reset_Password_Token nvarchar(100) ,
    Email_Confirm       TINYINT        DEFAULT(0),
    Email_Confirm_Token nvarchar(100) ,   
)

CREATE TABLE t_ROLE(
    Role_Id             INT             IDENTITY(1,1)    PRIMARY KEY ,
    Role_Name           nvarchar(20)    NOT NULL,
    Status_Role         NVARCHAR(5)     NOT NULL,
)
CREATE TABLE t_ROLE_USER(
    Id             INT             IDENTITY(1,1)    PRIMARY KEY ,
    Role_Id             INT        NOT NULL ,
    User_Id        INT             NOT NULL ,
    CONSTRAINT FK_ROLE_USER_1 FOREIGN KEY(Role_Id) REFERENCES t_ROLE(Role_Id),
    CONSTRAINT FK_ROLE_USER_2 FOREIGN KEY(User_Id) REFERENCES t_USER(User_Id)

)

CREATE TABLE t_HOTEL(
    Id_Hotel            INT      IDENTITY(1,1) PRIMARY KEY,
    Hotel_Name      nvarchar(50)    NOT NULL,
    Email          varchar(50)		NOT NULL,
    Address_Hotel   nvarchar(50)    NOT NULL,
	Phone_Number    varchar(15)     NOT NULL,
    Is_Delete       INT             NOT NULL,
    User_Id         Int             NOT NULL,
    CONSTRAINT FK_HOTEL1 FOREIGN KEY(User_Id) REFERENCES t_USER(User_Id)
)




CREATE TABLE t_AIRLINE(
    Id_Airline         INT      IDENTITY(1,1) PRIMARY KEY,
    Airline_Name      nvarchar(50)    NOT NULL,
    Email          varchar(50)		NOT NULL,
    Address_Airline   nvarchar(50)    NOT NULL,
	Phone_Number    varchar(15)     NOT NULL,
    Is_Delete       INT             NOT NULL,
)
CREATE TABLE t_NHA_XE(
    Id_Nha_Xe         INT      IDENTITY(1,1) PRIMARY KEY,
    Nha_xe_Name      nvarchar(50)    NOT NULL,
    Email          varchar(50)		NOT NULL,
    Address_Nha_Xe   nvarchar(50)    NOT NULL,
	Phone_Number    varchar(15)     NOT NULL,
    Is_Delete       INT             NOT NULL,

)
--3
CREATE TABLE t_BUS(
    Id_Bus              INT      IDENTITY(1,1) PRIMARY KEY,
    Id_Nha_Xe         INT      NOT NULL,
    Bus_Name            nvarchar(50)    NOT NULL,
    Price               INT             NOT NULL,
    Slot                INT             NOT NULL,
    Empty_Slot          INT             NOT NULL,
    Start_Point         nvarchar(15)    NOT NULL,
    End_Point           nvarchar(15)    NOT NULL,
	Start_Time	        SMALLDATETIME   NOT NULL,
    Is_Delete           INT     NOT NULL,
    CONSTRAINT FK_CHUYEN_XE_1 FOREIGN KEY (Id_Nha_Xe) REFERENCES t_NHA_XE(Id_Nha_Xe) 
)

--4
CREATE TABLE t_PLANE(
    Id_Plane            INT      IDENTITY(1,1) PRIMARY KEY,
    Plane_Name          nvarchar(50)    NOT NULL,
    Price               INT             NOT NULL,
    Slot                INT             NOT NULL,
    Empty_Slot          INT             NOT NULL,
    Start_Point         nvarchar(15)    NOT NULL,
    End_Point           nvarchar(15)    NOT NULL,
	Start_Time	        SMALLDATETIME   NOT NULL,
    Is_Delete           INT             NOT NULL,
    Id_Airline         INT          NOT NULL,
    CONSTRAINT FK_CHUYEN_BAY_1 FOREIGN KEY (Id_Airline) REFERENCES t_AIRLINE(Id_Airline)
)

--5
CREATE TABLE t_ROOM(
    Id_Room         INT     IDENTITY(1,1) PRIMARY KEY,
    Id_Hotel            INT      NOT NULL,
    Slot            INT             NOT NULL,
    Empty_Slot          INT             NOT NULL,
    Price           INT             NOT NULL,
    Type_Room       nvarchar(10)    NOT NULL, 
    Image_Url       nvarchar(300)   NOT NULL,
    Is_Delete       INT             NOT NULL,
    CONSTRAINT FK_PHONG_1 FOREIGN KEY (Id_Hotel) REFERENCES t_HOTEL(Id_Hotel)
)

--6
CREATE TABLE t_BILL_ROOM(
    Bill_Id             INT      IDENTITY(1,1) PRIMARY KEY,
    Guess_Name          nvarchar(50)    NOT NULL,
    Guess_Email         varchar(50)		NOT NULL,
    Phone_Number        varchar(15)     NOT NULL,
    Total_Price         INT             NOT NULL,
    Start_Time          DATE     NOT NULL,
    End_Time            DATE    NOT NULL,
	Buy_Time	        DATE     NOT NULL,
    User_Id             INT      NOT NULL,
    Id_Room             INT      NOT NULL,
    CONSTRAINT FK_HD_DAT_PHONG_1 FOREIGN KEY (Id_Room) REFERENCES t_ROOM(Id_Room),
    CONSTRAINT FK_HD_DAT_PHONG_2 FOREIGN KEY (User_Id) REFERENCES t_USER(User_Id),
)

--7

CREATE TABLE t_ORDER_BUS(
    Order_Id    INT      IDENTITY(1,1) PRIMARY KEY,
    Amount              INT             NOT NULL,
    Total_Price         INT             NOT NULL,
	Buy_Time	        DATE     NOT NULL,
    User_Id             INT      NOT NULL,
    Id_Bus                INT             NOT NULL,
    CONSTRAINT FK_ORDER_VE_XE_1 FOREIGN KEY (User_Id) REFERENCES t_USER(User_Id),
    CONSTRAINT FK_ORDER_VE_XE_2 FOREIGN KEY (Id_Bus) REFERENCES t_BUS(Id_Bus),


)
CREATE TABLE t_ORDER_PLANE(
    Order_Id    INT      IDENTITY(1,1) PRIMARY KEY,
    Amount              INT             NOT NULL,
    Total_Price         INT             NOT NULL,
	Buy_Time	        DATE     NOT NULL,
    User_Id             INT      NOT NULL,
    Id_Plane                INT             NOT NULL,
    CONSTRAINT FK_ORDER_VE_MAY_BAY_1 FOREIGN KEY (User_Id) REFERENCES t_USER(User_Id),
    CONSTRAINT FK_ORDER_VE_MAY_BAY_2 FOREIGN KEY (Id_Plane) REFERENCES t_PLANE(Id_Plane),

)
CREATE TABLE t_BUS_TICKET(
    Ticket_Id               INT      IDENTITY(1,1) PRIMARY KEY,
    Order_Id    INT      NOT NULL,            
    Guess_Name          nvarchar(50)    NOT NULL,
    Guess_Email         varchar(50)		NOT NULL,
    Phone_Number        varchar(15)     NOT NULL,
    Id_Bus                  INT      NOT NULL,
    CONSTRAINT FK_VE_XE_1 FOREIGN KEY (Id_Bus) REFERENCES t_BUS(Id_Bus),
    CONSTRAINT FK_VE_XE_2 FOREIGN KEY (Order_Id) REFERENCES t_ORDER_BUS(Order_Id),

)

--8
CREATE TABLE t_PLANE_TICKET(
    Ticket_Id               INT      IDENTITY(1,1) PRIMARY KEY,
    Order_Id    INT      NOT NULL,            
    Guess_Name          nvarchar(50)    NOT NULL,
    Guess_Email         varchar(50)		NOT NULL,
    Phone_Number        varchar(15)     NOT NULL,
    Date_Of_Birth       DATE            NOT NULL,
    Nationality            NVARCHAR(20)    NOT NULL,
    Passpost_Number     NVARCHAR(8)     NOT NULL,
    Expired_Time        DATE            NOT NULL,
    Id_Plane                INT             NOT NULL,
    CONSTRAINT FK_VE_MAY_BAY_1 FOREIGN KEY (Id_Plane) REFERENCES t_PLANE(Id_Plane),
    CONSTRAINT FK_VE_MAY_BAY_2 FOREIGN KEY (Order_Id) REFERENCES t_ORDER_PLANE(Order_Id),
    
)

UPDATE t_ROOM SET Empty_Slot=4 
WHERE Id_Room =1
