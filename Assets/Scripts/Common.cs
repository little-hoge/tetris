using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Common : MonoBehaviour {

}

public class GameInitial {
  [RuntimeInitializeOnLoadMethod]
  static void OnRuntimeMethodLoad() {
    Screen.SetResolution(Define.SCREEN_X, Define.SCREEN_Y, false, Define.FPS);

  }
}

public static class Define {
  // 音楽データ
  public const string DELETE = ("Delete");
  public const string DROP = ("Drop");
  public const string ROTATE = ("Rotate");
  public const string NOTROTATE = ("NotRotate");

  // 画面設定
  public const int SCREEN_X = (480), SCREEN_Y = (864), FPS = (60);

}

public static class Function {


}

// 共有データ
public class Data {
  public readonly static Data Instance = new Data();



}

namespace ENUM {

}
