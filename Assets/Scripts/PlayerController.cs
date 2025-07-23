//using System.Diagnostics;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    void Update()
    {
        if (!IsOwner) return;

        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed * Time.deltaTime;
        transform.position += movement;

    }

    void OnMove(InputValue value)
    {
        if (!IsOwner) return;

        moveInput = value.Get<Vector2>();
        Debug.Log($"[OnMove - SendMessages] Input: {moveInput}");
    }



}
