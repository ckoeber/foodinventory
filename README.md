# Food Inventory

##Introduction
The Food Inventory web application tracks an inventory of products for a store. You may view a listing of products for the store as well as perform CRUD operations for said products.

##Setup Instructions

###Minimum Requirements
This project was created with Microsoft Visual Studio 2015; the project has also been tested to run in Micrsoft Visual Studio 2013.

###Database
The SQL schema for this project is located in **DatabaseSchema.sql**. Use either an instance of Microsoft SQL Server or Microsoft SQL Server Express and update the appropriate configuration files (web.config within the Web Project) once the database has been set up for use on your system.

###Project
The primary solution file is FoodInventory.sln; all necessary component for running the solution is either within the solution itself or automatically made available via nuget packages by performing a restore.

##Instructions for Activity Completion
Complete **one (1)** of the following activities by the given deadline communicated to you via a separate message.

### Activity One - Import and Export

#### User Story
As a user of the Food Inventory Application I would like to import and export the listing of food into a Microsoft Excel file so that I can utilize Microsoft Excel for reporting purposes.

#### Acceptance Criteria
1. All rows in the imported Microsoft Excel file must be validated to meet the requirements for input into the database.
2. The application must inform the user if there are missing columns in the imported Microsoft Excel file and how many rows, if any, are invalid should there be invalid data.
3. The application must display to the user a message informing the user that the data from the Microsoft Excel file has been imported successfully and refresh the display of data within the web page upon successful import.
4. The application must allow exporting of the data into a compatable Microsoft Excel file with all rows **except** for the DeletedDate column.

### Activity Two - Attach Pictures to Products

#### User Story
As a user of the Food Inventory Application I would like to attach **one (1) or more** pictures to each product within the application so that users of the application can get a visual representation of each product currently available in the application.

#### Acceptance Criteria
1. The application should only allow users to attach JPEG and PNG image files to each product.
2. The application should only accept file sizes of up  to 500KB in size.
3. The user should be informed of this limitation and be prevented from uploading the file should said criteria not be met.
4. Each product/item listed should be allowed to have one or more pictures attached to them.
5. The user should be able to view the pictures associated with each product within the application.

### Activity Three - Track Sales of Products

#### User Story
As a user of the Food Inventory Application I would like to track the sales of each product so that I can know when the sale has taken place and how much of any given product I have left in my inventory.

#### Acceptance Criteria
1. The application must track the following aspects of any given sale of a product:
  1. Date and time of sale
  2. Product Purchased
  3. Amount of units of the product purchased
  4. Discount in dollars, if any
  5. Type of payment
    * Credit
    * Debit
    * Cash
    * Check
2. When a sale is made, the amount of items purchased should be deducted from the current inventory of the product.
3. Sales should be made available in a separate section of the application via a report by which all columns are sortable.
4. Sales should be searchable by date or the type of product purchased.
5. If the amount of units of said product is zero (0) or the user is attempting to enter in a sale by which the amount purchased is more than what the store currently has then the sale should be rejected.
