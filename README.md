# "Puzzle" 0

## Challenge

- Implement `Pack()` method in `Hotbar` class
>Note: See the Debug.Assert() statements in the DoHotbarPack()


```cs
    /// <summary>
    /// Ensures items start at slot 0 and there are no empty slots between items.
    /// For example, a hot bar like this (pipe symbol '|' is acting as the separator):
    ///     {empty}  |  sword  |  {empty}  |  ring     |  {empty}
    /// will look like this after calling this method:
    ///     sword    |  ring   |  {empty}  |  {empty}  |  {empty}
    /// </summary>
    void Pack();
```

-  (BONUS) Implement `SortByItemType()` method in `Hotbar` class
>Note: See the Debug.Assert() statements in the DoHotbarSortByItemType()

```cs
    /// <summary>
    /// Groups items by ItemType and sorts items within every group alphabetically by Name.
    /// Incidentally, it also packs all the items as if Pack() were called.
    /// For example, a hot bar like this:
    ///     {empty}  |  weapon1  |  ring1  | weapon2 | ring2
    /// will look like this after calling this method:
    ///     weapon1  |  weapon2  |  ring1  |  ring2  | {empty}
    /// </summary>
    void SortByItemType();
```


## What's Provided

### Interfaces
- IItem - Item interface
- Ring Class
- Weapon Class
- IHotbar - Hotbar interface
- Hotbar class

### Suggested Development Environments
#### .NET Fiddle - A quick and easy dev environment in a browser tab

If you want a playground where you can build and run the code all in the browser, here's the fiddle:
https://dotnetfiddle.net/0FoJYc

When you change the code in the fiddle and you click "Share", a new fiddle URL will be generated.

>Note: In the bottom output pane of the fiddle, you should see output similar to this:

```
Stack Trace:
[System.NotImplementedException:
The method or operation is not implemented.]
    at Hotbar.Pack() :line 167
    at Program.DoHotbarPack() :line 211
    at Program.Main() :line 263
```

>Double-clicking on the Hotbar.Pack() :line 167 will take you to the following code, which is where you would need to add your code:

```cs
    public void Pack() {
        /////////////////////////////////////////////////
        // TODO #1
        throw new System.NotImplementedException();
    }

    public void SortByItemType() {
        /////////////////////////////////////////////////
        // TODO #2
        throw new System.NotImplementedException();
    }
```

#### Github
For this project, if you want to use your own dev environment (i.e. Visual Studio) fork this repo:
https://github.com/gamedevandcodingdiscord/puzzle0



### How to Share Your Solution

In the `#puzzle` channel, post the URL to your .NET Fiddle or Github fork.


Thanks for participating!