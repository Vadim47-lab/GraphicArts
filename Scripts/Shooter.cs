using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Shooter : MonoBehaviour
{
    private ParticleSystem _shootEffect;

    private readonly int _countParticle = 1;

    void Start()
    {
        _shootEffect = GetComponent<ParticleSystem>();
    }

    public void Emit()
    {
        _shootEffect.Emit(_countParticle);
    }

    public void SetScale(float scale)
    {
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }
}