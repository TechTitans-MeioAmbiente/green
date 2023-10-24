# Introdução
#### O aplicativo x tem como problemática a emissão de CO<sub>2</sub> por escritórios e apresentamos a solução com o plantio de árvores por parte dos usuários não relacionados diretamente aos escritórios.
#### Definimos um escritório como sendo uma área compartilhada por vários funcionários que não emite CO<sub>2</sub> via emissões diretas (i.e. queima de combustíveis fósseis). Consideramos também que estes escritórios emitem CO<sub>2</sub> das seguintes formas:
- Translado dos funcionários até a empresa;
- Ar-condicionados;
- Emissão indireta via consumo de energia elétrica.
#### Para solucionar este problema utilizaremos como estratégia de mitigação o plantio de árvores. 
#### Cada usuário poderá plantar uma árvore que será rankeada de acordo com a categoria de extinção (IUCN), o CO<sub>2</sub> estocado pela planta e seus co-benefícios como, por exemplo, a zoocoria (dispersão realizada por animais, impulsionando a biodiversidade local). 
#### Deste modo, para que os escritórios possam ser considerados "carbon neutral" eles utilizarão o marketplace disponível em nossa aplicação que mostra as árvores e o seu valor buscando mitigar as emissões de CO<sub>2</sub> dos escritórios e fazendo quem plantou lucrar de forma sustentável.

## Front-end
<div style="display:flex; gap: 7px">
<img src="https://img.shields.io/badge/Flutter-02569B?style=for-the-badge&logo=flutter&logoColor=white" alt="">
<img src="https://img.shields.io/badge/Figma-F24E1E?style=for-the-badge&logo=figma&logoColor=white" alt="">
<img src="https://img.shields.io/badge/Dart-0175C2?style=for-the-badge&logo=dart&logoColor=white
" alt="">
</div>

#### Com um Front-end simples e dinâmico dividimos a aplicação "+green" em duas partes, sendo elas:
- ##### Módulo Empresarial
- ##### Módulo Pessoal

## Módulo Empresarial:
#### Após o cadastro do escritório o usuário poderá:
- ##### Adquirir créditos de carbono provenientes dos plantios resultantes do módulo pessoal;
- ##### Calcular suas emissões referentes ao período de um ano.
#### Consideraremos as emissões provinietes de translados dos funcionários, ar-condicionados e gastos energéticos. 
#### Para calcular as emissões de Co2 por translado dos funcionários o usuário responsável por fornecer os dados deve dar como input:
- ##### Números de carros utilizados pelos funcionários;
- ##### Consumo médio dos carros em quilômetros por litros de gasolina;
- ##### Distância média da casa dos funcionários até a empresa

#### Para calcular as emissões de Co2 causadas pelos ar-condicionados, o usuário deve fornecer:
- ##### Números de aparelhos de ar-condicionado e as suas potências.

#### Para calcular as emissões indiretas de Co2 devido ao gasto energético, o usuário deve fornecer;
- ##### Consumo médio mensal do perído de um ano (KWh)

## Módulo Pesssoal
#### Após o cadastro, o usuário poderá:
- ##### Cadastrar um nova árvore plantada com foto georeferenciada e o usuário deverá expecificar o nome do indivído plantado
- ##### Ver a lista lista com suas espécies plantadas, se já foram vendidos o carbono estocado;
- ##### Um mapa com a localização das espécies plantadas pelo próprio usuário.





## Back-end
<div style="display:flex; gap: 7px">
<img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt="">
<img src="https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white" alt="">
<img src="https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white" alt="">





</div>

#### Este repositório contém um backend modularizado em C# que consiste em diferentes módulos para lidar com várias funcionalidades relacionadas a empresas, pessoas físicas, API do banco, mensageria de e-mails e muito mais.

## Módulo Empresarial
### Este módulo lida com operações relacionadas a empresas, incluindo:

- Recebimento de inputs.
- Cálculo das emissões de carbono relacionadas à empresa
- Envio de dados para a API do banco.

## Módulo Pessoa Física
### Este módulo trata de operações relacionadas a pessoas físicas, incluindo:

- Envio de dados para a API do banco.
- Cálculo do crédito de carbono que a pessoa física vai receber.

## API do Banco
### Este módulo se concentra nas operações relacionadas ao banco de dados, incluindo:

- Recebimento e armazenamento de cadastros de usuários e empresas.
- Disponibilização de dados quando solicitados.
Conexão com o banco de dados (suportando SQL Server ou PostgreSQL).
- Implementação de autenticação JWT e OAuth2 para garantir a segurança.
- Definição de tempo de login usando JWT.

## Banco de Dados
### O backend suporta dois sistemas de gerenciamento de banco de dados: SQL Server e PostgreSQL.


Este repositório foi projetado para fornecer um backend modularizado que pode ser facilmente estendido e adaptado às necessidades específicas do seu projeto. Certifique-se de configurar os detalhes do banco de dados, autenticação e outras configurações de acordo com seus requisitos.
