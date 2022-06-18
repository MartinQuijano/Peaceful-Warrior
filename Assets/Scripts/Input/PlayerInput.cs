using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal;
    public bool upHeld;
    public bool upPressed;
    public bool jumpHeld;
    public bool jumpPressed;
    public bool raiseShieldHeld;
    public bool raiseShieldPressed;

    private bool readyToClear;

    public InLevelMenuManager inLevelMenuManager;

    void Update()
    {
        ClearInput();

        // if (GameManager.IsGameOver())
        //     return;

        ProcessInputs();
    }

    private void FixedUpdate()
    {
        readyToClear = true;  
    }

    private void ClearInput()
    {
        if (!readyToClear)
            return;

        horizontal = 0f;
        upHeld = false;
        upPressed = false;
        jumpHeld = false;
        jumpPressed = false;
        raiseShieldHeld = false;
        raiseShieldPressed = false;

        readyToClear = false;
    }

    private void ProcessInputs()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(inLevelMenuManager.isGamePaused()){
                inLevelMenuManager.ResumeGame();
            } else {
                inLevelMenuManager.PauseGame();
            }
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        upPressed = upPressed || Input.GetButtonDown("Vertical");
        upHeld = upHeld || Input.GetButton("Vertical");

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld || Input.GetButton("Jump");

        raiseShieldPressed = raiseShieldPressed || Input.GetButtonDown("RaiseShield");
        raiseShieldHeld = raiseShieldHeld || Input.GetButton("RaiseShield");
    }
}
