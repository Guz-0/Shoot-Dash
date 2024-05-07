using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private GameObject player;

    [SerializeField] private float movementSpeed = 1f;
    private float step;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        AimAtPlayer();

        movementSpeed = Random.Range(2.5f,7.5f);
        step = Time.deltaTime * movementSpeed;
        transform.position = Vector2.MoveTowards(transform.position,player.transform.position, step);
    }

    void AimAtPlayer()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.z = 0f;

        Vector3 aimDirection = (playerPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PROJECTILE"))
        {
            EnemySpawnerController.DisableEnemy(gameObject);
        }
    }


}