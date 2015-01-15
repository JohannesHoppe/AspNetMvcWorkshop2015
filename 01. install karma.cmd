@ECHO OFF

%~d0
CD "%~dp0"

SET PATH=%PATH%;%programfiles%\nodejs
SET PATH=%PATH%;%programfiles(x86)%\nodejs

rem Avoiding NodeJS for Windows installer bug
mkdir %AppData%\npm

CALL npm install --save-dev

pause