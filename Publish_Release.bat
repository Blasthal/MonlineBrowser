@echo off
setlocal

echo exeにdllをマージします。
echo.

rem ILMerge.exeへのパス
set ILMERGE_PATH=ILMerge\ILMerge.exe
rem Merge対象のディレクトリとファイル
set WORK_DIR=MonlineBrowser\bin\Release\
set INPUT_FILE=MonlineBrowser.exe

rem 作業用のtempディレクトリを作成する
set TEMP_DIR=__TEMP__\
if NOT EXIST %TEMP_DIR% (
mkdir %TEMP_DIR%
)

rem DLLをマージする
set OUTPUT_DIR=%~dp0%TEMP_DIR%
echo マージ処理中...
pushd %WORK_DIR%
rem 「FiddlerCore4.dll」は.NET Framework 4.0用なので「/v4」が必要
%~dp0%ILMERGE_PATH% /v4 /wildcards /out:%OUTPUT_DIR%%INPUT_FILE% %INPUT_FILE% *.dll
echo マージ処理終了
echo.

rem マージしたファイルを移動する
popd
set PUBLISH_DIR=Publish\
if NOT EXIST %PUBLISH_DIR% (
mkdir %PUBLISH_DIR%
)
move %OUTPUT_DIR%%INPUT_FILE% %PUBLISH_DIR%

rem tempディレクトリを削除する
if EXIST %TEMP_DIR% (
rmdir /s /q %TEMP_DIR%
)

