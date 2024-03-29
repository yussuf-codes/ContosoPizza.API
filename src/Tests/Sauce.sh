# Delete
curl -X 'DELETE' -v -s http://localhost:5000/api/sauce/{id}/

# Get All
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/sauce/ | jq

# Get by Id
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/sauce/1/ | jq

# Post
curl -X 'POST' -H 'accept: application/json' -H 'Content-Type: application/json' -d '{ "name": "Barbecue", "isVegan": true }' -v -s http://localhost:5000/api/sauce/ | jq

# Update
curl -X 'PUT' -H 'Content-Type: application/json' -d '{ "id": 3, "name": "Barbecue", "isVegan": false }' -v -s http://localhost:5000/api/sauce/3/
