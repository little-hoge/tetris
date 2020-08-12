# plantuml
#### Pegmatite用
 ```puml
 @startuml
class XY {
}
class Blocks {
    {static} XY(x:int, y:int) : XY
    {static} XYs(p1:XY, p2:XY, p3:XY) : XY[]
}
MonoBehaviour <|-- Blocks

class Board {
    drop : int = 60
    fast : int = 20
    insert : bool
    frm : int
    ResetVariables() : void
    Update() : void
    Insert() : void
    Fix() : void
    Hide() : void
    IsEmpty(x:int, y:int, r:XY[]) : bool
}
MonoBehaviour <|-- Board
Board --> "del" Delete
Board --> "c" Controller
Board o-> "s" Status
Board o-> "next" Next
Board o-> "hold" Hold

class Cell {
}
Cell --> "sr" SpriteRenderer
Cell --> "colors" Colors


class Cells {
    Back(x:float, y:float) : Cell
    Empty(x:float, y:float) : Cell
    Wall(x:float, y:float) : Cell
    Create(id:int, x:float, y:float, clr:Color) : Cell
}
class "List`1"<T> {
}
MonoBehaviour <|-- Cells
Cells --> "prfbCell" GameObject
Cells o-> "cells<GameObject>" "List`1"
Cells --> "c" Controller

class Colors {
}
MonoBehaviour <|-- Colors
Colors --> "empty" Color
Colors --> "wall" Color
Colors --> "i" Color
Colors --> "o" Color
Colors --> "s" Color
Colors --> "z" Color
Colors --> "j" Color
Colors --> "l" Color
Colors --> "t" Color

class Common {
}
class GameInitial {
    {static} OnRuntimeMethodLoad() : void
}
class Define <<static>> {
    + <<const>> DELETE : string
    + <<const>> DROP : string
    + <<const>> ROTATE : string
    + <<const>> NOTROTATE : string
    + <<const>> SCREEN_X : int
    + <<const>> SCREEN_Y : int
    + <<const>> FPS : int
}
class Function <<static>> {
}
class Data {
}
MonoBehaviour <|-- Common
Data o-> "Instance" Data


class Controller {
    Start() : void
}
MonoBehaviour <|-- Controller
Controller --> "fps" Fps
Controller --> "cam" Camera
Controller --> "canvas" Canvas
Controller --> "colors" Colors
Controller --> "cells" Cells
Controller --> "board" Board
Controller --> "score" Score
Controller --> "over" Over
Controller --> "ready" Ready

class Delete {
    frm : int
    delete : int = 30
    Update() : void
    Deleting() : void
    Complete() : void
    Enable() : void
}
class "List`1"<T> {
}
MonoBehaviour <|-- Delete
Delete --> "c" Controller
Delete --> "b" Board
Delete o-> "lines<int>" "List`1"

class Fps {
    frm : int = 0
    sec : float = 0
    fps : float = 0
    Update() : void
}
MonoBehaviour <|-- Fps
Fps --> "txt" Text

class Hold {
}
Hold --> "c" Controller
Hold o-> "s" Status

class Key {
    {static} LeftRightKeys() : bool
    {static} UpDownKeys() : bool
}

class Next {
    swap : int
    count : int
    show : bool
    CreateQueue() : void
    Shuffle(from:int[], to:Status[]) : void
    Dequeue(queue:Status[]) : int
    Enqueue(i:int, queue:Status[]) : void
    Show() : void
}
Next --> "c" Controller

class Over {
    focus : int
    frm : int
    delay : bool
    Update() : void
    Delay() : void
    EndDelay() : void
    Restart() : void
    TitleAlpha(a:float) : void
    Focus(next:int) : void
    Font(txt:Text, to:int) : void
}
MonoBehaviour <|-- Over
Over --> "title" Text
Over --> "tColor" Color
Over o-> "tCenter" Vector3
Over o-> "tUp" Vector3
Over --> "c" Controller

class Ready {
    frm : int
    ready : string
    Update() : void
}
MonoBehaviour <|-- Ready
Ready --> "txt" Text
Ready --> "c" Controller

class Score {
    line : int
    score : int
    Render() : void
}
MonoBehaviour <|-- Score
Score --> "txtLine" Text
Score --> "txtScore" Text

class "SingletonMonoBehaviour`1"<T> {
    + {static} Instance : T <<get>>
}
MonoBehaviour <|-- "SingletonMonoBehaviour`1"


class SoundManager {
    volume : float = 1
    bgmVolume : float = 1
    seVolume : float = 1
    + Volume : float <<set>> <<get>>
    + BgmVolume : float <<set>> <<get>>
    + SeVolume : float <<set>> <<get>>
    + Awake() : void
    + GetBgmIndex(name:string) : int
    + GetSeIndex(name:string) : int
    + PlayBgm(index:int) : void
    + PlayBgmByName(name:string) : void
    + StopBgm() : void
    + PlaySe(index:int) : void
    + PlaySeByName(name:string) : void
    + StopSe() : void
}
class "SingletonMonoBehaviour`1"<T> {
}
class "Dictionary`2"<T1,T2> {
}
"SingletonMonoBehaviour`1" "<SoundManager>" <|-- SoundManager
SoundManager o-> "bgmIndex<string,int>" "Dictionary`2"
SoundManager o-> "seIndex<string,int>" "Dictionary`2"
SoundManager --> "bgmAudioSource" AudioSource
SoundManager --> "seAudioSource" AudioSource

class Status {
}


@enduml
  ```
#### 見れない人用  
![キャプチャ](https://user-images.githubusercontent.com/3638785/90069194-ecd67a80-dd2c-11ea-8519-4ba44c6d9ff6.PNG)
