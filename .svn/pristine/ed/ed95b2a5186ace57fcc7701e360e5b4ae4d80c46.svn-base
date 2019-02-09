
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HTRANSB]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HTRANSB
GO

SELECT *
INTO ISADusRawDb.dbo.HTRANSB
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HTRANSB   ')c
GO