﻿ALTER TABLE [dbo].[EPGAEventPerfectItem] ADD CONSTRAINT [PKC_EPGAEventPerfectItem_EventUID_Type_ItemID] PRIMARY KEY CLUSTERED  ([EventUID], [Type], [ItemID]) WITH FILLFACTOR=80 ON [PRIMARY]

