
echo on

c:

taskkill /IM iisexpress.exe /F

set ProgramFilePath=C:\Program Files (x86)
if not exist "%ProgramFilePath%" (
	set ProgramFilePath="C:\Program Files"
)


if not exist "%USERPROFILE%\Documents\IISExpress\config\applicationhost.config" (
copy "%ProgramFilePath%\IIS Express\config\templates\PersonalWebServer\applicationhost.config" "%USERPROFILE%\Documents\IISExpress\config"
copy "%ProgramFilePath%\IIS Express\config\templates\PersonalWebServer\aspnet.config" "%USERPROFILE%\Documents\IISExpress\config"
copy "%ProgramFilePath%\IIS Express\config\templates\PersonalWebServer\redirection.config" "%USERPROFILE%\Documents\IISExpress\config"
) 

cd "%ProgramFilePath%\IIS Express"

appcmd delete site "WebSite1"
appcmd delete site "ATMTECH"

appcmd add site /name:"ATMTECH" /bindings:http/*:52990:localhost

appcmd add app /site.name:"ATMTECH" /path:/ /applicationPool:Clr4IntegratedAppPool

appcmd add vdir /app.name:"ATMTECH/" /path:/ /physicalPath:c:\dev\AtmtechRun

appcmd set config "ATMTECH/" -section:system.webServer/security/authentication/windowsAuthentication /enabled:"True" /commit:apphost
appcmd set config "ATMTECH/" -section:system.webServer/security/authentication/anonymousAuthentication /enabled:"false" /commit:apphost

start /B IISExpress /site:ATMTECH



