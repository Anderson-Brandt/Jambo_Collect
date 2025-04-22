using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJambo : MonoBehaviour
{
    public List<GameObject> JamboList = new List<GameObject>();

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            object p = Instantiate(JamboList[Random.Range(0, JamboList.Count)], new Vector3(Random.Range(-7.13f, 7.27f), transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            timer = 0f;
        }
    }
}
