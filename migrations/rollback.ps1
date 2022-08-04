param (
  [string]$ConnectionString,
  [string]$UserName,
  [string]$Password,
  [string]$Contexts,
  [string]$RollbackCount
)

$command = 'liquibase.bat'

& $command `
  --driver org.postgresql.Driver `
  --changeLogFile db.changelog.xml `
  --url `"jdbc:postgresql://$ConnectionString`" `
  --username $UserName `
  --password $Password `
  --contexts $Contexts `
  rollbackCount $RollbackCount `
  "2>&1"
