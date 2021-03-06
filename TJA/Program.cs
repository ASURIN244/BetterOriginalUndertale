using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amaoto;
using static DxLibDLL.DX;
using System.IO;
using System.Drawing;

namespace TJA
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WINDOW_W = 640;
            const int WINDOW_H = 480;

            SetOutApplicationLogValidFlag(TRUE); //ログ出力するか
            ChangeWindowMode(TRUE);  //ウィンドウモード切替
            SetGraphMode(WINDOW_W, WINDOW_H, 32); //ウィンドウサイズ決める
            SetMainWindowText("BetterUnderTale Start Up..."); //ソフト名決める
            SetWindowStyleMode(7); //画面最大化できるようにする
            SetWindowSizeChangeEnableFlag(TRUE); //ウィンドウサイズ変えれるようにする
            SetAlwaysRunFlag(TRUE); //ソフトがアクティブじゃなくても処理続行するようにする
            SetWindowSizeExtendRate(1f); //起動時のウィンドウサイズを設定 ( 1 = 100%)
            SetUseMaskScreenFlag(TRUE); //書かなくても良い。マスク使うときだけ書こう

            DxLib_Init();
            Game game = new Game();
            SetDrawScreen(-2);

            while (ProcessMessage() == 0 && ScreenFlip() == 0 && ClearDrawScreen() == 0)
            {
                ふち1 = DxLibDLL.DX.GetMouseWheelRotVol();
                if (ふち1 == 1)
                {

                    ふち1 = 0;

                }
                game.Main();
            }

            DxLib_End();
        }
       public static int ふち1;
    }
}
