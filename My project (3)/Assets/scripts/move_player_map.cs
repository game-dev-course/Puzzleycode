using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_player_map : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.name + " Trigger 3D with " + other.name + " tag=" + other.tag);
    }
    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        rb.velocity = new Vector3(xMove, 0, zMove) * speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 



    }


}

