# Igreja Dashboard – Backend

## **Descrição**
API para gerenciar membros da igreja, incluindo **CRUD**, dashboard com totais e filtragem.  
Utiliza **Entity Framework Core** e **SQL Server**. Swagger habilitado para testes.

---

## **Dependências**
- .NET 8 SDK
- Entity Framework Core
- SQL Server
- Visual Studio 2022 ou 2025 recomendado

---

## **Estrutura do Projeto**
IgrejaDashboard.Api/
├── Controllers/
├── DTOs/
├── Data/
├── Models/
├── Services/
├── Migrations/
├── Program.cs
└── IgrejaDashboardAPI.csproj

---

## Configuração do Banco de Dados e Execução da API

Esta seção explica como configurar o banco de dados, rodar as migrations e executar a API tanto pelo **Visual Studio** quanto pelo **CMD/Terminal**.

---

### **1. Configuração do Banco de Dados**

No arquivo `appsettings.json` ou `appsettings.Development.json`, configure a string de conexão:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=IgrejaDashboardAPI;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}

Substitua Server=localhost se usar outro servidor SQL.

Certifique-se de que o banco exista ou crie via SQL Server Management Studio.


## Rodando via Visual Studio
Abra a solução no Visual Studio.

Defina o projeto IgrejaDashboardAPI como projeto de inicialização.

Se necessário, execute o update do banco via Migrations:

Menu: Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes

Execute:

Add-Migration Inicial

Update-Database

Clique em Play / Iniciar Depuração (F5).

O Swagger estará disponível em:

HTTP: http://localhost:5136/swagger

HTTPS: https://localhost:7136/swagger


## Rodando via CMD / Terminal
cd <caminho_para_o_projeto_IgrejaDashboardAPI>
dotnet run

O Swagger será aberto na porta configurada no launchSettings.json.


## Endpoints
Método	Rota	Descrição
GET	/api/pessoas - Lista membros (filtro opcional ?search=)
GET	/api/pessoas/dashboard -	Totais de membros, masculinos e femininos
POST	/api/pessoas -	Cria novo membro
PUT	/api/pessoas/{id} -	Atualiza membro
DELETE	/api/pessoas/{id} -	Remove membro
