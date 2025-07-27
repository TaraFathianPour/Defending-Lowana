using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletDirection
{
    UP, // for player bullet
    DOWN // for enemy bullet
}

public class BulletController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    #endregion

    #region Privet Variables
    private Vector3 move = Vector3.down;
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    private void Start()
    {
        if (direction == BulletDirection.DOWN)
        {
            move = Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }

   private void Update()
    {
        transform.Translate(move * speed *Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.identity);
        Destroy(col.gameObject); // برای از بین بردن چیزی که بهش برخورد کرده
        Destroy(gameObject); //برای از بین رفتن گلوله
    }
    #endregion
}
