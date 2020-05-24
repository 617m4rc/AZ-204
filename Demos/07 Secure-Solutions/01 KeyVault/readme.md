# Key Vault

Create Key Vault & Get Key

```
az keyvault create \
 --resource-group <resource-group> \
 --name <your-unique-vault-name>

$key = Add-AzureKeyVaultKey -VaultName 'contoso' -Name 'MyFirstKey' -Destination 'HSM'
```
