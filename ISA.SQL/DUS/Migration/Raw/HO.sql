
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HO]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HO
GO

SELECT *
INTO ISADusRawDb.dbo.HO
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HO   ')c
GO