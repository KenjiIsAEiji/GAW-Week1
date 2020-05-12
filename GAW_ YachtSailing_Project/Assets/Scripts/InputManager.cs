using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] BoatController boatController;
    BoatControls inputs;

    private void Awake() => inputs = new BoatControls();

    private void OnEnable() => inputs.Enable();
    private void OnDestroy() => inputs.Disable();
    private void OnDisable() => inputs.Disable();

    // Update is called once per frame
    void Update()
    {
        boatController.MoveVec2 = inputs.Player.Move.ReadValue<Vector2>();
    }
}
