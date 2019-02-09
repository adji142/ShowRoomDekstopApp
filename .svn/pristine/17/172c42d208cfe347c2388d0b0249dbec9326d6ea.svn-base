USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[DPO]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.DPO
GO

SELECT *
INTO ISADusRawDb.dbo.DPO
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM DPO  ')c
GO

SELECT * FROM dbo.DPO
 


 