
USE ISADusRawDb
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISADusRawDb].[dbo].[HIST_HPP]') AND type in (N'U'))
DROP TABLE ISADusRawDb.dbo.HIST_HPP
GO

SELECT *
INTO ISADusRawDb.dbo.HIST_HPP
FROM OPENROWSET('VFPOLEDB', 'D:\Share\ali\GudangDos\'; ' '; ' ', 'SELECT   * FROM HIST_HPP   ')c
GO