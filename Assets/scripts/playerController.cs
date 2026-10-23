using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed;
    public float rangeX;
    public GameObject food;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInpt = Input.GetAxis("Horizontal");

        //Move player
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInpt);

        //Limit movement range
        if(transform.position.x > rangeX )
        {
            transform.position =
                new Vector3( rangeX, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -rangeX )
        {
            transform.position =
                new Vector3(-rangeX, transform.position.y, transform.position.z);
        }
        
        //GThrow food
        if(Input.GetKeyDown(KeyCode.Space))
        {
          Instantiate(food, transform.position, Quaternion.identity);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            Debug.Log("Game Over!");
        }
    }
}
