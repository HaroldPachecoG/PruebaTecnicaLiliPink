# PruebaTecnicaLiliPink

# Prueba Tecnica .NET + PostgreSQL

Este proyecto es una API REST desarrollada en **.NET Core** que interactúa con una base de datos **PostgreSQL** utilizando **Entity Framework Core**.

## 🚀 Requisitos Previos
Antes de instalar y ejecutar la aplicación, asegúrate de tener lo siguiente instalado:

1. **.NET SDK** (versión 6 o superior) - [Descargar](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. **PostgreSQL** - [Descargar](https://www.postgresql.org/download/)
4. **Git** (para clonar el repositorio) - [Descargar](https://git-scm.com/)
5. **Postman** o **Swagger** para probar la API

## 📂 Configuración del Proyecto
### 1️⃣ Clonar el Repositorio
```sh
git clone https://github.com/HaroldPachecoG/PruebaTecnicaLiliPink.git
cd PruebaTecnicaLiliPink
```

### 2️⃣ Configurar la Base de Datos PostgreSQL
Abre PostgreSQL y crea una base de datos manualmente:
```sql
CREATE DATABASE PruebaTecnica;
```

### 3️⃣ Configurar la Cadena de Conexión
Modifica el archivo **`appsettings.json`** en `PruebaTecnica.API` y reemplaza la cadena de conexión:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=PruebaTecnica;Username=admin;Password=admin"
}
```

## ▶️ Ejecutar la Aplicación
### 1️⃣ Restaurar Dependencias
Ejecuta el siguiente comando en la raíz del proyecto para instalar las dependencias:
```sh
dotnet restore
```

### 2️⃣ Aplicar Migraciones y Crear la Base de Datos
```sh
dotnet ef migrations add Inicial

dotnet ef database update
```

### 3️⃣ Ejecutar la API
Para iniciar la API en modo desarrollo:
```sh
dotnet run --project PruebaTecnica.API
```
Por defecto, la API se ejecutará en: `http://localhost:44355`.

### 4️⃣ Abrir Swagger para Probar Endpoints
Cuando la API esté en ejecución, abre en tu navegador:
```
http://localhost:44355/swagger
```
Desde Swagger, podrás probar los endpoints expuestos en la API.

## 🛠️ Ejecutar los Scripts SQL
Una vez que PostgreSQL esté configurado, abre **pgAdmin** o **psql** y ejecuta los siguientes scripts
que se encuentran en la carpeta scriptSQL dentro de la raiz del proyecto:

Dentro de cada archivo se encuentran las instrucciones necesarias para su correcto funcionamiento

### 1️⃣ Crear las Tablas e Insertar Datos
Ejecuta el archivo **`Script_creación_de_entidades.sql`**

### 2️⃣ Ejecutar las Consultas SQL
Ejecuta el archivo **`Script_ejecucion_ejercicios.sql`**

## 📝 Endpoints de la API
### 📌 Validar si un nombre está en una matriz
```http
POST /api/PrimerPunto/contieneNombre
```
#### 📥 Body (JSON):
```json
{
  "Info": ["ATFVRA", "B4KHES", "5JENTY", "T6IRF3", "ELLJ54", "24JKRT"],
  "Nombre": "LINEA"
}
```
#### 📤 Respuesta:
```json
{
  "resultado": true
}
```

### 📌 Obtener Reporte de Estadísticas
```http
GET /api/reporte/reporte
```
#### 📤 Respuesta:
```json
{
  "cuenta_contieneNombre": 40,
  "cuenta_noContieneNombre": 100,
  "relacion": 0.4
}
```
## 💡 Contacto
Si tienes dudas, contáctame en [haroldypachecog@gmailcom](mailto:haroldypachecog@gmailcom)

