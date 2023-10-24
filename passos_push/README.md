Fluxo de Trabalho para Contribuições
Para manter a integridade e a organização do código, seguimos um fluxo de trabalho específico para fazer alterações e implementações no projeto. As 'branches' principais são 'dev' e 'producao'. Abaixo, você encontrará as etapas para fazer contribuições.

NOTA: Apenas Igor e Matheus que darão o push para a main. Por isso que estamos utilizando a branch producao para teste, quando a branch producao estiver rodando "redondinha", os DevOps darão push na main que dará o trigger para modificar o app em operação!

1. Trabalhando na branch "dev"
Faça todas as alterações de desenvolvimento na branch "dev". Siga os passos abaixo para enviar suas alterações:

bash
Copy code
# Clone o repositório se ainda não o fez
git clone URL_DO_REPOSITORIO

# Navegue até o diretório do repositório
cd green

# Mude para a branch 'dev'
git checkout dev

# (Faça suas alterações)

# Adicione as alterações para preparar para o commit
git add .

# Comite as alterações com uma mensagem significativa
git commit -m "Descreva suas alterações em detalhes"

# Faça push das alterações para a branch 'dev' no repositório remoto
git push origin dev
2. Criando um Pull Request da "dev" para a "producao"
Após enviar suas alterações para a branch "dev", você deve criar um 'pull request' para a branch "producao". Siga os passos abaixo:

Passo 1: Vá para o repositório no GitHub.

Passo 2: Clique em "Pull requests".

Passo 3: Clique em "New Pull Request".

Passo 4: Selecione "producao" como a branch base e "dev" como a branch de comparação.

Passo 5: Revise suas alterações e, se estiver tudo correto, clique em "Create Pull Request".

Passo 6: Dê um título informativo e uma descrição detalhada das alterações propostas.

Passo 7: Clique em "Create Pull Request" para finalizar.

Sua contribuição será revisada e, se aprovada, será mesclada na branch "producao".
