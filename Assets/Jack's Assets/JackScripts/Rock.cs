using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    double timeInstantiated;
    public float assignedTime;
    public GameObject hitParticle;
    GameObject hitInstance;




    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shield")) {
            ScoreManager.Hit();

            hitInstance = Instantiate(hitParticle, transform);
            hitInstance.GetComponent<ParticleSystem>().Play();

            transform.DetachChildren();

            Destroy(gameObject);




        }
        else if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Miss();
            Destroy(gameObject);



        }



    }
    // Update is called once per frame
    void Update()
    {

        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));


        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            var parentGameObject = this.transform.parent.gameObject;
            transform.localPosition = Vector3.Lerp(new Vector3(parentGameObject.GetComponent<Lane>().noteSpawnX, parentGameObject.GetComponent<Lane>().noteSpawnY,0f), new Vector3(parentGameObject.GetComponent<Lane>().noteDespawnX, parentGameObject.GetComponent<Lane>().noteDespawnY, 0f), t);

            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}