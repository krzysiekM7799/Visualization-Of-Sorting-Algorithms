using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class SortAlgorithm
{
    public event Action<IComparable[]> OnStartSort;
    public event Action OnEndSort;
    public event Action<int, int> OnElementsSwap;
    public event Action<int, int> OnElementsCompare;
    public event Action<int> OnElementOnRightPlace;

    public void Sort(IComparable[] elementsToRoll)
    {
        OnStartSort?.Invoke(elementsToRoll);
        MakeSort(elementsToRoll);
        OnEndSort?.Invoke();
    }

    protected abstract void MakeSort(IComparable[] numbersToRoll);
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp;
        temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    protected void InvokeSwap(int positionOfFirstElement, int positionOfSecondElement)
    {
        OnElementsSwap?.Invoke(positionOfFirstElement, positionOfSecondElement);
    }

    protected void InvokeCompare(int positionOfFirstElement, int positionOfSecondElement)
    {
        OnElementsCompare?.Invoke(positionOfFirstElement, positionOfSecondElement);
    }

    protected void InvokeElementOnRightPlace(int positionOfElement)
    {
        OnElementOnRightPlace?.Invoke(positionOfElement);
    }

    public static IComparable[] ConvertToIComparable<T>(T[] tab) where T : IComparable
    {
        IComparable[] comparebales = new IComparable[tab.Length];

        for (int i = 0; i < tab.Length; i++)
        {
            comparebales[i] = (IComparable)tab[i];
        }
        
        return comparebales;
    }
}
