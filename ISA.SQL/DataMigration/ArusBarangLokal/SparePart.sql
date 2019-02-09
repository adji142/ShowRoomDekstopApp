USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[J_SPART]') AND type in (N'U'))
DROP TABLE [ISAPunyaJKT].[dbo].J_SPART
GO

SELECT *
INTO ISAPunyaJKT.dbo.J_SPART
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM J_SPART')c

GO


USE ISAPalurTradingDb02
GO

DELETE FROM ISAPalurTradingDb02.dbo.SparePart
GO



INSERT INTO ISAPalurTradingDb02.dbo.SparePart
(
  Jenis,
  Keterangan
)
SELECT 
	jns,
	ket
FROM ISAPunyaJKT.dbo.J_SPART

GO


  