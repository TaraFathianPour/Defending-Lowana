using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSwpaner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] asteroidsPrefab;
    public Vector2 timeToSpawn; //زمانی برای پخش کردن
    public Vector2 xAxisLimitToSpawn;
    #endregion

    #region Privet Variables
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(spawn());
        //Invoke("spawn", Random.Range(timeToSpawn.x, timeToSpawn.y));
    }

    // Update is called once per frame
    private void Update()
    {

    }
    //private void spawn()
    //{
    //    Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
    //    Vector3 pos = transform.position;
    //    pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
    //    Invoke("spawn", Random.Range(timeToSpawn.x, timeToSpawn.y));
    //}
    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));
        Vector3 pos = transform.position;
        pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
        int rnd = Random.Range(0, asteroidsPrefab.Length);
        Instantiate(asteroidsPrefab[rnd], pos, Quaternion.identity);
        StartCoroutine(spawn());
    }
    #endregion
}