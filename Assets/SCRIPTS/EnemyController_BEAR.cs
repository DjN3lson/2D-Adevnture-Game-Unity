using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class EnemyController_BEAR : MonoBehaviour
{
    #region Editor Settings
    [Tooltip("Material to switch to during the flash")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of the flash.")]
    [SerializeField] private float duration;
    #endregion
    [SerializeField] private KeyCode flashkey;
    private new Rigidbody2D rigidbody;
    private bool isPlayerInTrigger = false;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalMaterial = spriteRenderer.material;

        flashMaterial = new Material(flashMaterial);
    }

   public void Flash(){
        if(flashRoutine != null){
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine(originalMaterial.color));
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger)
        {
            disableMovement();
        }

        

    }

    void disableMovement()
    {
        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInTrigger = false;
    }

    private IEnumerator FlashRoutine(Color color)
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }
    

}
