# CopaFilmes

## Descrição
Uma competição de filmes incrível!

---

## Projeto
### Teconologias utilizadas:
- **backend:** dotnet core 2.1
- **front-end:** Angular 8
- **testes-automatizados (backend):** xUnit
- **deploy:** docker-compose

## Como executar
Existem duas formas de executar essa aplicação: com docker compose e sem docker compose. Veja abaixo como realizar cada uma:

## Executando com docker compose
### Pré-requisitos
- docker-compose instalado, configurado e funcionando.

### Execução
Todas as instruções abaixo devem ser executadas utilizando linha de comando do seu SO.
1. navegue até o diretório principal **./CopaFilmes**
2. na linha de comando execute o comando **docker-compose up**
3. em seu navegador, vá até a url **http://localhost:4200**

## Executando sem docker compose
### Pré-requisitos
- dotnet 2.1 instalado e configurado
- nodejs instalado e configurado
- angular CLI instalado e configurado

### Execução
Todas as instruções abaixo devem ser executadas utilizando linha de comando do seu SO.

1. navegue até o diretório da api ./CopaFilmesAPI
2. na linha de comando, execute o comando **dotnet run**
3. Isso deixará o servidor de aplicação (back-end) rodando, agora vamos subir o front-end
4. Navegue até o diretório ../CopaFilmesSPA
5. digite o comando ng serve na sua linha de comando
6. em seu navegador, vá até a url **http://localhost:4200**

## Execução dos testes automatizados
### Pré-requisitos
- dotnet 2.1 instalado e configurado

### Execução
Todas as instruções abaixo devem ser executadas utilizando linha de comando do seu SO.

1. navegue até o diretório da api ./CopaFilmesAPITests
2. execute o comando dotnet test
  


