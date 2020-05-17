using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private Vector3 jetpack;
    private Vector3 boost;
    private Vector3 runVector;
    public float jetpackSpeed = 40f;
    public float runSpeed = 0.5f;
   
    public float boostAmount = 10f;
    private Vector3 gravity;
    public float gravityAmount;




    public GameObject cannonBlast;

    private bool directionisRight= true;
    private bool rightFlag = true;
    private bool boostOn = false;
    private bool thrusterOn = false;
    private bool isFuelDepleting = false;
    private bool fuelTankingCurrently = false;
    private bool isFlying = false;

    public float fuelRemaining = 100;

    public Animator animator;
    public AudioSource jetPackSound;
    void Start()
    {
        jetpack = new Vector3(0, jetpackSpeed,0);
        boost = new Vector3(0, boostAmount, 0);
        //Debug.Log(fuelRemaining);
        gravity = new Vector3(0, -gravityAmount, 0);

    }

    // Update is called once per frame

    void fuelTank()
    {
        if (fuelRemaining >= 0)
            fuelRemaining -= 3;
        
        //Debug.Log(fuelRemaining);
    }

    void fuelTankReplenishPassive()
    {
        if (fuelRemaining<=99)
        fuelRemaining += 1.2f;
        //Debug.Log(fuelRemaining);
    }
    private void Update()
    {
        //Debug.Log(fuelRemaining);

        if (fuelRemaining <0)
            fuelRemaining = 0;
        
        runVector = new Vector3(Input.GetAxis("Horizontal") * runSpeed, 0, 0);
        Shoot();

        


        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("you're going left, son");
            //rb.transform.Rotate(0f, 180f, 0f);
            if (rightFlag)
            {
                rb.transform.Rotate(0f, 180f, 0f);
                rightFlag = false;
            }

        }
        if (Input.GetKey(KeyCode.D))
        {
            //Debug.Log("you're going right son");
            directionisRight = true;


            if (!rightFlag)
            {
                rb.transform.Rotate(0f, 180f, 0f);
                rightFlag = true;
            }

        }
        if (Input.GetKey(KeyCode.W))
        {

            fuelRemaining = 100;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isFlying = true;
            if (fuelRemaining > 0)
            {
                animator.SetFloat("isFlying", 1f);
                if (!jetPackSound.isPlaying)
                {
                    jetPackSound.Play();
                }
            }
            else if (fuelRemaining <= 0)
            {
                animator.SetFloat("isFlying", 0f);
                if (jetPackSound.isPlaying)
                {
                    jetPackSound.Stop();
                }
            }
        }
        else
        {
            isFlying = false;
            animator.SetFloat("isFlying", 0f);
            if (fuelRemaining<100)
            {
                if (fuelRemaining>=0)
                {
                    Invoke("fuelTankReplenishPassive", 0.05f);
                    //Debug.Log("falling");
                    animator.SetFloat("isRunning", 0f);
                }
            }
            if (jetPackSound.isPlaying)
            {
                jetPackSound.Stop();
            }
        }

        if (Input.GetAxis("Horizontal") != 0)
            if (!isFlying)
                animator.SetFloat("isRunning", 1.0f);
            if (isFlying)
                animator.SetFloat("isRunning", 0f);
        if (Input.GetAxis("Horizontal") == 0)
            animator.SetFloat("isRunning", 0f);
       

        if (isFlying && !IsInvoking("fuelTank"))
        {
            if (fuelRemaining > 0)
            {
                Invoke("fuelTank", 0.05f);
            }
            if (IsInvoking("fuelTankReplenishPassive"))
            {
                CancelInvoke("fuelTankReplenishPassive");
            }
        }

        if (!isFlying && IsInvoking("fuelTank"))
        {
            CancelInvoke("fuelTank");
        }

       

       


        //if (fuelRemaining <= 100 && !isFlying)
        //{
        //    CancelInvoke("fuelTank");
        //    Invoke("fuelTankReplenishPassive", 0.1f);
        //}



        //if(!isFlying && !IsInvoking("fuelTankReplenishPassive"))
        //{
        //    if (fuelRemaining>0)
        //    {
         //       Invoke("fuelTankReplenishPassive", 0.2f);
        //        Debug.Log("replenishing fuel");

        //    }
        //}






        //if (!Input.GetKey(KeyCode.Space))
        //{

        //    if (fuelRemaining < 100)
        //    {
        //        Invoke("fuelTankReplenishPassive", 0.2f);
        //    }
        //    if (IsInvoking("fuelTank"))
        //       CancelInvoke("fuelTank");
        //}



        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    boostOn = true;
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    thrusterOn = true;
        //}

        //Debug.Log(fuelRemaining);
       
    }
    void FixedUpdate()
    {
        transform.position += runVector * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)&& fuelRemaining>0)
        {
            transform.position += (jetpack * Time.deltaTime);
            
        }
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= (jetpack * Time.deltaTime);
        //}

        
        //if (boostOn)
        //if (Input.GetKey(KeyCode.Y))
        //{
        //    Debug.Log("thrust initiated");
            //Vector2 booster = new Vector2(0, 7);
            //rb.AddForce(booster, ForceMode2D.Impulse);
        //    rb.transform.position += (boost * Time.deltaTime); 
            //boostOn = false;
        //}
        //if (thrusterOn)
        //{
        //    Debug.Log("thrust initiated");
        //    Vector2 booster = new Vector2(0, 10);
        //    rb.AddForce(booster);
        //    boostOn = false;
        //}



        else
        {
            transform.position +=  (gravity * Time.deltaTime);
        }

        //if (Input.GetKey(KeyCode.A))
        //{
        //    Debug.Log("left has worked");
        //    transform.position += (-runVector * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += (runVector * Time.deltaTime);
        //}
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Debug.Log("fire CANNONS");
            GameObject.Instantiate(cannonBlast, transform);
        }
    }
}

    
