# Continuously update data using Hangfire on docker

Monkeypox data source (https://www.ecdc.europa.eu/en/publications-data/data-monkeypox-cases-eueea) used to request data at an given time interval.

Run the project,

### Step 1

```docker
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build
```

### Step 2

Navigate to http://localhost:5000/hangfire/ to access the hangfire dashboard. Use following creadentials to log into the hangfire dashboard.

> username: admin  
> password : abc@123

### Step 3

Trigger the recurring job by sending a POST reply to http://localhost:5000/api/Hangfire endpoint. You'll recieve the following request when it has successfully started.

```
Data pulling job initiated
```

#### Docker images

API build - `mcr.microsoft.com/dotnet/sdk:6.0`  
SQL server - `mcr.microsoft.com/mssql/server:2017-latest`

_Refer docker-compose files for more information_
