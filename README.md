# ShiftTech

## Setup

### Checkout the solution
Clone the repository

### Setting up the DB
The first thing that needs to be done is setting up a local RavenDB instance on `127.0.0.1:8080/` and create a database called `ShiftTech`. 
There is a super easy tutorial on how to do it: https://ravendb.net/docs/article-page/5.1/csharp/start/getting-started

### The client
Navigate to the ClientApp directory and run an `npm install` to compile the client application

### Client
A lot of the initial client app was just taken from the 'out of the box' .net template, I made a few modifications like upgrading the version of React, adding sass and slightly altering some of the default routing but the design and some of the responsiveness really came from whatever bootstrap came with the project template. Personally, I would have gone with a styled component approach as I just really appreciate that modular approach to development. 
I also didn't manage to get to the sorting and filtering of the historical feeds, but my approach would have been a client implementation likely using lodash or a similar collections library. There was also a small issue with RavenDB document IDs that I had to workaround and the solution isn't very pretty. 

### Server
So the main sacrifice here, or the one that irritates me the most is that this has all been done in a single project. Aside from this, I also hard coded a few configuration items like the DB source and name in the DocumentStoreHolder

## Contact
Please let me know if you run into any issues with the project setup or if there is anything unclear, I am happy to help with it all :)
