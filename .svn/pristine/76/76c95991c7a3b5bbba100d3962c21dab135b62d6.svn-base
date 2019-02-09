
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[numerator]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.numerator
GO

SELECT *
INTO ISADusRawDb.dbo.numerator
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM numerator   ')c
GO