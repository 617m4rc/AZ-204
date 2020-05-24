# Creating VMs

## Azure CLI

To create a Ubuntu VM execute `create-linux-vm.azcli`

Connect to VM

```
ssh azureuser@104.40.251.162

```

## PowerShell

[Azure Powershell](https://docs.microsoft.com/en-us/powershell/azure/?view=azps-3.3.0)

[Azure Porwershell Reference](https://docs.microsoft.com/en-us/powershell/module/?view=azps-2.8.0)

Install Azure PowerShell

```
Install-Module -Name PowerShellGet -Force
Install-Module -Name Az -AllowClobber -Scope CurrentUser
```

Execute `create-win-vm.ps1`
