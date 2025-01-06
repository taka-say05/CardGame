using UnityEngine;

public class Slot : MonoBehaviour
{
    public Unit ownerUnit;
    [SerializeField] SpriteRenderer outline_renderer;
    Card use_card;

    bool isSetting = false;

    // Start is called before the first frame update
    protected void Start()
    {
        outline_renderer.enabled = false;
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Card")
        {
            if (use_card == null)
            {
                use_card = collision.gameObject.GetComponent<Card>();
            }

            outline_renderer.enabled = true;
            use_card.slot_set = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Card" && !collision.gameObject.GetComponent<Card>().setting)
        {
            use_card.slot_set = false;
            outline_renderer.enabled = false;
            use_card = null;
        }
    }
}
