# 目次
<!-- TOC -->

- [目次](#目次)
- [操作方法](#操作方法)
- [デモ](#デモ)
  - [Android版](#android版)
  - [Unity1週間ゲームジャムお題「ふえる」](#unity1週間ゲームジャムお題ふえる)
- [開発環境](#開発環境)
- [使用アセット](#使用アセット)
  - [ユーザーデータ管理(必須)](#ユーザーデータ管理必須)
  - [ランキング(必須)](#ランキング必須)
  - [WebGL日本語入力(任意)](#webgl日本語入力任意)
  - [WebGL画面サイズ自動調整(任意)](#webgl画面サイズ自動調整任意)
  - [バージョン管理(任意)](#バージョン管理任意)
- [追加実装](#追加実装)
- [ハマったバグ](#ハマったバグ)
  - [ゴーストの回転軸が歯抜け](#ゴーストの回転軸が歯抜け)
  - [ゴーストがブロックを消していく](#ゴーストがブロックを消していく)
  - [消去中ハードドロップでハング](#消去中ハードドロップでハング)
- [参考リンク](#参考リンク)
  - [実装](#実装)
  - [素材](#素材)
- [メモ](#メモ)
  - [未実装](#未実装)

<!-- /TOC -->

# 操作方法
- 上：ハードドロップ
- 左右：左右移動
- 下：落下スピードUP
- Enter：回転, 決定
- Space：ホールド

# デモ
[テトリス](https://little-hoge.github.io/tetris/)  
[![main](https://user-images.githubusercontent.com/3638785/90015586-c3453100-dce3-11ea-959d-6de3a24d19ee.gif)](https://little-hoge.github.io/tetris/)

#### Android版
[Tetris_v1.1.apk](https://github.com/little-hoge/tetris/releases/download/v1.1/Tetris.apk)

#### Unity1週間ゲームジャムお題「ふえる」
[unity1week_202008100](https://unityroom.com/games/1weektetris)

# 開発環境
- Windows10 64bit
- unity2019.2.0f1  unity日本語化(https://www.sejuku.net/blog/56333)
- Visual C# 2019

# 使用アセット
#### ユーザーデータ管理(必須)
- NCMB v4.0.4(https://github.com/NIFCLOUD-mbaas/ncmb_unity/releases) \
※登録(https://console.mbaas.nifcloud.com/)

#### ランキング(必須)
- unity-simple-ranking v2.2(https://github.com/naichilab/unity-simple-ranking)

#### WebGL日本語入力(任意)
- WebGLInput(https://github.com/kou-yeung/WebGLInput) \
※unity-simple-ranking日本語入力対応  

#### WebGL画面サイズ自動調整(任意)
- WebGL responsive template(https://github.com/miguel12345/UnityWebglResponsiveTemplate) \
※WebGLに対応する場合便利  

#### バージョン管理(任意)
- Github for Unity(https://miyagame.net/github-for-unity/) \
※登録(https://github.com/) \
※使い方(https://qiita.com/toRisouP/items/97c4cddcb735acde2f03)

# 追加実装
- WebGL出力
- SE
- ゴースト
- ハードドロップ
- ランキング
- ふえる
- [Plantuml](https://github.com/little-hoge/tetris/tree/master/plantuml)
- 操作用釦

# ハマったバグ
#### ゴーストの回転軸が歯抜け  
<img src="https://user-images.githubusercontent.com/3638785/90013347-0d2c1800-dce0-11ea-88fe-b111bc047c99.gif" width="200" >  

#### ゴーストがブロックを消していく
<img src="https://user-images.githubusercontent.com/3638785/90013343-0bfaeb00-dce0-11ea-8078-cac88cd8cd88.gif" width="200" >

#### 消去中ハードドロップでハング
<img src="https://user-images.githubusercontent.com/3638785/90106430-5d5bb680-dd82-11ea-8746-45fb37804920.gif" width="200" >

# 参考リンク
#### 実装
- Unity 2D：テトリスの開発  
https://web-dev.hatenablog.com/entry/unity/2d/tetris/overview  
https://github.com/mamorum/tetris

#### 素材
- Google Fonts  
https://fonts.google.com/

- SoundManagerのC#スクリプト  
https://00m.in/Lp0Up

# メモ
#### 未実装
- 落下速度変更
- 各スピン判定(Tスピン等)
