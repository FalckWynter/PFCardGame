using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CardLoreMono : MonoBehaviour
{
    public TextMeshProUGUI cardLoreText;

    public Image cardImage;

    public ConfirmScreenMono screenParent;

    public AbstractTag cardTag;
    public virtual void Initialize(AbstractTag tag)
    {
        //Debug.Log("≥ı ºªØ√Ë ˆ" + tag.comment);
        cardLoreText.text = tag.comment;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
