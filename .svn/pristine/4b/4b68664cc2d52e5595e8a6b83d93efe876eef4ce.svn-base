USE ISAPunyaJKT

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[PROPINSI]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.PROPINSI
GO

SELECT  *
INTO ISAPunyaJKT.dbo.PROPINSI			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM PROPINSI')c
GO




DELETE FROM ISAPalurTradingDb02.dbo.Propinsi
GO



INSERT INTO ISAPalurTradingDb02.dbo.Propinsi
(
  Propinsi
)
SELECT 
	
	propinsi
	
FROM ISAPunyaJKT.dbo.PROPINSI	
