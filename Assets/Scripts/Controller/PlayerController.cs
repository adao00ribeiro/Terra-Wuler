using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TerraWuler;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private RpgPlayer PrefabRpgPlayer;
  private InputManager inputManager;
  //controles 
  private IControl control;
  private Moviment moviment;
  private SkillSystem skillSystem;
  void Start()
  {
    inputManager = GameController.Instance.GetComponentManager<InputManager>();
    var rpgplayer = Instantiate(PrefabRpgPlayer, transform.position, transform.rotation);
    var datamanager = GameController.Instance.GetComponentManager<DataManager>();
    rpgplayer.InstantiateCharacter(datamanager.GetDataCharacterByName("Warrior")?.PrefabCharacter);
    SetControl(rpgplayer);
  }
  void Update()
  {
    float moveHorizontal = inputManager.GetMove().x;
    float moveVertical = inputManager.GetMove().y;



    if (moviment != null)
    {
      moviment.HandleMovement(moveHorizontal, moveVertical);
      if (inputManager.GetJump())
      {
        //  moviment.Jump();
      }
    }
    if (inputManager.GetAlpha1())
    {
      skillSystem?.Hability1();
    }
    if (inputManager.GetAlpha2())
    {
      skillSystem?.Hability2();

    }
    if (inputManager.GetAlpha3())
    {
      skillSystem?.Hability3();

    }
    if (inputManager.GetAlpha4())
    {
      skillSystem?.Hability4();

    }
    if (inputManager.GetAlpha5())
    {
      skillSystem?.Hability5();

    }

  }
  public void SetControl(IControl control)
  {
    this.control = control;
    this.moviment = control.GetGameObject().GetComponent<Moviment>();
    this.skillSystem = control.GetGameObject().GetComponent<SkillSystem>();
  }
  public RpgPlayer GetCharacter()
  {
    return control.GetGameObject().GetComponent<RpgPlayer>();
  }

}
