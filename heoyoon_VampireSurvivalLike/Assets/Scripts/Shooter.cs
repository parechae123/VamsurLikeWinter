using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] public GameObject missile;
    [SerializeField] public GameObject target;
    [SerializeField] public float spd;
    [SerializeField] public int shot = 12;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMissile());
    }
    IEnumerator CreateMissile()
    {
        int _shot = shot;
        while (_shot>0) 
        {
            _shot--;
            GameObject temp = Instantiate(missile, transform.position,Quaternion.identity);
            temp.GetComponent<BezierMissile>().master = this.gameObject;
            temp.GetComponent<BezierMissile>().enemy = target;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
