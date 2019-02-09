
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[SASSTOK]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.SASSTOK
GO

SELECT *
INTO ISADusRawDb.dbo.SASSTOK
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM SASSTOK   ')c
GO