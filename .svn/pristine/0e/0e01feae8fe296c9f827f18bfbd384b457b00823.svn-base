USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRANSJ]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRANSJ
GO

SELECT *
INTO ISADusRawDb.dbo.DTRANSJ
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRANSJ   ')c
GO