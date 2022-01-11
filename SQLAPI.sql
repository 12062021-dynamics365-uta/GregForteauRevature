CREATE Database sweetNsaltyAPI;


CREATE TABLE Users(
UserID INT PRIMARY KEY IDENTITY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL);

CREATE TABLE Flavors(
FlavorID INT PRIMARY KEY IDENTITY,
FlavorName nvarchar(50) NOT NULL);

CREATE TABLE UserTastes(
UserID INT FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
FlavorID INT FOREIGN KEY REFERENCES Flavors(FlavorID) ON DELETE CASCADE);




INSERT INTO Flavors 
VALUES ('Sweet'), ('Salty'), ('SweetNSalty');

INSERT INTO Flavors
VALUES ('Sweet'), ('Salty'), ('SweetNSalty');

INSERT INTO UserTastes (UserID, FlavorID)
VALUES (1, 1);

