# 🧊 CoolZoneAPI

A **CoolZoneAPI** é uma API REST desenvolvida em .NET com o objetivo de gerenciar **abrigos térmicos** em diferentes cidades brasileiras. Esses abrigos servem como locais de acolhimento durante ondas de calor extremo, e a API permite o controle de suas informações, como tipo, capacidade, horário de funcionamento e localização.

---

## 🚀 Tecnologias Utilizadas

- .NET 7
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Clean Architecture (Domain, Application, Infrastructure, Persistence)
- Swagger (OpenAPI)

---

## 📦 Entidades Principais

### 🏙️ `City`
- `Id`: identificador único
- `Name`: nome da cidade
- `State`: estado (UF)
- `ThermalShelters`: lista de abrigos térmicos na cidade

### 🛑 `ThermalShelter`
- `Id`: identificador único
- `Name`: nome do abrigo
- `Address`: endereço
- `Capacity`: capacidade de pessoas
- `OpeningHours`: enum (`DAYTIME`, `NIGHTTIME`)
- `Type`: enum com tipos como `CHURCH`, `SCHOOL`, `LIBRARY` etc.
- `CityId`: cidade à qual o abrigo pertence

---

## ⚙️ Como Executar Localmente

1. **Clone o repositório**
```bash
git clone https://github.com/FelipeSants08/CoolZoneAPI.git
cd CoolZoneAPI
```
2. Configure o banco de dados
Edite appsettings.json com sua string de conexão:

json
Copiar
Editar
"ConnectionStrings": {
        "Oracle": "User Id=RM558916;Password=081105;Data Source=oracle.fiap.com.br:1521/ORCL"
    }
3. Rode as migrations e atualize o banco

```bash

dotnet ef database update
Execute o projeto
```

```bash
dotnet run
```
4. Acesse a documentação Swagger em:

https://localhost:5001/swagger
