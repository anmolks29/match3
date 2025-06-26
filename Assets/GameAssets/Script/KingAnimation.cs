using UnityEngine;
using Spine.Unity;

public class KingAnimation : MonoBehaviour
{
    public string animationName = "idle"; 
    public bool loop = true;

    private SkeletonGraphic skeletonGraphic;

    void Start()
    {
        
        skeletonGraphic = GetComponent<SkeletonGraphic>();

        if (skeletonGraphic != null)
        {
            
            skeletonGraphic.AnimationState.SetAnimation(0, animationName, loop);
        }
        else
        {
            Debug.LogError("SkeletonAnimation component not found on this GameObject.");
        }
    }
}
