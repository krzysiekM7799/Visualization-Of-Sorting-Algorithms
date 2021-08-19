using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SortingCommand : Command
{
    public SortingCommandType sortingCommandType;
    protected IComparable[] elementsToRoll;
}

