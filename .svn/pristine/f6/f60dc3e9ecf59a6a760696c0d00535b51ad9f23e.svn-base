USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DOSHEET]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DOSHEET
GO

SELECT *
INTO ISADusRawDb.dbo.DOSHEET
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DOSHEET   ')c
GO