
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[REG]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.REG
GO

SELECT *
INTO ISADusRawDb.dbo.REG
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM REG   ')c
GO