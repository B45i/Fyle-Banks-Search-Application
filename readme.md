# Fyle Backend Coding Test

## REST service that can fetch bank details, using the data given in the API’s query parameters.

-   Language: C#
-   Framework: asp.net core 3.0
-   ORM : EF core
-   Database: PostgreSQL
-   hosted on: Heroku (docker container)
-   Authentication: JWT
    <br/>
-   Bank details pulled from https://github.com/snarayanank2/indian_banks

> Branch details trimmed to only `9781` record to host on heroku

-   One Corrupted row is also removed.

## API Documentation.

-   Endpoint: https://fyle-net.herokuapp.com/api/

### Auth

#### Register

-   Endpoint: https://fyle-net.herokuapp.com/api/auth/register
-   Type: POST
-   Parameters: username, password

curl:

```curl
curl -X POST \
  https://fyle-net.herokuapp.com/api/auth/register \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Content-Length: 46' \
  -H 'Content-Type: application/json' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 420bd6fe-aa74-4e06-a617-fde9ece6b068,a60c7359-76ce-4ef1-9d33-7a24540864ce' \
  -H 'User-Agent: PostmanRuntime/7.18.0' \
  -H 'cache-control: no-cache' \
  -d '{
	"username": "b45i",
	"password": "abc123"
}'
```

#### Login

-   Endpoint: https://fyle-net.herokuapp.com/api/auth/login
-   Type: POST
-   Parameters: username, password
-   return: Auth token

*   curl:

```curl
curl -X POST \
  https://fyle-net.herokuapp.com/api/auth/login \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Content-Length: 46' \
  -H 'Content-Type: application/json' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 22626c36-cafe-4d49-92c9-5c65b8a2e493,a329256c-3881-4fb6-8b6f-853743b53e9b' \
  -H 'User-Agent: PostmanRuntime/7.18.0' \
  -H 'cache-control: no-cache' \
  -d '{
	"username": "b45i",
	"password": "abc123"
}'
```

### Bank

-   Endpoint: https://fyle-net.herokuapp.com/api/bank/
-   Type: GET
-   Parameters: IFSC (query), Auth token (header)
-   return: Bank details
-   As the api has only one result pagination is not added.

*   curl

```curl
curl -X GET \
  https://fyle-net.herokuapp.com/api/bank/ABHY0065001 \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMyIsInVuaXF1ZV9uYW1lIjoiYjQ1aSIsIm5iZiI6MTU3MTQ2OTQyMCwiZXhwIjoxNTcxOTAxNDIwLCJpYXQiOjE1NzE0Njk0MjB9.el9TWNitPDQJ0HkJIEpcJZPrJ3zUnN7mwh0xTGcBYfA' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 3a79b942-2315-4e48-940a-ebccf930220a,154d2f94-45c5-4914-9991-359d6f958645' \
  -H 'User-Agent: PostmanRuntime/7.18.0' \
  -H 'cache-control: no-cache'
```

### Branch

-   Endpoint: https://fyle-net.herokuapp.com/api/branch/
-   Type: GET
-   Parameters: bank name, city, offset, limit (query), Auth token (header)
-   return: list of branch with given name and city

```curl
curl -X GET \
  'https://fyle-net.herokuapp.com/api/branch/?bank=ABHYUDAYA%20COOPERATIVE%20BANK%20LIMITED&city=mumbai&offset=2&limit=3' \
  -H 'Accept: */*' \
  -H 'Accept-Encoding: gzip, deflate' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMyIsInVuaXF1ZV9uYW1lIjoiYjQ1aSIsIm5iZiI6MTU3MTQ2OTQyMCwiZXhwIjoxNTcxOTAxNDIwLCJpYXQiOjE1NzE0Njk0MjB9.el9TWNitPDQJ0HkJIEpcJZPrJ3zUnN7mwh0xTGcBYfA' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 92acaacb-2f0a-4835-96f1-3264960d68b4,8688783a-dae1-412f-8ea7-1840774e7958' \
  -H 'User-Agent: PostmanRuntime/7.18.0' \
  -H 'cache-control: no-cache'
```
