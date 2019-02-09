USE ISAPalurTradingDb02
GO
DELETE FROM dbo.Cabang 
GO

INSERT INTO dbo.Cabang
(
	CabangID, 
	Nama, 
	TelModem, 
	Alamat1, 
	Alamat2, 
	Kota, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT 
	left(ltrim(rtrim(Namatoko)),2),
	ltrim(rtrim(Namatoko)),
	ltrim(rtrim(noTelp)),
	ltrim(rtrim(Alamat)),
	'',
	ltrim(rtrim(Kota)),
	'Import',
	GETDATE()
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM Toko where len(rtrim(ltrim(NamaToko)))=4')

GO

