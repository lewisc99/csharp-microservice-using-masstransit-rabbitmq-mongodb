## Cadastro de Pessoas Microsserviços com Mensageria RabbitMQ <br/>
<hr>
<br/>

<h2>Descrição Português</h2>
<p>Aplicação de cadastro de pessoas, onde você pode cadastrar uma nova pessoa, e este cadastro e encaminhado para outro Microsserviço de Usuário com RabbitMQ e MassTransit,
onde este outro usuario que também têm um Banco de Dados próprio é atualizado ou cadastrado.
</p>
<p>
Para rodar o projeto Basta acessar a pasta Ms.Person e digitar no terminal
"docker-compose up"
e logo apos executar os projetos Ms.User e Ms.Person o serviço Ms.Person e o produtor
e o Ms.User e o consumidor.
Sendo assim quando você faz um Update ou Cadastro ou Deleção na aplicação Ms.Person a aplicação
Ms.User vai ser alterada também.
</p>
<p>
Containers: 
<img src="imgs/docker.JPG"/>
</p>
Banco de Dados: 
<p>
<img src="imgs/mongo.JPG"/>
</p>
<p>
Ms.Employee: 
<img src="imgs/swagger.JPG"/>
</p>
<p>
Ms.User: 
<img src="imgs/ms-user.JPG"/>
</p>
<hr>
<br/>
## 🚀 Tech Usada<br/>
<br/>
- C# .NET<br/>
- Banco de Dados MongoDb<br/>
- Mensageria RabbitMQ<br/>
- HATEOAS<br/>
- Clean Code<br/>
- MassTransit<br/>
-   Docker<br/>
-   Swagger <br/>

<br/>
<hr>

<hr>

## Linkedin Below - Linkedin ABaixo

<h4 align="center">
   Created by   <a href="https://www.linkedin.com/in/luiz-carlos-b50693173/" target="_blank"> Luiz Carlos </a>
</h4>

</html>
