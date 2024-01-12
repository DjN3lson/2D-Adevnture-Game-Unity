using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashDuration;
    
    private new Rigidbody2D rigidbody;
    private bool isPlayerInTrigger = false;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    private UnityEngine.UI.Image Life1, life2, Life3;
    Vector2 startPos;
    [SerializeField] private Transform respawnPoint;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalMaterial = spriteRenderer.material;
        flashMaterial = new Material(flashMaterial);

        startPos = transform.position;
    }

    void Update()
    {
        
    }

    public void Flash(){
        if(flashRoutine != null){
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine(originalMaterial.color));
    }

    private IEnumerator FlashRoutine(Color color){
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Enemy"))
            Die();
    }

    void Die()
    {
        Respawn();
    }
    void Respawn()
    {
        if(respawnPoint != null){
            transform.position = respawnPoint.position;
        }else{
            transform.position = startPos;
        }
    }
}
