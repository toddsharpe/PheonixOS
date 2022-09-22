dotnet publish -r win-x64 -c debug --self-contained Kernel
dotnet publish -r win-x64 -c debug --self-contained Loader

@set VHD=%CD%\build\PhoenixOS.vhdx
@set VHD_SCRIPT=%CD%\build\diskpart.txt
@set BUILD_OUT=%CD%\build
@del %VHD% >nul 2>&1
@del %VHD_SCRIPT% >nul 2>&1

@rem Build a VHD if requested

@(
echo create vdisk file=%VHD% maximum=500
echo select vdisk file=%VHD%
echo attach vdisk
echo convert gpt
echo create partition efi size=100
echo format quick fs=fat32 label="System"
echo assign letter="X"
echo exit
)>%VHD_SCRIPT%

diskpart /s %VHD_SCRIPT%

@rem Copy bootloader to VHD
xcopy %BUILD_OUT%\EFI\BOOT\BOOTX64.EFI X:\EFI\BOOT\

@rem Copy kernel and kernel libraries
xcopy %BUILD_OUT%\kernel.exe X:\

@(
echo select vdisk file=%VHD%
echo select partition 2
echo remove letter=X
echo detach vdisk
echo exit
)>%VHD_SCRIPT%

diskpart /s %VHD_SCRIPT%
@del %VHD_SCRIPT% >nul 2>&1

@rem Fix Perms
@rem Get-VM 'PhoenixOS' | Select-Object VMID
icacls %VHD% /grant 08eb2aeb-2033-4950-bcfa-b4a008cfb52c:F
