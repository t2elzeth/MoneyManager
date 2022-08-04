@echo off
chcp 1251 > nul
cls

SET database=money_manager
SET userName=money_manager
SET password=123
SET DOTNET_ENVIRONMENT=Development

cd migrations
powershell .\migrate.ps1 -ConnectionString localhost:5432/%database% -UserName %userName% -Password %password% -Contexts "dev"
cd ..