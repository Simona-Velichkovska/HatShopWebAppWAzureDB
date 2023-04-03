# Hat Shop
## Visit on: [Deployed Page](hatshopwebappwazuredb20230403030551.azurewebsites.net)

## Using ASP.NET CORE 6 and Razor Pages with Azure Cloud  Database. Deployed on Azure Services

### Current capabilities of the Web application
On the front page of the web application we have a list of all available items to the users. The users can then search them, filter through them, sort them, page through them. The users can also clear their search. The user can also click to view all the details of each item. The user can create an account, log in if they have an existing account and log out if they are already logged in. The user can also access the capabilities under the Admin tab (which in reality should be with limited authorization). The Admin tab offers capabilities to add new products into the database, see all the products in the database (without sorting/filtering/searching), he can also delete products and edit them.  

#### Capabilities still needed to implement
+ Authorization - Only Admins can have all the functionality with the database.
+ Users should be able to add an item in the shopping cart
+ Users should be able to make orders

### Additionally
The account creation was implemented with the help of ASP.NET Core Identity and Scaffolding. 





