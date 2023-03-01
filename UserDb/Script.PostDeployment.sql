if not exists(SELECT 1 FROM dbo.[User])
begin
	INSERT 
	INTO dbo.[User] (FirstName, LastName) 
	VALUES 
	('John', 'Snow'),
	('Mike', 'Magic'),
	('Sam', 'Smith'),
	('Anna', 'Johnes');
end