﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
  Controller c; Board b;
  public GameObject Over, Restart;
  public GameObject Up, Down, Left, Right;
  public GameObject Hold, Rotate;

  void Update() {

    if (Restart.activeSelf != Over.activeSelf) {
      Restart.SetActive(Over.activeSelf);
      Up.SetActive(!Over.activeSelf);
      Down.SetActive(!Over.activeSelf);
      Left.SetActive(!Over.activeSelf);
      Right.SetActive(!Over.activeSelf);
      Hold.SetActive(!Over.activeSelf);
      Rotate.SetActive(!Over.activeSelf);
    }
  }

  internal void Init(Controller ct) {
    c = ct; b = c.board;
  }
  public void OnClickUp() {
    b.HardDrop();
  }
  public void OnClickDown() {
    b.Drop();
  }
  public void OnClickLeft() {
    b.Move(-1, 0);
  }

  public void OnClickRight() {
    b.Move(1, 0);
  }

  public void OnClickHold() {
    b.Hold();
  }
  public void OnClickRotate() {
    b.Rotate();
  }

}
