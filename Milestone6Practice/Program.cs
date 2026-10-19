// Milestone 6 - ASP.NET Core Basics

// Lesson 1 - create and run your first ASP.NET Core server

// prepare/configure the ASP.NET Core application

using System.ComponentModel;
using Microsoft.AspNetCore.SignalR;
using Milestone6Practice;

var builder = WebApplication.CreateBuilder(args);

// okay, take the configuration we prepared and build the actual web application
var app = builder.Build();

// if a client sends a GET request to /, respond with "Hello world"
app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "hello from ASP.NET Core!");





// Console app: start -> run code -> finish
// ASP.NET server: start -> listen -> request -> response -> keep listening




// lesson 2 - route parameters and query parameters in actual ASP.NET Core
// this is where we start turning milestone 5 into real code

// 1. Route parameters
// app.MapGet("/products/{id}", (int id) =>
// {
//     return $"You asked for product {id}";
// });

// lambda, as in number => number * 2
// means a function that receives number
// same idea for (int) =>  {}
// means: a function that receives an int called id


// 3. Multiple Route parameters
// app.MapGet("/users/{userId}/orders/{orderId}",
//     (int userId, int orderId) =>
//     {
//         return $"User: {userId}, Order: {orderId}";
//     });

// 4. query parameters


// app.MapGet("/products", (string category) =>
// {
//     return $"Category: {category}";
//
// });

// then 
// /products?category=Electronics
// gives category = "Electronics";


// 5. Multiple query parameters
app.MapGet("/search", (string category, decimal minPrice) =>
{
    return $"Category: {category}, Minimum price: {minPrice}";
});
// request:
// /search?category=Electronics&minPrice=500
// becomes category = "Electronics"; minPrice = 500

// Question??? so what we are diong in here is, i mean i m not sure how query parameters are working here
// because we were actually writing them in the url no? like as in search: 
// /search?category=.....
// but we are doing something else, i am confused, this question goes to the code above as well, where we 
// did the same with string category, which i didn't really understand, i mean, was it something else???
// help???
// answered !!!!! _------_
// the client (browser) still writes the query parameter in the url
// the c# code does not create that query parameter
// the code says:
// if a request contains a query value called category, give it to me in this variable



// 6. Optional query parameters
// if filtering is optional, use nullable



// 7. route parameter + query parameter together
// we can combine them
// GET /products/5?includeReviews=true

app.MapGet("/prodcuts/{id}", (int id, bool includeReviews) =>
{
    return $"Product: {id}, Include Reviews: {includeReviews}";
});
// in here:
// id comes from route
// includeReviews comes from query string



// 8. Why doesn't ASP.NET get confused?
// because the route tells it where some values come from

// Practice
app.MapGet("/hello/{name}", (string name) =>
{
    return $"hello {name}!";
});


app.MapGet("/square/{number}", (int number) =>
{
    return number * number;
});


// app.MapGet("/products", (string? category) =>
// {
//     if (category is null)
//     {
//         return $"showing All products";
//     }
//     return $"Filtering by category: {category}";
// });


app.MapGet("/search", (string text, int limit) =>
{
    return $"Name: {text}; limit: {limit}";
});


app.MapGet("/users/{userId}/orders/{orderId}", (int userId, int orderId) =>
{
    return $"user - {userId}, Order - {orderId}";
});


// Lesson 3: Request bodies + POST + JSON in ASP.NET Core

List<Product> products = new();

// app.MapPost("/products", (Product product) =>
// {
//     products.Add(product);
//     return product;
// });

// app.MapGet("/products", () =>
// {
//     return products;
// });

// so now:
// POST /products -> add product 
// GET /products -> return all products
// question???? do tell me like which quesiton you are answering to so thta i coul dfind it in the comments
// so what we now just did is: we have used the requests.http to create a new product
// and we used mapget to get the same products we have created???
// answered !!!!! -------####
// exactly
// when we run POST from requests.http
// it sends HTTP POST + JSON -> ASP.NET converts JSON into Product
// products.add(product)




// ASP.NET does:
// JSON body -> deserialize -> Product object

// deserialize means:
// JSON -> C# object
// json object basically becomes Product object

// the reverse is called serialization
// so when we return product; ASP.NET can convert the C# object back into JSON



// Practice:

// app.MapPost("/products", (Product product) =>
// {
//     if (string.IsNullOrWhiteSpace(product.Name))
//     {
//         return Results.BadRequest("Name cannot be empty");
//     }
//
//     if (product.Price < 0)
//     {
//         return Results.BadRequest("Price cannot be negative");
//     }
//     products.Add(product);
//
//     return Results.Created(
//         $"/products/{product.Id}", 
//         product
//         );
//     // Results.Created(location, value) 
//     // roughly means: 201 crated; location /products/3 <created object>
//     // return product;
// });



// app.MapGet("/products", () =>
// {
//     return Results.Ok(products);
// });



// app.MapGet("/products/{id}", (int id) =>
// {
//     Product? product = products.FirstOrDefault(product => product.Id == id);
//     if (product is null)
//     {
//         return Results.NotFound();
//     }
//
//     return Results.Ok(product); // means status 200 Ok, body = product
//     // now if exists:
//     // we get 200 Ok and JSON body
//     // if not:
//     // 404 not found
// });



// delete endpoint
// app.MapDelete("/products/{id}", (int id) =>
// {
//     Product? product = products.FirstOrDefault(product => product.Id == id);
//
//     if (product is null)
//     {
//         return Results.NotFound();
//     }
//
//     products.Remove(product);
//     return Results.NoContent();
//     // now 
//     // DELETE /products/2
//     
//     // if product 2 exists: 204 no content
//     // meaning it worked, and i don't need to send a response body
//     // it doesn't exist:
//     // 404 not found
// });







// Lesson 4 - Returning proper HTTP status codes in ASP.NET Core
// we want the API to explicit use status codes
// The Result class

// instead of return product;
// we can use return Results.Ok(product);


app.MapPost("/products", (Product product) =>
{
    if (string.IsNullOrWhiteSpace(product.Name))
    {
        return Results.BadRequest("Name cannot be empty");
    }

    if (product.Price < 0)
    {
        return Results.BadRequest("Price cannot be negative");
    }

    products.Add(product);

    return Results.Created($"/products/{product.Id}", product);

});




app.MapGet("/products", () =>
{
    return Results.Ok(products);
});


app.MapGet("/products/{id}", (int id) =>
{
    Product? product = products.FirstOrDefault(product => product.Id == id);

    if (product is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
});



app.MapDelete("/products/{id}", (int id) =>
{
    Product? product = products.FirstOrDefault(product => product.Id == id);

    if (product is null)
    {
        return Results.NotFound();
    }

    products.Remove(product);
    return Results.NoContent();
});


// this starts the server and keeps it running, waiting for HTTP requests
app.Run();