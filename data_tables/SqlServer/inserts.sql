------------------------food_item----------------------------------
--$10 Foods
INSERT INTO food_item (itemName)
VALUES
('Apple'),
('Bread'),
('Orange');

--$15 Foods
INSERT INTO food_item (itemName)
VALUES
('Chicken Wing'),
('Sandwich'),
('Rice'),
('Burrito');

--$30 Foods
INSERT INTO food_item (itemName)
VALUES
('Sushi'),
('Steak'),
('Lasagna'),
('Lobster');

------------------------food_cost----------------------------------

--$10 Foods
INSERT INTO food_cost (itemId, cost)
VALUES
('1', 10),
('2', 10),
('3', 10);

--$15 Foods
INSERT INTO food_cost (itemId, cost)
VALUES
('4', 15),
('5',  15),
('6', 15),
('7', 15);

--$30 Foods
INSERT INTO food_cost (itemId, cost)
VALUES
('8', 30),
('9', 30),
('10', 30),
('11', 30);

------------------------problems----------------------------------
INSERT INTO problem (problem)
VALUES
('5x + 3 = 7x – 1. Find x'),
('5x + 2(x + 7) = 14x – 7. Find x'),
('12t – 10 = 14t + 2. Find t'),

('Given the function f(x) = 6 x + 1, f(2) - f(1) is given by:'),
('−4(−3n − 8) = 10n + 20. Solve for n.'),
('(6k+4)/2 = 2k − 11. Solve for k.'),
('Find the distance between points (-4 , -5) and (-1 , -1).'),
('x − 7y = −11 ; 5x + 2y = −18. Find x.'),
('|-2 x + 2| -3 = -3. Find x');


------------------------problem_payment----------------------------------
INSERT INTO problem_payment (problemId, payment)
VALUES
(1, 5),
(2, 5),
(3, 5),

(4, 10),
(5, 10),
(6, 10),
(7, 15),
(8, 15),
(9, 15);

------------------------problem_answer----------------------------------
INSERT INTO problem_answer (problemId, answer)
VALUES
(1, '2'),
(2, '3'),
(3, '-6'),

(4, '6'),
(5, '-6'),
(6, '-13'),
(7, '5'),
(8,'-4'),
(9, '1');


