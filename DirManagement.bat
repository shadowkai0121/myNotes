@echo on
chcp 65001
start _DirManagement\push.txt
pause
cd _DirManagement & ren push.txt push.bat
cd ..\
call _DirManagement\push.bat
pause 資料夾Push完畢
cd _DirManagement & ren push.bat push.txt
@echo finish