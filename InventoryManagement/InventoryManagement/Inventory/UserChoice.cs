using System;
namespace InventoryManagement.Inventory;

/// <summary>
/// An custom variable [enum] <see cref="UserChoice"/> to limit user choice in menu.
/// </summary>
enum UserChoice
{
    Add = 1,
    Display = 2,
    Delete = 3,
    Edit = 4,
    Search = 5,
    SortedDisplay = 6,
    Exit =7
}
