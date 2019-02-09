
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[SASOPNM]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.SASOPNM
GO

SELECT *
INTO ISADusRawDb.dbo.SASOPNM
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM SASOPNM   ')c
GO