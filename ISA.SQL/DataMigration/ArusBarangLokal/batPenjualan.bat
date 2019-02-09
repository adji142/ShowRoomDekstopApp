sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i AccHargaHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i AccHargaDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PenjualanHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PenjualanRequestCabang.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PenjualanDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i CheckerMapping.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i SJHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i SJDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i SJTitipan.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiPenjualan.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i RJHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i RJDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiRJ.sql
pause