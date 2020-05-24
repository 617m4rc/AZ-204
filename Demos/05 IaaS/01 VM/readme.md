# Implement solutions that use virtual machines

[Virtual Machines Documentation](https://docs.microsoft.com/en-us/azure/virtual-machines/)

## CLI Reference

[az vm](https://docs.microsoft.com/en-us/cli/azure/vm?view=azure-cli-latest)

## Disk Encryption

```
az keyvault create --location westeurope -n az203vaultap --resource-group az-203

az keyvault update -n az203vaultap -g az-203 --enabled-for-disk-encryption "true"

az vm encryption show -g az-203 -n winVM

az vm encryption enable -g az-203 -n winVM --disk-encryption-keyvault az203vaultap --volume-type all
```
