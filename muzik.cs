using UnityEngine;
using UnityEngine.SceneManagement;
  
public class SingletonMuzik : MonoBehaviour
{  
    private static SingletonMuzik obje = null;
	public AudioSource audioSource;
     
    void Awake()
    {
        if( obje == null )
        {
            obje = this;
            DontDestroyOnLoad( this );
             
            SceneManager.sceneLoaded += SahneYuklendi;
			
        }
        else if( this != obje )
        {
            Destroy( gameObject );
        }
    }
     
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= SahneYuklendi;
    }
     
    // Yeni bir sahne yüklenince çağrılır
    void SahneYuklendi( Scene scene, LoadSceneMode mode )
    {
        if( scene.name == "müziğin durmasını istediğimiz sahnelerin adı" || scene.name == "müziğin durmasını istediğimiz sahnelerin adı" )
        {
            audioSource.mute = true;
        }
		else{
			audioSource.mute = false;
		}
    }
}