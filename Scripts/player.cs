using System.Collections;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody rigidBody;
    Animator animator;
    [SerializeField] int score=0;
    [SerializeField] int bottle = 0;
    [SerializeField]ParticleSystem hittVFx;

    void Start()
    {

        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Move();
     
    }
    private void OnTriggerStay (Collider other)
    {

        if (other.gameObject.tag == "Platform")
        {
            
            rigidBody.isKinematic = true;
            Jump();
           
        }
        if (other.gameObject.tag == "Apple")
        {

            Destroy(other.gameObject);
            score = score + 10;
            bottle++;

        }
        if (other.gameObject.tag == "Enemy")
        {            
            deathscene() ;            
        }
    }
    void deathscene()
    {

        Instantiate(hittVFx, new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        
        

    }



    private void OnTriggerExit(Collider other)
    {
        rigidBody.isKinematic = false;
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
           
            transform.position = new Vector3(transform.position.x  , transform.position.y + 5f, transform.position.z);
            
        }
        
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walk", true);
            transform.position = new Vector3(transform.position.x + 5f*Time.deltaTime, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("walk", true);
            transform.position = new Vector3(transform.position.x - 5f * Time.deltaTime, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0f,90f,0f );
        }

        else
        {
            animator.SetBool("walk", false);
        }
    }

      
}
