USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[kurs]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].kurs
GO


SELECT
	*
INTO ISAPunyaJKT.dbo.kurs
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM kurs')



USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.DBO.KursHargaJualBarang

INSERT INTO ISAPalurTradingDb02.DBO.KursHargaJualBarang
(
	RowID, 	
	TglKurs, 
	TglKursAkhir, 
	USD_IDR, 
	USD_TWD, 
	USD_CNY, 
	USD_HKD, 
	LastUpdatedBy, 
	LastUpdatedTime
)
SELECT
	NEWID() AS RowID, 
	tanggal AS TglKurs, 
	tanggal2 AS TglKursAkhir, 
	us AS USD_IDR, -- us ??
	nt AS USD_TWD,  -- darimana?
	rmb AS USD_CNY, -- darimana?
	0 AS USD_HKD, -- darimana?
	'Import', 
	GETDATE()
FROM ISAPunyaJKT.dbo.kurs kur


GO