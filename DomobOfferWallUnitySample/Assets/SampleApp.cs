using UnityEngine;
using System.Collections;

public class SampleApp : MonoBehaviour {	
	// offerWall
	private string PublisherID_Online = "96ZJ2b8QzehB3wTAwQ";
	private string userID = "";
	
	private string stringCheckPointsRusult = "The results of checkPoints will display here";
	
	private string stringConsumePoints = "Please enter the Numbers here";
	
	private string stringConsumePointsRusult = "The results of consumePoints will display here";
	
	// Use this for initialization
	void Start () {
	
	}
	
    void OnGUI()
    {
		int x = 15;
        int y = 5;
        int pad = 20;
		int h = 60;
		int width = 500;
		y += h + pad+10+20;

	       //   scrollViewVector = GUI.BeginScrollView (new Rect (0,0,Screen.width,Screen.height), scrollViewVector, new Rect (0,0,Screen.width-1,1000));
		
		    AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		
        if (GUI.Button(new Rect(x, y, width, h), "loadOfferWall"))
        {
			string[] paramloadOfferWall = new string[2];
			//PublisherID
			paramloadOfferWall[0]=PublisherID_Online;
			//userID
			paramloadOfferWall[1]=userID;
            jo.Call("loadOfferWall",paramloadOfferWall);    
        }
			y += h + pad;
		    if (GUI.Button(new Rect(x, y, width, h), "cacheVideoOfferWall"))
        {
			string[] paramCacheVideoOfferWall = new string[2];
			//PublisherID
			paramCacheVideoOfferWall[0]=PublisherID_Online;
			//userID
			paramCacheVideoOfferWall[1]=userID;
            jo.Call("cacheVideoAd",paramCacheVideoOfferWall);    
        }
		
		y += h + pad;
		      if (GUI.Button(new Rect(x, y, width, h), "loadVideoOfferWall"))
        {
			string[] paramloadVideoOfferWall = new string[2];
			//PublisherID
			paramloadVideoOfferWall[0]=PublisherID_Online;
			//userID
			paramloadVideoOfferWall[1]=userID;
            jo.Call("loadVideoOfferWall",paramloadVideoOfferWall);    
        }
		y += h + pad;
		if (GUI.Button(new Rect(x, y, width, h), "checkPoints"))
        {
			//if checkPoints sucess,callback onCheckPointsSucess;else callback onCheckPointsFailed
			string[] paramcheckPoints = new string[2];
			//PublisherID
			paramcheckPoints[0]=PublisherID_Online;
			//userID
			paramcheckPoints[1]=userID;
            jo.Call("checkPoints",paramcheckPoints); 
        }
		
		y += h + pad;
		stringCheckPointsRusult =GUI.TextField(new Rect(x, y, width, h), stringCheckPointsRusult);
		
		y += h + pad;
		stringConsumePoints =GUI.TextField(new Rect(x, y, width, h), stringConsumePoints);
		
		y += h + pad;
		if (GUI.Button(new Rect(15, y, width, h), "consumePoints"))
        {
			//if consumePoints sucess,callback onConsumeSucess;else callback onConsumeFailed
			string[] paramconsumePoints = new string[3];
			//PublisherID
			paramconsumePoints[0]=PublisherID_Online;
			//set userid,Used to mark a user
			paramconsumePoints[1]=userID;
			paramconsumePoints[2]=stringConsumePoints;
           jo.Call("consumePoints",paramconsumePoints); 
        }
		
		y += h + pad;
		stringConsumePointsRusult =GUI.TextField(new Rect(x, y, width, h), stringConsumePointsRusult);
		

		//GUI.EndScrollView();      
    }
		// Update is called once per frame
	void Update () {
	  //  if (Input.GetKeyDown(KeyCode.Home))
        //{
          //  Application.Quit();
        //}
		        //处理横向两个方向旋
        if(Input.deviceOrientation == DeviceOrientation.LandscapeLeft)   
        {   
            if (Screen.orientation != ScreenOrientation.LandscapeLeft) {   
                Screen.orientation = ScreenOrientation.LandscapeLeft;   
            }   
        }else if(Input.deviceOrientation == DeviceOrientation.LandscapeRight)   
        {   
            if (Screen.orientation != ScreenOrientation.LandscapeRight) {   
                Screen.orientation = ScreenOrientation.LandscapeRight;   
            }   
               
        }else    
        //处理纵向两个方向的旋转
        if(Input.deviceOrientation == DeviceOrientation.Portrait)   
        {   
            if (Screen.orientation != ScreenOrientation.Portrait) {   
                Screen.orientation = ScreenOrientation.Portrait;   
            }   
        }else if(Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)   
        {   
            if (Screen.orientation != ScreenOrientation.PortraitUpsideDown) {   
                Screen.orientation = ScreenOrientation.PortraitUpsideDown;   
            }   
        }   
	}
	
	//The current user's current integral
	void onCheckPointsSucess(string   str)
	{   
		stringCheckPointsRusult = str;  
	}
	//Information and causes of failure
	void onCheckPointsFailed(string   str)
	{   
		stringCheckPointsRusult = str;  
	}
	
	//The current user's current integral
	void onConsumeSucess(string   str)
	{   
		stringConsumePointsRusult = str;  
	}
	
	//Information and causes of failure
	void onConsumeFailed(string   str)
	{   
		stringConsumePointsRusult = str;  
	}
	
	//When addWallClose the callback methods
	void onAddWallClose()
	{
	
	}
	//When AddWallFailed the callback methods
	void onAddWallFailed(string str)
	{
		
	}
	//When AddWallSuces the callback methods
	void onAddWallSucess()
	{
		
	}
	
		//When addVideoWallClose the callback methods
	void onAddVideoWallClose()
	{
	
	}
	//When AddVideoWallFailed the callback methods
	void onAddVideoWallFailed(string str)
	{
		
	}
	//When AddWallSuces the callback methods
	void onAddVideoWallSucess()
	{
		
	}
}
