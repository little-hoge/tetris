﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
  public Camera cam; public Colors colors;
  public Cells cells; public Score score;
  Board board = new Board();
  void Start() {
    colors.Init(this); cells.Init(this);
    board.Init(this); board.Render();
  }
  internal bool
    end = false, del = false;
  internal int frame = 0;
  int drop = 60, delete = 30;
  void Update() {
    if (end) return;
    frame++;
    if (del) Delete();
    else Process();
  }
  void Delete() {
    if (frame == delete) {
      board.Delete();
    } else {
      board.Deleting();
    }
  }
  void Process() {
    HandleInput();
    if (frame >= drop) {
      board.Drop();
    }
    board.Render();
  }
  //-> user input
  readonly int
    left = 1, right = 2, rotate = 3, hld = 4, down = 5;
  int preInput = 0;
  internal bool dropped = false;
  internal void HandleInput() {
    if (Input.GetAxisRaw("Horizontal") == -1) { // Left
      if (preInput == left) return;
      board.MoveBlock(-1, 0);
      preInput = left;
    } else if (Input.GetAxisRaw("Horizontal") == 1) { // Right
      if (preInput == right) return;
      board.MoveBlock(1, 0);
      preInput = right;
    } else if (Input.GetButton("Fire3")) { // Space or 〇
      if (preInput == rotate) return;
      board.RotateBlock();
      preInput = rotate;
    } else if (Input.GetButton("Jump")) { // H or △
      if (preInput == hld) return;
      board.Hold();
      preInput = hld;
    } else if (Input.GetAxisRaw("Vertical") == -1) { // Down
      if (dropped && preInput == down) return;
      frame += drop / 2; // speed up
      dropped = false;
      preInput = down;
    } else { // None
      preInput = 0;
    }
  }
}

