using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public float radius = 10f;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private bool _alive;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider hitCollider in hitColliders)
            {
                Vector3 direction = hitCollider.transform.position - transform.position;

                if (Vector3.Dot(transform.forward, direction) > 0.5f)
                {
                    Ray ray = new Ray(transform.position, direction);

                    GameObject hitObject = hitCollider.transform.gameObject;
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        if (_fireball == null)
                        {
                            var prevRotation = transform.rotation;
                            transform.LookAt(hitCollider.transform);

                            _fireball = Instantiate(fireballPrefab) as GameObject;
                            _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            _fireball.transform.rotation = transform.rotation;

                            transform.rotation = prevRotation;
                        }
                    }
                    else if (Physics.Raycast(ray, obstacleRange))
                    {
                        float angle = Random.Range(-110, 110);
                        transform.Rotate(0, angle, 0);
                    }
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
