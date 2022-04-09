using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerController : MonoBehaviour
{

    [SerializeField] ParticleSystem _destroyingParticles;

    private void OnTriggerEnter(Collider other)
    {
        //   print($"{this.name} triggered with {other.gameObject.name}");

        StartCrashing();
    }

    private void StartCrashing()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<RocketController>().enabled = false;
        _destroyingParticles.Play();
        Invoke("ReloadLevel", 1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
