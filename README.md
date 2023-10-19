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
