@echo Off

rem %WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild 
"c:\program files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\msbuild.exe" Icelandic.PublicHolidays.sln /p:Configuration="Release" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

md packages-local
md packages-local\release
.nuget\nuget pack Icelandic.PublicHolidays\Icelandic.PublicHolidays.csproj -Prop "Configuration=Release" -IncludeReferencedProjects -OutputDirectory packages-local\release -Symbols

.nuget\nuget.exe push packages-local\Release\Icelandic.PublicHolidays.0.9.2.nupkg oy2bwctxuynoexpjy3eqkbay7w4trftenlhd4sft6hyzm4 -Source https://nuget.org
