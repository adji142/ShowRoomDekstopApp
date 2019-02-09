
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[TOKO]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.TOKO
GO

SELECT *
INTO ISADusRawDb.dbo.TOKO
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM TOKO   ')c
GO