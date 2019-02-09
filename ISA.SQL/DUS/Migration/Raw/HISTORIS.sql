
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HISTORIS]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HISTORIS
GO

SELECT *
INTO ISADusRawDb.dbo.HISTORIS
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HISTORIS   ')c
GO