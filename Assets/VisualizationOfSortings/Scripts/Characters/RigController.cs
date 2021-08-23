using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class RigController : MonoBehaviour
{
    public TwoBoneIKConstraint rightHandRig;
    public TwoBoneIKConstraint leftHandRig;
    public float leftHandWeight;
    public float rightHandWeight;
    public Transform rightElement;
    public Transform leftElement;

    public void SetWeights(float weight)
    {
        leftHandWeight = weight;
        rightHandWeight = weight;
    }


    public void GrabRightElement()
    {
        ParentConstraint rightParentConstraint = rightElement.GetComponent<ParentConstraint>();
        rightParentConstraint.constraintActive = true;
    }

    public void LetGoRightElement()
    {
        ParentConstraint rightParentConstraint = rightElement.GetComponent<ParentConstraint>();
        rightParentConstraint.constraintActive = false;
    }

    public void GrabLeftElement()
    {
        ParentConstraint leftParentConstraint = leftElement.GetComponent<ParentConstraint>();
        leftParentConstraint.constraintActive = true;
    }

    public void LetGoLefttElement()
    {
        ParentConstraint leftParentConstraint = leftElement.GetComponent<ParentConstraint>();
        leftParentConstraint.constraintActive = false;
    }

    void Update()
    {
         rightHandRig.weight = Mathf.Lerp(rightHandRig.weight, rightHandWeight, 12 * Time.deltaTime);
         leftHandRig.weight = Mathf.Lerp(leftHandRig.weight, leftHandWeight, 12 * Time.deltaTime);
    }
}
