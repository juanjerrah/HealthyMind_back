
# Healthy Mind

O healthy mind é uma aplicação responsável por fazer o registro de dados de humor do usuário e permitir o vinculo remoto desses usuários com profissionais, possibilitando um tratamento continuo e simultâneo


# Documentação da API (Humor)

```http
  GET /api/Humor
```
## GET humor

| Parâmetro(Filtros)   | Tipo | Descrição |
| :---------- | :--------- | :---------------------------------- |
| `Id` | `Guid` | **Opcional**. |
| `Titulo` | `string` | **Opcional**. |
| `Descricao` | `string` | **Opcional**. |
| `TipoHumor` | `int` | **Opcional**. |
| `PermiteVisualizacao` | `bool` | **Opcional**. |
| `DataInicio` | `dateTime` | **Opcional**. |
| `DataFim` | `dateTime` | **Opcional**. |
| `Start` | `int` | **Opcional**. Paginação |
| `Length` | `int` | **Opcional**. Paginação |

#### Retorna uma lista de Dados de humor

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "tituloHumor": "string",
    "descricaoHumor": "string",
    "tipoDoHumor": 1,
    "permiteVisualizacao": true,
    "dataInclusao": "2023-07-09T17:22:59.839Z"
  }
]
```

## POST humor
```http
  POST /api/Humor
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `titulo`      | `string` | **Obrigatório**. O titulo do humor a ser inserido |
| `descricao`      | `string` | **Obrigatório**. O descricao do humor a ser inserido |
| `tipoHumor` | `int` | **Obrigatório**. O tipoHumor do humor a ser inserido |
| `permiteVisualizacao`      | `bool` | **Opcional**. Define se o profissional poderá acessar o registro do humor(Padrao é true) |

#### Retorna o id do humor inserido
```
3fa85f64-5717-4562-b3fc-2c963f66afa6
```

## PUT humor
```http
  PUT /api/Humor
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id` | `guid` | **Obrigatório**. O id do humor que deseja atualizar |
| `titulo` | `string` | **Opcional**. O titulo do humor a ser atualizado |
| `descricao` | `string` | **Opcional**. O descricao do humor a ser atualizado |
| `tipoHumor` | `int` | **Opcional**. O tipoHumor do humor a ser atualizado |
| `permiteVisualizacao` | `bool` | **Opcional**. Define se o profissional poderá acessar o registro do humor(Padrao é true) |

## DELETE humor
```http
  DELETE /api/Humor
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id` | `guid` | **Obrigatório**. O id do humor que deseja excluir |

# Documentação da API (Diáro)

```http
  GET /api/Diario
```
## GET Diáro

| Parâmetro(Filtros)   | Tipo | Descrição |
| :---------- | :--------- | :---------------------------------- |
| `Id` | `Guid` | **Opcional**. |
| `Descricao` | `string` | **Opcional**. |
| `DataInicio` | `dateTime` | **Opcional**. |
| `DataFim` | `dateTime` | **Opcional**. |
| `Start` | `int` | **Opcional**. Paginação |
| `Length` | `int` | **Opcional**. Paginação |

#### Retorna uma lista de Dados de diário

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "descricao": "string",
    "dataInclusao": "2023-07-09T18:14:15.245Z",
    "dataAlteracao": "2023-07-09T18:14:15.245Z"
  }
]
```
```http
  GET /api/Diario/PorId
```
## GET Diário por id

| Parâmetro  | Tipo | Descrição |
| :---------- | :--------- | :---------------------------------- |
| `Id` | `Guid` | **Obrigatório**. |

#### Retorna o diário correspondente ao id informado

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "descricao": "string",
  "dataInclusao": "2023-07-09T18:22:46.387Z",
  "dataAlteracao": "2023-07-09T18:22:46.387Z"
}
```


## POST Diário
```http
  POST /api/Diario
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `descricao`      | `string` | **Obrigatório**. O descricao do Diário a ser inserido |

#### Retorna o id do diário inserido
```
3fa85f64-5717-4562-b3fc-2c963f66afa6
```

## PUT Diário
```http
  PUT /api/Diario
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id` | `guid` | **Obrigatório**. O id do diairo que deseja atualizar |
| `descricao` | `string` | **Opcional**. O descricao do diario a ser atualizado |

## DELETE Diario
```http
  DELETE /api/Diario
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id` | `guid` | **Obrigatório**. O id do humor que deseja excluir |
