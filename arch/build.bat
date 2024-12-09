SonarScanner.MSBuild.exe begin /k:"Bank" /d:sonar.host.url=http://l:10000 
dotnet build --no-incremental
dotnet test --collect "Code Coverage"
SonarScanner.MSBuild.exe end