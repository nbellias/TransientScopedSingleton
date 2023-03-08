# TransientScopedSingleton

Run the web app with .NET Core 7.

Understanding the life cycle of Dependency Injection (DI) is very important in ASP.Net Core applications. As we know, Dependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies. Most often, classes will declare their dependencies via their constructor, allowing them to follow the Explicit Dependencies Principle. This approach is known as "constructor injection".
 
To implement dependency injection, we need to configure a DI container with classes that is participating in DI. DI Container has to decide whether to return a new instance of the service or provide an existing instance. In startup class, we perform this activity on ConfigureServices method.
 
The lifetime of the service depends on when the dependency is instantiated and how long it lives. And lifetime depends on how we have registered those services.
 
The below three methods define the lifetime of the services,

## AddTransient
Transient lifetime services are created each time they are instantiated.
This lifetime works best for lightweight, stateless services.
Examples: Email and SMS sending, unique codes creation for users, currency conversion, database migration/update processing, etc., services.

## AddScoped
Scoped lifetime services are instantiated once per request.
Examples: database context, expensive computations, shopping cart, user-uploaded processing, user session, etc., services.

## AddSingleton
Singleton lifetime services are instantiated the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance.
Examples: logging, configuration, caching, message queueing, etc., services

## Run the app
Once we execute the application, we will see two different Guids are displayed for their respective service types. Now run two instance of UI in two different tabs of the browser like request 1 and request 2.

## Observation from Request 1 and Request 2
 
Transient service always returns a new instance even though it’s the same request, that is why operation Ids are different for first instance and second instance for both the requests (Request 1 and Request 2).
 
In the case of Scoped service, a single instance is created per request and the same instance is shared across the request. That is why operation Ids are the same for first instance as well as second instance of Request 1. But if we click on refresh button or load the UI on different tab of a browser (which is nothing but Request 2), new ids are generated.
 
In the case of Singleton service, only one instance is created and shared across applications. If we click on refresh button or load the UI on the different tab of a browser (which is nothing but Request 2), those ids will remain the same.

## Summary
 
Let’s summarize what we discussed so far,
With a transient service, a new instance is provided every time an instance is requested whether it is in the scope of same http request or across different http requests.
With a scoped service we get the same instance within the scope of a given http request but a new instance across different http requests.
With Singleton service, there is only a single instance. An instance is created, when service is first requested and that single instance single instance will be used by all subsequent http request throughout the application.
