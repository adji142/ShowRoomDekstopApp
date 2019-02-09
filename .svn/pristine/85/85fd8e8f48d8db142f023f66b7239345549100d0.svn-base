
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[NOBAR]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.NOBAR
GO

SELECT *
INTO ISADusRawDb.dbo.NOBAR
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM NOBAR   ')c
GO