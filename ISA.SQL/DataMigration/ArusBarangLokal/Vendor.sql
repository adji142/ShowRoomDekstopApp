  USE ISAPalurTradingDb02
GO
TRUNCATE TABLE dbo.Vendor
GO
/*Lebar VendorID di ubah menjadi 10*/
GO
INSERT INTO dbo.Vendor (
			RowID, IdRecLama, VendorID, NamaVendor, 
			TipeVendor, Alamat, Negara, NoTelp, 
			ContactPerson, IsAktif, LastUpdatedBy
			)
SELECT		NEWID(), RTRIM(id_vendor),RTRIM(kd_vendor), RTRIM(nm_vendor),
			0, RTRIM(al_vendor1), RTRIM(Negara), RTRIM(no_telp),
			RTRIM(no_email), id_match, 'IMPORT' 
		
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM VEndors')c

GO
UPDATE dbo.Vendor
	SET TipeVendor = 1
WHERE CHARINDEX('Indonesia',Negara)>0
OR CHARINDEX('Indonesia',Alamat)>0
OR CHARINDEX('Jakarta',Alamat)>0