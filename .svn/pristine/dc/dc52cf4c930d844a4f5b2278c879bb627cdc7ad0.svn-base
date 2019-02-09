USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[F_CUTOFF]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.F_CUTOFF
GO

SELECT *
INTO ISADusRawDb.dbo.F_CUTOFF
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM F_CUTOFF   ')c
GO