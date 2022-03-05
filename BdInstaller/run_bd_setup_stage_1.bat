@echo off

echo  "1) Creo directorio temporal..."
title "1) Creo directorio temporal..."
(if not exist "c:\\crypton-install-tmp\" mkdir c:\crypton-install-tmp)
echo "OK"
echo "-------------------------------"

echo  "2) Extraigo instalador .exe..."
title "2) Extraigo instalador .exe..."
start /wait sql_server_setup /ACTION=Download /MEDIAPATH=c:\crypton-install-tmp /MEDIATYPE=Core /QUIET
echo "OK"
echo "-------------------------------"

echo  "3) Copio configuracion..."
title "3) Copio configuracion..."
copy config_bd_file.ini c:\crypton-install-tmp
echo "OK"
echo "-------------------------------"

echo  "4) Copio backup..."
title "4) Copio backup..."
copy launcher.sql c:\crypton-install-tmp
copy bd_backup.sql c:\crypton-install-tmp
copy crypton_backup_12.14.2021.01.40.54.bak c:\crypton-install-tmp
echo "OK"
echo "-------------------------------"

echo  "5) Extraigo archivos del instalador..."
title "5) Extraigo archivos del instalador..."
start /wait c:\crypton-install-tmp\SQLEXPR_x64_ENU.exe /q /x:c:\crypton-install-tmp\SQLEXPR_2019
echo "OK"
echo "-------------------------------"

echo  "6) Instalo usando la configuracion"
title "6) Instalo usando la configuracion"
start /wait c:\crypton-install-tmp\SQLEXPR_2019\setup.exe /SECURITYMODE=SQL /SAPWD="HJH35uQ2" /SQLSVCPASSWORD="HJH35uQ2" /AGTSVCPASSWORD="HJH35uQ2" /ASSVCPASSWORD="HJH35uQ2" /ISSVCPASSWORD="HJH35uQ2" /RSSVCPASSWORD="HJH35uQ2" /ConfigurationFile=c:\crypton-install-tmp\config_bd_file.ini
echo "OK"
echo "-------------------------------"