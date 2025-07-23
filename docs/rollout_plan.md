Messenger -> Servers -> Voice -> Video

# Messenger

- Design ideas:
  - Mobile first design. Consider asking for everyone's models of phones for screen size emulation
  - App opens up to DMs similar to https://www.pinterest.com/pin/250231323043375497/
    - Consider something similar to https://www.pinterest.com/pin/296463587992094641/
  - I also like the idea of using something like this as a landing page as well https://www.pinterest.com/pin/38491771811862999/
  - Consider Camera, Servers, Notifications, Messenger quick nav on bottom of screen for mobile
  - Notifications tab inspiration https://www.pinterest.com/pin/289919294781546571/

- Login should allow specification of an email and a select box for the duration desired for the logon session
  - Enter code passed via email on an input beneath the first login button
  - Handling the email code submission from client should trigger if the account also needs to be created or not

- Text channel and categories
- Store a server default ordering/heirachy of categories
- Allow for user categorization of server defaults
- Last read message for each channel needs to be saved per user to determine where to catch up with a channel

# Voice

- Add node js + media soup docker service for SFU media routing
- Add node js + websockets docker service for signaling
- Vue client uses WebRTC to forward their audio stream to mediasoup

# Video

- Extend voice solution to handle video webrtc streams

# Nomenclature

Message > Thread > Mesh > Chain

One can think of a chain as a discord server.
A chain has meshes which can be thought of as categories
A mesh is really just a logical reordering of a set of threads
A thread contains a chronologically ordered set of messages
