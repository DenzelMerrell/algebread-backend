DROP TABLE  IF EXISTS problem_answer, problem_payment, problem, food_cost, food_item;

CREATE TABLE food_item (
	itemId SERIAL PRIMARY KEY,
	itemName VARCHAR(50) 
);

CREATE TABLE food_cost (
	costId SERIAL PRIMARY KEY,
	itemId INT,
	cost INT,
	FOREIGN KEY (itemId) REFERENCES food_item(itemId)
);

CREATE TABLE problem (
	problemId SERIAL PRIMARY KEY,
	problem VARCHAR(500)
);

CREATE TABLE problem_payment (
	paymentId SERIAL PRIMARY KEY,
	problemId INT,
	payment INT,
	FOREIGN KEY (problemId) REFERENCES problem(problemId)
);

CREATE TABLE problem_answer (
	answerId SERIAL PRIMARY KEY,
	problemId INT,
	answer VARCHAR(50),
	FOREIGN KEY (problemId) REFERENCES problem(problemId)
);



