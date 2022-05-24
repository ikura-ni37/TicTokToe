# TicTacToe
拡張○×ゲーム　GUI版

## TTTConsole プロジェクト
- ゲーム進行フレームワーク
- C#実装

### Program.cs
- Main関数（プログラム開始点）

### Plugin.cs
- 思考プラグインDLLを扱うクラス
- プラグイン名，人間操作有無を読み込む
- 思考関数ポインタを取得する

### StartWindow.cs
- ゲームのスタート画面の表示
- プレイヤー，モードを選択できる．
- プラグインがなかった場合エラーメッセージを入力して終了
- プレーヤ―に人間がいない場合かつファストモードを選択した場合はFastModeフォームへ，それ以外ではGameWindowフォームへ移動する．

### GameWindow.cs
- ゲーム画面　startボタンで試合開始をする．
### FastMode.cs
- ゲーム画面，startボタンで試合開始をする．
### character.cs
- キャラクター情報格納クラス
### stone.cs
- まるばつを置くPictureBox用クラス
### GameData.cs
- ゲームデータ格納クラス

### 共通ヘッダーファイル TTTPlugin.h
- GetName, IsHuman, MyTurn 関数の定義


### 開発環境
- Visual C#/C++ 2019
