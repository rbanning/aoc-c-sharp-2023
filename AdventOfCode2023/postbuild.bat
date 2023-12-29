echo off
set source=Adventures\Data\
set dest=%1
xcopy .\%source%* %dest%\%source% /i /Y
echo data files copied to %dest%