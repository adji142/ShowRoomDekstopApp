
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HTRANSJ]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HTRANSJ
GO

SELECT *
INTO ISADusRawDb.dbo.HTRANSJ
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HTRANSJ   ')c
GO