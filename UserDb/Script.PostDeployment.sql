if not exists(SELECT 1 FROM dbo.[User])
begin
	INSERT 
	INTO db.[User] (FirstName, LastName) 
	VALUES 
	('John', 'Snow'),
	('Mike', 'Magic'),
	('Sam', 'Smith'),
	('Anna', 'Johnes');
end