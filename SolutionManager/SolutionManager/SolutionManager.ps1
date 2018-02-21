#
# Script.ps1
#

function show-menu 
{
 
[void][reflection.assembly]::Load('System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089')
$formShowmenu = New-Object 'System.Windows.Forms.Form'
$combobox1 = New-Object 'System.Windows.Forms.ComboBox'
$buttonUninstall = New-Object 'System.Windows.Forms.Button'
$buttonRemove = New-Object 'System.Windows.Forms.Button'

 
$combobox1_SelectedIndexChanged = {
$script:var = $combobox1.SelectedItem
$formShowmenu.Close()
}
 
 
$formShowmenu.Controls.Add($combobox1)
$formShowmenu.Controls.Add($buttonUninstall)
$formShowmenu.Controls.Add($buttonRemove)
$formShowmenu.AutoScaleDimensions = '6, 13'
$formShowmenu.AutoScaleMode = 'Font'
$formShowmenu.ClientSize = '284, 110'


 
#add array of items
#[void]$combobox1.Items.Addrange(1 .. 10)
 
#add single item
#[void]$combobox1.Items.Add('Single Item')

foreach(var item in )
{

}
 
$combobox1.Location = '45, 25'
$combobox1.Size = '187, 21'
$combobox1.add_SelectedIndexChanged($combobox1_SelectedIndexChanged)
 
$buttonUninstall.Location = '50,65'
$buttonUninstall.Text = 'Uninstall'
$buttonRemove.Location = '150,65' 
$buttonRemove.Text = 'Remove'
 
$formShowmenu.ShowDialog() | out-null
 
write-output $var
}

show-menu