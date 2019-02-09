 TRUNCATE TABLE DetailPerolehanBonus
INSERT  INTO dbo.DetailPerolehanBonus
        ( RowID ,
          KodeSales ,
          C1 ,
          Tanggal ,
          TanggalACC ,
          NoACC ,
          RpBonus ,
          RpACC ,
          RecordID ,
          SyncFlag ,
          CreatedBy ,
          CreatedON ,
          LastUpdatedBy ,
          LastUpdatedTime
        )
 
 
        SELECT  NEWID() ,RTRIM(kd_sales),RTRIM(C1) ,
             CASE WHEN YEAR(Tanggal) <=1900   THEN NULL
                     ELSE Tanggal
                END ,
                CASE WHEN YEAR(tgl_acc) <=1900   THEN NULL
                     ELSE tgl_acc
                END ,
                
                RTRIM(no_Acc) ,rp_bonus,rp_Acc,idrec,
               0,
                'IMPORT' ,
                GETDATE() ,
                'import' ,
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM DPBONUS.DBF') h
                           --OUTER APPLY (
                           --SELECT TOP 1 ROwID FROM dbo.HeaderAccBonus s
                           --WHERE s.RecordID = h.idtr
                           --)hd
 
							 