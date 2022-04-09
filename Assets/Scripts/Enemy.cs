using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffects;
    [SerializeField] private GameObject _hitParticles;
    
    [SerializeField] private int _hitPoints = 2;

    private GameObject _parentObj;
    ScoreBoard _score;

    private void Start()
    {
        _score = FindObjectOfType<ScoreBoard>();
        _parentObj = GameObject.FindGameObjectWithTag("ParticleSpawner");
        ComponentAdder();
    }

    private void ComponentAdder()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        AddingScore();
        if (_hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(_deathEffects, transform.position, Quaternion.identity);
        vfx.transform.parent = _parentObj.transform;
        Destroy(gameObject);
    }

    private void AddingScore()
    {
        GameObject vfx = Instantiate(_hitParticles, transform.position, Quaternion.identity);
        vfx.transform.parent = _parentObj.transform;
        _hitPoints--;
        _score.ScoreIncrease(10);
    }
}
