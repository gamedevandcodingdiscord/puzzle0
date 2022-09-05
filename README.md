# puzzle0

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

### .NET Fiddle
If you want a playground where you can build and run the code all in the browser, here's the fiddle:
https://dotnetfiddle.net/WVDPV8

>Note: When you change the code in the fiddle and you click "Share", then you'll get a new fiddle that is different from the WVDPV8 one above.

### Github Project
For this project if you want to use your own dev environment (i.e. Visual Studio), fork this repo:
https://github.com/gamedevandcodingdiscord/puzzle0



### How to Share Your Solution

In the `#puzzle` channel, post your URL to the .NET Fiddle or github fork.