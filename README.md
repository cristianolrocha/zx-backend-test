# Back-end Challenge
Acabou a cerveja em seu churrasco, confraternização, festa, ou seja lá o que for? Aaahhh, e não tem quem possa dirigir para buscar mais? Peça online.

Mas o aplicativo em seu smartphone não funciona sozinho! É necessário um serviço por trás para que, a partir de sua localização, possamos dar as opções mais próximas de você.


## Do que se trata

Esta é uma API desenvolvida segundo instruções postadas [AQUI](https://github.com/ZXVentures/code-challenge/blob/master/backend.md). 


## Como foi desenvolvido

Esta API foi desenvolvida em .NET Core. Portanto, é multiplataforma.
O Swagger é utilizado para documentar minimamente a utilização da API.
Também existem alguns poucos testes básicos do Controller.
O banco de dados utilizado é o MongoDB.
E também temos o Docker.

## Como utilizar localmente

Para utilizar localmente, é necessário ter o Docker instalado e rodando em modo Linux.
Após realizar o clone ou download, basta utilizar o comando **docker-compose up --build** em seu terminal para subir a aplicação.

Para acessar o Swagger: **/swagger**
Para acessar o Health Check: **/health**

## E agora? Como realizar o deploy?

Em primeiro lugar, deve rodar o comando abaixo na raiz do projeto:

 - **docker build -f .\src\pdv\Dockerfile -t pdv:latest --pull .**

Criada a imagem, deverá realizar o push (**docker push [DEMAIS PARÂMETROS]**) para o servidor desejado.

Para maiores informações:

 - https://docs.docker.com/engine/reference/commandline/push/

Para o deploy:

 - Necessita um servidor Mongo (banco de dados)
 - As **envs** em *pdv > enviroment > **mongo:database** / **mongo:host** / **mongo:port*** devem ser devidamente configuradas para o banco de dados
 - Configurar as secrets para o target adequado em *pdv > secrets*: o target de **mongo_user** deve ser *mongo:user* e o target de **mongo_password** deve ser *mongo:password*
 - Utilizar a ferramenta/plataforma que for mais confortável.
