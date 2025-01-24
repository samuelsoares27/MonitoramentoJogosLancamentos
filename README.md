# Monitoramento de Jogos

Este projeto permite consultar jogos, plataformas e gêneros utilizando a API da RAWG. É possível filtrar jogos por data, plataforma, gênero e ordenação.

## Como Obter a Chave da API

1. Acesse [RAWG API Docs](https://rawg.io/apidocs) e crie uma conta.
2. Após o login, gere uma chave de API na área de desenvolvedor.
3. Substitua o valor de `ApiKey` no código com a chave gerada.

## Endpoints

### 1. Listar Jogos

**GET** `/api/games`

- **Filtros**:
  - `startDate` (DD/MM/AAAA)
  - `endDate` (DD/MM/AAAA)
  - `platformId`
  - `genre`
  - `ordering`
- **Exemplo**:
  ```bash
  /api/games?startDate=01/01/2022&endDate=31/12/2022&platformId=4&genre=action&ordering=-released


### 2. Listar Plataformas

**GET** `/api/platforms`

- **Exemplo**:
  ```bash
  GET /api/platforms

### 3. Listar Plataformas

**GET** `/api/genres`

- **Exemplo**:
  ```bash
  GET /api/genres

### Exemplo de Uso no Código
``private const string ApiKey = "SUA_CHAVE_AQUI";

