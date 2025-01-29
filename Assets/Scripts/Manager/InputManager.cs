using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using TerraWuler;

public class InputManager : MonoBehaviour
{
    private InputControls _inputs;

    public Vector2 delta;
    public Vector2 move ; 
    void Awake()
    {
        _inputs = new InputControls();

    }
    public void Update(){
        delta = GetLook();
        move = GetMove();
    }
    private void OnEnable()
    {
        _inputs.Enable();
    }
    private void OnDisable()
    {
        _inputs.Disable();
    }

    public Vector2 GetMove()
    {
        return _inputs.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLook()
    {
        return _inputs.Player.Look.ReadValue<Vector2>();
    }

    public bool GetFire()
    {
        return _inputs.Player.Fire.triggered;
    }

    public bool GetCrouch()
    {
        return _inputs.Player.Crouch.WasPressedThisFrame();
    }
    public bool GetJump()
    {
        return _inputs.Player.Jump.triggered;
    }

    public bool GetRun()
    {
        return _inputs.Player.Run.triggered;
    }

    public bool GetInventory()
    {
        return _inputs.Player.Inventory.triggered;
    }

    public bool GetAim()
    {
        
        return _inputs.Player.Aim.triggered;
    }

    public bool GetAlpha1()
    {
        return _inputs.Player.Alpha1.triggered;
    }
    public bool GetAlpha2()
    {
        return _inputs.Player.Alpha2.triggered;
    }
    public bool GetAlpha3()
    {
        return _inputs.Player.Alpha3.triggered;
    }
    public bool GetAlpha4()
    {
        return _inputs.Player.Alpha4.triggered;
    }
    public bool GetAlpha5()
    {
        return _inputs.Player.Alpha5.triggered;
    }
    
    public Vector2 GetMousePosition()
    {
        return _inputs.Player.MousePosition.ReadValue<Vector2>();
    }

    public bool GetEsc()
    {
        return _inputs.Player.Esc.triggered;
    }
}
