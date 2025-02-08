using System.Collections;
using System.Collections.Generic;
using TerraWuler;
using UnityEngine;

public class RpgPlayer : MonoBehaviour, IControl
{

    [SerializeField] private Animator animator;
    private InputManager inputManager;
    private Moviment moviment;
    private Character meshCharacter;
    public GameObject GetGameObject()
    {
        return this.gameObject;
    }


    void Start()
    {
        inputManager = GameController.Instance.GetComponentManager<InputManager>();
        moviment = GetComponent<Moviment>();

    }


    void Update()
    {

        Vector2 moveInput = inputManager.GetMove();
        moviment.HandleMovement(moveInput.x, moveInput.y);
        if (animator == null)
        {
            return;
        }
        animator.SetBool("IsRun", inputManager.GetMove().x != 0 || inputManager.GetMove().y != 0);

    }


    public void InstantiateCharacter(GameObject character)
    {
        if (character == null)
        {
            return;
        }
        meshCharacter = Instantiate(character, transform.position, transform.rotation, transform).GetComponent<Character>();
        animator = meshCharacter.GetComponent<Animator>();
    }
}
