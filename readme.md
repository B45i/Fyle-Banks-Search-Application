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
  -H 'Postman-Token: 03002676-9301-42ee-93bc-8b3c5fefb30c,eabf9aa5-d81e-4e12-8e08-b025f45d67d4' \
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
  -H 'Postman-Token: 775534a9-68e1-4f75-bc97-f4dab5d1e97b,4a8e665a-03f4-4655-962b-4f8dd88b4cec' \
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
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMSIsInVuaXF1ZV9uYW1lIjoicmFmaSIsIm5iZiI6MTU3MDk5NDE5MywiZXhwIjoxNTcxNDI2MTkzLCJpYXQiOjE1NzA5OTQxOTN9.Nz4h4EFSdF_7-s4eahHQgqkaZTnfPJrUMCAy7Ie02jw' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 6f3528d3-ec09-4138-87cc-af646d3069fd,2bdc35c0-5b43-47b8-a225-15fc4225ce3c' \
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
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxMSIsInVuaXF1ZV9uYW1lIjoicmFmaSIsIm5iZiI6MTU3MDk5NDE5MywiZXhwIjoxNTcxNDI2MTkzLCJpYXQiOjE1NzA5OTQxOTN9.Nz4h4EFSdF_7-s4eahHQgqkaZTnfPJrUMCAy7Ie02jw' \
  -H 'Cache-Control: no-cache' \
  -H 'Connection: keep-alive' \
  -H 'Host: fyle-net.herokuapp.com' \
  -H 'Postman-Token: 66684634-0fef-43d1-82a0-dd6b5ed8037c,b02f67d9-a15d-4f7b-8684-628b88bfda0c' \
  -H 'User-Agent: PostmanRuntime/7.18.0' \
  -H 'cache-control: no-cache'
```
