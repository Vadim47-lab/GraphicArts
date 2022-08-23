using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Bandit _player;
    [SerializeField] private float _returnSpeed;
    [SerializeField] private Shooter _shooter1;
    [SerializeField] private Shooter _shooter2;
    [SerializeField] private ParticleSystem _healEffect;

    private Transform _companionPlace;
    private int _shootCount;
    private readonly int _leftMouseButton = 0;

    private void Start()
    {
        _companionPlace = _player.CompanionPlace;  
    }

    private void Update()
    {
        FolowingCharacter();

        if (Input.GetMouseButtonDown(_leftMouseButton))
        {
            if (transform.position.x < _player.transform.position.x)
            {
                _shooter1.SetScale(1);
                _shooter2.SetScale(1);
            }
            else
            {
                _shooter1.SetScale(-1);
                _shooter2.SetScale(-1);
            }

            if(_shootCount%2 == 0)
            {
                _shooter1.Emit();
                _shootCount++;
            }
            else
            {
                _shooter2.Emit();
                _shootCount = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            _healEffect.Play();
        }
    }

    private void FolowingCharacter()
    {
        if(transform.position != _companionPlace.position)
        {
            transform.position = Vector3.Lerp(transform.position, _companionPlace.position, _returnSpeed * Time.deltaTime);
        }
    }
}