using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
  public Delete del;
  internal Cell[,] cells; Controller c;
  internal int //-> range of inside wall
    minX = 1, maxX, minY = 1, maxY;
  Status s = new Status();
  Next next = new Next();
  Hold hold = new Hold();
  int drop = 60, fast = 20;
  bool insert; int frm;
  internal int ghostY = 0;

  internal void Init(Controller ct) {
    c = ct; cells = c.cells.main;
    maxX = cells.GetLength(0) - 1;
    maxY = cells.GetLength(1) - 2;
    del.Init(c); next.Init(c); hold.Init(c);
    ResetVariables();
    Next();
  }
  void ResetVariables() {
    insert = false; frm = 0;
  }
  internal void Resets() {
    ResetVariables();
    next.Hide(); next.Reset();
    hold.Hide(); hold.Reset();
    del.All(); Next();
    gameObject.SetActive(false);
  }
  void Update() {
    frm++;
    HandleInput();
    if (frm >= drop) Drop();
    Ghost(true);
    Render();
    Ghost(false);
  }
  internal void HandleInput() {
    Key.Handle();
    if (Key.PressingDown()) {
      if (!insert) frm += fast;
    } else {
      insert = false;
    }    
    if (Key.Left()) Move(-1, 0);
    else if (Key.Right()) Move(1, 0);
    if (Key.Hold()) Hold();
    else if (Key.Rotate()) Rotate();
    if (Key.Up()) HardDrop();
  }
  void Insert() {
    s.XY(5, 20); // first place
    if (s.id == Blocks.i) s.y++;
    s.ResetRotate();
    insert = true;
    //-> check collision
    XY[] r = Blocks.Relatives(s);
    if (IsEmpty(s.x, s.y, r)) return;
    gameObject.SetActive(false);
    c.over.Enable(); // game over
  }
  void Fix() {
    cells[s.x, s.y].id = s.id;
    XY[] r = Blocks.Relatives(s);
    int cx, cy;
    for (int i = 0; i < r.Length; i++) {
      cx = r[i].x; cy = r[i].y;
      cells[s.x + cx, s.y + cy].id = s.id;
    }
  }
  void Hide() {
    cells[s.x, s.y].id = Blocks.empty;
    XY[] r = Blocks.Relatives(s);
    int cx, cy;
    for (int i = 0; i < r.Length; i++) {
      cx = r[i].x; cy = r[i].y;
      cells[s.x + cx, s.y + cy].id = Blocks.empty;
    }
  }
  bool IsEmpty(int x, int y, XY[] r) {
    int b = cells[x, y].id;
    if (b != Blocks.empty) return false;
    int rX, rY;
    for (int i = 0; i < r.Length; i++) {
      rX = r[i].x; rY = r[i].y;
      b = cells[x + rX, y + rY].id;
      if (b != Blocks.empty) {
        return false;
      }
    }
    return true;
  }
  internal bool Move(int x, int y) {
    Hide();
    int nx = s.x + x;
    int ny = s.y + y;
    XY[] r = Blocks.Relatives(s);
    bool move = IsEmpty(nx, ny, r);
    if (move) { s.x = nx; s.y = ny; }
    Fix();
    return move;
  }

  internal void Rotate() {
    if (s.id == Blocks.o) return; // none
    Hide();
    int cr = s.rotate;
    s.Rotate();
    XY[] r = Blocks.Relatives(s);
    if (!IsEmpty(s.x, s.y, r)) {
      s.rotate = cr; // rollback
      SoundManager.Instance.PlaySeByName(Define.NOTROTATE);
    }
    else {
      SoundManager.Instance.PlaySeByName(Define.ROTATE);
    }
    Fix();
  }
  internal void Hold() {
    if (hold.used) return;
    Hide();
    s.id = hold.Replace(s.id);
    if (hold.IsEmpty(s.id)) {
      s.id = next.Id(); // first time
    }
    hold.used = true;
    frm = 0;
    Insert();
    Fix();
  }
  internal void Next() {
    s.id = next.Id();
    Insert();
    Fix();
  }
  internal void Drop() {
    frm = 0;
    if (Move(0, -1)) return;
    //-> dropped. no space to move.
    hold.used = false;
    del.Check();
    SoundManager.Instance.PlaySeByName(Define.DROP);
  }
  internal void Render() {
    for (int y = minY; y < maxY; y++) {
      for (int x = minX; x < maxX; x++) {
        cells[x, y].Render();
      }
    }
  }
  internal void Ghost(bool flag) {
    int cx, cy;
    XY[] r = Blocks.Relatives(s);

    Hide();

    if (!flag) {
      cells[s.x, s.y + ghostY].id = Blocks.empty;
      for (int i = 0; i < r.Length; i++) {
        cx = r[i].x; cy = r[i].y + ghostY;
        cells[s.x + cx, s.y + cy].id = Blocks.empty;
      }
    }
    else {
      ghostY = 0;
      while (IsEmpty(s.x, s.y + ghostY, r)) {
        ghostY--;
      }
      ghostY++;

      cells[s.x, s.y + ghostY].id = s.id;
      for (int i = 0; i < r.Length; i++) {
        cx = r[i].x; cy = r[i].y + ghostY;
        cells[s.x + cx, s.y + cy].id = s.id;
      }
    }
    Fix();
  }

  internal void HardDrop() {
    for (int y = ghostY; y <= 0; y++) {
      Drop();
    }
  }

  internal void BlockUp() {
    for (int y = maxY; y > minY; y--) {
      for (int x = minX; x < maxX; x++) {
        cells[x, y].id = cells[x, y - 1].id;
        if (y == minY + 1) cells[x, y - 1].id = Blocks.empty;
      }
    }
  }
}
