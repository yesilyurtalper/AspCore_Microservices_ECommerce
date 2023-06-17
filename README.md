# AspCore_Microservices_ECommerce

A tutorial-like application focusing on AspCore microservices for a basic  e-commerce application. Includes keycloak oidc authn/authz, rabbitmq based async communication and a simple apigw.

Services are backed by MySql database and secured by Keycloak oidc provider. Hence, before running microservices locally, I also suggested to run below docker compose which runs latest Keycloak and MySql containers.
https://github.com/yesilyurtalper/docker_services/blob/master/compose_mysql_keycloak.yml

After db instance startup, run add-migration and update-database commands from package manager console to create app db. You could also run just update-database if your cloned migrations folder for persistance projects are uptodate. 
