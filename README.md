# AspCore Microservices for a basic E-Commerce application
A tutorial-like aspcore e-commerce project to learn basic microservice architecture. Intented to include oidc authn/authz, rabbitmq based async communication and a simple apigw

Services are backed by MySql database and secured by Keycloak oidc provider. Hence, before running microservices locally, I also suggested to run below docker compose which runs latest Keycloak and MySql containers.
https://github.com/yesilyurtalper/docker_services/blob/master/compose_mysql_keycloak.yml
