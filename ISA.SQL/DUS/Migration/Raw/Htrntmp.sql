
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[Htrntmp]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.Htrntmp
GO

SELECT *
INTO ISADusRawDb.dbo.Htrntmp
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM Htrntmp   ')c
GO