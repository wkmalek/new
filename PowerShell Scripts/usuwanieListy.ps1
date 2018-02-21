$siteURL="http://devlab.billennium.pl"
$listName=$args[0]
$web=Get-SPWeb $siteURL
$list=$web.Lists.TryGetList($listName)
if($list -ne $null)
{
  write-host -f green $listName "exists in the site"
  Get-SPWeb $siteURL | Where-Object { $_.Lists.Delete([System.Guid]$_.Lists[$listName].ID) }
  write-host -f green $listName "Deleted"
}
else
{
  write-host -f yellow $listName "does not exist in the site"
}