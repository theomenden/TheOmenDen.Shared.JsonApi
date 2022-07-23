[![TheOmenDen.Shared.JsonApi](https://github-readme-stats.vercel.app/api/pin/?username=theomenden&repo=TheOmenDen.Shared.JsonApi&show_icons=false&theme=synthwave)](https://github.com/theomenden/THeOmenDen.Shared.JsonApi)[![Build](https://github.com/theomenden/TheOmenDen.Shared.JsonApi/actions/workflows/sonarcloud.yml/badge.svg)](https://github.com/theomenden/TheOmenDen.Shared.JsonApi/actions/workflows/sonarcloud.yml)

# This library aims to accomplish the following goals

1. Provide a stable implementation of the JSON:API standard
   - Allow for the ability to stream results via `IAsyncEnumerable` implementations
   - Allow for the ability for `Links` to maintain immutability
   - Allow for the ability for `Errors` to maintain immutability
   - Allow for the ability to generate relationships and attributes 
2. Provide an action state filter for custom response codes
   - This will provide a clear way to distingusih between the results of HTTP Methods
   - This will allow for other processing to take place during a request
3. Provide templating for validations of basic view models and other resource objects
   - Provide strict typing for View Models
   - Provide for strict typing on relationships, while maitaining easy JSON Serialization
4. Provide a simple, easy to understand JSON document to be interpreted by any api consumer
   - By conforming to the JSON API standard, any `Hypermedia` based API Consumer _should_ be able to read and consume the JSON Document
   - By allowing for the links object to contain references to specific endpoints, the API Consumer _should_ be able to utilize specific endpoints
   - By allowing for "Included" properties, the API Consumer _should_ be able to create less HTTP requests overall
5. Provide source generators for minimal API endpoints based off of registered view models


# This library is sourced/inspired by:

  - ## [The JSON API Standard](https://jsonapi.org/)



