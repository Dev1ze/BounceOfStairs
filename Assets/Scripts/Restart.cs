using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Restart : MonoBehaviour
{
    public bool isTrigger = false;
    [SerializeField] GameObject Explosion;
    async private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Precipice")
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            await Task.Delay(2000);
            SceneManager.LoadScene(0);
        }
    }
}
