using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Bu kesinlikle olmalýdýr


public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AyniBolumuGetir()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
