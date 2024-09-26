# Trabalho de APS - Backend

Equipe: 
<ul>
  <li>João Felipe Lacerda Amorim Henrique</li>
  <li>Lara Lopes Garcia</li>
  <li>Pedro Henrique Rocha Dos Santos Nonato</li>
  <li>Samuel Valente De Oliveira</li>
  <li>Silvio Goncalves Xavier Junior</li>
</ul>

## Instalações necessárias

<ol>
  <li>.NET 8
    <ul>
      <li>https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-8.0.401-windows-x64-installer</li>
    </ul>
  </li>
  <li>Visual Studio Community 2022
    <ul>
      <li>https://visualstudio.microsoft.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false</li>
    </ul>
  </li>
  <li>Visual Studio Code
    <ul>
      <li>https://code.visualstudio.com/docs/?dv=win64user</li>
    </ul>
  </li>
</ol>


## Para abrir o projeto

<ol>
  <li>VisualStudioCode: Abrir a pasta raiz com o arquivo de solução (.sln)</li>
  <li>VisualStudio: Abrir o arquivo de solução (.sln)</li>
</ol>

## Instalar o Entity Framework (Visual Studio Code apenas):

Na raiz do projeto:

```
dotnet tool install --global dotnet-ef --version 8.0
```

## Gerar Migrations

As migrations já estão definidas, mas caso seja necessário gerá-las novamente:
<ul>
  <li>VisualStudioCode: Na raiz do projeto, abra o console e execute o comando:</li>
</ul>

```
dotnet ef migrations add Initial -p APS-Backend.Persistence -s APS-Backend
```

<ul>
  <li>VisualStudio: Na aba superior de ferramentas, basta selecionar ‘Gerenciador de Pacotes do NuGet’, e depois ‘Console do Gerenciador de Pacotes’. Ao abrir o console,  selecione o projeto camada Persistence e execute o comando:</li>
</ul>

```
Migrations Add-Initial
```

Obs.: Initial é o nome da migration, pode ser outro.

## Gerar o Banco de Dados

As migrations já estão definidas, para gerar o banco de dados:

<ul>
  <li>VisualStudioCode: Na pasta da camada Persistence, abra o console e execute o comando:</li>
</ul>

```
dotnet ef database update
```

<ul>
  <li>VisualStudio: Na aba superior de ferramentas, basta selecionar ‘Gerenciador de Pacotes do NuGet’, e depois ‘Console do Gerenciador de Pacotes’. Ao abrir o console,  selecione o projeto camada Persistence e execute o comando: </li>
</ul>

```
Update-Database
```


## Executar a Aplicação

<ul>
  <li>VisualStudioCode: Abrir o terminal na pasta da camada da API e executar:</li>
</ul>

```
dotnet watch run
```

<ul>
  <li>VisualStudio: Clicar em executar no canto superior central</li>
</ul>


A documentação do Swagger está em:

http://localhost:7074/swagger/index.html
