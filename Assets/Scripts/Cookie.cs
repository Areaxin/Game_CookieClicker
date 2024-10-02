using UnityEngine;
using Random = UnityEngine.Random;

public class Cookie : MonoBehaviour
{
    public AudioSource audioSource;
    public CookieManager manager;
    public float popSpeed = 3;
    public GameObject particleObject;
    
    private void OnMouseDown()
    {
        manager.clicks++;
        audioSource.Play();
        transform.localScale = Vector3.one * 1.5f;
        
        // particles
        var obj = Instantiate(particleObject);
        obj.transform.position = new Vector3(Random.Range(-1f,1f),Random.Range(-1f,1f),Random.Range(-1f,1f));
    }

    private void Update()
    {
        if (transform.localScale.x > 1)
        {
            transform.localScale -= Vector3.one * popSpeed * Time.deltaTime; 
        }
    }
}
