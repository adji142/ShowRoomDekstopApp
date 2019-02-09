USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRTMP]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRTMP
GO

SELECT *
INTO ISADusRawDb.dbo.DTRTMP
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRTMP   ')c
GO