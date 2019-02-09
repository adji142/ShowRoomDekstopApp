
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[PEMASOK]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.PEMASOK
GO

SELECT *
INTO ISADusRawDb.dbo.PEMASOK
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM PEMASOK   ')c
GO