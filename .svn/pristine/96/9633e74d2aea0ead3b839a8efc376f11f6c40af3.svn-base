TRUNCATE TABLE HeaderAccBonus
INSERT  INTO dbo.HeaderAccBonus
        ( RowID ,
          RecordID ,
          C1 ,
          NoSj ,
          NoRq ,
          TglSJ ,
          WilID ,
          KodeSales ,
          KodeToko ,
          NamaToko ,
          TglTerima ,
          TglJthTempo ,
          HariSales ,
          RpSuratJalan ,
          RpSisa ,
          RpGiro ,
          RpPotongan ,
          RpLain ,RpRetur,
          NoACC ,
          TglACC ,
          LCek ,
          KetNota ,
          CreatedBy ,
          CreatedON ,
          LastUpdatedBy ,
          LastUpdatedTime
          
        )
        SELECT  NEWID() ,
                RTRIM(idtr) ,
                RTRIM(C1) ,
                RTRIM(No_Sj) ,
                RTRIM(No_rq) ,
                CASE WHEN YEAR(Tgl_SJ) <=1900   THEN NULL
                     ELSE Tgl_SJ
                END ,RTRIM(idwil),RTRIM(kd_Sales),RTRIM(kd_toko),RTRIM(nm_toko),
                CASE WHEN YEAR(tgl_trm) <=1900 THEN null
                     ELSE tgl_trm
                END  ,CASE WHEN YEAR(tgl_jt) <=1900   THEN NULL
                     ELSE tgl_jt
                END  ,
                hr_sls ,
                rp_SJ , rp_sisa ,rp_giro,rp_potong,lain_lain,rp_retur,no_acc, CASE  WHEN YEAR(Tgl_acc) <=1900   THEN NULL
                     ELSE Tgl_acc
                END ,
                0 ,RTRIM(ket_nota),
                'IMPORT' ,
                GETDATE() ,
                'import' ,
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM HACCBNS.DBF') h
                           --OUTER APPLY (
                           --SELECT TOP 1 ROwID FROM dbo.GroupStok s
                           --WHERE s.RecordID = h.id_grstok
                           --)hd
 
							  