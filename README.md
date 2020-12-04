# GlobalKineticAssessment
## Coin Restful API
A solution to the Global Kinetic assessment. An API with 3 end points

## Technologies
- C#
- asp.net core 3.1
- XUnit
- Newtonsoft

## API Endpoints
#### Add a coin
`http://localhost:5000/coinjar`
method type: post
```
{
    "amount":1
}
```

#### Get Total Amount
`http://localhost:5000/coinjar` method type:get

#### Reset coin 
`http://localhost:5000/coinjar` method type:put


## Testing it out

1. Clone this repository
2. Build the solution using Visual Studio, or on the [command line](https://www.microsoft.com/net/core) with `dotnet build`.
3. Run test with 'dotnet test'
4. Run the project, `cd GlobalKineticAssessment` then run `dotnet run`. The API will start up on http://localhost:5000.
5. Visit the swagger page on  http://localhost:5000/swagger
6. Use an HTTP client like [Postman](https://www.getpostman.com/) or [Fiddler](https://www.telerik.com/download/fiddler) to `GET http://localhost:5000/coinjar`.
