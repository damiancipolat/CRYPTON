echo "1) Creo directorio temporal..."
mkdir c:\crypton-install-tmp
echo "Ok"

echo "2) Extraigo instalador .exe..."
sql_server_setup /ACTION=Download /MEDIAPATH=c:\crypton-install-tmp /MEDIATYPE=Core /QUIET
echo "Ok"

echo "3) Copio configuracion..."
copy config_bd_file.ini c:\crypton-install-tmp\SQLEXPR_2019
echo "Ok"

echo "4) Copio backup..."
copy bd_backup.sql c:\crypton-install-tmp
echo "Ok"

echo "5) Extraigo archivos del instalador..."
cd c:\crypton-install-tmp
SQLEXPR_x64_ENU.exe /q /x:c:\crypton-install-tmp\SQLEXPR_2019
echo "Ok"

echo "6) Instalo usando la configuracion"
cd c:\crypton-install-tmp\SQLEXPR_2019
setup.exe /SECURITYMODE=SQL /SAPWD="HJH35uQ2" /SQLSVCPASSWORD="HJH35uQ2" /AGTSVCPASSWORD="HJH35uQ2" /ASSVCPASSWORD="HJH35uQ2" /ISSVCPASSWORD="HJH35uQ2" /RSSVCPASSWORD="HJH35uQ2" /ConfigurationFile=config_bd_file.ini

echo "8) Cargo el BACKUP..."
sqlcmd -S localhost\CRYPTON_BD -U sa -P HJH35uQ2 -i c:\crypton-install-tmp\bd_backup.sql@echo off

echo "1) Creo directorio temporal..."
mkdir c:\crypton-install-tmp
echo "Ok"

echo "2) Extraigo instalador .exe..."
sql_server_setup /ACTION=Download /MEDIAPATH=c:\crypton-install-tmp /MEDIATYPE=Core /QUIET
echo "Ok"

echo "3) Copio configuracion..."
copy config_bd_file.ini c:\crypton-install-tmp\SQLEXPR_2019
echo "Ok"

echo "4) Copio backup..."
copy bd_backup.sql c:\crypton-install-tmp
echo "Ok"

echo "5) Extraigo archivos del instalador..."
cd c:\crypton-install-tmp
SQLEXPR_x64_ENU.exe /q /x:c:\crypton-install-tmp\SQLEXPR_2019
echo "Ok"

echo "6) Instalo usando la configuracion"
cd c:\crypton-install-tmp\SQLEXPR_2019
setup.exe /SECURITYMODE=SQL /SAPWD="HJH35uQ2" /SQLSVCPASSWORD="HJH35uQ2" /AGTSVCPASSWORD="HJH35uQ2" /ASSVCPASSWORD="HJH35uQ2" /ISSVCPASSWORD="HJH35uQ2" /RSSVCPASSWORD="HJH35uQ2" /ConfigurationFile=config_bd_file.ini

echo "8) Cargo el BACKUP..."
sqlcmd -S localhost\CRYPTON_BD -U sa -P HJH35uQ2 -i c:\crypton-install-tmp\bd_backup.sql