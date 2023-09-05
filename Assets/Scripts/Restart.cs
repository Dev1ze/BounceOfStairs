using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Restart : MonoBehaviour
{
    async private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            await Task.Delay(2000);
            SceneManager.LoadScene(0);

        }
    }
}
