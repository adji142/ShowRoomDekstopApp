USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DTRANJcd]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DTRANJcd
GO

SELECT *
INTO ISADusRawDb.dbo.DTRANJcd
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DTRANJcd   ')c
GO