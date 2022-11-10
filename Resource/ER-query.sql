use trace_solutions_database
go

CREATE TABLE Users (
    UserID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
	Email varchar(255),
	Password varchar(255),
    PRIMARY KEY (UserID)
);

CREATE TABLE Products (
     ProductID int NOT NULL,
	 ProductName varchar(255) NOT NULL,
     OrderNumber int NOT NULL,
     OrderID int,
     PRIMARY KEY (ProductID),
   	
);
CREATE TABLE Additions (
     AdditionID int NOT NULL,
	 AdditionName varchar(255),
	 Strength varchar(255),
     OrderNumber int NOT NULL,
     PRIMARY KEY (AdditionID),
   );


CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    UserID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
);
CREATE TABLE Product_Orders (
    ProductOrderID int NOT NULL,
    ProductID int,
	Quantity int NOT NULL, 
	OrderID int,
    PRIMARY KEY (ProductOrderID ),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
);
CREATE TABLE Addition_Orders (
    AdditionOrderID int NOT NULL,
    AdditionID int,
	Quantity int NOT NULL, 
	OrderID int,
    PRIMARY KEY (AdditionOrderID ),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (AdditionID) REFERENCES Additions(AdditionID)
);

CREATE TABLE ShoppingCarts (
     ShoppingCartID int NOT NULL,
     OrderNumber int NOT NULL,
	 TotalItems int,
	 ShoppingDate Date,
     ProductOrderID int,
	 AdditionOrderID int,
	 UserID int,
	 PRIMARY KEY (ShoppingCartID),
   	 FOREIGN KEY (ProductOrderID) REFERENCES Product_Orders(ProductOrderID),
	 FOREIGN KEY (UserID) REFERENCES Users(UserID),
	 FOREIGN KEY (AdditionOrderID) REFERENCES Addition_Orders(AdditionOrderID)
);

