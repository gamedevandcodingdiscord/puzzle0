using System;
using System.Collections.Generic;
using System.Diagnostics;

public enum ItemType {
    Weapon,
    Ring,
}

public interface IItem {
    int Id { get; }
    string Name    { get; }
    ItemType Type { get; }

    string ToString();
}

public class Ring : IItem {
    public int Id { get; private set;}
    public string Name { get; private set; }

    public ItemType Type {
        get { return ItemType.Ring; }
    }

    public Ring(int id, string name) {
        Id = id;
        Name = name;
    }

    public override string ToString() {
        return string.Format("{0} [Ring] - Id {1}", Name, Id);
    }
}

public class Weapon : IItem {
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ItemType Type {
        get { return ItemType.Weapon; }
    }

    public Weapon(int id, string name) {
        Id = id;
        Name = name;
    }

    public override string ToString() {
        return string.Format("{0} [Weapon] - Id {1}", Name, Id);
    }
}

/// <summary>
/// The interface for a Hotbar.
/// </summary>
public interface IHotbar {
    /// <summary>
    /// Dumps the hotbar to the console for debugging purposes.
    /// </summary>
    void Dump();

    /// <summary>
    /// Gets the number of slots in the hotbar
    /// </summary>
    /// <returns>The number of slots of capacity in the hotbar</returns>
    int GetNumSlots();

    /// <summary>
    /// Gets a an item at the given slot. The first slot is 0 and the last slot is GetNumSlots() - 1.
    /// If there is no item at the slot, it returns null.
    /// If the slot >= GetNumSlots(), then it will throw a System.IndexOutOfRangeException.
    /// </summary>
    /// <param name="slot">The slot index. Must be from 0 to GetNumSlots() - 1</param>
    /// <param name="item">The <see cref="IItem"/> item.</param>
    /// <returns>The IItem item at the slot, or null if the slot was empty</returns>
    IItem GetItem(int slot);

    /// <summary>
    /// Puts an item (can be null for "no item") into the slot.
    /// </summary>
    /// <param name="item">The item to insert.</param>
    /// <param name="slot">The slot in which to place the item.</param>
    /// <returns>The item that was previously in the slot, or null if the slot was empty.</returns>
    IItem PutItemIntoSlot(IItem item, int slot);

    /// <summary>
    /// Removes all items from the hotbar.
    /// </summary>
    void RemoveAllItems();

    /// <summary>
    /// Ensures items start at slot 0 and there are no empty slots between items.
    /// For example, a hot bar like this (pipe symbol '|' is acting as the separator):
    ///     {empty}  |  sword  |  {empty}  |  ring     |  {empty}
    /// will look like this after calling this method:
    ///     sword    |  ring   |  {empty}  |  {empty}  |  {empty}
    /// </summary>
    void Pack();

    /// <summary>
    /// Groups items by ItemType and sorts items within every group alphabetically by Name.
    /// Incidentally, it also packs all the items as if Pack() were called.
    /// For example, a hot bar like this:
    ///     {empty}  |  weapon1  |  ring1  | weapon2 | ring2
    /// will look like this after calling this method:
    ///     weapon1  |  weapon2  |  ring1  |  ring2  | {empty}
    /// </summary>
    void SortByItemType();
}

/// <summary>
/// A Hotbar class that implements the <see cref="IHotbar"/> interface.
/// </summary>
public class Hotbar : IHotbar {
    private const int NumSlots = 8;
    private List<IItem> slots = new List<IItem>();

    public Hotbar() {
        // Empty out the slots to start with
        for (int i = 0; i < NumSlots; ++i) {
            slots.Add(null);
        }
    }

    public void Dump() {
        Console.WriteLine("    Hotbar {");

        for (int i = 0; i < NumSlots; ++i) {
            Console.Write("        Slot " + i + " - ");
            var item = slots[i];
            Console.WriteLine(item == null ? "NULL" : item.ToString());
        }

        Console.WriteLine("    }");
        Console.WriteLine();
    }

    public int GetNumSlots() {
        return NumSlots;
    }

    public IItem GetItem(int slot) {
        if (slot >= NumSlots) {
            throw new System.IndexOutOfRangeException("slot must be between 0 and " + (NumSlots - 1));
        }

        return slots[slot];
    }

    public void RemoveAllItems() {
        for (int slot = 0; slot < NumSlots; ++slot) {
            slots[slot] = null;
        }
    }

    public IItem PutItemIntoSlot(IItem item, int slot) {
        var oldItem = slots[slot];
        slots[slot] = item;
        return oldItem;
    }

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
}

public partial class Program {
    static IHotbar hotbar = new Hotbar();

    const int ID_SWORD = 0;
    const int ID_WATERGUN = 1;
    const int ID_RING_TELEPORTATION = 2;
    const int ID_RING_HEALING = 3;

    static void ResetHotbar() {
        hotbar.RemoveAllItems();
        SetItems();
    }

    static void SetItems() {
        IItem sword = new Weapon(ID_SWORD, "Excalibur");
        IItem watergun = new Weapon(ID_WATERGUN, "Watergun");
        IItem ringTeleportation = new Ring(ID_RING_TELEPORTATION, "Ring of Teleportation");
        IItem ringHealing = new Ring(ID_RING_HEALING, "Ring of Healing");

        // slot 0 is empty
        hotbar.PutItemIntoSlot(sword, 1);
        // slot 2 is empty
        hotbar.PutItemIntoSlot(ringTeleportation, 3);
        hotbar.PutItemIntoSlot(watergun, 4);
        // slot 5 is empty
        hotbar.PutItemIntoSlot(ringHealing, 6);
        // slot 7 is empty
    }

    static void DoHotbarPack() {
        ResetHotbar();
        Console.WriteLine("Hotbar before Pack():");
        hotbar.Dump();

        hotbar.Pack();
        Console.WriteLine("Hotbar after Pack():");
        hotbar.Dump();

        Debug.Assert(hotbar.GetItem(0) != null);
        Debug.Assert(hotbar.GetItem(0).Id == ID_SWORD);

        Debug.Assert(hotbar.GetItem(1) != null);
        Debug.Assert(hotbar.GetItem(1).Id == ID_RING_TELEPORTATION);

        Debug.Assert(hotbar.GetItem(2) != null);
        Debug.Assert(hotbar.GetItem(2).Id == ID_WATERGUN);

        Debug.Assert(hotbar.GetItem(3) != null);
        Debug.Assert(hotbar.GetItem(3).Id == ID_RING_HEALING);

        Debug.Assert(hotbar.GetItem(4) == null); // empty slot
        Debug.Assert(hotbar.GetItem(5) == null); // empty slot
        Debug.Assert(hotbar.GetItem(6) == null); // empty slot
        Debug.Assert(hotbar.GetItem(7) == null); // empty slot
    }

    static void DoHotbarSortByItemType() {
        ResetHotbar();
        Console.WriteLine("Hotbar before SortByItemType():");
        hotbar.Dump();

        hotbar.SortByItemType();
        Console.WriteLine("Hotbar after SortByItemType():");
        hotbar.Dump();

        Debug.Assert(hotbar.GetItem(0) != null);
        Debug.Assert(hotbar.GetItem(0).Id == ID_SWORD);

        Debug.Assert(hotbar.GetItem(1) != null);
        Debug.Assert(hotbar.GetItem(1).Id == ID_WATERGUN);

        Debug.Assert(hotbar.GetItem(2) != null);
        Debug.Assert(hotbar.GetItem(2).Id == ID_RING_TELEPORTATION);

        Debug.Assert(hotbar.GetItem(3) != null);
        Debug.Assert(hotbar.GetItem(3).Id == ID_RING_HEALING);

        Debug.Assert(hotbar.GetItem(4) == null); // empty slot
        Debug.Assert(hotbar.GetItem(5) == null); // empty slot
        Debug.Assert(hotbar.GetItem(6) == null); // empty slot
        Debug.Assert(hotbar.GetItem(7) == null); // empty slot
    }

    public static void Main() {
        SetItems();

        DoHotbarPack();

        // Uncomment next line if you want to do the bonus
        // DoHotbarSortByItemType();
    }
}