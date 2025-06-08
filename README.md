## 👨‍💻 Autores

Guilherme Augusto de Oliveira - RM:554176

Lucas Martinez Lopes - RM: 553816

Luiz Alecsander Viana — RM: 553034  


FIAP - Advanced Business Development with .NET




# 🌐 SafeZone API - Projeto .NET

Este é o repositório oficial da **API SafeZone**, desenvolvida para apoiar comunidades em situações de risco climático. Esta solução foi construída como parte da disciplina **Advanced Business Development with .NET**, utilizando boas práticas de desenvolvimento moderno com .NET 8, integração com Oracle DB, mensageria com RabbitMQ e inteligência preditiva com ML.NET.

---

## ✅ Funcionalidades

- CRUD completo para 3 entidades:
  - **HelpRequest** (Pedidos de Ajuda)
  - **Alert** (Alertas)
  - **RiskZone** (Zonas de Risco)
- Integração com banco de dados **Oracle SQL**
- **Swagger** para documentação automática da API
- **Rate Limiting** para controle de acesso (via `Microsoft.AspNetCore.RateLimiting`)
- Implementação de **HATEOAS** nas respostas
- Microsserviço de **mensageria com RabbitMQ**
- Modelo preditivo com **ML.NET**
- **Testes automatizados** com xUnit

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 8 (Web API)
- Entity Framework Core 8
- Oracle Database (via `Oracle.EntityFrameworkCore`)
- Swagger (Swashbuckle)
- ML.NET (Machine Learning)
- RabbitMQ (mensageria)
- xUnit e Moq (testes)
- Render.com (deploy gratuito)

---

## 🧭 Como Executar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/Guilhermeoliveira10/GS---Dotnet.git
   ```

2. Navegue até o diretório do projeto:
   ```bash
   cd SafeZone/SafeZone.API
   ```

3. Configure a **string de conexão do Oracle** em `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_HOST:PORTA/SEU_SERVICO"
   }
   ```

4. Restaure os pacotes e rode as migrações (caso necessário):
   ```bash
   dotnet restore
   dotnet ef database update --project ../SafeZone.Infrastructure
   ```

5. Rode a aplicação:
   ```bash
   dotnet run
   ```

6. Acesse a documentação no navegador:
   ```
   https://localhost:PORT/swagger
   ```

---

## 📘 Documentação dos Endpoints

Todos os endpoints estão documentados e disponíveis via Swagger, incluindo exemplos de requisição e resposta.

- `GET /api/HelpRequest`
- `POST /api/HelpRequest`
- `GET /api/Alert`
- `POST /api/Alert`
- `POST /api/Prediction/predict`

---

## 🧪 Instruções de Testes

Os testes unitários estão localizados no projeto `SafeZone.Tests`.

Execute os testes com o comando:

```bash
dotnet test
```

- Os testes utilizam `xUnit` e `Moq`
- A cobertura envolve o serviço de HelpRequest

---

## 📲 Integração com Mobile

Essa API será consumida por um **aplicativo React Native** na disciplina de **Mobile Application Development**. O app permitirá que usuários:

- Criem e consultem pedidos de ajuda
- Recebam alertas em tempo real
- Consultem zonas de risco
- Recebam previsões de risco baseadas em idade/localização

---

## 🧠 Inteligência Artificial (ML.NET)

O endpoint `POST /api/Prediction/predict` recebe um JSON com:
```json
{
  "idade": 35,
  "localizacao": "Zona Sul"
}
```

E retorna a predição de risco com base no modelo treinado com ML.NET.

---

## 📬 Mensageria com RabbitMQ

Toda nova criação de HelpRequest envia uma mensagem para a fila `helprequest-queue`, processada por um serviço `BackgroundService` implementado em `HelpRequestConsumer.cs`.

---
