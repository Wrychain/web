# Scope: Wrychain.DAL.Entity.Categories
> **File:** Category.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Categories/Category.cs

**References:** ['Wrychain.DAL.Entity.Categories.CategoryChannel', 'Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Users.User']

> **File:** CategoryChannel.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Categories/CategoryChannel.cs

**References:** ['Wrychain.DAL.Entity.Categories.Category', 'Wrychain.DAL.Entity.Channels.Channel']

# Scope: Wrychain.DAL.Entity.Channels
> **File:** Channel.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Channels/Channel.cs

**References:** ['Wrychain.DAL.Entity.Channels.Progress', 'Wrychain.DAL.Entity.Channels.ChannelWriter', 'Wrychain.DAL.Entity.Channels.ChannelReader', 'Wrychain.DAL.Entity.Users.User', 'Wrychain.DAL.Entity.Channels.Presence']

> **File:** ChannelReader.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Channels/ChannelReader.cs

**References:** ['Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Channels.Channel', 'Wrychain.DAL.Entity.Users.User']

> **File:** ChannelWriter.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Channels/ChannelWriter.cs

**References:** ['Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Channels.Channel', 'Wrychain.DAL.Entity.Users.User']

> **File:** Presence.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Channels/Presence.cs

**References:** ['Wrychain.DAL.Entity.Channels.Channel', 'Wrychain.DAL.Entity.Users.User']

> **File:** Progress.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Channels/Progress.cs

**References:** ['Wrychain.DAL.Entity.Messages.Message', 'Wrychain.DAL.Entity.Users.User', 'Wrychain.DAL.Entity.Channels.Channel']

# Scope: Wrychain.DAL.Entity.Files
> **File:** FilePointer.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Files/FilePointer.cs

**References:** []

# Scope: Wrychain.DAL.Entity.Invites
> **File:** ChannelInvite.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Invites/ChannelInvite.cs

**References:** ['Wrychain.DAL.Entity.Channels.Channel', 'Wrychain.DAL.Entity.Users.User']

> **File:** FriendInvite.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Invites/FriendInvite.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

> **File:** PlatformInvite.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Invites/PlatformInvite.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

> **File:** StationInvite.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Invites/StationInvite.cs

**References:** ['Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Users.User']

# Scope: Wrychain.DAL.Entity.Messages
> **File:** Attachment.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Messages/Attachment.cs

**References:** ['Wrychain.DAL.Entity.Files.FilePointer', 'Wrychain.DAL.Entity.Messages.Message', 'Wrychain.DAL.Entity.Users.User']

> **File:** Message.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Messages/Message.cs

**References:** ['Wrychain.DAL.Entity.Messages.Receipt', 'Wrychain.DAL.Entity.Users.User', 'Wrychain.DAL.Entity.Messages.Attachment', 'Wrychain.DAL.Entity.Messages.Reaction']

> **File:** Reaction.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Messages/Reaction.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

> **File:** Receipt.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Messages/Receipt.cs

**References:** ['Wrychain.DAL.Entity.Messages.Message', 'Wrychain.DAL.Entity.Users.User']

# Scope: Wrychain.DAL.Entity.Stations
> **File:** Station.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Stations/Station.cs

**References:** ['Wrychain.DAL.Entity.Stations.StationChannel', 'Wrychain.DAL.Entity.Invites.StationInvite', 'Wrychain.DAL.Entity.Stations.StationUserSetting', 'Wrychain.DAL.Entity.Users.User', 'Wrychain.DAL.Entity.Stations.StationDefaultCategory', 'Wrychain.DAL.Entity.Stations.StationUserCategory']

> **File:** StationChannel.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Stations/StationChannel.cs

**References:** ['Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Channels.Channel']

> **File:** StationDefaultCategory.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Stations/StationDefaultCategory.cs

**References:** ['Wrychain.DAL.Entity.Categories.Category', 'Wrychain.DAL.Entity.Stations.Station']

> **File:** StationUserCategory.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Stations/StationUserCategory.cs

**References:** ['Wrychain.DAL.Entity.Categories.Category', 'Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Users.User']

> **File:** StationUserSetting.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Stations/StationUserSetting.cs

**References:** ['Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Users.User']

# Scope: Wrychain.DAL.Entity.Users
> **File:** LoginAttempt.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/LoginAttempt.cs

**References:** []

> **File:** LoginSession.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/LoginSession.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

> **File:** Notification.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/Notification.cs

**References:** ['Wrychain.DAL.Entity.Files.FilePointer', 'Wrychain.DAL.Entity.Users.User']

> **File:** User.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/User.cs

**References:** ['Wrychain.DAL.Entity.Users.LoginSession', 'Wrychain.DAL.Entity.Users.LoginAttempt', 'Wrychain.DAL.Entity.Users.Notification', 'Wrychain.DAL.Entity.Users.UserConnection', 'Wrychain.DAL.Entity.Files.FilePointer', 'Wrychain.DAL.Entity.Users.UserVAPID', 'Wrychain.DAL.Entity.Stations.Station', 'Wrychain.DAL.Entity.Channels.Channel']

> **File:** UserConnection.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/UserConnection.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

> **File:** UserVAPID.cs

**Path:** /wrychain/backend/Wrychain.DAL/Entity/Users/UserVAPID.cs

**References:** ['Wrychain.DAL.Entity.Users.User']

