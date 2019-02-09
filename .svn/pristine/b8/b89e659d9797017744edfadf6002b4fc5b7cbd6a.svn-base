USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTR]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTR
GO

SELECT *
INTO ISADusRawDb.dbo.DTR
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTR   ')c
GO