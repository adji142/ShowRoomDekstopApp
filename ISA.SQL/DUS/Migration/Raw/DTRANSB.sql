USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRANSB]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRANSB
GO

SELECT *
INTO ISADusRawDb.dbo.DTRANSB
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRANSB   ')c
GO