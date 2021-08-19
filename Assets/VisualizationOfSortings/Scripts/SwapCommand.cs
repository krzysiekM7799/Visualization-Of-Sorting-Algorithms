using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCommand : SortingActionOnTwoElementsCommand
{
    public SwapCommand(IComparable[] elementsToRoll, int positionOfFirstElement, int positionOfSecondElement)
    {
        this.elementsToRoll = elementsToRoll;
        this.positionOfFirstElement = positionOfFirstElement;
        this.positionOfSecondElement = positionOfSecondElement;
        sortingCommandType = SortingCommandType.Swap;
    }

    public override void Execute()
    {
        SortAlgorithm.Swap<IComparable>(ref elementsToRoll[positionOfFirstElement], ref elementsToRoll[positionOfSecondElement]);
    }


    public override void MakeUndoAction()
    {
        SortAlgorithm.Swap<IComparable>(ref elementsToRoll[positionOfSecondElement], ref elementsToRoll[positionOfFirstElement]);
    }

}
