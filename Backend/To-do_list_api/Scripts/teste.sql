CREATE TABLE Tast(
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    isComplete BOOLEAN NOT NULL DEFAULT FALSE
);