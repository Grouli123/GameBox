using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinMenuAnim : MonoBehaviour
{

    public Image m_Image;

    public Sprite[] m_SpriteArray;
    public float m_Speed;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;

    private void Update() 
    {
        StartCoroutine(Func_PlayAnimUI());
    }
    // public void Func_PlayUIAnim()
    // {
    //     IsDone = false;
    //     StartCoroutine(Func_PlayAnimUI());
    // }

    // public void Func_StopUIAnim()
    // {
    //     IsDone = true;
    //     StopCoroutine(Func_PlayAnimUI());
    // }
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            m_IndexSprite = 0;
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (IsDone == false)
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }
}