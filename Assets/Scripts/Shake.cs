using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] bool shake;
    private Rigidbody rb;
    private Transform tr;
    private Die_d10 dice;

    private bool checkvalue = false;

    public void Start() {
        this.rb   = gameObject.GetComponent<Rigidbody>();
        this.tr   = gameObject.GetComponent<Transform>();
        this.dice = gameObject.GetComponent<Die_d10>();
    }

    public void Update() {
        
        // if(this.shake == true) {
        //     Debug.Log("jump");
        //     this.shake = false;
        //     this.DoIt();
        // }

        if(!dice.rolling && checkvalue) {
            checkvalue = false;
            Debug.Log("Add score: " + gameObject.GetComponent<Die_d10>().value);
            GameManager.Instance.AddScore(gameObject.GetComponent<Die_d10>().value);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            DoIt();
            checkvalue = true;
        }
    }

    public void DoIt()
    {
        float rx = GetRandom(-5f, 5f);
        float ry = GetRandom(0f, 5f);
        float rz = GetRandom(-5f, 5f);

        rb.AddForce(new Vector3(rx, ry, rz) * 25, ForceMode.Impulse);
        tr.rotation = Random.rotation;
    }

    public void OnTriggerStay(Collider other)
    {
        
    }

    private float GetRandom(float min, float max)
    {
        return Random.Range(min, max);
    }
}
