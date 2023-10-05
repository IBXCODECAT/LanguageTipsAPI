# Language Tips API Documentation
Welcome to the Language Tips API! This API provides access to a collection of language learning tips.
## Base URL
The base URL for all API endpoints is: `<port>/tips`
## Endpoints
### Get a Random Tip
- **URL**: `/random`
- **Method**: `GET`
- **Description**: Get a random language learning tip from the collection.
- **Rate Limiting**: Requests to this endpoint are subject to rate limiting.
**Request Example:**
```
GET https://your-api-domain.com/api/tips/random
```
**Response Example (200 OK):**
```json
{
    "id": 1,
    "title": "Practice Regularly",
    "description": "Consistent practice is key to language learning. Dedicate some time each day to study and practice."
}
```
### Get a Tip by ID
- **URL**: `/{id}`
- **Method**: `GET`
- **Description**: Get a language learning tip by its unique identifier (ID).
- **Rate Limiting**: Requests to this endpoint are subject to rate limiting.
**Parameters:**
- `id` (integer, required): The unique identifier of the tip to retrieve.
**Request Example:**
```
GET https://your-api-domain.com/api/tips/1
```
**Response Example (200 OK):**
```json
{
    "id": 1,
    "title": "Practice Regularly",
    "description": "Consistent practice is key to language learning. Dedicate some time each day to study and practice."
}
```
**Response Example (404 Not Found):**
```json
{
    "message": "Tip not found."
}
```
## Rate Limiting
To ensure fair usage of this API and prevent abuse, rate limiting has been applied to certain endpoints. Rate limits are defined as follows:
- **Endpoint**: `/random` and `/{id}`
- **Rate Limit Name**: `GlobalRateLimit`
- **Rate Limit Window**: 60 seconds
- **Rate Limit Limit**: 5 requests per window
Exceeding the rate limit will result in a `429 Too Many Requests` response.
## Error Handling
This API follows standard HTTP status codes for error responses. Common error responses include:
- `404 Not Found`: When the requested tip is not found.
- `429 Too Many Requests`: When the rate limit is exceeded.
## Data Model
### TipModel
- `id` (integer): The unique identifier of the tip.
- `title` (string): The title or headline of the tip.
- `description` (string): A detailed description of the language learning tip.
## Rate Limiting
This API uses rate limiting to protect against excessive use. Requests to rate-limited endpoints beyond the allowed limits will result in a `429 Too Many Requests` response.