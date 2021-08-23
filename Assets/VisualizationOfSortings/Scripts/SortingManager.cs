using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingManager : MonoBehaviour
{
    private SortAlgorithm sortAlgorithm;
    private SortAlgorithmStatistics sortAlgorithmStatistics;
    private SortAlgorithmSteps sortAlgorithmSteps;
    private SortingElementsManager sortingElementsManager;
    private CharacterController characterController;
    [SerializeField] private static int numberElementsToSort;

    private void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
        sortingElementsManager = GetComponent<SortingElementsManager>();
    }

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
            characterController.PerformAction(currentCommand);
            characterState = characterController.CurrentCharacterState;
            while (characterController.CurrentCharacterState == characterState)
            {
                yield return null;
            }
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
        IComparable[] ints = SortAlgorithm.ConvertToIComparable<int>(tab);
 
        sortAlgorithm.Sort(ints);
    }

    private static int[] MakeDataForSorting()
    {
        int[] tab = new int[numberElementsToSort];
        int j = 0;
        for (int i = tab.Length - 1; i >= 0; i--)
        {
            tab[j] = i;
            j++;
        }

        return tab;
    }
}
