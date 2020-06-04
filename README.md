# Copa do Mundo de Filmes

## Pré-requisitos

### Back-end

#### .NET Core

A versão do framework utilizada nos projetos foi a 3.1. O comando abaixo pode lhe trazer informações sobre o framework na sua máquina:

```
dotnet --info
```

Para instalar o .NET Core, acesse [a página de download do framework]( https://aka.ms/dotnet-download) para maiores informações.

### Front-end

#### Angular

A versão utilizada em ambos foi a 9.1.7. Para averiguar a versão instalada, você pode fazer uso do comando:

```
ng version
```

Para instalar o Angular, acesse [este setup descrito na documentação do framework](https://angular.io/guide/setup-local) para maiores informações.

## Ambiente de desenvolvimento

As aplicações foram desenvolvidas com uso de:

- Windows 10;
- Visual Studio Code e Angular CLI para a aplicação front-end;
- Visual Studio 2019 Community para a aplicação back-end;
        
## Execução das aplicações

### Back-end

- Abra seu terminal/console;
- Acesse a pasta raiz do repositório CopaFilmes;
- Execute o comando:

```
dotnet run --configuration Release --project CopaFilmes.WebAPI
```

### Front-end

**Os passos abaixo consideram uso do Angular CLI com opção global**. Para identificação disso, use o comando abaixo:

```
npm list -global --depth 0
```

Para executar a aplicação de front-end, **a aplicação de back-end já deve estar em execução**. Os passos para front-end são:

- Abra seu terminal/console;
- Acesse a pasta raiz do repositório CopaFilmes;
- Acesse a pasta copafilmes-spa;
- Execute o comando:

```
ng serve --prod=true --open=true
```

O seu browser será aberto com a exibição da página inicial da aplicação.

## Execução dos testes

- Abra seu terminal/console;
- Acesse a pasta raiz do repositório CopaFilmes;
- Execute o comando:

```
dotnet build --configuration Debug CopaFilmes.Tests
```

4º - Execute o comando:

```
dotnet vstest CopaFilmes.Tests\bin\Debug\netcoreapp3.1\CopaFilmes.Tests.dll
```

Caso deseja visualizar a lista de testes , execute o comando:

```
dotnet vstest CopaFilmes.Tests\bin\Debug\netcoreapp3.1\CopaFilmes.Tests.dll --ListTests
```

Para aqueles que possuem o Developer Command Prompt (instalado com o Visual Studio), após o comando do build, uma alternativa de exibição da suite de testes pode ser realizada com o comando abaixo:

```
vstest.console CopaFilmes.Tests\bin\Debug\netcoreapp3.1\CopaFilmes.Tests.dll
```