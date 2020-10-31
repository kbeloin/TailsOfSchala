using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestQuest : Quest
{
    public override void Setup()
    {
        questName = "Test Quest";
        description = "This is just a test so we have more than one quest in the quest log.";
        requirements = "???";
    }

    public override bool IsReadyToComplete()
    {
        return false;
    }

    public override void Complete()
    {
        throw new System.NotImplementedException();
    }
}
