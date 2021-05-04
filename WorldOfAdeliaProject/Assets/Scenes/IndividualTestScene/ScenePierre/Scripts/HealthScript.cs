using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// Gestion des points de vie et des dégâts
/// </summary>
public class HealthScript : MonoBehaviour {
    /// <summary>
    /// Points de vies
    /// </summary>
    /// 
    public int maxHp = 3;
    public Animator anim;

    public int hp;
    private UnityEngine.Canvas healthBar;
    public event Action<float> OnHealthPctChanged = delegate { };

    PhotonView _view;

    /// <summary>
    /// Ennemi ou joueur ?
    /// </summary>
    public bool isEnemy = true;

    private void OnEnable() {
        hp = maxHp;
    }

    public void Start() {
        healthBar = this.GetComponentInChildren<Canvas>();
        healthBar.enabled = false;

        if (isEnemy) {
            _view = this.GetComponent<PhotonView>();
        }
        else {
            _view = this.GetComponentInParent<PhotonView>();
        }
    }

    void OnTriggerEnter(Collider collider) {
        // Est-ce un tir du bateau ?
        ShotScript shot = collider.gameObject.GetComponent<ShotScript>();
        if (shot != null) {
            if (shot.isEnemyShot != isEnemy) {
                StartCoroutine(makeAppearHealtBar());

                decreaseHP(shot.damage);

                Destroy(collider.gameObject);

                if (PhotonNetwork.isMasterClient)
                {
                    verificationTypeOfObject();
                }
            }

            if (gameObject.name != "Ship(Clone)") {
                shot.Explode();
            }
        }

        // Est-ce un tir d'un ennemi ?
        Projectile projectile = collider.gameObject.GetComponent<Projectile>();
        if (projectile != null) {
            if (projectile.isEnemyShot != isEnemy) {
                StartCoroutine(makeAppearHealtBar());

                decreaseHP(projectile.damage);

                Destroy(collider.gameObject);

                if (PhotonNetwork.isMasterClient)
                {
                    verificationTypeOfObject();
                }
            }
        }

        //Est-ce un ennemi au cac?
        EnemyTouch touch = collider.gameObject.GetComponent<EnemyTouch>();
        if (touch != null) {
            if (touch.isEnemyShot != isEnemy) {
                StartCoroutine(makeAppearHealtBar());

                decreaseHP(touch.damage);

                if (PhotonNetwork.isMasterClient)
                {
                    PhotonNetwork.Destroy(collider.gameObject);
                    verificationTypeOfObject();
                }

            }
        }

        float currentHealthPct = (float) hp / (float) maxHp;
        OnHealthPctChanged(currentHealthPct);
    }

    private void verificationTypeOfObject() {
        if (hp <= 0) {
            if (this.gameObject.name == "Ship(Clone)") {
                Level.instance.endLoseLevel();
            }

            if (isEnemy) {
                if (_view.viewID != null) {
                    if (PhotonNetwork.isMasterClient)
                    {
                        if (PhotonNetwork.offlineMode)
                        {
                            destroy();
                        }
                        else
                        {
                            GetComponent<PhotonView>().RPC("destroy", PhotonTargets.All);
                        }
                    }
                }
            }
            else {
                destroyObject();
            }
        }
    }

    public void ReturnToLobby() {
        if (PhotonNetwork.isMasterClient) {
            if (PhotonNetwork.offlineMode) {
                AllReturnLobby();
            }
            else {
                GetComponent<PhotonView>().RPC("AllReturnLobby", PhotonTargets.All);
            }
        }
    }

    [PunRPC]
    public void AllReturnLobby() {
        GameManager.instance.NetworkManager.moveSceneLobby();
    }

    [PunRPC]
    private void destroy() {
        if (isEnemy) {
            //redFish
            if (gameObject.name.Contains("MediumEnemy")) {
                anim.SetBool("is_attack", false);
                anim.SetBool("is_dead", true);
                GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.DestroyEnemyRedFish);
            }else //Abiss fish
            if (gameObject.name.Contains("FollowerEnemy")) {
                anim.SetBool("is_dead", true);
                GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.DestroyEnemyAbiss);
            }
            else  //Shooter fish
            if (gameObject.name.Contains("ShooterEnemy"))
            {
                anim.SetBool("is_dead", true);
                GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.DestroyEnemyAbiss);
            }
        }
        StartCoroutine(destroyAfterAnim());
    }

    [PunRPC]
    private void destroyObject() {
        Destroy(gameObject);

        if (_view.isMine) {
            _view.RPC("destroyObject", PhotonTargets.OthersBuffered);
        }
    }

    [PunRPC]
    private void destroyObject(int viewID) {
        GameObject go = PhotonView.Find(viewID).gameObject;
        go.SendMessage("destroy");

        if (_view.isMine) {
            _view.RPC("destroyObject", PhotonTargets.OthersBuffered, viewID);
        }
    }

    public void decreaseHP(int damage)
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (PhotonNetwork.offlineMode)
            {
                hp -= damage;
                if (!isEnemy) {
                    GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.LostHearthShip);
                }
            }
            else
            {
                GetComponent<PhotonView>().RPC("decreaseHPForEachPlayer", PhotonTargets.All,damage);
            }
        }
    }

    [PunRPC]
    private void decreaseHPForEachPlayer(int damage)
    {
        Debug.Log("perte de point de vie"+damage);
        hp -= damage;
        if (!isEnemy) {
            GameManager.instance.SoundManager.PlaySoundFX(GetComponent<AudioSource>(), SFB_SoundManager.SoundFX.LostHearthShip);
        }
    }

    private IEnumerator makeAppearHealtBar() {
        healthBar.enabled = true;

        yield return new WaitForSeconds(1);
        healthBar.enabled = false;
    }

    private IEnumerator destroyAfterAnim()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    }
}