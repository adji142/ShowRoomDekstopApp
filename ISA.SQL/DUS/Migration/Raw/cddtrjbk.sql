USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[cddtrjbk]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.cddtrjbk
GO

SELECT *
INTO ISADusRawDb.dbo.cddtrjbk
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM cddtrjbk  WHERE LEN(idrec)>1')c
GO