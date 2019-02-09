USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.Jns_solo') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Jns_solo
GO
SELECT 
	*
INTO ISAPunyaJKT.dbo.Jns_solo
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM Jns_solo')
GO

USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.KelompokBarang
GO
INSERT INTO ISAPalurTradingDb02.dbo.KelompokBarang  (
			RowId, KodeKelompokBarang, NamaKelompokBarang, 
			[Status], LastSynch, CreatedBy, CreatedOn, 
			LastUpdateBy, LastUpdateDate
			)
SELECT		 NEWID(), RTRIM(KLP), RTRIM(ket),
			1, GETDATE(), 'IMPORT', GETDATE(),
			'IMPORT', GETDATE()
			
FROM ISAPunyaJKT.dbo.Jns_solo