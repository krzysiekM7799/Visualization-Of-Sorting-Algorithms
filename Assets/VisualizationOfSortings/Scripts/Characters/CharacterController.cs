using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public CharacterState CurrentCharacterState = CharacterState.Idle;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    public void SwapElements(int first, int second)
    {
        CurrentCharacterState = CharacterState.Swap;
        Debug.Log("Swaping"+ first + " " + second);
    }

    public void CompareElements(int first, int second)
    {
        CurrentCharacterState = CharacterState.Compare;
        Debug.Log("Comparing");
    }
    public void SetOnRightPlaceElements(int index)
    {
        CurrentCharacterState = CharacterState.SetRightPlace;
        Debug.Log("SetingOnRightPlace");
    }


    public virtual void PerformAction(SortingCommand currentCommand)
    {
        switch (currentCommand.sortingCommandType)
        {
            case SortingCommandType.Swap:
                {
                    SwapCommand swapCommand = currentCommand as SwapCommand;
                    SwapElements(swapCommand.positionOfFirstElement, swapCommand.positionOfSecondElement);
                    break;
                }
            case SortingCommandType.Compare:
                {
                    ComparisionCommand comparisionCommand = currentCommand as ComparisionCommand;
                    CompareElements(comparisionCommand.positionOfFirstElement, comparisionCommand.positionOfSecondElement);
                    break;
                }
            case SortingCommandType.SetGoodPlace:
                {
                    SetOnRightPlaceElements(2);
                    break;
                }
        }

    }

    public enum CharacterState
    {  
        Idle,
        Swap,
        Compare,
        SetRightPlace
    }
}
