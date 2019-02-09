USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[EXPEDISI]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.EXPEDISI
GO

SELECT *
INTO ISADusRawDb.dbo.EXPEDISI
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM EXPEDISI   ')c
GO