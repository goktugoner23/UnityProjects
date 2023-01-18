using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossFight : MonoBehaviour
{
    [Header("Components")]
    public Animator _animJohnny;
    public Animator _animBoss;
    public Transform bosspoint;
    public Transform bosstransform;
    public Transform boss;
    public ParticleSystem _muzzleFlash;
    public GameObject _assaultRifle;
    public GameObject mainCam;
    public GameObject tap_HoldImage;
    public List<string> animtype_boss = new List<string>();
    public static BossFight Instance; //make a singleton to access clickcount from UI
    public Canvas _canvasJohnny;
    public Canvas _canvasDog;
    private Transform BossPosition;
    [Header("Variables")]
    public bool bossfight;
    private bool bossfightTime;
    public int clickcount;
    private float distance_boss = 0;
    private bool shoot = false;
    private bool idle = true;
    private float smoothprogress;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);
    }
    private void Start()
    {
        animtype_boss.Add("Boss_Kick");
        animtype_boss.Add("Boss_Punch");
        animtype_boss.Add("Boss_Quad");
        _assaultRifle.SetActive(false);
        bossfight = false;
        bossfightTime = false;
        tap_HoldImage.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            JohnnyMovement.Instance.moving = false;
            _animJohnny.SetTrigger("Idle");
            transform.DOMove(bosspoint.position, 1f).SetEase(Ease.Linear).OnComplete(() =>
            {
                gameObject.transform.LookAt(new Vector3(boss.position.x, boss.position.y, boss.position.z));
                mainCam.gameObject.GetComponent<CameraFollow>().target = bosstransform;
                DOTween.To(() => mainCam.gameObject.GetComponent<CameraFollow>().offset, x => mainCam.gameObject.GetComponent<CameraFollow>().offset = x, new Vector3(6.4f, 5.49f, -10.22f), 1); //smooth cam move
            });

            bossfight=true;
            bossfightTime=true;
            _canvasJohnny.enabled = false;
            _canvasDog.enabled = false;
        }
    }

    private void Update()
    {
        if (bossfight) 
        {
            PistolCheck.hasGun = false;
            tap_HoldImage.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                _animJohnny.SetTrigger(animtype_boss[Random.Range(0, 2)]);
                _animBoss.SetTrigger("ReceivePunch");
                clickcount++; 
            }
        }
        if (bossfightTime)
        {
            StartCoroutine(BossfightTime());
        }
    }

    private IEnumerator BossfightTime() 
    {
        yield return new WaitForSeconds(3f);
        bossfight = false;
        PistolCheck.hasGun = false;
        tap_HoldImage.SetActive(false);
        UIManager.Instance.progressfill_clickcount.enabled = false;
        UIManager.Instance.progressfill_clickcountOutline.enabled = false;
        _assaultRifle.SetActive(true);
        _animJohnny.SetTrigger("Boss_Shoot");
        gameObject.transform.LookAt(new Vector3(boss.position.x, boss.localPosition.y + 0.4f, boss.position.z));
        //mainCam.gameObject.GetComponent<CameraFollow>().target = null;
        if (!shoot) 
        {
            StartCoroutine(ShootCount());
            shoot=true;
        }
    }

    private IEnumerator ShootCount()
    {
        while (distance_boss < 5) 
        {
            _muzzleFlash.Play();
            boss.position = new Vector3(boss.position.x, boss.position.y, boss.position.z + 10f * Time.deltaTime);
            _animBoss.SetTrigger("ReceivePunch");
            distance_boss += 0.5f;
            yield return new WaitForSeconds(0.2f);
        }
        _animBoss.SetTrigger("Death");
        if (idle) 
        {
            _animJohnny.SetTrigger("Idle");
            idle = false;
            UIManager.levelPassed = true;
        }
        
    }
}