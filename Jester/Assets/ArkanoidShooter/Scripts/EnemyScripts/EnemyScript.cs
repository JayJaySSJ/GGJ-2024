using System.Collections;
using System.Security.Cryptography;

using TMPro;

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float yMin = -5f;
    public float yMax = 5f;
    public float respawnInterval = 5f;
    public float spawnXPosition = 11f;
    public float respawnTime = 5.0f;

    //public GameObject score;
    public int scoreInt;
    private Transform player;
    private Animator animator;
    public GameObject enemyPrefab;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector2(player.position.x, player.position.y);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    //private void FixedUpdate()
    //{
    //    score.GetComponent<TextMeshProUGUI>().text = $"Score: {scoreInt}";
    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            scoreInt++;
            PlayDestructionAnimation();
        }
        if(CompareTag("Player"))
        {
            scoreInt++;
            Destroy(gameObject);
        }
    }

    private void PlayDestructionAnimation()
    {
        if (animator != null)
        {
            Vector3 spawnPosition = new Vector3(spawnXPosition, Random.Range(yMin, yMax), transform.position.z);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
