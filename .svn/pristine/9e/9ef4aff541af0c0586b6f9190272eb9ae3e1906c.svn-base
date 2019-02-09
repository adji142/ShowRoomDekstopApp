
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HMUTSTOK]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HMUTSTOK
GO

SELECT *
INTO ISADusRawDb.dbo.HMUTSTOK
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HMUTSTOK   ')c
GO