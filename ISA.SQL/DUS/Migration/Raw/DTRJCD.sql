USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRJCD]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRJCD
GO

SELECT *
INTO ISADusRawDb.dbo.DTRJCD
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRJCD   ')c
GO