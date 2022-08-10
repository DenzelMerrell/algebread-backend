SELECT * FROM food_item;
SELECT * FROM food_cost;
SELECT * FROM problem;
SELECT * FROM problem_answer;
SELECT * FROM problem_payment;


SELECT problem, answer, payment FROM problem 
JOIN problem_payment ON problem.problemId = problem_payment.problemId
JOIN problem_answer ON problem.problemId = problem_answer.problemId;