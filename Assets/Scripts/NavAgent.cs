using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    public Transform target;
    
    public float rotationSpeed;

    NavMeshAgent nma;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        nma = GetComponent<NavMeshAgent>();
    }

    void Update()
{
    if (target == null)
        return;

    Vector3 flatTarget = new Vector3(target.position.x, transform.position.y, target.position.z);

    nma.SetDestination(flatTarget);

    Vector3 direction = flatTarget - transform.position;
    direction.y = 0f;

    if (direction != Vector3.zero)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
}