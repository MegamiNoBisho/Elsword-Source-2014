﻿ALTER TABLE [dbo].[GItemEndurance] ADD
CONSTRAINT [FK_GItemEndurance_GItem] FOREIGN KEY ([ItemUID]) REFERENCES [dbo].[GItem] ([ItemUID]) ON DELETE CASCADE ON UPDATE CASCADE

