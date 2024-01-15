DECLARE @StreetName nvarchar (50)     SET @StreetName = 'Rullstensbacken 12'
DECLARE @PostalCode  nvarchar (50)    SET @PostalCode = '703 53'
DECLARE @City nvarchar (50)           SET @City = 'Örebro'


IF NOT EXISTS (SELECT 1 FROM Adresses WHERE StreetName=@StreetName AND PostalCode= @PostalCode AND City=@City ) INSERT INTO Adresses OUTPUT INSERTED.Id VALUES ( @StreetName, @PostalCode,  @City) 
