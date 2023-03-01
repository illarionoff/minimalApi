CREATE PROCEDURE [dbo].[spUser_GetAll]
	@param1 int = 0,
	@param2 int
AS
begin
	SELECT Id, FirstName, LastName 
	FROM dbo.[User];
end
