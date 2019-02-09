
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HRETURJ]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HRETURJ
GO

SELECT *
INTO ISADusRawDb.dbo.HRETURJ
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HRETURJ   ')c
GO