Console.WriteLine("Hello, World!");

// Milestone 5 - Web Fundamentals


// Lesson 1 - Client, Server, Request, Response
// the basic web model is: 
// client (request) -> Server <- (response) Client

// web server:
// start -> begin listening -> wait for requests -> request arrives -> handle request -> send response -> keep listening
// it may stay running for days or months

// What is HTTP?
// HTTP defines how a client asks for something from a server and how the server responds


// Request
// an HTTP request can contain several things
// conceptually
// Method
// URL / route
// Headers
// body


// Response
// the server responds with things such as:
// status code
// headers
// body


// Request
// = 
// client -> server

// Response
// =
// server -> client


// Where does ASP.NET Core fit?
// Client -> HTTP request -> ASP.NET Core -> C# code -> HTTP response -> client

// client
//     = something that sends a request
// e.g. browser, mobile app, frontend, another backend
//
//     server
//         = a program that waits for requests,
// processes them, and sends responses
//
//     request
//         = what the client sends to the server
// asking it to do/get something
//
//     response
//         = what the server sends back
// after processing the request
//
//     HTTP
//         = the rules/protocol clients and servers use
// to communicate on the web


// Lesson 2 - HTTP methods - GET, POST, PUT, PATCH, DELETE

// these methods tell the server what kind of action the client wants to perform
// get -> read
// post -> create
// put -> replace/update
// patch -> partially update
// delete -> delete

// get
// is used when the client wants to retrieve data

// post
// use post when the client wants to create something new


// put
// use put when the client wants to replace/update an existing resource, usually with a full representation


// patch.
// patch is similar to put, but it's usually for changing only part of something
// meaning: do not replace the whole product, just change this field

// delete
// use delete when you want to remove something

// CRUD
// create; read; update; delete



// Lesson 3 - URLs, routes, route parameters, query parameters, and request bodies
// these are all about how the client tell  the server what it wants

// 1. URL
// it is the address used to reach something on the web
// https://example.com/products/5
// https://example.com -> server/domain
// /products/5 -> path/route


// 2. Route
// a route is the path the backend listens to


// 3. Route parameters


// 4. Query parameters
// they usually come with ?
// ex:
// GET /products?/category=Electronics

// category=Electronics
// is a query parameter
// meaning:
// get products where category is Electronics


// Route parameters vs query parameters

// route param usually identifies a specific resource 
// (which product? -> ID 5)

// Query param usually changes/filters/sorts the result
// (which products match these conditions?)

// a useful rule:

// route param:
// -> identify something

// query param
// -> filter/search/sort/optional settings


// 5. Request body
// the request body is data sent inside the request
// the route says get/create a product
// the body says here's the product data


// route -> what operation/resource?
// body -> what data?


// put everything together
// example:
// GET /products/5

// breakdown:
// GET          -> HTTP method
// /products/5  -> route
// 5            -> route parameter


// ex
// GET /products?category=Electronics&sort=price

// breakdown
// GET
// /products
// category=Electronics
// sort=price


// Tiny check
// Tell me what each one is in:
// GET /products/12?includeReviews=true


// Specifically:
// HTTP method = get
//     route = /products/12
//         route parameter = 12
//     query parameter = includeReview=true
//
//     Then for:
//     POST /products
//
// with:
// {
//     "name": "Mouse",
//     "price": 40
// }
//
// tell me what the request body is.


// post is HTTP method
// name:mouse, price: 40 is the body of the route/request


// Lesson 4: HTTP status codes
// a status code is the server's short way of saying what happened with the request
// groups

// 2xx -> success
// 4xx -> client-side problem
// 5xx -> server-side problem


// 200 → success
// 201 → created
// 204 → success, no response body
// 400 → bad client input
// 401 → not authenticated
// 403 → authenticated but not allowed
// 404 → resource not found
// 500 → unexpected server error| `500` | Server error | Unexpected backend failure |


// Lesson 5 - Headers, JSON, and Content-Type

// 1. Headers
// HTTP headers are extra metadata sent with a request or response
// (extra information about the request/response)

// common headers:
// content-type
// authorization
// accept

// headers = extra information about the HTTP message


// 2. JSON
// It is a text format commonly used to send structured data between client and server.

// C# object -> JSON -> sent over HTTP
// JSON request -> ASP.NET Core -> C# object


// 3. Content-Type
// this h header tells the receiver:
// what format is the body in?
// for JSON:
// Content-Type: application/json



// 4. Accept
// another header:
// Accept: application/json
// this means:
// i would like the response in JSON format

// Content-Type describes the body we are sending
// Accept describes what response format we want


// 5. Authorization header

// Authorization: Bearer <token>
// this is how a client can send authentication information to the server


// 6. Example full request
// conceptually:
// ------------
// POST /products
// Content-Type: application/json
// Authorization: Bearer abc123

// {
// "name": "Keyboard",
// "price": 80
// }
// ------------

// breakdown:
// POST -> http method
// /products -> route
// Content-Type: application/json -> body is JSON
// Authorization: Bearer abc123 -> authentication information
// JSON object -> request body


// server might respond:
// 201 created
// content-type: application/json
// <request body>



// POST /todos
// Content-Type: application/json
//
// {
//     "title": "Learn ASP.NET",
//     "isCompleted": false
// }

// HTTP method = post (create)
// route = /todos
// header = / content-type: application/json
// body format = JSON
// body = // {
        // //     "title": "Learn ASP.NET",
        // //     "isCompleted": false
        // // }





// Lesson 6 - API, REST, and RESTful API design

// What is an API?
// API - Application Programming Interface

// an api is a defined way for one piece of software to communicate with another

// ex:
// frontend -> GET /products -> backend api -> returns products
// the frontend does not need to know how the backend stores the products
// it just needs to know:
// "If I send GET /products,
// I get products back."

// that interface between them is the API



// why do we need an API?
// a browser or mobile app cannot directly call c# methods
// instead we expose them through HTTP:
// get, post, delete

// so, the api acts like a bridge
// client (HTTP) -> API -> c# logic -> database


// WHAT IS REST?

// REST - representational state transfer
// rest is a style for designing web APIs around resources and HTTP

// a resource is basically the thing the API manages
// examples: products, todos, users, orders, books
// rest usually prefers/designs routes around the resources


// instead of /getProducts; /createProduct; /updateProduct; /deleteProduct
// we do:
// GET /products; POST /products; PUT /products/5; DELETE /products/5

// /products stays the resource




// collections vs single resource

// collection:
// /products -> returns all products
// means: products as a group

// specific resource:
// /products/5 -> returns one product
// means: one product, ID 5



// A RESTful Todo API

// resource - todos
// rest-style api could look like:
// get /todos - get all todos
// get /todos/5 - get one todo



// REST is not a programming language or framework
// rest is a design style
// we can build rest apis using any other frameworks

// ASP.NET Core
// = framework

// REST
// = API design style



// WHAT DOES RESTful mean?
// this is a restful api means:
// the api follows REST-style conventions reasonably well


// REST is a set of conventions and principles 



// the main mental model

// API = way for a software to communicate

// Web API = API communicated over HTTP

// REST = style for designing web APIs around resources

// RESTful API = API that follows rest-style conventions


// resource = noun in the URL
// action = HTTP method




// Mixed Practice


// Method:
// Route:
// Route parameter:
// Query parameter:
// Body:
// Success status:
// Possible error status:


// Use this imaginary resource:
// products
//
// A product has:
// Id
// Name
// Category
// Price
// Stock


// 1. Get all products.
// Method: GET 
// Route: /products
// Route parameter: NA
// Query parameter: NA
// Body: NA
// Success status: 200
// Possible error status: 400, 401

// 2. Get product with ID 7.
// Method: GET 
// Route: /products/7
// Route parameter: 7
// Query parameter: NA
// Body: NA
// Success status: 200
// Possible error status: 404, 500


// 3. Get all products in category "Electronics".
// Method: GET 
// Route: /products
// Route parameter: NA
// Query parameter: ?category=Electronics
// Body: NA
// Success status: 200
// Possible error status: 400, 401, 403, 404, 500


// 4. Get all products costing at least 500.
// Method: GET 
// Route: /products
// Route parameter: NA
// Query parameter: ?minPrice=500 // !£!£!£!£!£££!£!£!*****))))))(((((((
// Body: NA
// Success status: 200
// Possible error status: 400, 401, 403, 404, 500



// 5. Create a new product:
// - Name: "Monitor"
// - Category: "Electronics"
// - Price: 400
// - Stock: 6

// Method: POST
// Route: /products
// Route parameter: NA
// Query parameter: NA
// Body: { name: monitor, category: electronics, price: 400, stock:6}
// Success status: 201 created
// Possible error status: 400, 500


// 6. Fully update product 7.
// Method: PUT
// Route: /products/7
// Route parameter: 7
// Query parameter: NA
// Body: {updated data}
// Success status: 200, 204
// Possible error status: 400, 401, 403, 404, 500



// 7. Change only the stock of product 7 to 12.
// Method: PATCH
// Route: /products/7
// Route parameter: 7
// Query parameter: NA
// Body: {stock: 12}
// Success status: 200, 204
// Possible error status: 400, 401, 403, 404, 500



// 8. Delete product 7.
// Method: DELETE 
// Route: /products/7
// Route parameter: 7
// Query parameter: NA
// Body: NA
// Success status: 200, 204
// Possible error status: 400, 401, 403, 404, 500


// 9. Try to get product 999, but it doesn't exist.
// Method: GET
// Route: /products/999
// Route parameter: 999
// Query parameter: NA
// Body: NA
// Success status: NA
// Expected response: 404 Not found
// Possible error status: 400, 401, 403, 404, 500


// 10. Send a create-product request with an empty name and negative price.
// Method: POST 
// Route: /products
// Route parameter: NA
// Query parameter: NA
// Body: {name:"", price:-500}
// Success status: NA
// Expected response: 400 bad request
// Possible error status: 400, 401, 403, 404, 500

