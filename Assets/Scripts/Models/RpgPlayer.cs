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
       // moviment.HandleMovement();
        /*  Vector2 moveInput = inputManager.GetMove();
          bool isMoving = moveInput.x != 0 || moveInput.y != 0;

          if (isMoving)
          {
              // Converte a entrada de 2D (x, y) para 3D (x, 0, y)
              Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;
              Vector3 mov = transform.TransformDirection(moveDirection).normalized;
              // Atualiza a rotação da mesh na direção do movimento
              Quaternion targetRotation = Quaternion.LookRotation(mov);
              meshCharacter.transform.rotation = Quaternion.Lerp(meshCharacter.transform.rotation, targetRotation, Time.deltaTime * 10f);  // Ajuste a velocidade (10f) conforme necessário
          }
          if (animator == null)
          {
              return;
          }
          animator.SetBool("IsRun", inputManager.GetMove().x != 0 || inputManager.GetMove().y != 0);
        */
    }


    public void InstantiateCharacter(GameObject character)
    {
        if(character == null)
        {
            return;
        }
         meshCharacter = Instantiate(character , transform.position , transform.rotation, transform).GetComponent<Character>();
        animator =  meshCharacter.GetComponent<Animator>();
    }
}
