$feature = $args[0]
$web = "http://devlab.billennium.pl"

Write-Host -f green disable feature
Disable-SPFeature -Identity $feature -Url $web

Write-Host -f green uninstall feature
Uninstall-SPFeature -Identity $feature -Force

Write-Host -f green install feature
Install-SPFeature $feature -Force

Write-Host -f green enable feature
Enable-SPFeature -Identity $feature -Url $web