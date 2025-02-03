using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float _rayLong;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Ray _ray;
    [SerializeField] private RaycastHit _raycastHit;

    [SerializeField] private Transform _transformPointRay;

    [SerializeField] private bool _canShoot;


    [SerializeField] private float _delay;

    [SerializeField] private AudioSource _shootAudio;

    [SerializeField] private TextMeshProUGUI _ammoCountView;

    [SerializeField] private float timeReload;

    [SerializeField] private float maxAmmo;

    private float _ammoCount;

    [SerializeField] private AudioSource reloadGunAudio;

    [SerializeField] private Animator animator;

    bool canRload;

    public GameObject mobileUi;
    public GameObject _sled;

    private void Start()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            mobileUi.SetActive(true);
        }
        else
        {
            mobileUi.SetActive(false);  
        }

        _ammoCount = maxAmmo;
        ViewText();

    }

    private void Update()
    {
        _ray = new Ray(_transformPointRay.position, _transformPointRay.forward);

        
        if (YandexGame.EnvironmentData.isDesktop)
        {
            if (_ammoCount > 0)
            {

                if (Input.GetMouseButton(0))
                {
                    animator.Play("Shoot");

                    if (_canShoot)
                    {

                        if (Physics.Raycast(_ray, out _raycastHit, _rayLong, _layerMask))
                        {
                            Debug.Log("Popal");

                            if (_raycastHit.collider.TryGetComponent(out EnemyHealth enemyHealth))
                            {
                                enemyHealth.DamageEnemy();
                            }

                        }

                        _sled.SetActive(true);
                        _shootAudio.PlayOneShot(_shootAudio.clip);
                        _canShoot = false;
                        _ammoCount--;
                        ViewText();
                        StartCoroutine(ResolutionCanShoot());

                    }
                }
            }



            if (Input.GetMouseButtonUp(0))
            {
                animator.Play("Idle");
            }

            if (Input.GetKeyDown(KeyCode.R))
            {

                if (_ammoCount < maxAmmo && !canRload)
                {
                    canRload = true;
                }
                else
                {
                    canRload = false;
                }

                if (!canRload)
                    return;

                if (canRload)
                {
                    canRload = false;
                    StartCoroutine(ReloadProcess());
                }

            }
        }
        

        if (YandexGame.EnvironmentData.isMobile)
        {
            if (_canShoot)
            {

                if (!canRload && _ammoCount <= 0)
                {
                    StartCoroutine(ReloadProcess());
                    canRload = true;
                }

                if (_ammoCount > 0)
                {
                    if (Physics.Raycast(_ray, out _raycastHit, _rayLong, _layerMask))
                    {
                        Debug.Log("Popal");

                        if (_raycastHit.collider.TryGetComponent(out EnemyHealth enemyHealth))
                        {
                            enemyHealth.DamageEnemy();

                            animator.Play("Shoot");
                            _sled.SetActive(true);
                            _shootAudio.PlayOneShot(_shootAudio.clip);
                            _canShoot = false;
                            _ammoCount--;
                            ViewText();
                            StartCoroutine(ResolutionCanShoot());
                        }

                    }
                    else
                    {
                        animator.Play("Idle");
                    }
                }
            }

            
        }
    }

    private void ViewText()
    {
        _ammoCountView.text = _ammoCount.ToString();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(_ray);
    }

    private IEnumerator ResolutionCanShoot()
    {
        yield return new WaitForSeconds(_delay);
        _sled.SetActive(false );
        _canShoot = true;
    }


    private IEnumerator ReloadProcess()
    {
        reloadGunAudio.PlayOneShot(reloadGunAudio.clip);
        print(reloadGunAudio.clip); 
        animator.Play("Reload");
        yield return new WaitForSeconds(reloadGunAudio.clip.length - 0.3f);
        animator.Play("Idle");

        float addAmmo = maxAmmo - _ammoCount;

        _ammoCount += addAmmo;

        ViewText();
        canRload = false;
    }
}
