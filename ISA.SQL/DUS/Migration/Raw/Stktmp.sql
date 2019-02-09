
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[Stktmp]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.Stktmp
GO

SELECT *
INTO ISADusRawDb.dbo.Stktmp
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM Stktmp   ')c
GO