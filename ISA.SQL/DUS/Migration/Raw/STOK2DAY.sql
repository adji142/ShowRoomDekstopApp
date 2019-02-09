
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[STOK2DAY]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.STOK2DAY
GO

SELECT *
INTO ISADusRawDb.dbo.STOK2DAY
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM STOK2DAY   ')c
GO