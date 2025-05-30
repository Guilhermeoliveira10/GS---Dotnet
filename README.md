# 🌐 SafeZone API

API desenvolvida em ASP.NET Core para auxiliar comunidades em eventos extremos com alertas, pedidos de ajuda e mapeamento de áreas de risco.

---

## 📌 Objetivo

Oferecer uma solução tecnológica para:

- Emitir **alertas** sobre desastres naturais (enchentes, calor extremo, etc)
- Permitir **pedidos de ajuda** geolocalizados
- Exibir **zonas de risco** em cidades afetadas

---

## 🛠️ Tecnologias Utilizadas

- ✅ ASP.NET Core 8 (Web API)
- ✅ Entity Framework Core + SQLite
- ✅ Swagger/OpenAPI
- ✅ Injeção de Dependência com Scoped
- ✅ Arquitetura em camadas: API, Domain, Application, Infrastructure
- ✅ RESTful API (sem HATEOAS)
- 🚧 Pronto para extensão com ML.NET, RabbitMQ e xUnit

---

## 🚀 Como Executar o Projeto

```bash
git clone https://github.com/seuusuario/safezone-api.git
cd safezone-api/SafeZone.API
dotnet build
dotnet ef database update --project ../SafeZone.Infrastructure --startup-project .
dotnet run
```

Acesse: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 🔌 Endpoints Disponíveis

### 🔔 Alertas

- `GET /api/alert`
- `GET /api/alert/{id}`
- `POST /api/alert`
- `PUT /api/alert/{id}`
- `DELETE /api/alert/{id}`

### 🆘 Pedidos de Ajuda

- `GET /api/helprequest`
- `GET /api/helprequest/{id}`
- `POST /api/helprequest`
- `PUT /api/helprequest/{id}`
- `DELETE /api/helprequest/{id}`

### ⚠️ Zonas de Risco

- `GET /api/riskzone`
- `GET /api/riskzone/{id}`
- `POST /api/riskzone`
- `PUT /api/riskzone/{id}`
- `DELETE /api/riskzone/{id}`

---

## 🧪 Testes

```bash
dotnet run
```

Acesse o Swagger em: [https://localhost:5001/swagger](https://localhost:5001/swagger)  
Teste os endpoints de forma interativa pela interface gerada.

---

## 📂 Estrutura de Pastas

```
SafeZone.API                --> Camada de API e Controllers
SafeZone.Application        --> Camada de regras de negócio (futura expansão)
SafeZone.Domain             --> Entidades
SafeZone.Infrastructure     --> DbContext, Migrations e Repositórios
```

---
