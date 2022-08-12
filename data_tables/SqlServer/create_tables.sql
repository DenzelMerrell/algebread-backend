DROP TABLE  IF EXISTS problem_answer, problem_payment, problem, food_cost, food_item;

CREATE TABLE food_item (
	itemId INT PRIMARY KEY IDENTITY(1,1),
	itemName VARCHAR(50) 
);

CREATE TABLE food_cost (
	costId INT PRIMARY KEY IDENTITY(1,1),
	itemId INT,
	cost INT,
	FOREIGN KEY (itemId) REFERENCES food_item(itemId)
);

CREATE TABLE problem (
	problemId INT PRIMARY KEY IDENTITY(1,1),
	problem VARCHAR(500)
);

CREATE TABLE problem_payment (
	paymentId INT PRIMARY KEY IDENTITY(1,1),
	problemId INT,
	payment INT,
	FOREIGN KEY (problemId) REFERENCES problem(problemId)
);

CREATE TABLE problem_answer (
	answerId INT PRIMARY KEY IDENTITY(1,1),
	problemId INT,
	answer VARCHAR(50),
	FOREIGN KEY (problemId) REFERENCES problem(problemId)
);



