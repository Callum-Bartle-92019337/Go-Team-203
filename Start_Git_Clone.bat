@echo off

setlocal
:PROMPT
SET /P AREYOUSURE=Are you sure you want to clone the repo (Y/[N])?
IF /I "%AREYOUSURE%" NEQ "Y" GOTO END

git clone https://github.com/Callum-Bartle-92019337/Go-Team-203-Mobile-App.git
pause

:END
endlocal