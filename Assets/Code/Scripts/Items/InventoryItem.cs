using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InventoryItem : IEquatable<InventoryItem>
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int weight;
    public int value;
    public int count;

    public bool Equals(InventoryItem other)
    {
        if (other == null) return false;
        return this.itemName.Equals(other.itemName);
    }
}
