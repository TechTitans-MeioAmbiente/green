# Hackweek Devs2Blu time DevOps 💻

## Tecnologia utilizadas:

<div style="display: flex; align-items: center; justify-content: center; gap: 5px;"> 
   <img src="https://img.shields.io/badge/Amazon_AWS-FF9900?style=for-the-badge&logo=amazonaws&logoColor=white" alt="aws">
   <img src="https://img.shields.io/badge/Ansible-000000?style=for-the-badge&logo=ansible&logoColor=white"alt="ansible">
   <img src="https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white"  alt="docker">
   <img src="https://img.shields.io/badge/Terraform-7B42BC?style=for-the-badge&logo=terraform&logoColor=white" alt="terraform">
   <img src="https://img.shields.io/badge/Github%20Actions-282a2e?style=for-the-badge&logo=githubactions&logoColor=367cfe"  alt="github_actions">
</div>


<div style="display: flex; justify-content: center; align-items: center; padding: 5px;">

<img src="imgs/icon-terraform.png" alt="">

<img src="imgs/icon-ansible.png" alt="">

<img src="imgs/icon-github-actions.png" alt="">

<img src="imgs/icon-aws.png" alt="">

</div>

## Introdução 📈

O time DevOps foi responsável pela "dockerização" da aplicação Backend (em C#).

Este README explica:

- A Dockerização das aplicações em C#.

- O provisionamento da máquina na AWS utilizando Terraform;

- Como as imagens Docker foram buildadas e todo o mapeamento de portas utilizado com Docker-Compose e fazendo o acesso via Ansible;

- Como o Ansible acessa as máquinas para fazer a instalação e configuração da VM para buildar e rodar a aplicação construida pelo Backend.

**Ao dar push na main, automaticamente inicia-se os processos citados aqui.**

Para provisionar a máquina EC2 na AWS é necessário:

1.  **Criação do repositório**

- Criar um repositório no github com .gitignore contendo as chaves geradas (id_rsa e id_rsa.pub) que possibilitarão seu acesso via ansible.

2.  **Criação de arquivos auxiliares**

- Cria-se um arquivo inventory.ini vazio na pasta base que será populado, este arquivo é importante pois guardará informações da máquina que está sendo provisionada;

3.  **Criar secrets no github para acessarmos a máquina e o Banco de Dados**

- No repositório adicionar as seguintes secrets em > settings > Security > Secrets and variables > Actions:

- AWS_ACCESS_KEY_ID - Chave de acesso da nossa AWS;

- AWS_SECRET_ACCESS_KEY - Senha da chave de acesso da conta AWS;

- SSH_PRIVATE_KEY - Informações da nossa chave id_rsa privada;

- SSH_PUBLIC_KEY - Informações da nossa chave id_rsa.pub;

- APPSETTINGS - Aqui é o conteúdo do arquivo appsettings.json que guarda as informações de acesso ao banco de dados criados pelo backend.

## Provisionamento da máquina na AWS com Terraform

A seguir tem-se a documentação do arquivo **provisioning.yml** que provisiona a máquia EC2 na AWS.

1.  **Checkout do Repositório**:

- A ação "Checkout code" é usada para obter o código do repositório no qual o workflow está sendo executado.

2.  **Criação de um Bucket S3 AWS**:

- Cria um bucket S3 na região 'us-east-1' para armazenar o arquivo terraform.tfstate.

3.  **Configuração das Chaves SSH na Instância Provisionada**:

- Configura as chaves SSH na instância que está sendo provisionada, permitindo acesso seguro.

4.  **Configuração do Terraform**:

- Configura o ambiente para uso do Terraform.

5.  **Inicialização do Terraform**:

- Inicializa o Terraform no ambiente de trabalho.

6.  **Aplicação do Terraform**:

- Aplica as configurações do Terraform para criar a infraestrutura especificada.

7.  **Aguarda a Instância Ficar Pronta**:

- Espera 20 segundos para garantir que a instância AWS esteja pronta.

8.  **Definição da Variável de Ambiente INSTANCE_IP**:

- Define a variável de ambiente "instance_ip" com o valor da saída "instance_ip" do arquivo outputs.tf do Terraform.

9.  **Verificação do Status da Instância EC2**:

- Monitora o status da instância EC2. Se ela estiver pronta, o fluxo de trabalho continua.

11. **Instalação do Ansible**:

- Instala o Ansible para viabilizar o acesso e configuração da máquina provisionada.

12. **Configuração do Arquivo de Inventário Ansible**:

- Popula-se o inventário do Ansible chamado "inventory.ini" com o endereço IP da instância criada.

14. **Adição da Chave Pública do Servidor Remoto**:

- Escaneia a chave pública do servidor remoto (instância EC2) e a adiciona ao arquivo "known_hosts" para estabelecer uma conexão segura.

15. **Execução do Playbook Ansible**:

- Executa o playbook Ansible "ansible-playbook-install-docker.yml" na instância criada, usando o arquivo de inventário "inventory.ini" e a chave privada SSH para acesso.

Os seguintes arquivos foram feitos para auxiliar nos processos de provisionamento:

1.  **./backend.tf**

- Auxilia na Criação do bucket S3, guardando informações como região e nome do bucket;

2. **./key.tf**

- Informa o nome da chave usada na AWS e aponta o arquivo id_rsa para ser usado como chave.

3. **./output.tf**

- Guarda aalguns outputs do provisionamento como ip da máquina e o ID da instância

4. **./main.tf**

- Cria ou configura o grupos de segurança para o provisinamento, faz as regras de entrada e saída da máquina, abrindo as portas utilizadas para o acesso das APIs. Além disso, este arquivo indica o tipo da instância e sistema operacional utilizado pela máquina, em nosso caso utilizamos a instância t2.micro pois consideramos ela suficientemente boa para este caso.

## Playbook Ansible para buildar as imagens Docker em um Host Remoto

O arquivo **ansible-playbook-install-docker.yml** foi criado para automatizar configuração e instalação do Docker em um host remoto. Ele realiza as seguintes etapas:

1. Atualiza a lista de pacotes do sistema para garantir que os pacotes estejam atualizados.

2. Instala o Python 3 para garantir a compatibilidade com as tarefas subsequentes.

3. Instala os pacotes necessários, incluindo `apt-transport-https`, `ca-certificates`, `curl`, `software-properties-common` e `python3-pip`.

4. Adiciona a chave GPG do Docker ao sistema.

5. Adiciona o repositório do Docker ao sistema.

6. Instala o Docker Community Edition.

7. Garante que o serviço do Docker esteja em execução e configurado para iniciar automaticamente no boot.

8. Baixa e instala o Docker Compose usando o pip.

9. Copia uma chave SSH do host de controle para o host remoto para facilitar o acesso SSH no futuro.

10. Clona um repositório Git em um diretório especificado no host remoto.

11. Adiciona o usuário 'ubuntu' ao grupo 'docker' para permitir a execução de comandos Docker.

12. Copia arquivos de configuração `appsettings.json` para módulos específicos do aplicativo, configurando as strings de conexão do banco de dados.

13. Acessa a instância por SSH, limpa todos os contêineres e imagens Docker existentes e inicia os contêineres definidos no arquivo `docker-compose.yml`.

### Pré-requisitos

- O host remoto deve ser acessível via SSH e o usuário remoto 'ubuntu' deve ter permissões de superusuário (sudo).

- Configure as variáveis de ambiente, como `CONNECTION_STRING`, conforme necessário, ou descomente as linhas que usam as variáveis no playbook.
