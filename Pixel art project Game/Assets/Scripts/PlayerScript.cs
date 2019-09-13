using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Environement
    const float gravity = 9.81f;
    //Statistique Player
    public static byte lifePoint, lifePointMax;
    byte magicalAmount, magicalMax;
    byte stamina, staminaMax;
    static ushort moneyAmount;

    //Valeurs de déplacement
    public int movementSpeed = 7;
    public int JumpHigh = 9, JumpCounter;


    //Gestion des Inputs
    public float YAxisValue;
    public bool Jump;
    public bool Action;
    public bool Attack;
    
    //Component player
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded, isAerial;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool Left, Right, isOnLadder, isOnColliderLadder; 
    private int ForceBackValue = 5; 
    public ShakyCamScripts CameraShake;
    public float FallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public Joystick joystick;

    public GameObject AndroidInputManagerGameObject; 

    


    // Start is called before the first frame update
    void Start()
    {
        lifePoint = 3;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
        Animation();
        DetectGrounded();
        PlayerJump(); 
    }
    void InputManager(){

        YAxisValue = Input.GetAxis("Vertical");
    }
    void FixedUpdate(){
        InputManager();
    }
    void Movement(){
        rb.velocity = new Vector2(joystick.Horizontal * movementSpeed, rb.velocity.y);  
    }
    void PlayerJump(){
        if(Jump && isGrounded){
            rb.velocity = Vector2.up * JumpHigh;
            anim.Play("Jump");
            isAerial = true; 
        }
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Jump){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void MagicRegen(){

    }
    void StaminaRegen(){

    }
    void HealthRegen(){}
    void Animation(){
        if(joystick.Horizontal != 0 && isGrounded){ //Declenchement de l'animation de marche
            anim.Play("Walk");
        }
        else if(joystick.Horizontal == 0 && isGrounded){
                anim.Play("Idle");
        }
        if(!isGrounded){

        }
        if(joystick.Horizontal > 0){
            gameObject.transform.localScale = new Vector3(1,1,1);
            Left = false;
            Right = true;
        }
        else if(joystick.Horizontal<0){
            gameObject.transform.localScale = new Vector3(-1,1,1);
            Left = true;
            Right = false;
        }
        
    }
    void DetectGrounded(){
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded){
            isAerial = false; 
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("Enemies")){
            TakeDamage();
        }
        if(col.gameObject.CompareTag("Ladder")){
            isOnColliderLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.CompareTag("Ladder")){
            isOnColliderLadder = false;
            isOnLadder = false;
        }
    }
    void TakeDamage(){
        lifePoint--;
        anim.Play("Damage");
        StartCoroutine(CameraShake.shake(.15f, .1f));
        if(Left == true){
            rb.AddForce(new Vector2(1,1) * ForceBackValue , ForceMode2D.Impulse); 
        }
        else{
            rb.AddForce(new Vector2(-1,1) * ForceBackValue, ForceMode2D.Impulse); 
        }
        //Lancement du recovery Time
        if(lifePoint == 0){
            Death();
        }
    }
    void Death(){

    }
    void ControlLadder(){
        if(isOnColliderLadder && YAxisValue > 0){
            print("Je suis sur l'echelle");
            isOnLadder = true; 
        }
        if(isOnLadder && YAxisValue > 0){
            print("Je Monte");
            print("Test");
            rb.gravityScale = 0;

            transform.Translate(Vector3.up * Time.deltaTime);

        }
        if(isOnLadder && Input.GetButtonDown("Jump")){
            isOnLadder = false;
            PlayerJump();
        }
        if(!isOnLadder){
            //Reapplique la gravité normal
            rb.gravityScale = 1;
        }
    }
}
