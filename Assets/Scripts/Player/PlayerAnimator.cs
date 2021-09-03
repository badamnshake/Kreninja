using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//   animator◄┐ ┌──────┐
//            ├─┤Player│
// controller◄┘ └──────┘
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    // tags
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int Jump = Animator.StringToHash("jump");
    private static readonly int Walk = Animator.StringToHash("walk");

    // Update is called once per frame
    public void PlayMoveAnim(Vector2 direction)
    {
        animator.SetInteger(MoveX, (int) direction.x);
        animator.SetInteger(MoveY, (int) direction.y);
        animator.SetTrigger(Walk);
    }


    public void PlayJumpAnim()
    {
        animator.SetTrigger(Jump);
    }
}