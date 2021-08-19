using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : SortAlgorithm
{

    protected override void MakeSort(IComparable[] numbersToRoll)
    {
        for (int j = 0; j < numbersToRoll.Length - 1; j++)
        {
            for (int i = 0; i < numbersToRoll.Length - 1; i++)
            {
                InvokeCompare(i, i+1);
                if (numbersToRoll[i].CompareTo(numbersToRoll[i + 1]) > 0)
                {
                    Swap<IComparable>(ref numbersToRoll[i], ref numbersToRoll[i + 1]);
                    InvokeSwap(i, i + 1);
                }                 
            }
            InvokeElementOnRightPlace(j);
        }
        InvokeElementOnRightPlace(numbersToRoll.Length - 1);
    }
}
