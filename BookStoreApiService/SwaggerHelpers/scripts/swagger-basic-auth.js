// BookStoreApiService.SwaggerHelpers.scripts.swagger-basic-auth.js

//swaggerUi.api.clientAuthorizations.add("basic", new SwaggerClient.ApiKeyAuthorization("Authorization", "Basic U3dhZ2dlcjpUZXN0", "header"));

swaggerUi.api.clientAuthorizations.add("custom1", new SwaggerClient.ApiKeyAuthorization("X-Fourth-Org", "SwaggerTest", "header"));
swaggerUi.api.clientAuthorizations.add("custom2", new SwaggerClient.ApiKeyAuthorization("X-Fourth-Version", "1", "header"));
swaggerUi.api.clientAuthorizations.add("custom3", new SwaggerClient.ApiKeyAuthorization("X-Fourth-UserId", "Test", "header"));