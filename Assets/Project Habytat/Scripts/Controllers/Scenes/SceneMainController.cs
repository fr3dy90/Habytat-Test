public class SceneMainController : SceneController
{
   protected override void OnInit()
   {
      base.OnInit();
      AudioManager.Instance.PlayMusic(_audioModel.music);
      MenuInputController.Instance.HandleInputs(true);
   }
   
   public void OnLoadScene()
   {
      GameManager.Instance.HandleScenes(_sceneToLoad);
   }
}
