CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY, 
	Name VARCHAR(255) NOT NULL
);

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(255) NOT NULL
);

CREATE TABLE ProductsCategories
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY(ProductId, CategoryId)
);

INSERT INTO Products VALUES('Product1'), ('Product2'), ('Product3');
INSERT INTO Categories VALUES('Category1'), ('Category2');
INSERT INTO ProductsCategories VALUES(1, 1), (1, 2), (3, 2);

SELECT Products.Name, Categories.Name FROM Products
LEFT JOIN ProductsCategories AS ProdCat ON Products.id = ProdCat.ProductId
LEFT JOIN Categories ON Categories.Id = ProdCat.CategoryId;