
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[NODOC]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.NODOC
GO

SELECT *
INTO ISADusRawDb.dbo.NODOC
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM NODOC   ')c
GO