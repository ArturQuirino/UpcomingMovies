# Upcoming Movies Mobile App

This app is able to list the upcoming movies and its details!

## Build
There are no specific requirements to build and run this project. You just need to have Xamarin installed and a device to run.
Although this application was tested only on Android, it should also works fine on iOS.

### Third party libraries
This project used those libraries:

* Autofac - Autofac is an IoC conatiner for Microsoft .NET. It manages the dependencies between classes. It was used to manages the Dependency Injection.

* Polly - Polly is a library that allows developers to express resilience and transient fault handling policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner. It was used to increase resilience in HTTP requests.

* Refit - The automatic type-safe REST library for Xamarin and .NET.  It turns your REST API into a live interface that makes easier to manipulate Rest requests.

## Testing
There are some tests in the Test Projects. Those tests are simple, just to exemplify how the application should be tested. 

### Unit Tests
There are some unit tests in the UpcomingMovies.UnitTest project.
They are unit, so they are quick and use mocks to not depend on integrations

#### Third party libraries
This test project used those libraries:

* Moq - This library was used to mock the Services allowing the tests to be unit.

### Integration Tests
There are some integration tests in the UpcomingMovies.IntegrationTest project.
They exist to test the business logic integrated with the API. If the API is offline, for example, the test will fail. 
As they depend on external resources, they might not be so fast.