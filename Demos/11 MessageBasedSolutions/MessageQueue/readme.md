Create a storage account

```
az storage account create --name queuelab -g learn-df4f6803-a9dc-4327-bf70-9a2aca58b2d1 --kind StorageV2 --sku Standard_LRS
```

Create the application

```
dotnet new console -n QueueApp
cd QueueApp
dotnet build
```

Get your connection string and add it to program.cs

```
az storage account show-connection-string --name queuelab --resource-group learn-df4f6803-a9dc-4327-bf70-9a2aca58b2d1
```

Add Azure Storage

```
dotnet add package WindowsAzure.Storage --version 9.3.3
```

Execute the App

```
dotnet run Send this message
```

Check Result

```
az storage message peek --queue-name newsqueue --connection-string <connection-string>
```

> Note: Put your connection string value into an environment variable named AZURE_STORAGE_CONNECTION_STRING to save yourself from having to type the --connection-string parameter every time!

Cleanup

```
az storage queue delete --name newsqueue --connection-string <connection-string>
```
