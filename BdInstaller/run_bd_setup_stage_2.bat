@echo off

echo  "7) Cargo el BACKUP..."
title "7) Cargo el BACKUP..."
cd c:\crypton-install-tmp\
sqlcmd -S localhost\CRYPTON_BD -U sa -P HJH35uQ2 -i c:\crypton-install-tmp\launcher.sql
echo "OK"
echo "-------------------------------"

echo  "8) Borrando directorio temporal..."
title "8) Borrando directorio temporal..."
rd /s c:\crypton-install-tmp /q
echo "OK"
echo "-------------------------------"