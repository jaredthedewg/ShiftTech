# VistaFeed

## Setup

### Checkout the solution
Clone the repository

### Setting up the DB
The first thing that needs to be done is setting up a local RavenDB instance on `127.0.0.1:8080/` and create a database called `VistaFeed`. 
There is a super easy tutorial on how to do it: https://ravendb.net/docs/article-page/5.1/csharp/start/getting-started

### The client
Navigate to the ClientApp directory and run an `npm install` to compile the client application

## Sacrifices

The main sacrifice that lives throughout this project is the painful lack of error handling. I tried to code defensively where I could, but it is nowhere near sufficient.

### Client
A lot of the initial client app was just taken from the 'out of the box' .net template, I made a few modifications like upgrading the version of React, adding sass and slightly altering some of the default routing but the design and some of the responsiveness really came from whatever bootstrap came with the project template. Personally, I would have gone with a styled component approach as I just really appreciate that modular approach to development. 
I also didn't manage to get to the sorting and filtering of the historical feeds, but my approach would have been a client implementation likely using lodash or a similar collections library. There was also a small issue with RavenDB document IDs that I had to workaround and the solution isn't very pretty. 

### Server
So the main sacrifice here, or the one that irritates me the most is that this has all been done in a single project. Aside from this, I also hard coded a few configuration items like the DB source and name in the DocumentStoreHolder and the vista feed in the RssService. Due to a lack of experience with XML, I also wrote my own class for processing the data that I got back from the feed, I am sure there are better ways of doing this but I was concerned about time. I also left in the string extension I was using to remove the character data from the XML but I later realised that InnerText automatically removes it... I left a few comments on some of the classes I thought may need a little additional information but other than that, the project isn't very well documented.

## Contact
Please let me know if you run into any issues with the project setup or if there is anything unclear, I am happy to help with it all :)
