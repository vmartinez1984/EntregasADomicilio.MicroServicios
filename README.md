# EntregasADomicilio MicroServicios

## Diagrama del sistema
```mermaid
flowchart TD
    A[Api platillos] -->Db[(Sql)]
    B[Api usuarios] --> Db
    D[Api pedidios] --> Db
    C[Api datos] -->DbMysql[(Mysql)]    
```
