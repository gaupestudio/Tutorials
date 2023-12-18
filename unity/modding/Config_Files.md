# Add Config Files
[Go back](UnityModding.md)

# Syntax
Syntax `<type> <name> <value>`
`GetString(filePath, valueName);` `str` `str test Hello, world!`
`GetInt(filePath, valueName);` `int` `int test 0`
`GetFloat(filePath, valueName);` `float` `float test 0.0`
`GetVec3(filePath, valueName);` `vec3` `vec3 10 10 10`
`Comment #` hashtag must be first in a new line. A variable cannot have a comment inline.

# Coding
So go to the `Start();` function in `Game` and edit the method.
Change the `Console.WriteLine("Hello, world");` to `Console.WriteLine(ConfigHelper.GetInt("ModData/config.cfg", "test_int"));` and Compile and Save Module.

Now make a folder in the game folder **Not in managed** and call it **ModData**. Create a file inside Modata called **config.cfg** and write `int test_int 1`.

Run the game, and look in the **Player.log** and you should see **1**

**Congratulations you finished Config Files**
[Next](Config_Files.md)