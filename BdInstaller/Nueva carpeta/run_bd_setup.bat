@echo off 
set arg=%1

if "%arg%"=="1" (
	echo "1) Creo directorio temporal..."
	(if not exist "c:\\crypton-install-tmp\" mkdir c:\\crypton-install-tmp)
)

if "%arg%"=="2" (
	echo "2) Extraigo instalador .exe..."
	sql_server_setup /ACTION=Download /MEDIAPATH=c:\crypton-install-tmp /MEDIATYPE=Core /QUIET
)

if "%arg%"=="3" (
	echo "3) Copio configuracion..."
	copy config_bd_file.ini c:\crypton-install-tmp
)

if "%arg%"=="4" (
	echo "4) Copio backup..."
	copy bd_backup.sql c:\crypton-install-tmp
)

if "%arg%"=="5" (
	echo "5) Extraigo archivos del instalador..."	
	c:\crypton-install-tmp\SQLEXPR_x64_ENU.exe /q /x:c:\crypton-install-tmp\SQLEXPR_2019
)

if "%arg%"=="6" (
	echo "6) Instalo usando la configuracion"
	c:\crypton-install-tmp\SQLEXPR_2019\setup.exe /SECURITYMODE=SQL /SAPWD="HJH35uQ2" /SQLSVCPASSWORD="HJH35uQ2" /AGTSVCPASSWORD="HJH35uQ2" /ASSVCPASSWORD="HJH35uQ2" /ISSVCPASSWORD="HJH35uQ2" /RSSVCPASSWORD="HJH35uQ2" /ConfigurationFile=c:\crypton-install-tmp\config_bd_file.ini
)

if "%arg%"=="7" (
	echo "7) Cargo el BACKUP..."
	rem sqlcmd -S localhost\CRYPTON_BD -U sa -P HJH35uQ2 -i c:\crypton-install-tmp\bd_backup.sql
)