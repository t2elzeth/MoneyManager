@echo off

SET database=money_manager
SET userName=money_manager
SET password=123

cd migrations
powershell .\rollback.ps1 -MigrationsPath %migrationsPath% -ConnectionString localhost:5432/%database% -UserName %userName% -Password %password% -Contexts "dev" -RollbackCount %1
cd ..