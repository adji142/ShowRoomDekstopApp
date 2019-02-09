USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DMUTSTOK]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DMUTSTOK
GO

SELECT *
INTO ISADusRawDb.dbo.DMUTSTOK
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DMUTSTOK   ')c
GO