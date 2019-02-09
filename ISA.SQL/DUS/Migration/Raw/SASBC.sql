
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[SASBC]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.SASBC
GO

SELECT *
INTO ISADusRawDb.dbo.SASBC
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM SASBC   ')c
GO