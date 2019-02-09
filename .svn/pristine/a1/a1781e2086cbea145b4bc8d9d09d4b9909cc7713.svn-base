TRUNCATE TABLE GroupStokSubDetail
  INSERT INTO dbo.GroupStokSubDetail
          ( RowID ,
            HeaderID ,
            RecordID ,
            HRecordID ,
            Tmt1 ,
            Tmt2 ,
            Qty ,
            Persen ,
            Tempo ,
            SyncFlag ,
            CreatedBy ,
            CreatedON ,
            LastUpdatedBy ,
            LastUpdatedTime
          )
 
 
        SELECT  NEWID() ,hd.RowID,
                '' ,
                RTRIM(id_grstok) ,
                CASE WHEN tmt1='0200-09-01' THEN '2000-09-01' ELSE Tmt1 END ,
                tmt2 ,
                qty,
                prosen ,
                 tempo ,
                 0,
                 'IMPORT',GETDATE(),'import',
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM GR_PRIOD.dbf') h
                           OUTER APPLY (
                           SELECT TOP 1 ROwID FROM dbo.GroupStok s
                           WHERE s.RecordID = h.id_grstok
                           )hd
                           
                           UPDATE dbo.GroupStokSubDetail
							SET Tmt1 = CASE WHEN YEAR(Tmt1)<=1900 THEN NULL ELSE Tmt1 END,
							Tmt2 = CASE WHEN YEAR(Tmt2)<=1900 THEN NULL ELSE Tmt2 END ;
							
							 