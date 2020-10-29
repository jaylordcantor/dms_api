# SPI Document Management System REST API

## How to use?

The consumption of this API was below, follow the order of server request from top to bottom of this markdown in order for this API works correctly. 

## Logical Drive


` ##### {{host}}/drive/api/drives`


This will return a result that shown below:
> _Note:_ If the server has an access to shared drives that the server has no permission it will return a **not found** error.
```
{
"data": [
{
"volumeLabel": null,
"driveFormat": null,
"name": "C:\\",
"type": null,
"totalSize": 0,
"freeSpace": 0
},
{
"volumeLabel": null,
"driveFormat": null,
"name": "D:\\",
"type": null,
"totalSize": 0,
"freeSpace": 0
}
],
"success": true,
"message": null
}
```
