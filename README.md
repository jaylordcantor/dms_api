# SPI Document Management System REST API

## How to use

The consumption of this API was below, follow the order of server request from top to bottom of this markdown in order for this API works correctly.

## Logical Drive

### Get Server Drive

#### `{{host}}/drive/api/drives`

This will return a result that shown below:
> _Note:_ If the server has an access to shared drives that the server has no permission it will return a **not found** error.

```json
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

## User Catalog Permission

### Add User Catalog

#### `{{host}}/UserCatalog/api/post`

To add user catalog permission you just need to supply these two(2) required fields.

```JSON
{
    "UserId":3,
    "CatalogId":1
}
```

These will return an output like this.

```JSON
{
    "data": {
        "id": 3,
        "division": {
            "id": 8,
            "name": "Finance Division"
        },
        "department": {
            "id": 1,
            "divisionId": 8,
            "code": "TRD",
            "name": "Treasury"
        },
        "section": null,
        "location": {
            "id": 1,
            "name": "Corporate Office",
            "address": "Unit 1406 Antel 200 Corporate Center121 Valero Street, Salcedo Village 1231, Makati City"
        },
        "username": "johndoe",
        "lastName": "Doe",
        "firstName": "John",
        "mi": "D",
        "employeeNo": "2020-10-1234",
        "isActive": true,
        "catalogs": [
            {
                "id": 1,
                "departmentId": 3,
                "department": null,
                "sectionId": 1,
                "section": null,
                "code": "c-trd-000001",
                "name": "Filing Chart"
            }
        ]
    },
    "success": true,
    "message": null
}
```
