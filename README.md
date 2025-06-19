# Santander.Api

Sample of a .Net Core Web API to retrieve stories details from Hacker News API.

## Description

- Retrieves top stories from Hacker News
- Returns only the relevant fields (title, URL, author, score, etc.)
- Limits number of results using the `n` parameter
- Using parrallel tasks to improve performance
- OpenAPI support for testing

## Instructions to setup and start the project

- git clone https://github.com/victor-lara/santander.git
- cd Santander.Api
- dotnet restore
- dotnet run

## Request stories detail

- To run locally perform a Get to this url
  http://localhost:5276/api/stories?n=100
- Replace the value of n with the number of expected results.
- Do the request using Postman, curl or any other tool that can handle JSON results.
- Example of curl command
  curl "http://localhost:5276/api/stories?n=100"

## Response model

```json
[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2019-10-12T13:43:01+00:00",
    "score": 1716,
    "commentCount": 572
  }
]
```

## Todo

- Handle more types of exceptions/issues
- Add Swagger for dev environments
- Keep urls in env variables
- Add authentication/authorization
- Organize the models, services and interfaces in child projects (not needed yet because of simplicity)
- Add unit testing
- Add XML comments
