CREATE TABLE "Events" (
                          "EventId" INTEGER NOT NULL CONSTRAINT "PK_Events" PRIMARY KEY AUTOINCREMENT,
                          "OwnerId" TEXT NOT NULL,
                          "Name" TEXT NOT NULL,
                          "Description" TEXT NOT NULL,
                          "Place" TEXT NOT NULL,
                          "EventDate" TEXT NULL,
                          CONSTRAINT "FK_Events_AspNetUsers_OwnerId" FOREIGN KEY ("OwnerId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Friendship" (
                              "FriendshipId" INTEGER NOT NULL CONSTRAINT "PK_Friendship" PRIMARY KEY AUTOINCREMENT,
                              "FirstUserId" TEXT NOT NULL,
                              "SecondUserId" TEXT NOT NULL,
                              CONSTRAINT "FK_Friendship_AspNetUsers_FirstUserId" FOREIGN KEY ("FirstUserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
                              CONSTRAINT "FK_Friendship_AspNetUsers_SecondUserId" FOREIGN KEY ("SecondUserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Participation" (
                                 "ParticipationId" INTEGER NOT NULL CONSTRAINT "PK_Participation" PRIMARY KEY AUTOINCREMENT,
                                 "ParticipantId" TEXT NOT NULL,
                                 "EventId" INTEGER NOT NULL,
                                 CONSTRAINT "FK_Participation_AspNetUsers_ParticipantId" FOREIGN KEY ("ParticipantId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
                                 CONSTRAINT "FK_Participation_Events_EventId" FOREIGN KEY ("EventId") REFERENCES "Events" ("EventId") ON DELETE CASCADE
);

CREATE INDEX "IX_Events_OwnerId" ON "Events" ("OwnerId");
CREATE INDEX "IX_Friendship_FirstUserId" ON "Friendship" ("FirstUserId");

CREATE INDEX "IX_Friendship_SecondUserId" ON "Friendship" ("SecondUserId");

CREATE INDEX "IX_Participation_ParticipantId" ON "Participation" ("ParticipantId");

CREATE INDEX "IX_Participation_EventId" ON "Participation" ("EventId");
