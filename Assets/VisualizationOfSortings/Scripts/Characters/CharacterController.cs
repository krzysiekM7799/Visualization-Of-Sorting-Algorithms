using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterState characterState = CharacterState.Move;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);     
    }

    public void SwapElements(int first, int second)
    {
        characterState = CharacterState.Swap;
        Debug.Log("Swaping");
    }

    public void CompareElements(int first, int second)
    {
        characterState = CharacterState.Compare;
        Debug.Log("Comparing");
    }
    public void SetOnRightPlaceElements(int index)
    {
        characterState = CharacterState.SetRightPlace;
        Debug.Log("SetingOnRightPlace");
    }

    public enum CharacterState
    {
        Move,
        PickUp,
        PutDown,
        Swap,
        Compare,
        SetRightPlace
    }
}
