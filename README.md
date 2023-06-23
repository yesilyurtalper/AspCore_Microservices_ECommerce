# AspCore_Microservices_ECommerce

A tutorial-like application focusing on AspCore microservices for a basic  e-commerce application.
Includes keycloak oidc authn/authz, rabbitmq based async communication and a simple apigw.
SOLID principles and CLEAN architecture including CQRS, fluent validation, global error handling applied.

Services are backed by MySql database and secured by Keycloak oidc provider.
Before running microservices locally, it is suggestted to run below docker compose which runs latest Keycloak and MySql containers.
https://github.com/yesilyurtalper/docker_services/blob/master/compose_mysql_keycloak.yml

After db instance startup, run add-migration and update-database commands from package manager console to create app db.
You could also run just update-database if your cloned migrations folder for persistance projects are uptodate.
