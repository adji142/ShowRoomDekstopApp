
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[retail_ref]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.retail_ref
GO

SELECT *
INTO ISADusRawDb.dbo.retail_ref
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM retail_ref   ')c
GO