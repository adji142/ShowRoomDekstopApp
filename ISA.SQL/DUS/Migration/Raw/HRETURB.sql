
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HRETURB]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HRETURB
GO

SELECT *
INTO ISADusRawDb.dbo.HRETURB
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HRETURB   ')c
GO