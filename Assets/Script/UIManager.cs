using UnityEngine;
using System.Collections;

    public class UIManager : MonoBehaviour
    {
       

        public HomeView homeView;
        public PauseView pauseView;
		public GameView gamePlayView;
        public GameOverView gameOverView;
    
       
        [Header("Animation curve")]
        public AnimationCurve fadeCurve;
        public static UIManager Instance;



        void Start()
        {
            Instance = this;
            ShowHomeView();
        }


        public void ShowHomeView() {
            homeView.ShowView();
            gamePlayView.HideView();
            gameOverView.HideView();
            pauseView.HideView();
            
        }

        public void ShowGamePlayView()
        {
            gamePlayView.ShowView();
            gameOverView.HideView();
            homeView.HideView();
            pauseView.HideView();
        }

        public void ShowGameOverView()
        {
            gameOverView.ShowView();
            gamePlayView.HideView();
            homeView.HideView();
            pauseView.HideView();
        }

        public void ShowPauseView() {
            pauseView.ShowView();
        }

}
