using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingElementsManager : MonoBehaviour
{
    public GameObject SortingElementPrefab;
    private SortAlgorithmSteps sortAlgorithmSteps;
    public List<SortingElement> sortingElements = new List<SortingElement>();
    
    public void SetAlgorithmSteps(SortAlgorithmSteps sortAlgorithmSteps)
    {
        this.sortAlgorithmSteps = sortAlgorithmSteps;
    }

    [ContextMenu("SetStartValuesToSortingElements")]
    private void SetStartValuesToSortingElements()
    {
        int i = 0;
        foreach (var sortingElemenent in sortingElements)
        {         
            sortingElemenent.value.text = sortAlgorithmSteps.rollingElements[i].ToString();
            i++;
        }
    }

    public void SetPositionToSortingElement(int indexOfElement, Vector3 position)
    {
        sortingElements[indexOfElement].transform.position = position;
    }


    [ContextMenu("SpawnSortingElements")]
    public void SpawnSortingElements()
    {
        for (int i = 0; i < sortAlgorithmSteps.rollingElements.Length; i++)
        {
            GameObject sortingElement = Instantiate(SortingElementPrefab, Vector3.zero + new Vector3(i, 0, 0),Quaternion.identity);
            sortingElements.Add(new SortingElement(){ transform = sortingElement.transform, value = sortingElement.GetComponentInChildren<Transform>().GetComponentInChildren<Text>() });
        }
        SetStartValuesToSortingElements();

    }

    public struct SortingElement
    {
        public Transform transform;
        public Text value;
    }
}
