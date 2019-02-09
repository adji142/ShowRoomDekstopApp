USE ISAPalurTradingDb02
GO
DELETE FROM dbo.Numerator 
GO

INSERT INTO dbo.Numerator
(
	RowID, 
	Doc, 
	Depan, 
	Belakang, 
	Nomor, 
	Lebar, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	NEWID(),
	ltrim(rtrim(kode_doc)),
	ltrim(rtrim(Depan)),
	'',
	ltrim(rtrim(Numerator)),
	(len(ltrim(rtrim(Depan)))+len(ltrim(rtrim(Numerator)))),
	'Import',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM NoDoc')

GO

delete from Numerator where Doc=''