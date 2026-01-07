# MyWebApiDemo

Simple demo for ASP.NET Core / WebAPI. 

## Features

Provides data for stock and weather forecast from third party APIs. Admin user can update the settings to change stock list or location for weather forecast.

## Important info

### API Keys
Get your own API Keys:
- https://openweathermap.org/
- https://twelvedata.com/

Add API keys in appsettings.json

### Deliberate Code Smells

Since this is only a demo with WebAPI focus, I have not added real user credential validation. So you will find hardcoded user credentials in AuthController.
Also some data are stored in memory instead of a database. 

## Postman

import MyWebApiDemo.postman_collection.json

### Environment
Your Postman environment needs five variables: weatherApiKey, twelveDataApiKey, baseUrl, MyWebApiDemo.User, MyWebApiDemo.Admin

Use your own API keys for the key variables. As baseUrl use "https://localhost:7057/api" or whatever you have defined in launchSettings.json. Both user variables needs a bearer token which can be generated when calling the login requests in auth folder

## OpenAPI

https://localhost:7057/openapi/v1.json