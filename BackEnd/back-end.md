# Documentação para o uso das APIs com ASP.NET CORE. 
<div style="display: flex; align-items: center; justify-content: center; gap: 5px;"> 
 <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt=""> 
 <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=""> 
 <img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt=""> 
 <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white" alt=""> 
</div> 

## 1. Instalação. 🔌  
### Para fazer a instalação do nosso projeto primeiramente terás que abrir um repositório local em sua máquina e efetuar o seguinte comando:
```bash
git clone https://github.com/TechTitans-MeioAmbiente/green
```  
### Após ter feito isso, você precisará ter um editor de código compatível para abrir as aplicações. Recomendamos o uso do Visual Studio, pois o mesmo foi usado para criar todas as 4 APIs e o documentação de do projeto se baseará no uso junto a ele.
### Em seguida, precisarás abrir a pasta "Backend" e procurar a pasta chamadda "DBModule". Nela deverás criar um arquivo chamado "appsettings.json" e nele deverás escrever o seguinte: 
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "seu_servidor_local_ou_na_nuvem"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*" 
}
``` 
### Em "DefaultConnection" você deve colocar a string de conexão com o seu banco de dados, seja ele local ou na nuvem.  
### Após isso, você terá que abrir o "Console do Gerenciador de Pacotes" e executar o seguinte comando: 
```powershell
update-database
```
 
## 2. Funciomento. ⚙️
## 2.1 DBModule. 💾 🔐  
### - Introdução 📖
### O módulo do banco é responsável por receber as requisições HTTP dos módulos empresarial e pessoal. Ele também é responsável pela conexão com o banco de dados, criptografia das senhas usando o algoritmo HMAC com a função hash SHA-512 junto a um valor salt aleaório para aumentar a segurança. 
### As senhas do usuários não são salvas no banco, sendo apenas seus hashes junto aos valores salt salvos para maior segurança dos dados. 

### - Principais componentes: 
- ### <span style="color: #77559e;">Program.cs</span> -> local onde toda a aplicação é executada 
- ### <span style="color: #77559e;">Services</span>  -> local onde os serviços de acesso ao banco são executados.
- ### <span style="color: #77559e;">SecurityServices</span>  -> local onde os algoritmos de criptografia criam hashes e salts e verificam a autenticidade de senhas fornecidas pelos módulos empresarial e pessoal.
- ### <span style="color: #77559e;">Models</span> -> Local onde todos os principais modelos, sendo eles: TreeModel, PictureModel, CompanyModel e AppUserModel estão armazenados.
- ### <span style="color: #77559e;">Migrations</span>  -> Local onde estão armazenadas todas as migrações da aplicação, ou seja, as relações entre os modelos que serão transferidas para relações entre entidades no banco. 
- ### <span style="color: #77559e;">DTOs</span> -> local onde estão todos as classes DTO (Data Transfer Object), que são usadas para a transferência de arquivos pela API e pelas classes services. 
- ### <span style="color: #77559e;">Data</span>  -> Contém a classe DataContext, que é responsável por definir as entidades e as relações entre elas no banco de dados. 
- ### <span style="color: #77559e;">Controllers</span> -> Contém os controladores da API, sendo eles: TreeController, AppUserController, CompanyController e PictureController. Cada controlador é responsável por definir o que cada rota de determinado serviço retorna ou recebe.  
 
## 2.2 UserModule. 🙋🏻‍♂️
### - Introdução 📖
### O módulo de usuário é um dos módulos com função de camada intermediadora entre o Front-end e o banco de dados.Ele contém serviços que fazem requisições HTTP para o DBModule e também contém controladores próprios que servem para criar uma API que é usada para a comunicação com o Front-end.
### - Principais componentes:  
- ### <span style="color: #77559e;">Program.cs</span> -> responsável pela execução de toda a aplicação e por adicionar as injeções de dependência das classes services através do método AddScoped<>() 
- ### <span style="color: #77559e;">Services</span> -> Contém os serviços de PictureModel, TreeModel e AppUserModel. É através desses serviços junto à classe HttpClient que as requisições são feitas para o DBModule. 
- ### <span style="color: #77559e;">Models</span> -> Contém as classes AppUserModel e TreeModel que servem como base para as classes DTOs. 
- ### <span style="color: #77559e;">DTOs</span> -> Contém todas as classes DTOs da aplicação, incluindo classes destinadas a métodos GET, POST e PUT. 
- ### <span style="color: #77559e;">Controllers</span> -> Contém as classes controladoras, que servem para definir as requisições HTTP e as respectivas rotas que uma API pode fornecer. Todas as classes controladoras acessam os dados de DBModule através de uma injeção de dependências das interfaces services. As três classes controladoras contidas em Controllers são: PictureController, TreeController e UserController.  
 
## 2.2.1 - Documentação das rotas: 
### UserController: 
### <span style="color: #61affe;">HTTPGET</span>: 
- ### [URL da API]/user/{id}: Retorna uma string com os dados públicos do usuário, ou uma mensagem de erro se o usuário não existir no banco.
- ### [URL da API]/tree/{id}: Retorna uma string com todas as árvores que um usuário possui através do ID do usuário, ou uma mensagem de erro se o usuário não existir no banco 
 
### <span style="color: #49cc90;">HTTPPOST</span>: 
- ### [URL da API]: Cria um usuário no banco, retornando uma string “registred” se for bem sucedido, ou uma mensagem de erro se houver algum problema na hora de envio. 
 
###  <span style="color: #fca130;">HTTPPUT</span>: 
- ### [URL da API]/update/{id}: Atualiza o CPF, Nome e as árvores(através de seus IDs) que o usuário possui através de seu ID, retornando uma string “updated”, ou uma mensagem de erro se o usuário não existir no banco. 
 
###  <span style="color: #f93e3e;">HTTPDELETE</span>: 
- ### [URL da API]/delete/{id}: Deleta um usuário e as árvores que ele possui através de seu ID, retornando uma string “deleted” se for feito com sucesso, ou uma mensagem de erro se o usuário não existir no banco. 
 
 ### TreeController: 
 ### <span style="color: #61affe;">HTTPGET</span>: 
 - ### [URL da API]/{id}: Retorna uma string com os dados de uma árvore através de seu ID, ou uma mensagem de erro se a árvore não existir no banco. 
 ### <span style="color: #49cc90;">HTTPPOST</span>: 
 - ### [URL da API]: Cria uma árvore no banco com o ID de seu dono e seus outros dados, e retorna uma string “registred”, ou uma mensagem de erro se houver algum erro na hora de envio. 
 ### <span style="color: #fca130;">HTTPPUT</span>: 
 - ### [URL da API]/{id}: Atualiza os dados de uma árvore através de seu ID, retornando uma string “updated”, ou uma mensagem de erro caso a árvore não exista no banco.
 ### <span style="color: #f93e3e;">HTTPDELETE</span>: 
 - ### [URL da API]/{id}: Deleta uma árvore no banco através de seu ID, retornando uma string “deleted”, ou uma mensagem de erro caso a árvore não exista no banco. 
  
### PictureController: 
### <span style="color: #49cc90;">HTTPPOST</span>:
- ### [URL da API]/{id}: Cria uma foto no banco com o ID de sua árvore e seus outros dados (os bytes da imagem e o ID da árvore), e retorna uma resposta HTTP “Ok”, uma “BadRequest” se houver algum erro na hora de envio, ou uma “NotFound” se o ID da árvore na foto não existir no banco.
 
## 2.3 CompanyModule. 💼
### - Introdução 📖
### Juntamente com o módulo de usuário, o módulo empresarial é um dos módulos que serve de intermediador entre o front-end e o banco de dados através do DBModule. Além disso, ele também é responsável por realizar os cálculos de emissão de CO2 por parte das empresas. 
 ### - Principais componentes: 
 - ### <span style="color: #77559e;">Program.cs</span> -> É aqui onde toda a aplicação é executada. Contém todos os escopos dos services que são usados nas requisições HTTP e no serviços de cálculos através do método AddScoped<>(). 
 - ### <span style="color: #77559e;">Models</span> -> Contém a clase CompanyModel, que é usada como base para a criação das classes DTOs de company que são usadas para a transferência de dados através da chamada e recebimento de requisições HTTP.
  - ### <span style="color: #77559e;">HTTPServices</span> -> Como o próprio nome sugere, contém as classes e interfaces services relacionadas às requisições HTTP sendo elas, respectivamente, HTTPService e IHTTPService.
   - ### <span style="color: #77559e;">DTOs</span> -> Contém as DTOs que são utilizadas para a transferência de dados via requisições HTTP. Contém também a pasta SecurityDTOs, que contém duas classes, LoginCNPJDTO e LoginEmailDTO, que são utilizadas para a autenticação através do CNPJ e senha ou Email e senha da empresa. 
  - ### <span style="color: #77559e;">Controller</span> -> Contém os controladores que são responsáveis pelas rotas da API que recebem requisições HTTP. CompanyController contém uma injeção de dependência de IHTTPService para se comunicar com o DBModule, enquanto o CalculatorController contém uma injeção de dependências de ICalculatorService, usada para o cálculo de emissões de CO2
  - ### <span style="color: #77559e;">Calculator</span> ->  Contém a classe Emissions, que é responsável por todos os cálculos de emissão de CO2. Contém também duas pastas, sendo elas CalculatorMdoels, que contém os modelos para o recebimento de dados, e CalculatorServices, que contém a classe CalculatorService e a interface ICalculatorService, que são responsáveis pelos cálculos e são acessadas através de injeção de dependências no CalculatorController,.   
   
  ## 2.3.1 Documentação das rotas: 
  ### CompanyController: 
  ### <span style="color: #61affe;">HTTPGET</span>: 
  - ### [URL da API]/{id}: Retorna os dados de uma empresa através de seu ID, ou uma mensagem de erro caso a empresa não exista no banco. 
  ### <span style="color: #49cc90;">HTTPPOST</span>: 
  - ### [URL da API]: Cria uma empresa no banco, retornando uma string “registred” se for bem sucedido, ou uma mensagem de erro se houver algum problema na hora de envio. 
  - ### [URL da API]/login-cnpj: Faz o login da empresa através de seu CNPJ, retornando uma resposta HTTP “Ok”, ou uma “BadRequest” caso aconteça algum erro na hora do login. 
  - ### [URL da API]/login-email: Faz o login da empresa através de seu email, retornando uma resposta HTTP “Ok”, ou uma “BadRequest” caso aconteça algum erro na hora do login. 
  ### <span style="color: #fca130;">HTTPPUT</span>: 
  - ### [URL da API]/{id}: Atualiza o nome, CNPJ e email de uma empresa através de sua ID, retornando uma resposta HTTP “Ok”, ou uma “BadRequest” se a empresa não existir no banco. 
  ### <span style="color: #f93e3e;">HTTPDELETE</span>: 
  - ### [URL da API]/{id}: Deleta uma empresa através de sua ID, retornando uma resposta HTTP “Ok” se for feito com sucesso, ou “BadRequest” se a empresa não existir no banco. 
   
  ### CalculatorController: 
  ### <span style="color: #49cc90;">HTTPPOST</span>: 
  - ### [URL da API]/car: Aceita o número de carros, consumo médio de gasolina em km/litro, e a distância diária percorrida por cada carro em km como parâmetro, e retorna o total de Co2 produzido pelos carros, ou uma mensagem de erro caso aconteça algum erro na hora de enviar. 
  - ### [URL da API]/air-conditioning: Aceita como parâmetro o número de dispositivos, e a energia gasta em btus (British Thermal Units), retornando o total de Co2 emitido pelos dispositivos, ou uma mensagem de erro caso aconteça algum erro na hora de enviar. 
  - ### [URL da API]/energy: Aceita como parâmetro a média de consumo de energia mensal em KWh, retornando a emissão de Co2 anual, ou uma mensagem de erro caso aconteça algum erro na hora de enviar. 

   
 ## 2.4 EmailModule. 📧  
 ### - Introdução 📖
 ### O módulo de envio de e-mails, como o próprio nome sugere, tem como principal finalidade o envio de e-mails para usuários e empresas. Toda vez que uma empresa ou pessoa física é cadastrada ou que seus dados são atualizados, um e-mail é enviado avisando que o evento aconteceu. 
### - Principais componentes:   
 - ### <span style="color: #77559e;">Program.cs</span> -> É onde toda a aplicação é executada. Com o método AddScope<> as injeções de dependências de IMenssageService podem ser realizadas. 
 - ### <span style="color: #77559e;">Services</span> -> Contém a class MessageService e a interface IMessageService que são responsáveis pelo envio de e-mais. 
 - ### <span style="color: #77559e;">DTOs</span> -> Contém a classe EmailDTO que é utilizada como molde para o envio de e-maisl.
 - ### <span style="color: #77559e;">Controllers</span> -> Contém o controlador EmailController, que é responsável pelas rotas das requisições HTTP.  
  
## 2.4.1 Documentação das rotas: 
### <span style="color: #49cc90;">HTTPPOST</span>:
- ### [URL da API]: Aceita como parâmetros o destinatário (to), o assunto (subject), e o corpo/conteúdo (body). Retorna uma resposta HTTP “Ok” depois de enviar.
  
## 3. Observações. 🔍
### gostaríamos de implementar JWT e Oauth2 no nosso projeto, mas infelizmente não coube no nosso cronograma. 
 
## 4. Considerações Finais. 📝
### A construção do nosso projeto final foi bem interessante. Nessa semana de HackWeek tivemos a oportunidade de ter, pelo menos até certo nível, uma experiência real de como é trabalhar num projeto Full-Stack. 
 
## 5. Agradecimentos. 🤝
### Gostaríamos de agradecer às empresas âncoras e em especial à Blusoft e à prefeitura de Blumenau por estarem disponibilizando esta oportunidade para nós. Gostaríamos também de agradecer ao nosso instrutor, Rannyer, por todo o conhecimento transmitido ao longo desses seis meses. 

 
