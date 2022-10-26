# Stock Tracking

Stock Tracking es una aplicación de escritorio realizada en C#, usando el patrón de diseño Fachada (Facade), arquitectura N-Tiers y SQL Server como base de datos para la persistencia de los datos.

Tiene implementado 5 roles (administrador, recursos humanos, reponedor, comercial y vendedor). De esta forma, al hacer login, se cargara la pantalla principal adaptada a las operaciones que cada rol puede realizar, tal y como se muestran en las siguientes imagenes:

![image](./images/login.png "Pantalla de Login")
>Pantalla de Login

![image](./images/main_admin.png "Pantalla del Administrador")
>Pantalla del Administrador

![image](./images/main_vededor.png "Pantalla del Vendedor")
>Pantalla del Vendedor

![image](./images/main_hr.png "Pantalla de Recursos Humanos")
>Pantalla de Recursos Humanos

![image](./images/main_comercial.png "Pantalla del Comercial")
>Pantalla del Comercial

En el caso del rol reponedor, tendremos una variación. En caso de ser necesario (numero de producto en stocl menor de 10), saldrá antes del menú un formulario de alerta.

![image](./images/Stock_alert.png "Alerta de Stock")
>Alerta de Stock

![image](./images/main_reponedor.png "Pantalla del Reponedor")
>Pantalla del Reponedor

A continuación, se enumeran las operacioens que podemos realizar

## Añadir Stock

A través del correspondiente botón (o bien desde el formulario de alerta de stock), podemos acceder al siguiente formulario para modificar el stock de los productos

![image](./images/Add_stock.png "Añadir Stock")

## Categorías

pendiente