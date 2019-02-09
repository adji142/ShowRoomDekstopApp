USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRJ811]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRJ811
GO

SELECT *
INTO ISADusRawDb.dbo.DTRJ811
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRJ811   ')c
GO