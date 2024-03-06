using UnityEngine;
using Gaupe.Netcode;

public class PlayerMovement : ClientScript {
    [SerializeField] private float speed = 2f;

    private void Update() {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;
        if (Input.GetKey(KeyCode.W)) moveDir += Vector3.up;
        if (Input.GetKey(KeyCode.S)) moveDir += Vector3.down;

        transform.position += moveDir.normalized * speed * Time.deltaTime;
    }
}