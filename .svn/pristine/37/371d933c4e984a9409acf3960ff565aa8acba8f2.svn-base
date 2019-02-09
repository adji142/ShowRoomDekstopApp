
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[SBARCODE]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.SBARCODE
GO

SELECT *
INTO ISADusRawDb.dbo.SBARCODE
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM SBARCODE   ')c
GO