   INSERT INTO dbo.GroupStokDetail
          ( RowID ,
            HeaderID ,
            RecordID ,
            HRecordID ,
            TglAktif ,
            TglPasif ,
            KodeBarang ,
            Tempo ,
            SyncFlag ,
            CreatedBy ,
            CreatedON ,
            LastUpdatedBy ,
            LastUpdatedTime
          )
 
        SELECT  NEWID() ,hd.RowID,
                RTRIM(idrec) ,
                RTRIM(id_grstok) ,
                Tgl_aktif ,
                Tgl_pasif ,
                idmain ,
                 tempo ,
                 0,
                 'IMPORT',GETDATE(),'import',
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM DT_STOK.dbf') h
                           OUTER APPLY (
                           SELECT TOP 1 ROwID FROM dbo.GroupStok s
                           WHERE s.RecordID = h.id_grstok
                           )hd
                           
                           UPDATE dbo.GroupStokDetail
							SET TglAktif = CASE WHEN YEAR(TglAktif)<=1900 THEN NULL ELSE TglAktif END,
							TglPasif = CASE WHEN YEAR(TglAktif)<=1900 THEN NULL ELSE TglPasif END ;
							
							WITH Cumi AS (
							SELECT d.ROwID,g.KodeBarang KodeBarangBaru
							FROM dbo.GroupStokDetail d
							OUTER APPLY (
							SELECT TOP 1 KodeBarang 
							FROM dbo.Stock s WHERE s.IDRecLama = d.RecordID
							)g
							WHERE D.KodeBarang=''
							) 
							 
							 
							 UPDATE dbo.GroupStokDetail
								SET KodeBarang = KodeBarangBaru
							FROM dbo.GroupStokDetail d
							INNER JOIN Cumi c ON d.RowID = c.RowID