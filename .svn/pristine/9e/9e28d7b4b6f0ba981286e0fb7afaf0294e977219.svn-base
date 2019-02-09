
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HTRJ811]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HTRJ811
GO

SELECT *
INTO ISADusRawDb.dbo.HTRJ811
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HTRJ811   ')c
GO