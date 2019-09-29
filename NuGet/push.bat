@echo off
cd /d %~dp0
set PACKAGEVERSION=3.2.1-pre
dotnet build ..\Livet.Code.sln -c=Release
rem API Key は nuget.org から取得して nuget setApiKey xxxx でセットしてください
dotnet nuget push ..\LivetCask.Extensions\bin\Release\LivetExtensions.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.Core\bin\Release\LivetCask.Core.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.Messaging\bin\Release\LivetCask.Messaging.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.EventListeners\bin\Release\LivetCask.EventListeners.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.Converters\bin\Release\LivetCask.Converters.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.Behaviors\bin\Release\LivetCask.Behaviors.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.Mvvm\bin\Release\LivetCask.Mvvm.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask.StatefulModel\bin\Release\LivetCask.StatefulModel.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package
dotnet nuget push ..\LivetCask\bin\Release\LivetCask.%PACKAGEVERSION%.nupkg -s https://www.nuget.org/api/v2/package

mkdir dist
copy ..\LivetCask.Extensions\bin\Release\LivetExtensions.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.Core\bin\Release\LivetCask.Core.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.Messaging\bin\Release\LivetCask.Messaging.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.EventListeners\bin\Release\LivetCask.EventListeners.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.Converters\bin\Release\LivetCask.Converters.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.Behaviors\bin\Release\LivetCask.Behaviors.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.Mvvm\bin\Release\LivetCask.Mvvm.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask.StatefulModel\bin\Release\LivetCask.StatefulModel.%PACKAGEVERSION%.nupkg .\dist
copy ..\LivetCask\bin\Release\LivetCask.%PACKAGEVERSION%.nupkg .\dist
 