/*YukikoAIプラグイン
*	作成者　河野由貴子　　
*	最終更新日　1/8
*	使用エディタ　Microsoft VisualStudio2019
*/

#include "TTTPlugin.h"
#include <iostream>
#include <random>

const int LINE_SIZE = 8;		//ライン数
const int LINES[8][3] = { { 1, 4, 7 }, { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 },{ 0, 3, 6 },
		{ 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };	//ラインを入れる配列

/// <summary>
/// 人間操作かどうかを返す
/// </summary>
/// <returns>人間ならtrue, 機械ならfalse</returns>
bool IsHuman() {
	return false;
}

/// <summary>
/// 名前を返す
/// </summary>
/// <param name="buf">名前を格納する文字列</param>
/// <param name="bufsize">文字列バッファのサイズ</param>
void GetName(char* buf, size_t bufsize) {
	sprintf_s(buf, bufsize, "YukikoCPU");
}


/// <summary>
/// 手を打つ
/// </summary>
/// <param name="board">盤の状態（値 1～3は自分駒，-1～-3は相手駒，次置くと1が消える）</param>
/// <returns>置く場所</returns>
int MyTurn(int* board) {

	int score[LINE_SIZE];			//それぞれのラインの盤の値の和を入れる配列
	int lineStoneNum[LINE_SIZE];	//それぞれのラインに置かれてる駒の数を入れる配列

	int lastStoneLine[LINE_SIZE];	//それぞれのラインに自分の最後に置いた駒が入っているかを格納する配列(ある：1 ない：0)
	int R_lastStoneLine[LINE_SIZE];	//それぞれのラインに自分の最後に置いた駒が入っているかを格納する配列(ある：1 ない：0)


	int turnNum = 0;							//ボード上の〇×の数を格納する（ターン数取得（序盤））
	int pos = -1;								//置く位置を格納する変数
	int winPoint, losePoint;					//次勝ちor負けの際のラインの盤の和を入れる配列(第一段階で使う)
	int lastNumber, R_lastNumber, stoneNum;		//最後に置いた駒の値を格納する変数（自分，相手）
	int tempStone = -1;							//他にいい手がなかった場合に使う変数
	int lastLineNum = 0;						//自分の最後に置いた駒がいくつのラインに含まれるかを入れた配列
	int R_lastLineNum = 0;						//相手の最後に置いた駒がいくつのラインに含まれるかを入れた配列

	bool _numberDesided = false;	//置く場所が決まったかを示すbool変数

	//ボード上の駒の数を数える
	for (int i = 0; i < BOARD_SIZE; i++) {
		if (board[i] != 0) {
			turnNum++;
		}
	}

/*〇〇〇〇〇先行初手の場合〇〇〇〇〇*/
	//初手は３に置く
	if (turnNum == 0) {
		pos = 3;
		return pos;
	}

	//勝ち点負け点の定義
	if (turnNum <= 5) winPoint = 3; else winPoint = 5;	
	if (turnNum < 5) losePoint = -3; else losePoint = -5;

/*〇〇〇〇〇第一段階〇〇〇〇〇*/
	//（説明）
	//		全てのラインにおいてscore,lineStoneNum,lastStoneLine,R_lastStoneLineの取得
	//		次勝てる，負けるところの探索
	//	　＜探索後＞
	//		次勝てるがあった→ループを抜けてそこに置く
	//		次負けるがあった→全てのラインを見て次勝てるがなかった場合そこに置く
	//		両方ない→先行3手目? Yes→先行３手目の場合へ行く
	//							 No →第二段階へ

	for (int i = 0; i < LINE_SIZE; i++) {
		/*初期化*/
		lastStoneLine[i] = 0;
		R_lastStoneLine[i] = 0;
		score[i] = 0;
		lineStoneNum[i] = 0;
		lastNumber = (int)(turnNum / 2);
		R_lastNumber = (int)((turnNum + 1) / 2);
		R_lastNumber *= -1;

		/*score,lineStoneNum,lastStoneLine,R_lastStoneLineの取得*/
		for (int j = 0; j < 3; j++) {
			score[i] += board[LINES[i][j]];
			if (board[LINES[i][j]] == lastNumber) lastStoneLine[i] = 1;
			if (board[LINES[i][j]] == R_lastNumber) R_lastStoneLine[i] = 1;
			if (board[LINES[i][j]] != 0)lineStoneNum[i]++;
		}
		/*次勝てる探索*/
		if (score[i] == winPoint) {
			_numberDesided = true;
			stoneNum = i;
			break;
		}
		/*次まける探索*/
		else if (score[i] == losePoint) {
			_numberDesided = true;
			stoneNum = i;
		}
	}

	/*次勝てる次負ける探索見つけた場合*/
	if (_numberDesided) {
		for (int i = 0; i < 3; i++) {
			if (board[LINES[stoneNum][i]] == 0) {
				pos = LINES[stoneNum][i];
			}
		}
		return pos;
	}


/*〇〇〇〇〇先行3手目の場合〇〇〇〇〇*/
	//次勝てる負ける探索でみつからなかったら
	//2か8に置く
	if (turnNum == 4) {
		if (board[2] == 0 && lineStoneNum[2] != 0) pos = 2;
		else if (board[8] == 0)pos = 8;
		else pos = 2;

		return pos;
	}

/*〇〇〇〇〇第二段階〇〇〇〇〇*/
	//（説明）
	//		次の次に勝てるところの探索・・・scoreが2の列
	//	　＜探索後＞
	//		あった→そこに置く
	//	　　ない　→第三段階へ

	for (int i = 0; i < 3; i++) {
		if (score[i] == 2 && lastStoneLine[i] == 1 && lineStoneNum[i] == 2) {
			for (int j = 0; j < 3; j++) {
				if (board[LINES[i][j]] == 0) {
					stoneNum = LINES[i][j];
					_numberDesided = true;
				}
			}
		}
	}
	/*あった場合*/
	if (_numberDesided) {
		pos = stoneNum;
		return pos;
	}

	
/*〇〇〇〇〇第三段階〇〇〇〇〇*/
	//（説明）
	//		自分主導権探索・・・リーチをつくる
	//	　＜探索後＞
	//		あった→そこに置く
	//	　　ない　→第４段階へ

	for (int i = 0; i < LINE_SIZE; i++) {
		if (lastStoneLine[i] == 1) lastLineNum++;
		if (R_lastStoneLine[i] == 1) R_lastLineNum++;
	}

	//最後に置いたのが隅の場合
	//優先順位
	//	リーチになる角(石がない列)
	//	真ん中
	//　斜めの端
	if (lastLineNum == 3) {
		for (int i = 0; i < LINE_SIZE; i++) {
			if ((lineStoneNum[i] == 1 && lastStoneLine[i] == 1)		//最後に置いたかつ他に何もない列
				|| (lineStoneNum[i] == 2 && lastStoneLine[i] == 1 && score[i] == 4)) //最後に置いたかつ次消えるのがおいてある 
			{
				if (board[LINES[i][0]] == 0) {
					_numberDesided = true;
					stoneNum = LINES[i][0];
					break;
				}
				else if (board[LINES[i][2]] == 0) {
					_numberDesided = true;
					stoneNum = LINES[i][2];
					break;
				}
				else tempStone = LINES[i][1];
			}
			if (i == 5 && board[4] == 0) {
				_numberDesided = true;
				stoneNum = 4;
				break;
			}
		}
		if (_numberDesided == false && tempStone != -1) {
			_numberDesided = true;
			stoneNum = tempStone;
		}
	}
	//最後に置いたのが真ん中の場合
	//優先順位　真ん中を通る列（真ん中→端）
	//			他の列
	else if (lastLineNum == 2) {
		for (int i = 0; i < LINE_SIZE; i++) {
			if ((lineStoneNum[i] == 1 && lastStoneLine[i] == 1)
				|| (lineStoneNum[i] == 2 && lastStoneLine[i] == 1 && score[i] == 4)) {
				if (i < 2) {
					if (board[LINES[i][1]] == 0) {
						_numberDesided = true;
						stoneNum = LINES[i][1];
					}
					else if (board[LINES[i][0]] == 0)tempStone = LINES[i][0];
					else tempStone = LINES[i][2];
				}
				else if (i < 4) {
					_numberDesided = true;
					if (score[4] > score[5] && board[LINES[i][2]] == 0)stoneNum = LINES[i][2];
					else if (board[LINES[i][0]] == 0)stoneNum = LINES[i][0];
					else stoneNum = LINES[i][2];
				}
				else {
					_numberDesided = true;
					if (score[2] > score[3] && board[LINES[i][2]] == 0)stoneNum = LINES[i][2];
					else if (board[LINES[i][0]] == 0)stoneNum = LINES[i][0];
					else stoneNum = LINES[i][2];
				}
				if (_numberDesided) {
					break;
				}
			}
		}
		if (_numberDesided == false && tempStone != -1) {
			_numberDesided = true;
			stoneNum = tempStone;
		}

	}
	/*あった場合*/
	if (_numberDesided) {
		if (board[stoneNum] == 0) {
			pos = stoneNum;
		}
		return pos;
	}

	
/*〇〇〇〇〇第四段階〇〇〇〇〇*/
	//（説明）
	//		相手次の次勝ち探索・・・-3と2が並んでいる場合
	//	　＜探索後＞
	//		あった→そこに置く
	//	　　ない　→最終段階へ
	for (int i = 0; i < 3; i++) {
		if (score[i] == -1 && lineStoneNum[i] == 2 && R_lastStoneLine[i] == 1) {
			for (int j = 0; j < 3; j++) {
				if (board[LINES[i][j]] == 0) {
					stoneNum = LINES[i][j];
					_numberDesided = true;
				}
			}
		}
	}
	/*あった場合*/
	if (_numberDesided) {
		pos = stoneNum;
		return pos;
	}

	
/*〇〇〇〇〇最終段階〇〇〇〇〇*/
	//（説明）
	//	　どこおいてもんーって時，相手の直前手で決める
	//		相手の直前手が隅
	//			中央→真ん中（近い順）→その他の順に優先的においていく
	//		相手の直前手が真ん中（後攻初手の時だけ注意）
	//		    隅(遠い順)→その他の順に優先的においていく
	//

	int PRIORITY_CENTER0[9] = { 4,1,3,5,7,0,2,6,8 };	//相手0
	int PRIORITY_CENTER2[9] = { 4,1,5,3,7,0,2,6,8 };	//相手2
	int PRIORITY_CENTER6[9] = { 4,3,7,1,5,0,2,6,8 };	//相手6
	int PRIORITY_CENTER8[9] = { 4,5,7,3,1,0,2,6,8 };	//相手8
	int PRIORITY_EDGE1[9] = { 4,6,8,0,2,1,3,5,7 };		//相手1
	int PRIORITY_EDGE3[9] = { 4,8,2,6,0,1,3,5,7 };		//相手3
	int PRIORITY_EDGE5[9] = { 4,0,6,2,8,1,3,5,7 };		//相手5
	int PRIORITY_EDGE7[9] = { 4,2,0,8,6,1,3,5,7 };		//相手7
	int* priority;										//優先順位を入れる配列を示すポインタ

	/*相手が端に打った場合*/
	if (R_lastLineNum == 3) {
		if (R_lastStoneLine[2] && R_lastStoneLine[4]) {
			priority = PRIORITY_CENTER0;
		}else if (R_lastStoneLine[2] && R_lastStoneLine[5]) {
			priority = PRIORITY_CENTER2;			
		}else if (R_lastStoneLine[3] && R_lastStoneLine[4]) {
			priority = PRIORITY_CENTER6;		
		}else {
			priority = PRIORITY_CENTER8;	
		}
	/*相手が真ん中に打った場合*/
	}else {
		if (R_lastStoneLine[0] && R_lastStoneLine[2]) {
			priority = PRIORITY_EDGE1;
		}else if (R_lastStoneLine[1] && R_lastStoneLine[4]) {
			priority = PRIORITY_EDGE3;
		}else if (R_lastStoneLine[1] && R_lastStoneLine[5]) {
			priority = PRIORITY_EDGE5;
		}else {
			priority = PRIORITY_EDGE7;
		}
	}
	/*優先順位で空いてる場所に置く*/
	for (int i = 0; i < BOARD_SIZE; i++) {
		if (board[priority[i]] == 0) {
			if (turnNum == 1 && i == 0 && R_lastLineNum == 2) {
				continue;
			}
			pos = priority[i];
			break;
		}
	}
	return pos;
}
//
//#include "TTTPlugin.h"
//#include <iostream>
//#include <random>
//
//const int LINE_SIZE = 8;
//const int LINES[8][3] = { { 1, 4, 7 }, { 3, 4, 5 }, { 0, 1, 2 }, { 6, 7, 8 },{ 0, 3, 6 },
//		{ 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
//
///// <summary>
///// 人間操作かどうかを返す
///// </summary>
///// <returns>人間ならtrue, 機械ならfalse</returns>
//bool IsHuman() {
//	return false;
//}
//
///// <summary>
///// 名前を返す
///// </summary>
///// <param name="buf">名前を格納する文字列</param>
///// <param name="bufsize">文字列バッファのサイズ</param>
//void GetName(char* buf, size_t bufsize) {
//	sprintf_s(buf, bufsize, "YukikoCPU");
//}
//
//
///// <summary>
///// 手を打つ
///// </summary>
///// <param name="board">盤の状態（値 1～3は自分駒，-1～-3は相手駒，次置くと1が消える）</param>
///// <returns>置く場所</returns>
//int MyTurn(int* board) {
//
//	int score[LINE_SIZE];			//それぞれの列の盤の数の和を獲得
//	int lastStoneLine[LINE_SIZE];
//	int R_lastStoneLine[LINE_SIZE];
//	int lineStoneNum[LINE_SIZE];
//
//	int turnNum = 0;	//ボード上の〇×の数を格納する（ターン数取得用）
//
//	int pos = -1;		//返す値を入れる変数
//	int winPoint, losePoint;
//	int lastNumber, R_lastNumber, stoneNum;
//	int tempStone = -1;
//	int lastLineNum = 0;
//	int R_lastLineNum = 0;
//
//	bool _numberDesided = false;
//
//	//ボード上の駒の数を数える
//	for (int i = 0; i < BOARD_SIZE; i++) {
//		if (board[i] != 0) {
//			turnNum++;
//		}
//		std::cout << board[i] << ",";
//	}
//
//	std::cout << std::endl;
//
//	//コンソールに駒の数を表示
//	std::cout << turnNum << std::endl;
//
//	if (turnNum == 0) {		//初手であった場合
//		pos = 3;
//		std::cout << "１手目だようとりま" << pos << "におく" << std::endl;
//		return pos;
//	}
//
//	//勝ち点負け点の定義
//	if (turnNum <= 5) winPoint = 3; else winPoint = 5;
//	if (turnNum < 5) losePoint = -3; else losePoint = -5;
//
//	//全てのラインにおいてlastStoneLine,score,lineStoneNumの取得
//	for (int i = 0; i < LINE_SIZE; i++) {
//		lastStoneLine[i] = 0;
//		R_lastStoneLine[i] = 0;
//		score[i] = 0;
//		lineStoneNum[i] = 0;
//		lastNumber = (int)(turnNum / 2);	//最後の数字
//		R_lastNumber = (int)((turnNum + 1) / 2); //相手の最期の数字
//		R_lastNumber *= -1;
//
//
//		for (int j = 0; j < 3; j++) {
//			score[i] += board[LINES[i][j]];
//			if (board[LINES[i][j]] == lastNumber) lastStoneLine[i] = 1;
//			if (board[LINES[i][j]] == R_lastNumber) R_lastStoneLine[i] = 1;
//			if (board[LINES[i][j]] != 0)lineStoneNum[i]++;
//		}
//
//		if (score[i] == winPoint) {
//			_numberDesided = true;
//			stoneNum = i;
//			std::cout << stoneNum << "	ＬＩＮＥに置けば勝てる" << std::endl;
//			break;
//		}
//		else if (score[i] == losePoint) {
//			_numberDesided = true;
//			stoneNum = i;
//			std::cout << stoneNum << "ＬＩＮＥに置かないとまける" << std::endl;
//		}
//	}
//
//	if (_numberDesided) {
//		for (int i = 0; i < 3; i++) {
//			if (board[LINES[stoneNum][i]] == 0) {
//				pos = LINES[stoneNum][i];
//			}
//		}
//		std::cout << pos << "に置く" << std::endl;
//		return pos;
//	}
//
//	//5手目の場合
//	if (turnNum == 4) {
//		if (board[2] == 0 && lineStoneNum[2] == 0) {
//			pos = 2;
//		}
//		else {
//			pos = 8;
//		}
//
//		std::cout << "5手目だよう" << pos << "におく" << std::endl;
//		return pos;
//	}
//
//	//-1と3が並んでいる列があったら
//	for (int i = 0; i < 3; i++) {
//		if (score[i] == 2 && lastStoneLine[i] == 1 && lineStoneNum[i] == 2) {
//			for (int j = 0; j < 3; j++) {
//				if (board[LINES[i][j]] == 0) {
//					stoneNum = LINES[i][j];
//					_numberDesided = true;
//				}
//			}
//		}
//	}
//
//	if (_numberDesided) {
//		pos = stoneNum;
//		std::cout << "-1と3がならんでるよう" << pos << "におく" << std::endl;
//		return pos;
//	}
//
//	//決まらない場合(主導権はこっち側)
//	for (int i = 0; i < LINE_SIZE; i++) {
//		if (lastStoneLine[i] == 1) lastLineNum++;
//		if (R_lastStoneLine[i] == 1) R_lastLineNum++;
//	}
//
//	std::cout << lastLineNum << "," << R_lastLineNum << std::endl;
//
//
//	//最後に置いたのが隅の場合
//	//優先順位
//	//	リーチになる角(石がない列)
//	//	真ん中
//	//　斜めの端
//	if (lastLineNum == 3) {
//		std::cout << "最後に置いたとこは隅" << std::endl;
//		for (int i = 0; i < LINE_SIZE; i++) {
//			if ((lineStoneNum[i] == 1 && lastStoneLine[i] == 1)		//最後に置いたかつ他に何もない列
//				|| (lineStoneNum[i] == 2 && lastStoneLine[i] == 1 && score[i] == 4)) //最後に置いたかつ次消えるのがおいてある 
//			{
//				std::cout << i << "ＬＩＮＥに置くのが得策" << std::endl;
//				if (board[LINES[i][0]] == 0) {
//					_numberDesided = true;
//					stoneNum = LINES[i][0];
//					std::cout << stoneNum << "に置こう" << std::endl;
//					break;
//				}
//				else if (board[LINES[i][2]] == 0) {
//					_numberDesided = true;
//					stoneNum = LINES[i][2];
//					std::cout << stoneNum << "に置こう" << std::endl;
//					break;
//				}
//				else tempStone = LINES[i][1];
//			}
//			if (i == 5 && board[4] == 0) {
//				_numberDesided = true;
//				stoneNum = 4;
//				std::cout << stoneNum << "に置こう" << std::endl;
//				break;
//			}
//		}
//		if (_numberDesided == false && tempStone != -1) {
//			_numberDesided = true;
//			stoneNum = tempStone;
//			std::cout << stoneNum << "におくかあ" << std::endl;
//		}
//	}
//	//最後に置いたのが真ん中の場合
//	//優先順位　真ん中を通る列（真ん中→端）
//	//			他の列
//	else if (lastLineNum == 2) {
//		std::cout << "最後に置いたとこは真ん中" << std::endl;
//		for (int i = 0; i < LINE_SIZE; i++) {
//			if ((lineStoneNum[i] == 1 && lastStoneLine[i] == 1)
//				|| (lineStoneNum[i] == 2 && lastStoneLine[i] == 1 && score[i] == 4)) {
//				std::cout << i << "ＬＩＮＥに置くのが得策" << std::endl;
//				if (i < 2) {
//					if (board[LINES[i][1]] == 0) {
//						std::cout << "真ん中の真ん中空いてたおこう！" << std::endl;
//						_numberDesided = true;
//						stoneNum = LINES[i][1];
//					}
//					else if (board[LINES[i][0]] == 0)tempStone = LINES[i][0];
//					else tempStone = LINES[i][2];
//				}
//				else if (i < 4) {
//					_numberDesided = true;
//					std::cout << "近い角とろう！" << std::endl;
//					if (score[4] > score[5] && board[LINES[i][2]] == 0)stoneNum = LINES[i][2];
//					else stoneNum = LINES[i][0];
//				}
//				else {
//					_numberDesided = true;
//					std::cout << "近い角とろう！" << std::endl;
//					if (score[2] > score[3] && board[LINES[i][2]] == 0)stoneNum = LINES[i][2];
//					else stoneNum = LINES[i][0];
//				}
//				if (_numberDesided) {
//					break;
//				}
//			}
//		}
//		if (_numberDesided == false && tempStone != -1) {
//			_numberDesided = true;
//			stoneNum = tempStone;
//			std::cout << stoneNum << "におくかあ" << std::endl;
//		}
//
//	}
//
//	if (_numberDesided) {
//		if (board[stoneNum] == 0) {
//			pos = stoneNum;
//		}
//
//		std::cout << "最後に置いたとこより" << pos << "におく" << std::endl;
//		return pos;
//	}
//
//	////2と-3が並んでいる列があったら
//	for (int i = 0; i < 3; i++) {
//		if (score[i] == -1 && lineStoneNum[i] == 2 && R_lastStoneLine[i] == 1) {
//			for (int j = 0; j < 3; j++) {
//				if (board[LINES[i][j]] == 0) {
//					stoneNum = LINES[i][j];
//					_numberDesided = true;
//				}
//			}
//		}
//	}
//	if (_numberDesided) {
//		pos = stoneNum;
//		std::cout << "2と-3がならんでるよう" << pos << "におく" << std::endl;
//		return pos;
//	}
//
//	//何しても決まらない場合
//	//第一希望　真ん中
//	//相手の直前手が隅		中央→真ん中（近い順）→その他の順に優先的においていく
//	//
//	//相手の直前手が真ん中　隅(遠い順)→その他の順に優先的においていく
//	//
//	int PRIORITY_CENTER0[9] = { 4,1,3,5,7,0,2,6,8 };
//	int PRIORITY_CENTER2[9] = { 4,1,5,3,7,0,2,6,8 };
//	int PRIORITY_CENTER6[9] = { 4,3,7,1,5,0,2,6,8 };
//	int PRIORITY_CENTER8[9] = { 4,5,7,3,1,0,2,6,8 };
//	int PRIORITY_EDGE1[9] = { 4,6,8,0,2,1,3,5,7 };
//	int PRIORITY_EDGE3[9] = { 4,8,2,6,0,1,3,5,7 };
//	int PRIORITY_EDGE5[9] = { 4,0,6,2,8,1,3,5,7 };
//	int PRIORITY_EDGE7[9] = { 4,2,0,8,6,1,3,5,7 };
//
//	int* priority;
//
//	if (R_lastLineNum == 3) {
//		std::cout << "相手端においたのかあじゃ真ん中優先で" << std::endl;
//		if (R_lastStoneLine[2] && R_lastStoneLine[4]) {
//			std::cout << "相手0においたのかあじゃ13優先で" << std::endl;
//			priority = PRIORITY_CENTER0;
//		}
//		else if (R_lastStoneLine[2] && R_lastStoneLine[5]) {
//			std::cout << "相手2においたのかあじゃ15優先で" << std::endl;
//			priority = PRIORITY_CENTER2;
//		}
//		else if (R_lastStoneLine[3] && R_lastStoneLine[4]) {
//			std::cout << "相手6においたのかあじゃ37優先で" << std::endl;
//			priority = PRIORITY_CENTER6;
//		}
//		else {
//			std::cout << "相手8においたのかあじゃ57優先で" << std::endl;
//			priority = PRIORITY_CENTER8;
//		}
//	}
//	else {
//		std::cout << "相手真ん中においたのかあじゃ端優先で" << std::endl;
//
//		if (R_lastStoneLine[0] && R_lastStoneLine[2]) {
//			std::cout << "相手1においたのかあじゃ68優先で" << std::endl;
//			priority = PRIORITY_EDGE1;
//		}
//		else if (R_lastStoneLine[1] && R_lastStoneLine[4]) {
//			std::cout << "相手3においたのかあじゃ82優先で" << std::endl;
//			priority = PRIORITY_EDGE3;
//		}
//		else if (R_lastStoneLine[1] && R_lastStoneLine[5]) {
//			std::cout << "相手5においたのかあじゃ06優先で" << std::endl;
//			priority = PRIORITY_EDGE5;
//		}
//		else {
//			std::cout << "相手真ん中か7においたのかあじゃ02優先で" << std::endl;
//			priority = PRIORITY_EDGE7;
//		}
//	}
//	for (int i = 0; i < BOARD_SIZE; i++) {
//		if (board[priority[i]] == 0) {
//			if (turnNum == 1 && i == 0 && R_lastLineNum == 2) {
//				continue;
//			}
//			pos = priority[i];
//			break;
//		}
//	}
//
//	std::cout << "正直どこでもいいけど" << pos << "におく" << std::endl;
//	return pos;
//}