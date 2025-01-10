using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�ă��b�N�I�����ł��Ȃ�
//���̐�[�ɕt����z��̃R�[�h
public class Arrow : MonoBehaviour
{
    //[SerializeField] GameObject arrow_line;

    [System.NonSerialized] public bool arrow_set_ready = false;//��󂪃��j�b�g�Əd�Ȃ��Ă��邩(=�Z�b�g���悤�Ƃ��Ă��邩)
    [System.NonSerialized] public bool arrow_set = false;//���j�b�g���(=ready��true��)�N���b�N���ꂽ��(=>�Z�b�g����Ă��邩)
    [System.NonSerialized] public Unit targetUnit;
    [SerializeField] GameObject originPoint;

    Vector3 target_position;

    BezierCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        curve = GetComponentInChildren<BezierCurve>();
        curve.point0 = originPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        arrow_line.transform.localScale = new Vector3(get_distance() / 100, arrow_line.transform.localScale.y, arrow_line.transform.localScale.z);

        arrow_line.transform.eulerAngles = new Vector3(0, 0, get_angle());
        */

        if (arrow_set)
        {
            transform.position = target_position;
        }
        else
        {
            Vector3 thisPosition = Input.mousePosition;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
            worldPosition.z = 0f;
            transform.position = worldPosition;
        }

        transform.eulerAngles = new Vector3(0, 0, curve.angle_z - 90);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit" && !collision.gameObject.GetComponent<Unit>().player && arrow_set == false && targetUnit == null)
        {
            targetUnit = collision.gameObject.GetComponent<Unit>();
            if (targetUnit == null)
            {
                Debug.Log("nullTarget");
            }
            arrow_set_ready = true;
            target_position = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit" && !collision.gameObject.GetComponent<Unit>().player)
        {
            Debug.Log("lockoff");
            arrow_set_ready = false;
            targetUnit = null;
        }
    }

    private void OnMouseDown()
    {
        if (arrow_set_ready)
        {
            arrow_set = true;
        }
    }

    /*
    private float get_distance()
    {
        float distance_x = transform.position.x - arrow_line.transform.position.x;
        float distance_y = transform.position.y - arrow_line.transform.position.y;

        float distance = Mathf.Sqrt((distance_x * distance_x) + (distance_y * distance_y));

        return distance;
    }

    */
}
