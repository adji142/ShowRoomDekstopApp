USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ISAPunyaJKT.dbo.NEWKOTA') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.NEWKOTA
GO
SELECT 
	*
INTO ISAPunyaJKT.dbo.NEWKOTA
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT * FROM NEWKOTA')
GO

USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.dbo.Kota
GO



INSERT INTO ISAPalurTradingDb02.dbo.Kota
(
  Kota,
  Propinsi,
  Cabang2
)
SELECT 
	kota,
	propinsi,
	cab2
FROM ISAPunyaJKT.dbo.NEWKOTA

GO


 