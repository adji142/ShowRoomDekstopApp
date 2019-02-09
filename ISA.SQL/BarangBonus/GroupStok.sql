  TRUNCATE TABLE GroupStok
INSERT  INTO dbo.GroupStok
        ( RowId ,
          RecordID ,
          NamaGroup ,
          SyncFlag ,
          CreatedBy ,
          CreatedON ,
          LastUpdatedBy ,
          LastUpdatedTime
        )
        SELECT  NEWID() ,
                RTRIM(id_grstok) ,
                RTRIM(nama_group) ,
                0 ,
                'IMPORT' ,
                GETDATE() ,
                'IMPORT' ,
                GETDATE()
        FROM    OPENROWSET('VFPOLEDB', 'D:\Share\ali\Bonus\'; ' '; ' ',
                           'SELECT 	 * FROM GR_STOK.dbf')