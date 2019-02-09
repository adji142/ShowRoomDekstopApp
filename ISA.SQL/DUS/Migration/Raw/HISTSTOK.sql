
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HISTSTOK]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HISTSTOK
GO

SELECT *
INTO ISADusRawDb.dbo.HISTSTOK
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HISTSTOK   ')c
GO