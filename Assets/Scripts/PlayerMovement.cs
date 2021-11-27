using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public readonly string TRIGGER_JUMPING = "TriggerJumping";
    private Animator Animator;
    private CharacterController CharacterController;
    
    [SerializeField ]
    private float JumpHeight = 1f;
    private float VerticalVelocity = 0f;




    [SerializeField]
    private float MovementSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent<Animator>(out this.Animator)) 
            Debug.LogWarning("Missing Animator Component on " + gameObject.name);

        if (!TryGetComponent<CharacterController>(out this.CharacterController)) 
            Debug.LogWarning("Missing CharacterController Component on " + gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CharacterController.isGrounded) 
        {
            
            if (Input.GetKey(KeyCode.Space))
            {
                Animator.SetTrigger(TRIGGER_JUMPING);
                VerticalVelocity = Mathf.Sqrt(Physics.gravity.y * -2f * JumpHeight);
            }
            else
            {
                VerticalVelocity = 0f;
            }

        } 
        else
        {
            VerticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        
        
        CharacterController.Move(transform.forward * Time.deltaTime * MovementSpeed + transform.up * VerticalVelocity);

    }
}
