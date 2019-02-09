
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HOSHEET]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HOSHEET
GO

SELECT *
INTO ISADusRawDb.dbo.HOSHEET
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HOSHEET   ')c
GO