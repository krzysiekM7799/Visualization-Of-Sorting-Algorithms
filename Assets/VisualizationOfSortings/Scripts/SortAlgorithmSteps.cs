using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortAlgorithmSteps
{
    SortAlgorithm sortAlgorithm;
    public IComparable[] rollingElements;
    IComparable[] startingelementsToRoll;
    public Stack<SortingCommand> redoCommands = new Stack<SortingCommand>();
    public Stack<SortingCommand> undoCommands = new Stack<SortingCommand>();

    public SortAlgorithmSteps(SortAlgorithm sortAlgorithm)
    {
        this.sortAlgorithm = sortAlgorithm;
        sortAlgorithm.OnStartSort += OnStartSort;
        sortAlgorithm.OnEndSort += OnEndSort;
        sortAlgorithm.OnElementsCompare += OnCompare;
        sortAlgorithm.OnElementsSwap += OnSwap;
    }

    private void OnSwap(int arg1, int arg2)
    {
        ExecuteCommand(new SwapCommand(rollingElements, arg1, arg2));
    }

    private void OnCompare(int arg1, int arg2)
    {
        ExecuteCommand(new ComparisionCommand(rollingElements, arg1, arg2));
    }

    private void OnEndSort()
    {
       startingelementsToRoll.CopyTo(rollingElements, 0);
    }

    private void OnStartSort(IComparable[] elementsToRoll)
    {
        this.rollingElements = new IComparable[elementsToRoll.Length];
        this.startingelementsToRoll = new IComparable[elementsToRoll.Length];
        elementsToRoll.CopyTo(this.rollingElements, 0);
        elementsToRoll.CopyTo(this.startingelementsToRoll, 0);
        redoCommands.Clear();
        undoCommands.Clear();
    }

    
    public void RedoAction()
    {
        if (redoCommands.Count == 0)
        {
            Debug.Log("There's no more redo actions");
        }
        else
        {
            SortingCommand nextCommand = redoCommands.Pop();
            nextCommand.Execute();
            undoCommands.Push(nextCommand);
        }
    }

    public void UndoAction()
    {
        if (undoCommands.Count == 0)
        {
            Debug.Log("There's no more undo actions");
        }
        else
        {
            SortingCommand lastCommand = undoCommands.Pop();
            lastCommand.MakeUndoAction();
            redoCommands.Push(lastCommand);
        }
    }

    private void ExecuteCommand(SortingCommand command)
    {
        command.Execute();
        undoCommands.Push(command);
        redoCommands.Clear();
    }
}
