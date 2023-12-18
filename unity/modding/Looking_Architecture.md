# Looking at the architecture
[Go back](UnityModding.md)
## Open Dnspy
Let's look at the code using Dnspy.
Open Dnspy, then click **File->Open**, and then find the game. We need to find the Assembly-CSharp.dll, wich contains the code. That is located at **FlagGame_Data/Managed/Assembly-CSharp.dll**.
## Finding the Game Code
In dnspy find **Assembly-CSharp.dll** open that, and the other one. Then open **{}**, there is the Game class if you open that you see the game code.
This is a very simple game. See if you can understand the code, and how it works.
- `GetNewFlag()` Sets the field `flag` to a random flag in the `GameObject[] flagObjects`. When `OnClick()` is trigged by clicking on a flag, it checks if it's the right flag. And gives 1 in `score`.

- If you want to do this on your own game, you can try.

**Congratulations you finished Looking at the architecture**
[Next](Hello_World.md)