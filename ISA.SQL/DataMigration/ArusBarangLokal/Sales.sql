USE ISAPunyaJKT

GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ISAPunyaJKT].[dbo].[Sales]') AND type in (N'U'))
DROP TABLE ISAPunyaJKT.dbo.Sales
GO

SELECT  *
INTO ISAPunyaJKT.dbo.Sales			
FROM OPENROWSET('VFPOLEDB', 'C:\Persediaan\'; ' '; ' ', 'SELECT  * FROM Sales')c
GO



CREATE TABLE DBO.Salesman_Import
(
[RowId] [uniqueidentifier] NOT NULL,
[RecordID] varchar(50),
	[KodeSales] [varchar](11) NOT NULL,
	[NamaSales] [varchar](30) NOT NULL,
	[AlamatSales] [varchar](50) NOT NULL,
	[TglMasuk] [datetime] NULL,
	[TglKeluar] [datetime] NULL,
	[CabangId] [varchar](50) NOT NULL,
	[CabangTransaksi] [varchar](150) NOT NULL,
	[LastUpdatedBy] [varchar](30) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[Inisial] [char](3) NULL,
	[LastSyncDate] [datetime] NULL
)

INSERT INTO DBO.Salesman_Import
(
RowId, 
RecordID,
KodeSales, 
NamaSales, 
AlamatSales, 
TglMasuk, 
TglKeluar, 
CabangId, 
CabangTransaksi, 
LastUpdatedBy, 
LastUpdatedTime, 
Inisial, 
LastSyncDate
)
SELECT
NEWID(),
MAX(idrec) AS RecordID,
kd_sales,
nm_sales,
alamat,
CASE WHEN YEAR(tgl_masuk) < 1900 THEN NULL ELSE tgl_masuk END AS TglMasuk,
CASE WHEN YEAR(tgl_keluar) < 1900 THEN NULL ELSE tgl_keluar END AS TglKeluar,
kd_toko,
'',
'IMPORT',
GETDATE(),
'',
NULL
FROM ISAPunyaJKT.dbo.Sales
--where kd_toko <> '' or idrec <> '' and idrec <> 'SAS2008041014:58:15ANE '	
group by kd_sales,
nm_sales,
alamat,
(CASE WHEN YEAR(tgl_masuk) < 1900 THEN NULL ELSE tgl_masuk END) ,
(CASE WHEN YEAR(tgl_keluar) < 1900 THEN NULL ELSE tgl_keluar END) ,
kd_toko
 	

DELETE FROM  ISAPalurTradingDb02.dbo.Salesman
	

INSERT INTO ISAPalurTradingDb02.dbo.Salesman
SELECT  
RowId,
KodeSales, 
NamaSales, 
AlamatSales, 
TglMasuk, 
TglKeluar, 
CabangId, 
CabangTransaksi, 
LastUpdatedBy, 
LastUpdatedTime, 
Inisial, 
LastSyncDate
FROM ISAPunyaJKT.dbo.Salesman_Import
