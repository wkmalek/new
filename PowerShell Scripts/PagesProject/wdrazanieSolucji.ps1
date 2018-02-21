$path =  "C:\Users\Administrator\Documents\Visual Studio 2013\Projects\FirstDevSP\PagesProject\bin\Debug\PagesProject.wsp"
$name = "PagesProject.wsp"
$web = "http://devlab.billennium.pl"
$features = @("PagesProject_ContentTypesFeature","PagesProject_PageLayoutsFeature")

$sln = get-spsolution -identity $name

Write-Host -f green "`nUNINSTALL SOLUTION`n"
Uninstall-SPSolution -identity $name -Confirm:$false

#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Uninstall in progress..."
start-sleep -s 10 
}

Write-Host -f green "`nREMOVE SOLUTION`n"
Remove-SPSolution -identity $name -Confirm:$false

#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Removing solution in progress..."
start-sleep -s 10 
}

Write-Host -f green "`nADD SOLUTION`n"
Add-SPSolution $path  -Confirm:$false

Write-Host -f green "`nINSTALL SOLUTION`n"
Install-SPSolution -Identity $name -GACDeployment -Confirm:$false

#waiting
while($sln.JobExists) { 
Write-Host -f yellow " > Installing solution in progress..."
start-sleep -s 10 
}

foreach($feature in $features)
{
	Write-Host -f green "`nDISABLE FEATURE`n"
	Disable-SPFeature -Identity $feature -Url $web -Confirm:$false

	Write-Host -f green "`nUNINSTALL FEATURE`n"
	Uninstall-SPFeature -Identity $feature -Force -Confirm:$false

	Write-Host -f green "`nINSTALL FEATURE`n"
	Install-SPFeature $feature -Force -Confirm:$false

	Write-Host -f green "`nENABLE FEATURE`n"
	Enable-SPFeature -Identity $feature -Url $web -Confirm:$false
}
