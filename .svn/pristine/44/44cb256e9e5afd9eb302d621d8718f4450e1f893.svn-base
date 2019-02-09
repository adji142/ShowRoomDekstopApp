USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DRETURJ]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DRETURJ
GO

SELECT *
INTO ISADusRawDb.dbo.DRETURJ
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DRETURJ   ')c
GO