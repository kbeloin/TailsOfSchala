using System;
using UnityEngine;
using UnityEngine.UI;

public class Quest : IEquatable<Quest>
{
    public string questName;
    public string description;
    public bool isComplete = false;

    public bool Equals(Quest other)
    {
        if (other == null) return false;
        return this.questName.Equals(other.questName);
    }
}
