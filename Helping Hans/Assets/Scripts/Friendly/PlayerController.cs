using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed;                       // Tốc độ di chuyển của người chơi
    public GameObject playerItemOne;                // Đồ vật ở tay thứ nhất
    public GameObject playerItemTwo;                // Đồ vật ở tay thứ hai
    private const int playerInventorySlot = 2;      // Số lượng vật phẩm người chơi có thể cầm

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region Movement System
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        #endregion

        #region Interactive System
        #endregion
    }
}
