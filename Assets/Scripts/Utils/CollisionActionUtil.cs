using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionActionUtil : MonoBehaviour
{

    [SerializeField] private bool playSound;

    [SerializeField] private bool changeMaterial;
    [SerializeField] private AudioClip audioFile;
    [SerializeField] private Material hitMaterial;
    [SerializeField] private Renderer gameObjRenderer;
    private Material defaultMat;
    private AudioSource gameObjAS;

    // Start is called before the first frame update
    void Start()
    {
        gameObjAS = gameObject.AddComponent<AudioSource>();
        if (gameObjRenderer == null)
        {
            gameObjRenderer = gameObject.GetComponent<Renderer>();
        }
        defaultMat = gameObjRenderer.material;
        gameObjAS.playOnAwake = false;
        gameObjAS.loop = false;
        gameObjAS.clip = audioFile;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        DoOnCollision();
    }

    private void OnTriggerEnter(Collider other)
    {
        DoOnCollision();
    }

    private void DoOnCollision()
    {
        if (playSound)
        {
            gameObjAS.Play();
        }
        if (changeMaterial)
        {
            gameObjRenderer.material = hitMaterial;
        }
    }

    void OnCollisionExit()
    {
        StartCoroutine(ChangeBackMaterial());
    }

    private IEnumerator ChangeBackMaterial()
    {
        yield return new WaitForSeconds(0.3f);
        gameObjRenderer.material = defaultMat;
    }
}
