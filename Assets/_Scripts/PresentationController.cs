using System.Collections; using System.Collections.Generic; using UnityEngine; using System.Linq;   public class PresentationController : MonoBehaviour
{     public int i;     public Texture2D[] textures = null;     private SpriteRenderer sp;

    private SteamVR_TrackedObject trackedObj;

    // 2
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    // Use this for initialization
    void Start()
    {         i = -1;         sp = GetComponent<SpriteRenderer>();         textures = Resources.LoadAll("Textures", typeof(Texture2D)).Cast<Texture2D>().ToArray();
        //foreach (var t in textures)
        //Debug.Log(t.name);
    }

    // Update is called once per frame
    void Update()
    {         if (Controller.GetHairTriggerDown())
        {             i++;             if (i < textures.Length)
            {                 sp.sprite = Sprite.Create(textures[i], new Rect(0.0f, 0.0f, textures[i].width, textures[i].height), new Vector2(0.5f, 0.5f), 425.0f);             }
            else
            {                 sp.sprite = Sprite.Create(textures[textures.Length - 1], new Rect(0.0f, 0.0f, textures[textures.Length - 1].width, textures[textures.Length - 1].height), new Vector2(0.5f, 0.5f), 425.0f);             }         }          if (Controller.GetHairTriggerDown())         {             i--;             if (i >= 0)             {                 sp.sprite = Sprite.Create(textures[i], new Rect(0.0f, 0.0f, textures[i].width, textures[i].height), new Vector2(0.5f, 0.5f), 425.0f);             }             else             {                 sp.sprite = Sprite.Create(textures[0], new Rect(0.0f, 0.0f, textures[0].width, textures[0].height), new Vector2(0.5f, 0.5f), 425.0f);             }         }     } }  