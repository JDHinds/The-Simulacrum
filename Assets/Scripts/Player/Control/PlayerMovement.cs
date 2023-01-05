using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 playerVelocity;
    bool groundedPlayer;
    float playerSpeed = 15.0f;
    float jumpHeight = 0.4f;
    float gravityValue = -9.81f;
    public bool paused = false;

    Vector3 airVelocity;

    bool sprinting;

    public Player Player;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        controller.center = new Vector3(0f, -0.73637f, 0f);
        controller.height = 2.089728f;
        controller.radius = 0.4f;

        sprinting = false;

        Player.PlayerPreferences = Player.GetComponent<Player>().PlayerPreferences;
    }

    void FixedUpdate()
    {
        if (Player.PlayerPreferences.sprint.Any(i => Input.GetKey(i)) && !Player.PlayerPreferences.holdSprint)
        {
            if (sprinting)
            { sprinting = false; }
            else
            { sprinting = true; }
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            airVelocity = new Vector3(0, 0, 0);
        }

        Vector3 move = new Vector3(0, 0, 0);
        if (airVelocity != Vector3.zero)
        { move = airVelocity; }
        else if (!paused)
        {
            move = Vector3.ClampMagnitude(new Vector3(GetCustomAxis("H"), 0, GetCustomAxis("V")), 1);
            move = transform.rotation * move;
            move.y = 0;

        }

        controller.Move(move * Time.smoothDeltaTime * playerSpeed);

        if (Player.PlayerPreferences.jump.Any(i => Input.GetKey(i)) && groundedPlayer && !paused)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            airVelocity = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private float GetCustomAxis(string i)
    {
        float j = 0f;
        if (i == "H")
        {
            if (Player.PlayerPreferences.left.Any(i => Input.GetKey(i)))
            { j -= 1f; }
            if (Player.PlayerPreferences.right.Any(i => Input.GetKey(i)))
            { j += 1f; }
            if (Mathf.Abs(j) > 0.001f)
            {
                if (Player.PlayerPreferences.sprint.Any(i => Input.GetKey(i)) || sprinting == true)
                { return Mathf.MoveTowards(0f, j, 25f * Time.smoothDeltaTime); }
                else
                { return Mathf.MoveTowards(0f, j, 10f * Time.smoothDeltaTime); }
            }
            else
            { return 0; }
        }
        else if (i == "V")
        {
            if (Player.PlayerPreferences.backward.Any(i => Input.GetKey(i)))
            { j -= 1f; }
            if (Player.PlayerPreferences.forward.Any(i => Input.GetKey(i)))
            { j += 1f; }
            if (Mathf.Abs(j) > 0.001f)
            {
                if (Player.PlayerPreferences.sprint.Any(i => Input.GetKey(i)) || sprinting == true)
                { return Mathf.MoveTowards(0f, j, 25f * Time.deltaTime); }
                else
                { return  Mathf.MoveTowards(0f, j, 10f * Time.deltaTime); }
            }
            else
            { return 0; }
        }

        return j;
    }
}