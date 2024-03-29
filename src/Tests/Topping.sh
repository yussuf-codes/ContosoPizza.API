# Delete
curl -X 'DELETE' -v -s http://localhost:5000/api/topping/{id}/

# Get All
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/topping/ | jq

# Get by Id
curl -X 'GET' -H 'accept: application/json' -v -s http://localhost:5000/api/topping/1/ | jq

# Post
curl -X 'POST' -H 'accept: application/json' -H 'Content-Type: application/json' -d '{ "name": "Cheese", "calories": 80 }' -v -s http://localhost:5000/api/topping/ | jq

# Update
curl -X 'PUT' -H 'Content-Type: application/json' -d '{ "id": 3, "name": "Beef", "calories": 70 }' -v -s http://localhost:5000/api/topping/3/
