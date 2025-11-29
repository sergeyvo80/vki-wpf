-- Добавляем группы
INSERT INTO [Group] (GroupName) VALUES 
('ИТ-101'),
('ИТ-102'),
('ФИЗ-201');

-- Добавляем студентов
INSERT INTO Student (FirstName, LastName, Email, GroupId) VALUES 
('Иван', 'Петров', 'ivan.petrov@email.com', 1),
('Мария', 'Сидорова', 'maria.sidorova@email.com', 1),
('Алексей', 'Иванов', 'alex.ivanov@email.com', 2),
('Елена', 'Козлова', 'elena.kozlova@email.com', 3);