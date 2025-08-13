using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Public Variables

    #endregion

    #region Privet Variables
    [SerializeField] // باعث میشه متغیر مثل پابلیک نشون داده بشه
    private Animator anim;
    #endregion

    #region Public Methods
    #endregion

    #region Privet Methods
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyThis());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length); //به اندازه طول انیمیشن صبر میکنه بعد اونو از بین میبره
        Destroy(gameObject);
    }
    #endregion
}
