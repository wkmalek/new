$path =  "C:\Users\Administrator\Documents\Visual Studio 2013\Projects\DevLab\PagesProject\bin\Debug\PagesProject.wsp"
$name = "PagesProject.wsp"

Write-Host -f green uninstall solution
Uninstall-SPSolution -identity $name

Write-Host -f green remove solution
Remove-SPSolution -identity $name

Write-Host -f green add solution
Add-SPSolution $path

Write-Host -f green install solution
Install-SPSolution -Identity $name -GACDeployment