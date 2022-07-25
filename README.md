[![TheOmenDen.Shared.JsonApi](https://github-readme-stats.vercel.app/api/pin/?username=theomenden&repo=TheOmenDen.Shared.JsonApi&show_icons=false&theme=synthwave)](https://github.com/theomenden/THeOmenDen.Shared.JsonApi)[![Build](https://github.com/theomenden/TheOmenDen.Shared.JsonApi/actions/workflows/sonarcloud.yml/badge.svg)](https://github.com/theomenden/TheOmenDen.Shared.JsonApi/actions/workflows/sonarcloud.yml)

# This library aims to accomplish the following goals

1. Provide a stable implementation of the JSON:API standard
   - Allow for the ability to stream results via `IAsyncEnumerable` implementations
   - Allow for the ability for `Links` to maintain immutability
   - Allow for the ability for `Errors` to maintain immutability
   - Allow for the ability to generate relationships and attributes 
2. Provide a template for validations of basic view models and other resource objects
   - Provide strict typing for View Models
   - Provide for strict typing on relationships, while maintaining easy JSON Serialization
3. Provide a simple, easy to understand JSON document to be interpreted by any API consumer
   - By conforming to the JSON API standard, any `Hypermedia` based API Consumer _should_ be able to read and consume the JSON Document
   - By allowing for the links object to contain references to specific endpoints, the API Consumer _should_ be able to utilize specific endpoints
   - By allowing for "Included" properties, the API Consumer _should_ be able to create less HTTP requests overall
4. Provide simple extension methods for easy access to the `IViewModel` interface
# This library is sourced/inspired by:

  - ## [The JSON API Standard](https://jsonapi.org/)
  - ## [Scott Mcdonald's JsonApiFramework](https://github.com/scott-mcdonald/JsonApiFramework)
  - ## [codecutout's JsonApiSerializer](https://github.com/codecutout/JsonApiSerializer)  


# An example of using the Fluent API to build a view model
## Then you can use a source generator to generate the json from this later!
  ``` csharp
  var vm = ViewModelBuilder<TestClass>
    .CreateBuilder()
    .FromData(testClass)
    .WithLinks()
        .AddSelfLink()
        .AddLink(PaginationLink.First("/test?page=1"))
    .WithRelatedData()
        .AddRelationship(test2.Name, test2)
            .WithSelfLink<TestClass>(test2.Name)
            .Include(ViewModelBuilder<TestClass>
                        .CreateBuilder()
                        .FromData(test2)
                        .Build)
    .WithRelatedData()
    .AddRelationship(test3.Id.ToString(), test3)
        .WithSelfLink<Additional>(test3.Id.ToString())
        .DoNotInclude()
    .Build();

   Console.WriterLine(JsonSerializer.Serialize(vm, ViewModelContext.Default.IViewModel));
  ```
# An example of Declaring a Collection of ViewModels - with relationships
## Using the above Fluent API to build a view model, then creating a view model collection from other data
``` csharp
var testClass = new TestClass
{
    Count = 1,
    Description = "Short dumb description",
    Name = "Test 1"
};

var test2 = new TestClass
{
    Count = 2,
    Description = "Relate Me",
    Name = "Test 2"
};

var test3 = new Additional
{
    Id = Guid.NewGuid(),
    Count = 1,
    Name = "Additional Class To Relate"
};

var vm = ViewModelBuilder<TestClass>
    .CreateBuilder()
    .FromData(testClass)
    .WithLinks()
        .AddSelfLink()
        .AddLink(PaginationLink.First("/test?page=1"))
    .WithRelatedData()
        .AddRelationship(test2.Name, test2)
            .WithSelfLink<TestClass>(test2.Name)
            .Include(ViewModelBuilder<TestClass>
                        .CreateBuilder()
                        .FromData(test2)
                        .Build)
    .WithRelatedData()
    .AddRelationship(test3.Id.ToString(), test3)
        .WithSelfLink<Additional>(test3.Id.ToString())
        .DoNotInclude()
    .Build();

var createListOfVm = new List<ViewModel<TestClass>> { vm };


var vmc = ViewModelCollection<TestClass>.From(createListOfVm);
```

# This library also includes the ability to work with simple source generated `System.Text.Json` Contexts based off of the `IViewModel` type 
## Example: Using the built-in Serialization context for a minimal API
``` csharp
app.MapGet("/getVm", () => JsonSerializer.Serialize(vmc, ViewModelContext.Default.IViewModel));
```

# ToDos

1. Finish Async Streaming Implementations
   - The way they are currently implemented limits the functionality of the `AsyncStreamingViewModelCollection` to only provide controller support.
   - We want to change this to provide support for streaming through Minimal APIs
2. Work on providing more Generic typing support for JSON Serialization
   - This is a `.NET` and a `System.Text.Json` limitation.
   - Current proposed fix is in `.NET 7`
3. Add support for customizable collection returns
   - Currently due to the way we've worked with reflection, the collection models/view models return relatively hard to understand results
4. Improve fluent interface
   - Allow for the ability to customize relationships further
   - Allow for the ability to customize `selfUrl` further when calling `AddSelfLink/WithSelfLink`
   - Allow for the ability to add relationships for the collection types
5. Continue to provide maintainence and optimizations