CREATE TABLE Hobbies
(
	Id INT,
	Name VARCHAR(255),
	CONSTRAINT HOBBIES_ID_PK PRIMARY KEY(Id)
);

CREATE TABLE Users
(
	Id INT IDENTITY,
	Name VARCHAR(200) NOT NULL,
	Password VARCHAR(32) NOT NULL,
	PhoneNumber VARCHAR(20),
	CONSTRAINT USERS_ID_PK PRIMARY KEY (ID)
);

CREATE TABLE Hobbies_Users
(
	UserId INT, 
	HobbieId INT, 
	CONSTRAINT FK_USER_ID FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_HOBBIES_ID FOREIGN KEY (HobbieId) REFERENCES Hobbies(Id)
);