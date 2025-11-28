-- Создание таблицы Group
CREATE TABLE [Group] (
    GroupId INT IDENTITY(1,1) PRIMARY KEY,
    GroupName NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE()
);

-- Создание таблицы Student
CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    GroupId INT NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETDATE(),
    
    -- Внешний ключ, связывающий студента с группой
    CONSTRAINT FK_Student_Group 
        FOREIGN KEY (GroupId) 
        REFERENCES [Group](GroupId)
);

-- Создание индекса для улучшения производительности запросов по группе
CREATE INDEX IX_Student_GroupId ON Student(GroupId);