dotnet restore
dotnet build src/dotnet-structuring/ -c release -o artifacts/wpf/
dotnet build src/dotnet-structuring.console/ -c release -o artifacts/console/
PAUSE