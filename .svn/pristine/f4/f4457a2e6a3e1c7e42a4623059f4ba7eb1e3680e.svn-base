USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DRETURB]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DRETURB
GO

SELECT *
INTO ISADusRawDb.dbo.DRETURB
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DRETURB   ')c
GO