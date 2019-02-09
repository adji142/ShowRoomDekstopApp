TRUNCATE TABLE DetailAccBonus
INSERT  INTO dbo.DetailAccBonus
        ( RowID ,
          HeaderID ,
          RecordID ,
          HRecordID ,
          C1 ,
          KodeBarang ,
          NamaStok ,
          QtySJ ,
          HargaNetto ,
          NoACC ,
          TglACC ,
          CreatedBy ,
          CreatedON ,
          LastUpdatedBy ,
          LastUpdatedTime
        )
 
        SELECT  NEWID() ,hd.ROwID,
                rtrim(idrec),RTRIM(idtr) ,
                RTRIM(C1) ,
                RTRIM(id_brg) ,
                RTRIM(nama_Stok) ,j_sj,h_netto,no_acc,
                CASE WHEN YEAR(tgl_acc) <=1900   THEN NULL
                     ELSE tgl_acc
                END , 
                'IMPORT' ,
                GETDATE() ,
                'import' ,
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM DACCBNS.DBF') h
                           OUTER APPLY (
                           SELECT TOP 1 ROwID FROM dbo.HeaderAccBonus s
                           WHERE s.RecordID = h.idtr
                           )hd
 
							  