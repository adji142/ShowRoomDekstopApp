
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HPO]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HPO
GO

SELECT *
INTO ISADusRawDb.dbo.HPO
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HPO   ')c
GO