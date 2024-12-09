dotnet tool uninstall --global dotnet-sonarscanner 
dotnet tool install --global dotnet-sonarscanner --version 9.0.2
dotnet sonarscanner begin /k:"Bank" /d:sonar.host.url=http://l:10000 /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect "dotnet test" -f xml -o "coverage.xml"
dotnet sonarscanner end
rm -rf .sonarqube