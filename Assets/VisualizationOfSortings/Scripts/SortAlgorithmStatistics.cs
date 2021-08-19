using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class SortAlgorithmStatistics
{
    private SortAlgorithm sortAlgorithm;
    public long sortingTime;
    Stopwatch stopwatch = new Stopwatch();
    public int numberOfComparisons;
    public int numberOfSwaps;
    public int numberOfOperations;

    public SortAlgorithmStatistics(SortAlgorithm sortAlgorithm)
    {
        this.sortAlgorithm = sortAlgorithm;
        sortAlgorithm.OnStartSort += OnStartSort;
        sortAlgorithm.OnEndSort += OnEndSort;
        sortAlgorithm.OnElementsCompare += OnCompare;
        sortAlgorithm.OnElementsSwap += OnSwap;
    }
    public void SetSortAlgorithm(SortAlgorithm sortAlgorithm)
    {
        if (sortAlgorithm != null)
        {
            sortAlgorithm.OnStartSort -= OnStartSort;
            sortAlgorithm.OnElementsCompare -= OnCompare;
            sortAlgorithm.OnElementsSwap -= OnSwap;
        }

        this.sortAlgorithm = sortAlgorithm;
        sortAlgorithm.OnStartSort += OnStartSort;
        sortAlgorithm.OnElementsCompare += OnCompare;
        sortAlgorithm.OnElementsSwap += OnSwap;
    }

    private void OnStartSort(IComparable[] elementsToRoll)
    {
        sortingTime = 0;
        numberOfComparisons = 0;
        numberOfSwaps = 0;
        numberOfOperations = 0;
        stopwatch.Start();
    }
    private void OnEndSort()
    {
        stopwatch.Stop();
        sortingTime = stopwatch.ElapsedMilliseconds;
        numberOfOperations = numberOfComparisons + numberOfOperations;
    }
    private void OnCompare(int x, int y)
    {
        numberOfComparisons++;
    }
    private void OnSwap(int x, int y)
    {
        numberOfSwaps++;
    }
}
