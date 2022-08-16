::
:: "Manual" build script that bypasses MSBuild and directly invokes the necessary tools.
:: Good to show how things get hooked up together, but redundant with the project file.
::
:: The tools are:
::
:: * CSC, the C# compiler
::   Opening a "x64 Native Tools Command Prompt for VS 2019" will place csc.exe on your PATH.
:: * ILC, the Native AOT compiler
::   If you use the project file to build this sample at least once, you can find ILC
::   in your NuGet cache. It will be somewhere like
::   C:\Users\username\.nuget\packages\runtime.win-x64.microsoft.dotnet.ilcompiler\7.0.0-alpha.1.21430.2
:: * Linker
::   This is the platform linker. "x64 Native Tools Command Prompt for VS 2019" will place
::   the linker on your PATH.
::
@set DROPPATH="C:\Users\todds\.nuget\packages\runtime.win-x64.microsoft.dotnet.ilcompiler\7.0.0-preview.2.22152.2"
@set ILCPATH=%DROPPATH%\tools
@if not exist %ILCPATH%\ilc.exe (
  echo The DROPPATH environment variable not set.
  exit /B
)
@where csc >nul 2>&1
@if ERRORLEVEL 1 (
  echo CSC not on the PATH.
  exit /B
)

@del Loader.ilexe >nul 2>&1
@del Loader.obj >nul 2>&1
@del Loader.exe >nul 2>&1
@del Loader.map >nul 2>&1
@del Loader.pdb >nul 2>&1

@if "%1" == "clean" exit /B

csc /define:WINDOWS /debug:embedded /noconfig /nostdlib /runtimemetadataversion:v4.0.30319 Console.cs Native.cs Efi.cs Platform.cs Program.cs /out:Loader.ilexe /langversion:latest /unsafe -reference:"C:\Users\todds\GitHub\toddsharpe\PhoenixOS\CoreLib\bin\Debug\net6.0\CoreLib.dll" || goto Error
%ILCPATH%\ilc Loader.ilexe -g -o Loader.obj --systemmodule CoreLib --map Loader.map -O || goto Error
link /debug /subsystem:EFI_APPLICATION Loader.obj /entry:__managed__Main /incremental:no || goto Error

@goto :EOF

:Error
@echo Tool failed.
exit /B 1
