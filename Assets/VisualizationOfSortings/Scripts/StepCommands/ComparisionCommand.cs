using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparisionCommand : SortingActionOnTwoElementsCommand
{   
    public ComparisionCommand(IComparable[] elementsToRoll, int positionOfFirstElement, int positionOfSecondElement)
    {
        this.elementsToRoll = elementsToRoll;
        this.positionOfFirstElement = positionOfFirstElement;
        this.positionOfSecondElement = positionOfSecondElement;
        sortingCommandType = SortingCommandType.Compare;
    }

    public override void Execute()
    {     
    }

    public override void MakeUndoAction()
    { 
    }
}
