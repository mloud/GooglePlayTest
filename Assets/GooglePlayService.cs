using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GooglePlayService : MonoBehaviour
{

    private const string ACHIEVEMENT_NORMAL = "CgkImML6lcIKEAIQAQ";
    private const string ACHIEVEMENT_INCREMENTAL = "CgkImML6lcIKEAIQAg";
    private const string ACHIEVEMENT_3 = "CgkImML6lcIKEAIQAw";
    private const string ACHIEVEMENT_4 = "CgkImML6lcIKEAIQBA ";
    private const string ACHIEVEMENT_5 = "CgkImML6lcIKEAIQBQ ";

    private string LEADERBOARD = "CgkImML6lcIKEAIQBg";

    private int incrementalAchCounter = 0;

	void Start () 
    {
        PlayGamesPlatform.Activate();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height));
        GUILayout.BeginVertical("box");
        
        GUILayout.Label("Official Google Play Services");

        GUILayout.Space(20);


        if (GUILayout.Button("LogIn"))
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                    Debug.Log("Logged in");
                else
                    Debug.Log("Login failed");
            });
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Unlock achievement"))
        {
            Social.ReportProgress(ACHIEVEMENT_NORMAL, 100.0, (bool success) =>
            {
                if (success)
                    Debug.Log("Achievement succesfully unlocked");
                else
                    Debug.Log("Achievement unlocking failed");
            });
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Press " + incrementalAchCounter + " unlock"))
        {
            ((PlayGamesPlatform)Social.Active).IncrementAchievement(ACHIEVEMENT_INCREMENTAL, 5, (bool success) =>
            {

            });
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Press " + incrementalAchCounter + " unlock"))
        {
            Social.ReportScore(12345, LEADERBOARD, (bool sucess) =>
            {
                
            });
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Show leaderboard"))
        {
            Social.ShowLeaderboardUI();
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Show specific leaderboard"))
        {
            ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(LEADERBOARD);
        }

        GUILayout.Space(20);


        if (GUILayout.Button("Show achievements"))
        {
            Social.ShowAchievementsUI();
        }

        GUILayout.Space(20);

        if (GUILayout.Button("Sign out"))
        {
            ((PlayGamesPlatform)Social.Active).SignOut();
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

}
