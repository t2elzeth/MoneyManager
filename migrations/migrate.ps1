param (
  [string]$ConnectionString,
  [string]$UserName,
  [string]$Password,
  [string]$Contexts
)

$command = 'liquibase.bat'

& $command `
  --driver org.postgresql.Driver `
  --changeLogFile db.changelog.xml `
  --url `"jdbc:postgresql://$ConnectionString`" `
  --username $UserName `
  --password $Password `
  --contexts $Contexts `
  migrate "2>&1"
