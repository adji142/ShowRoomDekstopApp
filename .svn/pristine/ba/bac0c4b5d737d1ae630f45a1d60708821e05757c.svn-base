USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[Dtrntmp]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.Dtrntmp
GO

SELECT *
INTO ISADusRawDb.dbo.Dtrntmp
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM Dtrntmp   ')c
GO