sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i POHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PODetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PLHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PLHeaderLokal.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PLDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i PLDetailLokal.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i BLHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiPB.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiPBL.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i RBHeader.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i RBDetail.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i RBDetailLokal.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiRB.sql
sqlcmd -S SRV11 -U sa -P dotnet -t 0 -i KoreksiRBLokal.sql
pause