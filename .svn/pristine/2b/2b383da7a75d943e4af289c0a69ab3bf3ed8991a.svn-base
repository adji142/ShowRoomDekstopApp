USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[cDetail]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.cDetail
GO

SELECT *
INTO ISADusRawDb.dbo.cDetail
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM cDetail   ')c
GO