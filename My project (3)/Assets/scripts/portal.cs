using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public float speed = 10f;
    public string next_scene;
    public string tag_player = "Player";
    // Start is called before the first frame update ofek
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == tag_player)
        {
            Debug.Log(this.name + " Trigger 3D with " + other.name + " tag=" + other.tag);
            SceneManager.LoadScene(next_scene);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
