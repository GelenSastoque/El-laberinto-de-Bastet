using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class Pasarnivel2 : MonoBehaviour
{
    [SerializeField] private Button _spawnButton;
    [SerializeField] private Button _spawnButton2;
    [SerializeField] private Image _spawnImage;
       // [SerializeField] private Image _spawn;
    //[SerializeField] private AssetReference _assetReference;

    public AssetReference Menu;
    public AssetReference Scene;
    public AssetReference CrearScene;
    // Start is called before the first frame update
    private AsyncOperationHandle<SceneInstance> handle;
    private bool unloaded;
   
   private void Awake()
    {
         DontDestroyOnLoad(gameObject);
          }

    void Start()
    {
        
        _spawnButton.onClick.AddListener(SpawnObject);
        _spawnButton2.onClick.AddListener(SpawnObject2);
        
    }

private void SpawnObject2()
{
    // _assetReference.InstantiateAsync();
    Addressables.LoadSceneAsync(CrearScene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadComplete;
      //Destroy( _spawnButton);
       Destroy(_spawnButton.gameObject);
       Destroy(_spawnImage.gameObject);
       Destroy(_spawnButton2.gameObject);
        //Destroy(_spawn.gameObject);
          //Destroy(Menu.AssetReference);
    
   //Addressables.ReleaseInstance(Menu).Completed += SceneLoadComplete;
}
private void SpawnObject()
{
    // _assetReference.InstantiateAsync();
    Addressables.LoadSceneAsync(Scene, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += SceneLoadComplete;
      //Destroy( _spawnButton);
       Destroy(_spawnButton.gameObject);
       Destroy(_spawnImage.gameObject);
    Destroy(_spawnButton2.gameObject);
    
  //  Addressables.ReleaseInstance(Scene).Completed += SceneLoadComplete;
}
   private void SceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
   { 
        if (obj.Status == AsyncOperationStatus.Succeeded) 
        { 
            // Set our reference to the AsyncOperationHandle (see next section) 
        Debug.Log(obj.Result.Scene.name + " successfully loaded.");
        handle = obj;
         // (optional) do more stuff 
        //UnityEngine.SceneManagement.ReleaseAsset();
     
        } 
   }
   // Update is called once per frame 
   void Update() 
   { 
    if (Input.GetKeyDown(KeyCode.X) && !unloaded) 
    { 
        unloaded = true; UnloadScene(); 
    } 
    }
    void UnloadScene() 
    {
         Addressables.UnloadSceneAsync(handle, true).Completed += op =>
          {
             if (op.Status == AsyncOperationStatus.Succeeded)
              Debug.Log("Successfully unloaded Scene."); 
              
             };
    }
}
