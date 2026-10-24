# LH-Pets – Web API (ASP.NET Core)

Web API em C# para cadastro e listagem de **clientes** e **pets** da empresa LH-Pets.
Os dados ficam **em memória** (`List<T>`), sem banco de dados, e a API é documentada e testada via **Swagger**.

## Como executar
```bash
cd LHPets.Api
dotnet run
```
Acesse `http://localhost:<porta>/swagger` (a porta aparece no terminal).

## Endpoints

| Método | Rota                          | Descrição                                |
|--------|-------------------------------|------------------------------------------|
| GET    | /api/clientes                 | Lista todos os clientes                  |
| POST   | /api/clientes                 | Cadastra um cliente                      |
| GET    | /api/pets                     | Lista todos os pets                      |
| POST   | /api/pets                     | Cadastra um pet vinculado a um ClienteId |
| GET    | /api/pets/cliente/{clienteId} | Lista os pets de um cliente              |

## Validações
- Campos obrigatórios e e-mail válido → 400
- CPF duplicado → 409
- Pet com ClienteId inexistente → 400
- Pets de cliente inexistente → 404

## Observação
Por usar `List<T>` em memória, os dados são perdidos ao reiniciar a aplicação.
