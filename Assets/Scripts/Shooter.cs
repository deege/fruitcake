using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float speed = 20.0f;
    [SerializeField] float lifespan = 1.0f;
    [SerializeField] float firerate = 1.0f;

    public bool isFiring = false;
    Coroutine firingCoroutine;

    Facing facing;

    // Start is called before the first frame update
    void Start()
    {
        facing = GetComponent<Facing>();
    }

    // Update is called once per frame
    void Update()
    {
       Fire(); 
    }

    void Fire() {
        if (isFiring && firingCoroutine == null) {
            firingCoroutine = StartCoroutine(FireContinuously());
        } else if (!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously() {
        while (true) {
            Vector3 instancePos = transform.position;
            if (Mathf.Abs(facing.Direction.x) < 0) {
                instancePos.x = -instancePos.x;
            }
            if (Mathf.Abs(facing.Direction.y) < 0) {
                instancePos.y = -instancePos.y;
            }
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if ((facing != null) && (rb != null)) {
                Vector3 direction = facing.Direction;
                Debug.Log(direction);
                rb.velocity = direction * speed;
            }
            Destroy(instance, lifespan);
            yield return new WaitForSeconds(firerate);
        }
    }
}
