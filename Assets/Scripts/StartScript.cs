using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	public void LoadByIndex(int index)
    {

        SceneManager.LoadScene(index);

    }
}
