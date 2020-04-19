# FreeChat
P2P Messenger
## Changelog
- 4/19/2020 - Added PM function / Whisper, as well as userlist and online status. Doubleclick on username in list to send whisper. Added Safe behavior (HTML will no longer render by default and can only do so if the message is flagged for unsafe. In future, want to be able to grant per-user or per-message render functionality)
- 4/18/2020 - Added Multipoint chat, split send and receive, color scheming, reworked entire GUI and flow, fixed duplicate message bugs
- 4/16/2020 - Hammered out chat protocol, Added encryption, test test test
- 4/15/2020 - Initial GUI, bringing STUN in from HolePuncher

## Using this thing - updated 4/18/2020

Click settings to set your identity information
![](./11.png)

Most important here - set your name, set your color (click the Pick Color button) and if you're using a shared secret, set it here. If you need a secret to share, click generate and share the result

![](./12.png)

Click Initialize to get your Endpoint information

![](./13.png)

Send your endpoint to your friend and get theirs then both click "Connect to peer"

![](./14.png)

Enter the endpoint info of your friend and press ok

![](./15.png)

Put text in the bar at the bottom and press enter and enjoy.

![](./16.png)

Want more people in the convo? Give the secret to the third, trade endpoints with the third. The third will get the seconds address in the ping and vice-versa and everyone adds the missing ones to their neighbors and tunnels to them and starts routing messages to all neighbors. As long as one person in the convo trades endpoints with someone and everyone has the same secret, the network meshes out to all participants.
