using UnityEngine;

public class HammerIdle : StateMachineBehaviour {
    
    private static readonly int HammerAttack1 = Animator.StringToHash("Hammer Attack 1");
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        PlayerHammer.Instance.canReceiveInput = true;
        PlayerInput.Instance._state = PlayerInput.State.Normal;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (!PlayerHammer.Instance.inputReceived) return;
        animator.SetTrigger(HammerAttack1);
        PlayerHammer.Instance.MeleeInputManager();
        PlayerHammer.Instance.inputReceived = false;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
