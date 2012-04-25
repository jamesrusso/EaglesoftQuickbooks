!include "MUI.nsh"
!define DebugOrRelease "Release"
!define ProductName "Eaglesoft Deposit"
!define ProductDescription "Eaglesoft Deposit"

Name "${ProductName}"
OutFile "${ProductName}Installer.exe"
InstallDir "$PROGRAMFILES\Halo3 Consulting\${ProductName}"
ShowInstDetails show
ShowUnInstDetails show

!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_UNPAGE_CONFIRM
!define MUI_ABORTWARNING
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_LANGUAGE "English"

!define Version "1.0.0.0.0"

VIProductVersion "${Version}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "${ProductName}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyName" "Halo3 Consulting, LLC"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductVersion" "${Version}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "${Version}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "${ProductDescription}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "(c) 2009 Halo3 Consulting, LLC"
VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyWebsite" "http://www.halo3.net"

InstallDirRegKey HKLM "Software\Halo3 Consulting\${ProductName}" "InstallPath"

Section "Programs"
  SetOutPath "$INSTDIR"
  SetShellVarContext all
  File "${ProductDescription}\bin\${DebugOrRelease}\${ProductName}.exe"
  File "${ProductDescription}\bin\${DebugOrRelease}\${ProductName}.exe.config"
  File "..\QuickbooksLibraryInstaller\${DebugOrRelease}\Halo3 Consulting QBSDK Library Installer.msi"
  
  DetailPrint '... installing third party QB library.'
  ExecWait 'msiexec /i "Halo3 Consulting QBSDK Library Installer.msi" /qn'

  WriteUninstaller $INSTDIR\uninstall.exe
  CreateDirectory "$SMPROGRAMS\${ProductName}"
  CreateShortCut "$SMPROGRAMS\${ProductName}\${ProductName}.lnk" "$INSTDIR\${ProductName}.exe"
  CreateShortCut "$SMPROGRAMS\${ProductName}\Uninstall.lnk" "$INSTDIR\Uninstall.exe"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProductName}" \
                 "DisplayName" "${ProductName}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProductName}" \
                 "UninstallString" "$INSTDIR\uninstall.exe"
  WriteRegStr HKLM "Software\Halo3 Consulting\${ProductName}" "InstallPath" $INSTDIR
SectionEnd 

Section "uninstall"
  SetShellVarContext all
  Delete "$INSTDIR\uninstall.exe" 
  Delete "$SMPROGRAMS\${ProductName}\${ProductName}.lnk"
  Delete "$SMPROGRAMS\${ProductName}\uninstall.lnk"
  Rmdir "$SMPROGRAMS\${ProductName}"

  Delete /REBOOTOK "$INSTDIR\Halo3 Consulting QBSDK Library Installer.msi"
  Delete /REBOOTOK "$INSTDIR\${ProductName}.exe"
  Delete /REBOOTOK "$INSTDIR\${ProductName}.exe.config"
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${ProductName}"
SectionEnd

