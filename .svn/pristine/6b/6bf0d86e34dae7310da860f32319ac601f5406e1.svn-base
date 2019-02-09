
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HTRANJcd]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HTRANJcd
GO

SELECT *
INTO ISADusRawDb.dbo.HTRANJcd
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HTRANJcd   ')c
GO