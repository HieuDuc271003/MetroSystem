CREATE DATABASE MetroSystem;
GO

USE MetroSystem;
GO

-- Bảng phân quyền người dùng
CREATE TABLE Role (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL
);
-- Bảng lưu thông tin người dùng
CREATE TABLE [User] (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Status BIT DEFAULT 1,
    RoleID INT NOT NULL,
    CONSTRAINT FK_User_Role FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);

-- Bảng lưu thông tin tuyến metro
CREATE TABLE MetroLine (
    LineID INT IDENTITY(1,1) PRIMARY KEY,
    LineName NVARCHAR(100) NOT NULL,
    Distance FLOAT NOT NULL,
    Status BIT DEFAULT 1
);

-- Bảng lưu thông tin các ga metro
CREATE TABLE MetroStation (
    StationID INT IDENTITY(1,1) PRIMARY KEY,
    StationName NVARCHAR(100) NOT NULL,
    LineID INT NOT NULL,
    Location NVARCHAR(255),
    Status BIT DEFAULT 1,
    CONSTRAINT FK_Station_Line FOREIGN KEY (LineID) REFERENCES MetroLine(LineID)
);

-- Bảng lưu lịch trình metro
CREATE TABLE Schedule (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    LineID INT NOT NULL,
    StationID INT NOT NULL,
    ArrivalTime TIME NOT NULL,
    DepartureTime TIME NOT NULL,
    CONSTRAINT FK_Schedule_Line FOREIGN KEY (LineID) REFERENCES MetroLine(LineID),
    CONSTRAINT FK_Schedule_Station FOREIGN KEY (StationID) REFERENCES MetroStation(StationID)
);

-- Bảng lưu lịch sử hành trình của người dùng
CREATE TABLE Log (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    ScheduleID INT NOT NULL,
    Location NVARCHAR(255),
    Date DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Log_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_Log_Schedule FOREIGN KEY (ScheduleID) REFERENCES Schedule(ScheduleID)
);

-- Bảng lưu các tuyến hoặc ga yêu thích của người dùng
CREATE TABLE Bookmark (
    BookmarkID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    LineID INT NULL,
    StationID INT NULL,
    Status BIT DEFAULT 1,
    CONSTRAINT FK_Bookmark_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_Bookmark_Line FOREIGN KEY (LineID) REFERENCES MetroLine(LineID),
    CONSTRAINT FK_Bookmark_Station FOREIGN KEY (StationID) REFERENCES MetroStation(StationID)
);

-- Bảng lưu phản hồi từ người dùng
CREATE TABLE Feedback (
    FeedbackID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    LineID INT NULL,
    Comment NVARCHAR(1000),
    Rating INT CHECK (Rating BETWEEN 1 AND 5),
    CONSTRAINT FK_Feedback_User FOREIGN KEY (UserID) REFERENCES [User](UserID),
    CONSTRAINT FK_Feedback_Line FOREIGN KEY (LineID) REFERENCES MetroLine(LineID)
);

-- Bảng lưu lịch sử tìm kiếm và đề xuất tuyến đường AI
CREATE TABLE History (
    HistoryID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT NOT NULL,
    Timestamp DATETIME DEFAULT GETDATE(),
    Message NVARCHAR(1000),
    RecommendID INT NULL,
    CONSTRAINT FK_History_User FOREIGN KEY (UserID) REFERENCES [User](UserID)
);

-- Dữ liệu mẫu
INSERT INTO Role (RoleName) VALUES ('Guest'), ('User'), ('Staff'), ('Manager');
INSERT INTO [User] (Name, Email, Password, PhoneNumber, Status, RoleID) VALUES 
('John Doe', 'john@example.com', 'hashedpassword1', '123456789', 1, 2),
('Jane Smith', 'jane@example.com', 'hashedpassword2', '987654321', 1, 3),
('Alice Johnson', 'alice@example.com', 'hashedpassword3', '555666777', 1, 4),
('Bob Brown', 'bob@example.com', 'hashedpassword4', '444555666', 1, 1);

INSERT INTO MetroLine (LineName, Distance, Status) VALUES 
('Line 1', 15.5, 1),
('Line 2', 20.0, 1);

INSERT INTO MetroStation (StationName, LineID, Location, Status) VALUES 
('Station A', 1, 'Downtown', 1),
('Station B', 1, 'Uptown', 1),
('Station C', 2, 'Suburb', 1);

INSERT INTO Schedule (LineID, StationID, ArrivalTime, DepartureTime) VALUES 
(1, 1, '08:00:00', '08:05:00'),
(1, 2, '08:10:00', '08:15:00'),
(2, 3, '09:00:00', '09:05:00');
