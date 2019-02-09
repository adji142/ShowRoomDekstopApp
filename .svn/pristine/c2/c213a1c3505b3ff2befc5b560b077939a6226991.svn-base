
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HTR1]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HTR1
GO

SELECT *
INTO ISADusRawDb.dbo.HTR1
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HTR1   ')c
GO