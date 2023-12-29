echo off
set source=Adventures\Data\
set dest=%1
xcopy .\%source%* %dest%\%source% /i /Y /d /s
echo data files copied to %dest%