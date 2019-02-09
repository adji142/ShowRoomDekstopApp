
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[Perusahaan]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.Perusahaan
GO

SELECT *
INTO ISADusRawDb.dbo.Perusahaan
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM Perusahaan   ')c
GO