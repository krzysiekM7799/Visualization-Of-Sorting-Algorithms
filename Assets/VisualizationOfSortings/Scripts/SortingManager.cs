using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    SortAlgorithm sortAlgorithm;
    SortAlgorithmStatistics sortAlgorithmStatistics;
    public SortAlgorithmSteps sortAlgorithmSteps;
    public SortingElementsManager sortingElementsManager;
    public CharacterController characterController;

    void Start()
    {
        BubbleSort bubbleSort = new BubbleSort();
        PrepareElementsToVisualSortScript(bubbleSort);
        StartCoroutine(PlaySteps(sortAlgorithmSteps));
    }

    public IEnumerator PlaySteps(SortAlgorithmSteps sortAlgorithmSteps)
    {
        SortingCommand[] oldCommands = sortAlgorithmSteps.undoCommands.ToArray();
        CharacterController.CharacterState characterState = default;
        
        for (int i = oldCommands.Length - 1; i >= 0; i--)
        {
            SortingCommand currentCommand = oldCommands[i];

            currentCommand.Execute();

            switch (currentCommand.sortingCommandType)
            {
                case SortingCommandType.Swap:
                    SwapCommand swapCommand = currentCommand as SwapCommand;
                    characterController.SwapElements(swapCommand.positionOfFirstElement, swapCommand.positionOfFirstElement);
                    characterState = CharacterController.CharacterState.Swap;

                    break;
                case SortingCommandType.Compare:
                    ComparisionCommand comparisionCommand = currentCommand as ComparisionCommand;
                    characterController.CompareElements(comparisionCommand.positionOfFirstElement, comparisionCommand.positionOfSecondElement);
                    characterState = CharacterController.CharacterState.Compare;
                    break;
                case SortingCommandType.SetGoodPlace:
                    characterState = CharacterController.CharacterState.SetRightPlace;
                    break;
            }
            while(characterController.characterState == characterState)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    private void PrepareElementsToVisualSortScript(SortAlgorithm sortAlgorithm)
    {
        this.sortAlgorithm = sortAlgorithm;
        sortAlgorithmStatistics = new SortAlgorithmStatistics(sortAlgorithm);
        sortAlgorithmSteps = new SortAlgorithmSteps(sortAlgorithm);
        sortingElementsManager.SetAlgorithmSteps(sortAlgorithmSteps);
        int[] tab = MakeDataForSorting();
        IComparable[] ints = SortAlgorithm.SwitchToIComparable<int>(tab);
        sortAlgorithm.Sort(ints);
    }

    private static int[] MakeDataForSorting()
    {
        int[] tab = new int[5];
        int j = 0;
        for (int i = tab.Length - 1; i >= 0; i--)
        {
            tab[j] = i;
            j++;
        }

        return tab;
    }
}
