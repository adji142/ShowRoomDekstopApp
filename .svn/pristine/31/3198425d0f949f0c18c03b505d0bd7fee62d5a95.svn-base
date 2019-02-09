USE ISAPunyaJKT
GO

CREATE TABLE SalesmanRiwayat_Import
(
[RowID] [uniqueidentifier] NOT NULL,
	[SalesRowID] [uniqueidentifier] NOT NULL,
	[CabangID] [varchar](50) NOT NULL,
	[TglMasuk] [datetime] NULL,
	[TglKeluar] [datetime] NULL,
	[LastUpdatedBy] [varchar](30) NOT NULL,
	[LastUpdatedTime] [datetime] NOT NULL,
	[KodeSales] [varchar](11) NOT NULL
)

INSERT INTO dbo.SalesmanRiwayat_Import
(
RowID,
SalesRowID,
CabangID,
TglMasuk,
TglKeluar,
LastUpdatedBy,
LastUpdatedTime,
KodeSales
)

select
NEWID(),
NEWID(),
a.kd_toko,
CASE WHEN YEAR(a.tgl_masuk) < 1900 THEN NULL ELSE a.tgl_masuk END AS TglMasuk,
CASE WHEN YEAR(a.tgl_keluar) < 1900 THEN NULL ELSE a.tgl_keluar END AS TglKeluar,
'IMPORT',
GETDATE(),
a.kd_sales
from dbo.Sales a inner join dbo.Salesman_Import b on a.kd_sales = b.KodeSales
where a.idrec <> b.RecordID


INSERT INTO ISAPalurTradingDb02.dbo.Salesmanriwayat
SELECT * FROM dbo.SalesmanRiwayat_Import


UPDATE ISAPalurTradingDb02.dbo.Salesmanriwayat
SET SalesRowID = a.RowId
FROM ISAPalurTradingDb02.dbo.Salesman a INNER JOIN
ISAPalurTradingDb02.dbo.Salesmanriwayat b ON a.KodeSales = b.KodeSales 


DROP TABLE DBO.Salesman_Import
DROP TABLE dbo.SalesmanRiwayat_Import