using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using Random = UnityEngine.Random;
using System.Text.RegularExpressions;
[RequireComponent(typeof(AudioSource))]
public class Talker : MonoBehaviour {

    AudioSource audioSource;
    
    [Header("GUI")]
    public Font font;

    /// <summary>
    /// Texto que se vera en la burbuja
    /// </summary>
    public TMP_Text textGUI;
    /// <summary>
    /// Muestra las paginas de dialogos disponibles
    /// </summary>
	public TMP_Text pageNumberGUI;
    /// <summary>
    /// el texto para la siguiente pagina.
    /// </summary>
	public TMP_Text nextPagePromptGUI;

    [Space(20)] //tecla para pasar a la siguiente pagina
	public string nextPagePromptText;
    public KeyCode textPageKey;

    [Space(20)]
    [Header("Sound Settings")]
	public AudioClip[] letters; //array para poner todos los sonidos de las teclas
    public AudioClip[] letterSounds { get; set; }

    public float letterTime = 1f;
    [Space(20)]
    public bool useLetterSounds = true;
	public bool canChangeSpeed = true;
	public bool useSounds = true;
	public bool useRandomPitch = false;

    [Space(20)]
	[Range(0, 10f)] //pitch base y su variacion.
	public float basePitch = 1.5f;
	[Range(0f, 3f)]
	public float pitchShift = 0.5f;
    
    // usar false cuando se quiera instanciar desde otro script.
	public bool speakAtInstantiation = true; 

    [Space(20)]
    [Header("Text")] //recibe el scriptable object de los dialogos.
    public TextSpeakOver sentence;
	
	float time;

    [SerializeField]bool isWriting = false;
    [SerializeField]bool isPrompted = false;
    [SerializeField]bool nextPagePrompt = false;
    [SerializeField]private int actualPage;
    public GameObject m_PressGUI;
    void Start() {

        letterSounds = letters;
        audioSource = gameObject.GetComponent<AudioSource>();

        
    }

    private void Update()
    {
        if(speakAtInstantiation && actualPage == 0)
        {
            speakAtInstantiation = false;
            StartCoroutine(PrintSentences(sentence.sentences));
        }

    }

    public IEnumerator PrintSentences(string[] sentences)
    {
        isPrompted = true;

        for (actualPage = 0; actualPage < sentences.Length; actualPage++)
        {

            

            while(nextPagePrompt)
            {
                StartCoroutine(ContinueTimer(2));
                if (Input.GetKeyDown(KeyCode.E))
                {
                    nextPagePrompt = false;

                    // remueve el texto cuando se pasa de pagina.
                    nextPagePromptGUI.text = "";
                    StopCoroutine(ContinueTimer(2));
                }

                yield return null;
            }
            // muestra el numero de la pagina.
            pageNumberGUI.text = (actualPage + 1 ) + " / " + sentences.Length;
            yield return StartCoroutine(PrintText( sentences[actualPage])); //inicia la corrutina para imprimir el texto
            
            
            if (actualPage < sentences.Length -1)
            {
                nextPagePrompt = true;

                if (nextPagePromptGUI != null)
                    nextPagePromptGUI.text = nextPagePromptText;
            }else if (actualPage == sentences.Length-1 )
            {
                StartCoroutine(FinishText());
            }
            
        }
    }

    
	private IEnumerator PrintText(string text) {

        textGUI.text = string.Empty;
        isWriting = true;
        bool isAddingRichTextTag = false; //para saber si se usa rich text tag de TMP
        // recorre todas las letras del texto
		for (int i = 0; i < text.Length; i++) {

            time = letterTime;

            // Cancela el texto si no se ha solicitado.
            if (!isPrompted) {
				isWriting = false;
				break;
			}

            if (text[i] == '<' || isAddingRichTextTag) // siempre que encuentre un < o un > del los tags los ignorara hasta que no encuentre.
            {
                isAddingRichTextTag = true;
                textGUI.text += text[i];
                if (text[i] == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                // inserta la letra actual. 
                textGUI.text = textGUI.text.Insert( i, char.ToString(text[i]));
            

                // pone el pitch a cada letra segun lo establecido antes.
                if(useRandomPitch)
                    audioSource.pitch = Random.Range(basePitch - (pitchShift / 2), basePitch + (pitchShift / 2));
                else
                    audioSource.pitch = basePitch;
			
                if (useLetterSounds && letterSounds != null) {

                    // si existe todos los sonidos de las letras
                    if (letterSounds.Length >= 26) {				
                        int audioID = GetLetterSound(text[i].ToString());

                        audioSource.clip = (audioID <= 25) ? letterSounds[audioID] : letterSounds[0];

                    } else
                        Debug.LogError("Se necesita todos los sonidos de las letras del alphabeto.");
				
                } else { // si no se usa una unica letra

                    if (letterSounds[0] != null) {
                        if(audioSource.clip != letterSounds[0])
                            audioSource.clip = letterSounds[0];
                    } else {
                        Debug.LogError("no hay sonido unico.");
                    }

                }

                // Reproduce el sonido
                audioSource.Play ();

                // aumentara la velocidad cuando se presione.
                if(Input.GetKey(KeyCode.Q))
                    time /= 2;

                // no espera espacios
                if (text [i].ToString () != " ") {
                    // aunmenta la velocidad en los puntos.
                    if(text[i].ToString() == ".")
                        time /= 2;

                    // añade una pausa entre letras.
                    yield return new WaitForSeconds (time * 0.2f);
                } 
            }
            

		}

		isWriting = false;
	}

    /// <summary>
    /// la letra y su audio respectivo, si no es una letra retorna default.
    /// </summary>
    /// <param name="letter"></param>
    /// <returns></returns>
	int GetLetterSound(string letter) {

		letter = letter.ToLower();

        switch(letter)
        {
            case "a":
                return 0;
            case "b":
                return 1;
            case "c":
                return 2;
            case "d":
                return 3;
            case "e":
                return 4;
            case "f":
                return 5;
            case "g":
                return 6;
            case "h":
                return 7;
            case "i":
                return 8;
            case "j":
                return 9;
            case "k":
                return 10;
            case "l":
                return 11;
            case "m":
                return 12;
            case "n":
                return 13;
            case "o":
                return 14;
            case "p":
                return 15;
            case "q":
                return 16;
            case "r":
                return 17;
            case "s":
                return 18;
            case "t":
                return 19;
            case "u":
                return 20;
            case "v":
                return 21;
            case "w":
                return 22;
            case "x":
                return 23;
            case "y":
                return 24;
            case "z":
                return 25;
            default:
                return 26;
        }

	}

    private IEnumerator FinishText()
    {
        StopCoroutine(PrintSentences(sentence.sentences));
        yield return new WaitForSeconds(1);
        actualPage = 0;
        this.gameObject.SetActive(false);
        isPrompted = false;
        speakAtInstantiation = true;
    }

    private IEnumerator ContinueTimer(float Nexttime)
    {
        yield return new WaitForSeconds(Nexttime);
        nextPagePrompt = false;
        nextPagePromptGUI.text = "";
    }

}

