# RetailApp.WebApi

#### "A WebAPI to implement retail functionality"

On this retail application, the following discounts would apply: 
1. If the user is an employee of the store, he gets a 30% discount 
2. If the user is an affiliate of the store, he gets a 10% discount 
3. If the user has been a customer for over 2 years, he gets a 5% discount. 
4. For every $100 on the bill, there would be a $ 5 discount (e.g. for $ 990, you get $ 45 as a discount). 
5. The percentage based discounts do not apply on groceries. 
6. A user can get only one of the percentage based discounts on a bill. 

This WebAPI has the following components:
1. **RetailApp.Common** (Common functionality i.e interfaces, logging)
2. **RetailApp.BusinessLogic** (Implementation of business related things)
3. **RetailApp.Tests** (Testing project)
4. **RetailApp.WebApi** (Main API project)

## Getting Started with RetailApp.Common

This project contains all the following generic components used for retail application --

1. **Enum** - contains the enums for UserTypes and Product Types
2. **Interfaces** - all the interfaces related to product, user, order and discount is present there
3. **Logging**  - all the interfaces related to logging is there
4. **Models** - for user, order and product related models are present there
5. **View-Model** - model which contains the relevant fields which needs to be shown in the output

## Getting Started with RetailApp.BusinessLogic

This project contains all the following implementation components used for retail application --

1. **Discount** - contains all the implementation related to discounts for different users
2. **Factory** - contains the Incoker class (part of Command patterns) which decides the Discount object based on the user-type
3. **Filters**  - exception filter is being written there
4. **Logging** - Log4net implementation is been written
5. **Order** - Order processing is been implemented there where the method return the updated amount of the order after discount
6. **Product** - Product processing is been implemented there where the method return the updated amount of the product after discount
7. **User** - User processing is been implemented there where the method return the updated amounts of all the orders of user after discount

## Getting Started with RetailApp.Tests

This project contains all the following testing components used for retail application --

1. **Factory** - contains the test cases for the discount invoker
2. **Filter** - contains the test cases for the user-defined exception filter
3. **Implementation**  - contains the test cases for all the processers be it user, product and order

## Getting Started with RetailApp.WebAPI

This project contains the following end-point used for retail application --

**User/GetInvoice** - Returns the orders related to the particular user with updated invoice amount after all types of applicable discounts.



## Execute the application

To execute this WebAPI, we need to do the following steps --
1. Host the application into the IIS server/ run the application using Visual Studio
2. Install postman/ any rest-client to send a request to the WebAPI
3. Create the POST request to the WebAPI using postman with the following end-point - `http://{servername}:{port-number}/User/GetInvoice` for e.g. http://localhost:61290/User/GetInvoice
4. Incorporate the JSON body as a input containing the user and order details to get the updated invoice amount after all applicable discounts -
        ``{
        "Id": 1,
        "Name": "Gourav",
        "Type": 0,
        "AssociationYears": 1,
        "Orders": [
            {
                "Id":1,
                "Name":"Order-1",
                "DiscountedPrice": 0,
                "Products": [
                    {
                        "Quantity": 1,
                        "Id": 1,
                        "Name": "Item-1",
                        "Cost": 50,
                        "Type": 1
                    },
                    {
                        "Quantity": 2,
                        "Id": 2,
                        "Name": "Item-2",
                        "Cost": 100,
                        "Type": 1
                    },
                    {
                        "Quantity": 2,
                        "Id": 3,
                        "Name": "Item-3",
                        "Cost": 200,
                        "Type": 1
                    }
                ]
            }
        ]
    }``
5. Then send the request and see the JSON output with the updated invoice amount -

   `` [
        {
            "InvoiceId": 1,
            "InvoiceName": "Order-1",
            "InvoiceAmount": 435
        }
    ]``
