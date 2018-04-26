using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour {
  
    float speed = 5f;
    Rigidbody playerRigidBody;
    Animator anim;
    AudioSource hurt;
    AudioClip PlayerDeath;
    public Image damageImage;
    public Slider healthSlider;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public static bool isDead = false;
    public static int HP = 100;
    public static bool gameOver = false;

    void Start() {
        anim = GetComponent<Animator>();
        hurt = GetComponent<AudioSource>();
    }

    IEnumerator triggerAnimation() {

      yield return new WaitForSeconds(2.0f);
      gameOver = true;
    }

    private void Awake() {

        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
      if (BridgeEnemy.TookDamage == true && Player.isDead == false) {
        if( LevelManager.isPlaying == true) {
          hurt.play();
        }

        damageImage.color = flashColor;
        healthSlider.value = HP;

      } else if (BridgeEnemy.TookDamage == false) {

            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        if (HP <= 0 && isDead == false)
            Death();

        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(0f, 0f, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(0f, 0f, -speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Hellephant" && isDead == false) {

            HP = 0;
            healthSlider.value = HP;
            Death();
        }
    }

    void Death() {

        isDead = true;
        Time.timeScale = 0.3f;
        anim.Play("Death");
        StartCoroutine(triggerAnimation());
    }
}
