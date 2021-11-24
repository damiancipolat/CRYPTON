echo "Descargando imagen de SQL SERVER 2019"
docker pull mcr.microsoft.com/mssql/server:2019-latest
echo ""

echo "Limpio contenedor"
docker stop crypton
docker rm crypton
echo ""

echo "Creando contenedor"
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=7sNE22d7" -p 1433:1433 --name crypton -h crypton -d -v cryptondata:/var/opt/mssql mcr.microsoft.com/mssql/server:2019-latest
echo ""

echo "Creando directorio de backup"
docker exec -it crypton mkdir /var/opt/mssql/backup
echo ""

echo "Copiando backup a volumen"
docker cp backup.bak crypton:/var/opt/mssql/backup
echo ""

echo "Inicio backup 1/2"
docker exec -it crypton /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "7sNE22d7" -Q "RESTORE FILELISTONLY FROM DISK = '/var/opt/mssql/backup/backup.bak'"
echo ""

echo "Inicio backup 2/2"
docker exec -it crypton /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "7sNE22d7" -Q "RESTORE DATABASE Crypton FROM DISK = '/var/opt/mssql/backup/backup.bak' WITH MOVE 'Crypton' TO '/var/opt/mssql/data/Crypton_log.mdf', MOVE 'Crypton_log' TO '/var/opt/mssql/data/Crypton_log.ldf';"
echo ""

echo "Fin!"