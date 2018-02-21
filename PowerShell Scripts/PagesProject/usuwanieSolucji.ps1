$path =  "C:\Users\Administrator\Documents\Visual Studio 2013\Projects\FirstDevSP\PagesProject\bin\Debug\PagesProject.wsp"
$name = "PagesProject.wsp"

Write-Host -f green uninstall solution
Uninstall-SPSolution -identity $name

Start-Sleep -s 10

Write-Host -f green remove solution
Remove-SPSolution -identity $name

