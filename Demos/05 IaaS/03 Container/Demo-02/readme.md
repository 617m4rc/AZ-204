# Web App for Container

Execute `create-webapp-container.azcli`

### AKS

#### Create AKS Cluster

Install kubectl command line client locally:

```
az aks install-cli
```

> Note: You might need to set a path to your system env variables

Create resource group:

```
az group create --name az-203 --location westeurope
```

Create AKS cluster:

```
az aks create --resource-group az-203 --name foodcluster --node-count 1 --enable-addons monitoring --generate-ssh-keys
```

Get credentials for the Kubernets cluster:

```
az aks get-credentials --resource-group az-203 --name foodcluster
```

Get a list of cluster nodes:

```
kubectl get nodes
```

Apply the yaml

```
kubectl apply -f foodui.yaml
```

Get the serive IP and use it on the assigned port

```
kubectl get service foodui --watch
```
