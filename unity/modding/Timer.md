# Adding a timer
[Go back](UnityModding.md)

[Source Code](data/timer_src.cs)

We need to add a timer, using config files and changing the source code. Now let's have fun, by making mods.

Copy the [Source Code](data/timer_src.cs) and this is what it does!

# What do we need to do
Here are the key changes:

1. **New Variables:**
   - Added two new variables, `private int time;` to store the remaining time, and `private float deltaTime;` to keep track of the time elapsed since the last update.

2. **Initialization in `GetNewFlag()` method:**
   - Initialized `this.time` by retrieving the maximum time from a configuration file using `ConfigHelper.GetInt("ModData/config.cfg", "maxtime");`.
   - Initialized `this.deltaTime` to 0.

3. **Update Method:**
   - Added a new `Update()` method to handle the time limit logic.
   - Incremented `this.deltaTime` with `Time.deltaTime` on each update.
   - If `this.deltaTime` exceeds 1 second, decreased `this.time` by 1 and reset `this.deltaTime` to 0.
   - If `this.time` reaches 0, reset the time and get a new flag.

4. **Displaying Time in UI:**
   - Updated the UI text in both `GetNewFlag()` and `Update()` methods to include the remaining time.

The added time limit adds an extra challenge to the game, where players need to find the flag within a specified time frame. Overall, it's a nice enhancement to your game!

**Congratulations you finished Adding a timer**
[Next](Chazzvader_Helpers.md)