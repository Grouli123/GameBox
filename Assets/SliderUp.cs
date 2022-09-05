using UnityEngine;

public class SliderUp : MonoBehaviour
{
   [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer spriteRenderer;
    private bool currentRotation;

    [SerializeField] private float speed = -2f;

    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentRotation = false;
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            ChangeDirection();

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void ChangeDirection()
    {
        currentRotation = !currentRotation;
        //spriteRenderer.flipX = currentRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
