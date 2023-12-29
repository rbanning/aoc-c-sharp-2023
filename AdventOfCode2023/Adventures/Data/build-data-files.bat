echo off

if "%~1"=="" goto ERROR

set day=%1
set folder=%1
if not exist %folder% mkdir %folder%
cd %folder%

set file="data-%folder%-a.txt"
if not exist %file% copy /y NUL %file%

set file="data-%folder%-a-sample.txt"
if not exist %file% copy /y NUL %file%

set file="data-%folder%-b.txt"
if not exist %file% copy /y NUL %file%

set file="data-%folder%-b-sample.txt"
if not exist %file% copy /y NUL %file%

cd ..
dir %folder%

goto DONE

:ERROR
echo ERROR - please include folder (day) name... e.g. O1 or 10
goto DONE

:DONE
echo .
