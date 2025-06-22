:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
::Install XNB-UVExplorer Via MSBuild                             ::
::Gihub https://github.com/RussDev7/XNB-UVExplorer               ::
::Developed, Maintained, And Sponsored By Discord:dannyruss      ::
:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
@ECHO OFF

Rem | Set Params
Set "VersionPrefix=1.1.1.0"
Set "filename=XNBUVExplorer-%VersionPrefix%"

Rem | Put the expected location of vswhere into a variable.
set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"

Rem | Ask for the newest VS install that includes Microsoft.Component.MSBuild
Rem | and let vswhere do the glob‑expansion that finds MSBuild.exe.
for /f "usebackq tokens=*" %%I in (`
  "%VSWHERE%" -latest ^
              -products * ^
              -requires Microsoft.Component.MSBuild ^
              -find MSBuild\**\Bin\MSBuild.exe
`) do (
    set "MSBUILD=%%I"
)

Rem | Install SLN under x86 profile.
"%MSBUILD%" ".\src\XNBUVExplorer.sln" /p:Configuration=Release /p:Platform=x86"

Rem | Delete Paths & Create Paths
rmdir /s /q ".\release"
mkdir ".\release"

Rem | Copy Over Items
xcopy /E /Y ".\src\XNBUVExplorer\bin\x86\Release" ".\release\%filename%\"

Rem | Clean Up Files
del /f /q /s ".\release\*.pdb"
del /f /q /s ".\release\*.config"

Rem | Delete & Create ZIP Release
if exist ".\%filename%.zip" (del /f ".\%filename%.zip")
powershell.exe -nologo -noprofile -command "Compress-Archive -Path ".\release\*" -DestinationPath ".\%filename%.zip""

Rem | Operation Complete
echo(
pause
