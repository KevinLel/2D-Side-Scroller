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
    public float XAxisValue, YAxisValue;
    private bool Jump;
    private bool Action;
    private bool Menu;
    private bool Shoot;
    private bool Inventory;
    
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
        //Gestion des Axes
        XAxisValue = Input.GetAxis("Horizontal");
        YAxisValue = Input.GetAxis("Vertical");
        //On appuie sur le bouton
        if(Input.GetButtonDown("Jump")){
            Jump = true;
        }
        else{Jump = false;}
        if(Input.GetButtonDown("Action")){
            Action = true;
        }
        if(Input.GetButtonDown("Menu")){
            Menu = true;
        }
        if(Input.GetButtonDown("Shoot")){
            Shoot = true;
        }
        if(Input.GetButtonDown("Inventory")){
            Jump = true;
        }
        //On relache le bouton
        if(Input.GetButtonUp("Jump")){
            Jump = false;
        }
        if(Input.GetButtonUp("Action")){
            Action = false;
        }
        if(Input.GetButtonUp("Menu")){
            Menu = false;
        }
        if(Input.GetButtonUp("Shoot")){
            Shoot = false;
        }
        if(Input.GetButtonUp("Inventory")){
            Jump = false;
        }
    

    }
    void FixedUpdate(){
        InputManager();
    }
    void Movement(){
        rb.velocity = new Vector2(XAxisValue * movementSpeed, rb.velocity.y);  
    }
    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.velocity = Vector2.up * JumpHigh;
            anim.Play("Jump");
            isAerial = true; 
        }
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    void MagicRegen(){

    }
    void StaminaRegen(){

    }
    void HealthRegen(){}
    void Animation(){
        if(XAxisValue != 0 && isGrounded){ //Declenchement de l'animation de marche
            anim.Play("Walk");
        }
        else if(XAxisValue == 0 && isGrounded){
                anim.Play("Idle");
        }
        if(!isGrounded){

        }
        if(XAxisValue > 0){
            gameObject.transform.localScale = new Vector3(1,1,1);
            Left = false;
            Right = true;
        }
        else if(XAxisValue<0){
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
