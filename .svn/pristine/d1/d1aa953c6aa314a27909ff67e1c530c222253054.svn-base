USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[dataopnm]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.dataopnm
GO

SELECT *
INTO ISADusRawDb.dbo.dataopnm
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM dataopnm   ')c
GO