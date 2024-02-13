# EntregasADomicilio MicroServicios

## Diagrama del sistema
```mermaid
flowchart LR
    Db[(Sql)]
    DbMysql[(Mysql)] 
    DbMongo[(MongoDb)]   

    C[Api web datos] -->DbMysql
    A[Api web platillos] -->Db
    B[Api web usuarios] --> Db
    D[Api web pedidios] --> Db

    H[Api cocina pedidos] -->Db
    I[Api cocina clientes] -->Db
    J[Api cocina login] -->Db
    K[Api cocina platillos] -->Db
    L[Api cocina repartidor Ubicacion] --> DbMongo

    G[Api repartidor Ubicacion] --> DbMongo
    E[Api repartidor pedidos] --> Db
    F[Api repartidor login] --> Db        

    M[Api Admin web datos] --> DbMysql
    N[Api Admin clientes] --> Db
    O[Api Admin pedidos] --> Db
    P[Api Admin platillos] --> Db
    Q[Api Admin repartidor Ubicacion] --> DbMongo
    R[Api Admin usuarios] --> Db
    S[Api Admin login] --> Db
```
