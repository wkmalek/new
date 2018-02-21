$path =  "C:\Users\Administrator\Documents\Visual Studio 2013\Projects\FirstDevSP\FirstDevSP\bin\Debug\FirstDevSP.wsp"
$name = "FirstDevSP.wsp"
$web = "http://devlab.billennium.pl"
$feature = "FirstDevSP_Feature1"
$feature2 = "FirstDevSP_Feature2"
$feature3 = "FirstDevSP_Feature3"

Write-Host -f green uninstall solution
Uninstall-SPSolution -identity $name

Write-Host -f green remove solution
Remove-SPSolution -identity $name

Write-Host -f green add solution
Add-SPSolution $path

Write-Host -f green install solution
Install-SPSolution -Identity $name -GACDeployment

Write-Host -f green disable feature
Disable-SPFeature -Identity $feature -Url $web

Write-Host -f green uninstall feature
Uninstall-SPFeature -Identity $feature

Write-Host -f green install feature
Install-SPFeature $feature

Write-Host -f green enable feature
Enable-SPFeature -Identity $feature -Url $web



Write-Host disable feature2
Disable-SPFeature -Identity $feature2 -Url $web

Write-Host uninstall feature2
Uninstall-SPFeature -Identity $feature2

Write-Host install feature2
Install-SPFeature $feature2

Write-Host enable feature2
Enable-SPFeature -Identity $feature2 -Url $web



Write-Host disable feature3
Disable-SPFeature -Identity $feature3 -Url $web

Write-Host uninstall feature3
Uninstall-SPFeature -Identity $feature3

Write-Host install feature3
Install-SPFeature $feature3

Write-Host enable feature3
Enable-SPFeature -Identity $feature3 -Url $web