# aksdemo

#create aks cluster

az aks create `
    --resource-group rg-aks-handson1 `
    --name akshandson `
    --os-sku Mariner `
    --node-vm-size Standard_DS2_v2 `
    --node-count 2 `
    --windows-admin-username vmssadmin `
    --windows-admin-password "<password>" `
    --vm-set-type VirtualMachineScaleSets `
    --network-plugin azure

#add linux node pool to the cluster

az aks nodepool add `
    --resource-group rg-aks-handson1 `
    --cluster-name akshandson `
    --name nplnx `
    --node-count 2 `
    --node-vm-size Standard_DS2_v2 `
    --os-sku Mariner

#add windows node pool to the AKS

az aks nodepool add `
    --resource-group rg-aks-handson1 `
    --cluster-name akshandson `
    --os-type Windows `
    --os-sku Windows2019 `
    --name npwin `
    --node-count 1 

#Build docker Image

docker build -t tempdockerwebapi:v0 .

#Login to ACR
```
docker login akscvmacr.azurecr.io -u akscvmacr -p <token>
```

#Tag local image

docker tag webappservice:v0 akscvmacr.azurecr.io/webappservice:v0

#Push image to ACR

docker push akscvmacr.azurecr.io/webappservice:v0

#Link AKS with ACR

az aks update --resource-group rg-aks-handson1 --name akshandson --attach-acr akscvmacr

#Fetch AKS credentials

az aks get-credentials --resource-group rg-aks-handson1 --name akshandson --overwrite-existing

#deploy ACR image to pods

kubectl apply -f deployment_Linux.yaml

#check status of deployment

kubectl get deployments
kubectl describe deployments lnxappdeployment

#check status of pods

kubectl get pods
kubectl describe pods mkmslicdeployment-7fdf847bd7-zxz6g

#check status of service

kubectl get services
kubectl describe service lnxappservice
