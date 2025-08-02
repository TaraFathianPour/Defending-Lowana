using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipController : MonoBehaviour
{
    #region Public Variables
    public float vSpeed; // vertical speed
    public float hSpeed; // horizontal speed
    public GameObject bulletPrefab;
    public Vector2 timeToFire;
    public GameObject[] guns;
    public int power;
    #endregion

    #region Private Variables
    private int direction = 0; // 1 => right, -1 => left, 0 => no movement
    [SerializeField]
    private int _health = 10; // مقدار اولیه سلامت
    #endregion

    #region Unity Methods
    void Start()
    {
        InvokeRepeating("ChangeDirection", 1f, 0.5f);
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }

    void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y *= vSpeed;
        transform.position += move * Time.deltaTime;
        CheckSpaceShipOutOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet_player")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }
        else if (col.gameObject.tag == "Asteroid")
        {
            _health -= col.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth();
        }
        else if (col.gameObject.tag == "ship_player")
        {
            _health -= col.gameObject.GetComponent<ShipController>().Health;
            CheckHealth();
        }
    }
    #endregion

    #region Private Methods
    private void CheckSpaceShipOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -7f, 7f);
        transform.position = pos;
    }

    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2); // -1, 0, 1
    }

    private void Fire()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
        }
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            // افکت انفجار (اختیاری)
            // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // AudioSource.PlayClipAtPoint(deathSound, transform.position);

            Destroy(gameObject);
        }
    }
    #endregion
}