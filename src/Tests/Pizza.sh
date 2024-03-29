# Delete
curl -X 'DELETE' -v -s http://localhost:5000/api/pizza/{id}/

# Get All
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/pizza/ | jq

# Get by Id
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/pizza/1/ | jq

# Post
curl -X 'POST' -H 'accept: application/json' -H 'Content-Type: application/json' -d '{ "name": "Margherita", "isGlutenFree": false, "sauceId": 3, "toppingsId": [ 4, 5 ] }' -v -s http://localhost:5000/api/pizza/ | jq

# Update
curl -X 'PUT' -H 'Content-Type: application/json' -d '{ "id": 4, "name": "Margherita", "isGlutenFree": false, "sauceId": 1, "toppingsId": [ 5, 6 ] }' -v -s http://localhost:5000/api/pizza/4/
