@echo off
setlocal

echo exe��dll���}�[�W���܂��B
echo.

rem ILMerge.exe�ւ̃p�X
set ILMERGE_PATH=ILMerge\ILMerge.exe
rem Merge�Ώۂ̃f�B���N�g���ƃt�@�C��
set WORK_DIR=MonlineBrowser\bin\Release\
set INPUT_FILE=MonlineBrowser.exe

rem ��Ɨp��temp�f�B���N�g�����쐬����
set TEMP_DIR=__TEMP__\
if NOT EXIST %TEMP_DIR% (
mkdir %TEMP_DIR%
)

rem DLL���}�[�W����
set OUTPUT_DIR=%~dp0%TEMP_DIR%
echo �}�[�W������...
pushd %WORK_DIR%
rem �uFiddlerCore4.dll�v��.NET Framework 4.0�p�Ȃ̂Łu/v4�v���K�v
%~dp0%ILMERGE_PATH% /v4 /wildcards /out:%OUTPUT_DIR%%INPUT_FILE% %INPUT_FILE% *.dll
echo �}�[�W�����I��
echo.

rem �}�[�W�����t�@�C�����ړ�����
popd
set PUBLISH_DIR=Publish\
if NOT EXIST %PUBLISH_DIR% (
mkdir %PUBLISH_DIR%
)
move %OUTPUT_DIR%%INPUT_FILE% %PUBLISH_DIR%

rem temp�f�B���N�g�����폜����
if EXIST %TEMP_DIR% (
rmdir /s /q %TEMP_DIR%
)

