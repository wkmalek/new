$path =  "C:\Users\Administrator\Documents\Visual Studio 2013\Projects\FirstDevSP\PagesProject\bin\Debug\PagesProject.wsp"
$name = "PagesProject.wsp"

Write-Host -f green add solution
Add-SPSolution $path

Write-Host -f green install solution
Install-SPSolution -Identity $name -GACDeployment
