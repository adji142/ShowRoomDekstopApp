USE ISAPunyaJKT
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[SASSTOK]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.SASSTOK
GO
SELECT * INTO ISAPunyaJKT.dbo.SASSTOK
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM SASSTOK')c


USE ISAPalurTradingDb02
GO
DELETE FROM ISAPalurTradingDb02.dbo.Stock
GO

INSERT INTO ISAPalurTradingDb02.dbo.Stock (
			RowId, KodeBarang, IDRecLama, NamaBarang, 
			KelompokBrgRowId, Satuan, Kendaraan, Merek, 
			PartNo, CabangPengguna, Catatan, Area1, Area2, Area3, 
			[Status], IsiKoli, stockMax, stockMin, CreatedBy, CreatedOn, LastUpdateBy, LastUpdateTime
			)
SELECT		NEWID(), RTRIM(idMain),RTRIM(idrec), RTRIM(nm_plist),
			NEWID(), RTRIM(sat_jual), RTRIM(Kendaraan), RTRIM(merek),
			RTRIM(PartNo), '', '' , kd_rak,kd_rak1,kd_rak2,
			lpasif, isi_koli, stokMin, stokMax , 'IMPORT', GETDATE(), 'IMPORT', GETDATE()
			
FROM ISAPunyaJKT.dbo.SASSTOK c

GO
UPDATE ISAPalurTradingDb02.dbo.Stock 
	SET KelompokBrgRowId = k.RowId
FROM ISAPalurTradingDb02.dbo.Stock s
INNER JOIN ISAPalurTradingDb02.dbo.KelompokBarang k ON k.KodeKelompokBarang = LEFT(s.KodeBarang,3)
GO



--UPDATE ISAPalurTradingDb02.dbo.Stock
--SET Area1 = ss.kd_rak,
--Area2 = ss.kd_rak1,
--Area3 = ss.kd_rak2,
--FROM ISAPalurTradingDb02.dbo.Stock s INNER JOIN ISAPunyaJKT.dbo.SASSTOK ss
--ON s.IDRecLama = ss.idrec
	
