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
    public GameObject gun;
    public int power;
    #endregion

    #region Privet Variables
    private int direction = 0; // 1=> right & -1 => left & 0 = no right no left 
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeDirection" , 1 , 0.5f );
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y = move.y * vSpeed;
        transform.position += move * Time.deltaTime;
        CheckSpaceShipOutOfBounds();
    }
    private void CheckSpaceShipOutOfBounds()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -7, 7);
        transform.position = pos;
    }
    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2); // -1 , 0 , 1
    }
    private void Fire()
    {
        Instantiate(bulletPrefab, gun.transform.position, quaternion.identity);
    }
    #endregion
}
