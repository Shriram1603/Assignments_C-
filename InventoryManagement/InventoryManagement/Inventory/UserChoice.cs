using System;
namespace InventoryManagement.Inventory;

/// <summary>
/// An custom variable [enum] <see cref="UserChoice"/> to limit user choice in menu.
/// </summary>
enum UserChoice
{
    Add = 1,
    Display,
    Delete,
    Edit,
    Search,
    SortedDisplay,
    Exit
}
