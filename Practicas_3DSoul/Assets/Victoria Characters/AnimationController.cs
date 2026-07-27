using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private PhysicsController physics;

    void Start()
    {
        animator = GetComponent<Animator>();
        physics = GetComponentInParent<PhysicsController>();

        Debug.Log(animator);
        Debug.Log(physics);

        if (animator != null)
            animator.SetBool("isWalking", false);
    }

    void Update()
    {
        if (animator == null || physics == null)
            return;

        animator.SetBool("isWalking", physics.IsWalking());
    }
}