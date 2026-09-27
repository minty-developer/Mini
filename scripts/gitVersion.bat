@echo off

set /p Version=Release Version: 

git tag -a %Version% -m "Release %Version%"

if errorlevel 1 (
    echo.
    echo Tag creation failed.
    pause
    exit /b 1
)

git push origin %Version%

if errorlevel 1 (
    echo.
    echo Tag push failed.
    pause
    exit /b 1
)

echo.
echo Release %Version% pushed successfully.
pause