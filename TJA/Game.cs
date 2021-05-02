using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amaoto;
using static DxLibDLL.DX;
using System.IO;
using System.Drawing;
using System;

namespace TJA
{
    public class Game
    {
        public void Main()
        {

            Input input = new Input();
            Counter Exit = new Counter(1, 4, 1000000, false);
            Counter tennmetu = new Counter(0, 11, 50000, false);
            Counter SoulAnime = new Counter(0, 226, 2500, false);
            Counter Opacity = new Counter(0, 255, 1000, false);
            Counter ATK = new Counter(0, 640, 3000, false);
            Counter ATK2 = new Counter(0, 640, 3000, false);
            Counter ATKA = new Counter(0, 100, 5000, false);
            Counter ATKA2 = new Counter(0, 100, 5000, false);
            ctキー制限 = new Counter(0, 1, 100000, false);
            ctキー制限.Start();
            ctキー制限2 = new Counter(0, 1, 100000, false);
            ctキー制限2.Start();
            var dirPath = @"SystemFile\" + @"クラス別\" + @"game\" + @"Chara\";

            Conf(@"Config.txt");
            File.Delete(dirPath + "LoadedChara.txt");
            File.Delete(dirPath + "LoadedChara2.txt");
            foreach (string file2 in Directory.GetFiles(dirPath, "Chara_" + headers.name.ToString() + "*.png*", SearchOption.AllDirectories))
            {
                File.AppendAllText(dirPath + "実際に使われたキャラ.txt", file2 + "\n");
                Chara = new Texture(file2);
                // File.AppendAllLines(dirPath + "SongList.list",file2.Split());
            }
            foreach (string file3 in Directory.GetFiles(dirPath, "Chara_" + "*.png*", SearchOption.AllDirectories))
            {
                File.AppendAllText(dirPath + "読み込んだキャラ画像一覧.txt", file3 + "\n");

            }

            FontFamily ff = new FontFamily("JFドット東雲ゴシック14");
            FontRender fr = new FontRender(ff, 15, 5);
            Texture txTest = fr.GetTexture(headers.tati);
            Texture tx適 = fr.GetTexture(headers.tati2);
            Texture txこうどう1 = fr.GetTexture("＊"+headers.tati6);
            Texture txこうどう2 = fr.GetTexture("＊" + headers.tati7);
            Texture txこうどう3 = fr.GetTexture("＊" + headers.tati8);
            Texture txこうどう4 = fr.GetTexture("＊" + headers.tati9);

            Texture txこうどう5 = fr.GetTexture("＊" + "あなたは"+headers.tati2+"を" + "\n"+headers.tati6+"した。");
            Texture txこうどう6 = fr.GetTexture("＊" + "あなたは" + headers.tati2 + "を" + "\n" + headers.tati7 + "した。");
            Texture txこうどう7 = fr.GetTexture("＊" + "あなたは" + headers.tati2 + "を" + "\n" + headers.tati8 + "した。");
            Texture txこうどう8 = fr.GetTexture("＊" + "あなたは" + headers.tati2 + "を" + "\n" + headers.tati9 + "した。");
            var lineCount = File.ReadAllLines(dirPath + "読み込んだキャラ画像一覧.txt").Count();
            string SkinPath = @"SystemFile\クラス別\";
            Texture Back = new Texture(SkinPath + @"game\" + @"Back.png");
            Texture select = new Texture(SkinPath + @"game\" + @"bar.png");
            Texture Soul = new Texture(SkinPath + @"game\" + @"Soul_Overlay.png");
            Texture FRSK = new Texture(SkinPath + @"game\" + @"Chara.png");
            Texture HP = new Texture(SkinPath + @"game\" + @"HP.png");
            Texture A = new Texture(SkinPath + @"game\" + @"ATTACK.png");
            Texture Atv = new Texture(SkinPath + @"game\" + @"atb.png");
            Sound 選択音 = new Sound(SkinPath + @"game\" + "select.ogg");
            Sound 決定音 = new Sound(SkinPath + @"game\" + "selected.ogg");
            hp = 10;

            Back.Opacity = 0;
            Chara.Opacity = 0;
            select.Opacity = 0;
            A.ScaleX = ATKA.Value / 100f;
            while (ProcessMessage() == 0 && ScreenFlip() == 0 && ClearDrawScreen() == 0)
            {
                Opacity.Tick();
                SoulAnime.Tick();
                ATKA.Tick();
                ATKA2.Tick();
                // ATK.Start();
                ATK.Tick();
                ATK2.Tick();
                //SoulAnime.Start();
                tennmetu.Tick();
                ctキー制限.Tick();
                ctキー制限2.Tick();
                tennmetu.Start();
                ChangeFont("JFドット東雲ゴシック14");

                //SetFontSize(20);
                Exit.Tick();
                //KEYS
                if (input.IsPushingKey(KEY_INPUT_ESCAPE))
                {
                    Exit.Start();
                    //DxLib_End();
                    DrawString(0, 0, "Exit..." + Exit.Value, GetColor(255, 255, 255));

                }
                else
                {
                    Exit.Stop();
                    Exit.Value = 1;
                }
                if (Exit.Value == Exit.End)
                {
                    DxLib_End();
                }

                Back.Draw(0, 0);
                Chara.Draw(0, 0);
                FRSK.Draw(300, 195);

               // DrawString(0, 0, nダメージ + "", GetColor(255, 255, 255));
                #region [SoulANime(あほコード過ぎて草]
                if (tennmetu.Value >= 0)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                else if (tennmetu.Value >= 2)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                if (tennmetu.Value >= 2)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                else if (tennmetu.Value >= 3)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                if (tennmetu.Value >= 3)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                else if (tennmetu.Value >= 5)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                if (tennmetu.Value >= 5)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                else if (tennmetu.Value >= 7)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                if (tennmetu.Value >= 7)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                else if (tennmetu.Value >= 9)
                {
                    FRSK.Opacity = 1;
                    Soul.Opacity = 0;
                }
                if (tennmetu.Value >= 9)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                else if (tennmetu.Value >= 11)
                {
                    FRSK.Opacity = 0;
                    Soul.Opacity = 1;
                }
                #endregion
                if (tennmetu.Value == tennmetu.End)
                {
                    SoulAnime.Start();
                }
                if (SoulAnime.Value == SoulAnime.End)
                {
                    txTest.Draw(38, 384);
                    Opacity.Start();
                    input.Update();
                }
                else
                {
                    Soul.Draw((float)(300 - SoulAnime.Value / 0.8828125), 195 + SoulAnime.Value);
                }
                Back.Opacity = Opacity.Value / 255f;
                Chara.Opacity = Opacity.Value / 255f;
                select.Opacity = Opacity.Value / 255f;
                HP.Opacity = Opacity.Value / 255f;
                #region [あ、ゴミコードｫ！！♡]
                if (!this.b行動[0])
                {
                    if (n現在の選択行R == 0 || n現在の選択行R == 1)
                    {
                        if (n現在の選択行R == 1 && ctキー制限.Value == 1)
                        {

                            if (input.IsPushedKey(KEY_INPUT_RETURN))
                            {
                                ATKA.Value = 0;
                                ATKA2.Value = 0;
                                ATK.Value = 0;
                                ATK2.Value = 0;
                                n現在の選択行R = 0;
                                tキー入力R(2);
                                決定音.Play();
                            }
                        }
                        else if (n現在の選択行 == 0 && ctキー制限.Value == ctキー制限.End)
                        {

                            if (input.IsPushedKey(KEY_INPUT_RIGHT))
                            {
                                tキー入力(1);
                                選択音.Play();
                            }
                            if (input.IsPushedKey(KEY_INPUT_RETURN))
                            {
                                tキー入力R(1);
                                決定音.Play();
                            }
                        }
                        if (n現在の選択行 == 1 && ctキー制限.Value == ctキー制限.End)
                        {

                            if (input.IsPushedKey(KEY_INPUT_LEFT))
                            {
                                tキー入力(0);
                                選択音.Play();
                            }
                            if (input.IsPushedKey(KEY_INPUT_RIGHT))
                            {
                                tキー入力(2);
                                選択音.Play();
                            }
                        }
                        if (n現在の選択行 == 2 && ctキー制限.Value == ctキー制限.End)
                        {

                            if (input.IsPushedKey(KEY_INPUT_LEFT))
                            {
                                tキー入力(1);
                                選択音.Play();
                            }
                            if (input.IsPushedKey(KEY_INPUT_RIGHT))
                            {
                                tキー入力(3);
                                選択音.Play();
                            }
                        }
                        if (n現在の選択行 == 3 && ctキー制限.Value == ctキー制限.End)
                        {

                            if (input.IsPushedKey(KEY_INPUT_LEFT))
                            {
                                tキー入力(2);
                                選択音.Play();
                            }

                        }
                    }
                }
                   
                
                #endregion
                #region [選択行系]
                {
                    if (!this.b行動[0])
                    {
                        if (this.n現在の選択行 == 0)
                        {
                            select.Draw(0, 0, new Rectangle(0, 0, 167, 462));
                            Soul.Draw((float)(300 - SoulAnime.Value / 0.8828125), 195 + SoulAnime.Value);
                        }
                        if (this.n現在の選択行 == 1)
                        {
                            select.Draw(167, 0, new Rectangle(167, 0, 151, 462));
                            Soul.Draw(191, 419);
                            if (input.IsPushedKey(KEY_INPUT_RETURN))
                            {
                                b行動[0] = true;
                                ctキー制限.Start();
                                ctキー制限.Value = 0;
                                決定音.Play();
                            }
                        }
                        if (this.n現在の選択行 == 2)
                        {
                            select.Draw(318, 0, new Rectangle(318, 0, 144, 462));
                            Soul.Draw(345, 419);
                        }
                        if (this.n現在の選択行 == 3)
                        {
                            select.Draw(463, 0, new Rectangle(463, 0, 177, 462));
                            Soul.Draw(495, 419);
                        }
                        if (n現在の選択行R == 1)
                        {
                            tx適.Draw((float)(64 * 1.3), 259);
                            Soul.Draw(59, 254);
                        }

                        if (n現在の選択行R == 2)
                        {
                            ATKA.Start();
                            A.ReferencePoint = ReferencePoint.Center;

                            A.Draw((float)(640 / 2), (float)(480 / 2));
                            if (ATKA.Value == 100)
                            {

                                Atv.Draw(0 + ATK.Value, 0);
                            }
                            else { A.ScaleX = ATKA.Value / 100f; }
                            if (ATKA.Value == 99)
                            {
                                ATK.Start();
                                ATK2.Start();
                            }
                            if (ATK2.Value == ATK2.End)
                            {
                                ATKA2.Start();
                                A.ScaleX = 100 / 100f - ATKA2.Value / 100f;
                            }

                            if (ATKA2.Value == ATKA2.End)
                            {
                                n現在の選択行R = 0;

                                //n現在の選択行 = 0;

                            }
                            if (input.IsPushedKey(KEY_INPUT_RETURN))
                            {
                                ATK.Stop();

                            }
                        }
                    }
                   
                    

                }
                #endregion
                //行動画面

                if (b行動[0])
                {
                    if(testtttt==false)
                    {
                        Soul.Draw(59, 254);
                        tx適.Draw((float)(64 * 1.3), 259);
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            決定音.Play();
                            testtttt = true;
                            b行動[1] = true;
                        }
                    }

                   
                }
                 if (b行動[1])
                {
                    int x = n現在の選択行こうどう * 305;
                    int y = n現在の選択行こうどう2 * 281;
                    DrawString(0, 0, "aa", GetColor(255, 255, 255));
                    txこうどう1.Draw((float)(64 * 1.3), 259);
                    txこうどう2.Draw(64*6, 259);
                    txこうどう3.Draw((float)(64 * 1.3), (float)(259 * 1.1));
                    txこうどう4.Draw((float)(64 *6), (float)(259 * 1.1));
                    Soul.Draw(((59)+x),((254)+n現在の選択行こうどう2*27));
                    if (this.n現在の選択行こうどう==1&&input.IsPushedKey(KEY_INPUT_LEFT) && this.ctキー制限.Value == this.ctキー制限.End)
                    {
                        選択音.Play();
                        ctキー制限.Start();
                        ctキー制限.Value = 0;
                        this.n現在の選択行こうどう = 0;

                    }
                    if (this.n現在の選択行こうどう == 0 && input.IsPushedKey(KEY_INPUT_RIGHT) && this.ctキー制限.Value == this.ctキー制限.End)
                    {
                        選択音.Play();
                        ctキー制限.Start();
                        ctキー制限.Value = 0;
                        this.n現在の選択行こうどう = 1;

                    }
                    if (this.n現在の選択行こうどう2==0&& input.IsPushedKey(KEY_INPUT_DOWN) && this.ctキー制限.Value == this.ctキー制限.End)
                    {
                        選択音.Play();
                        ctキー制限.Start();
                        ctキー制限.Value = 0;
                        this.n現在の選択行こうどう2 = 1;
  
                    }
                    if (this.n現在の選択行こうどう2 == 1 && input.IsPushedKey(KEY_INPUT_UP) && this.ctキー制限.Value == this.ctキー制限.End)
                    {
                        選択音.Play();
                        ctキー制限.Start();
                        ctキー制限.Value = 0;
                        this.n現在の選択行こうどう2 = 0;
   
                    }
                    if (this.n現在の選択行こうどう==0)
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[1] = false;
                            b行動[2] = true;
                            決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 1)
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[1] = false;
                            b行動[2] = true;
                            決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 0&& this.n現在の選択行こうどう2 == 1)
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[1] = false;
                            b行動[2] = true;
                            決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 1&& this.n現在の選択行こうどう2 == 1)
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[1] = false;
                            b行動[2] = true;
                            決定音.Play();
                        }
                    }
                }
                if (b行動[2])
                {
                    if (this.n現在の選択行こうどう == 0)
                    {
                        txこうどう5.Draw((float)(64 ), 259);
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[0] = false;
                            b行動[1] = false;
                            b行動[2] = false;
                            testtttt = false; 決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 1)
                    {
                        txこうどう6.Draw((float)(64 ), 259);
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[0] = false;
                            b行動[1] = false;
                            b行動[2] = false;
                            testtttt = false; 決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 0 && this.n現在の選択行こうどう2 == 1)
                    {
                        txこうどう7.Draw((float)(64 ), 259);
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[0] = false;
                            b行動[1] = false;
                            b行動[2] = false;
                            testtttt = false; 決定音.Play();
                        }
                    }
                    else if (this.n現在の選択行こうどう == 1 && this.n現在の選択行こうどう2 == 1)
                    {
                        txこうどう8.Draw((float)(64 ), 259);
                        if (input.IsPushedKey(KEY_INPUT_RETURN) && this.ctキー制限.Value == this.ctキー制限.End)
                        {
                            ctキー制限.Start();
                            ctキー制限.Value = 0;
                            b行動[0] = false;
                            b行動[1] = false;
                            b行動[2] = false;
                            testtttt = false; 決定音.Play();
                        }
                    }

                }

                #region[判定機能]
                {
                    if (ATK.Value <= 0)//0から65最低ダメ
                    {

                    }
                    else if (ATK.Value <= 65)//0から65最低ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1100;

                        }
                    }
                    else if (ATK.Value <= 176)//65から176中ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1200;

                        }
                    }
                    else if (ATK.Value <= 252)//176から252高ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1300;

                        }
                    }
                    else if (ATK.Value <= 288)//252から288最高ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1500;

                        }
                    }
                    else if (ATK.Value <= 363)//252から288高ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1300;

                        }
                    }
                    else if (ATK.Value <= 467)//252から288中ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1200;

                        }
                    }
                    else if (ATK.Value <= 524)//252から288最低ダメ
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 1100;

                        }
                    }
                    else
                    {
                        if (input.IsPushedKey(KEY_INPUT_RETURN))
                        {
                            nダメージ = 0;

                        }
                        nダメージ = 0;
                    }
                }
                #endregion
                if (Opacity.Value == Opacity.End)
                {
                    bgmyou++;
                    if (bgmyou == 1)
                    {
                        if(headers.tati3=="")
                        {
                            headers.tati3 = "null";
                        }
                        else
                        {
                        PlaySound(SkinPath + @"BGM\" + headers.tati3+"."+headers.tati4, DX_PLAYTYPE_LOOP);
                        }

                    }
                    
                }
                DrawString(0, 0, "BGM:" + headers.tati3, GetColor(255, 255, 255));
                HP.Draw(275, 385);
                hp = headers.tati5;
                HP.ScaleX = hp / 20f;
            }

            DxLib_End();
        }
        public static void Conf(string tntn)
        {
            if (File.Exists(tntn))
            {
                var stream = new StreamReader(tntn, Encoding.GetEncoding("UTF-8"));
                var strOpenTexts = stream.ReadToEnd();
                var str = strOpenTexts.Replace(Environment.NewLine, "\n");
                var strText = str.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var text in strText)
                {
                    string[] strSplitComma = text.Split(new char[] { ':' });

                    if (strSplitComma.Length > 1)
                    {
                        if (strSplitComma[0].Equals("Chara")) headers.name = strSplitComma[1];
                        else if (strSplitComma[0].Equals("name")) headers.tati = strSplitComma[1];
                        else if (strSplitComma[0].Equals("適の名前")) headers.tati2 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("使用するbgm")) headers.tati3 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("使用するbgmの拡張子")) headers.tati4 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("こうどう1")) headers.tati6 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("こうどう2")) headers.tati7 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("こうどう3")) headers.tati8 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("こうどう4")) headers.tati9 = strSplitComma[1];
                        else if (strSplitComma[0].Equals("最大体力")) headers.tati5 = int.Parse(strSplitComma[1]);
                    }
                }
            }
        }
        private bool testtttt;
        private int nダメージ;
        private bool battle;
        private int bgmyou;
        public Counter ctキー制限;
        public Counter ctキー制限2;
        private int n現在の選択行;
        private int n現在の選択行R;
        private static Texture Chara;
        public static header headers = new header();
        private bool[] b行動 = {false,false, false, false };
        private int n現在の選択行こうどう;
        private int n現在の選択行こうどう2;
        public class header
        {
            public string name ="**";
            public string tati;
            public string tati2;
            public string tati3;
            public string tati4;
            public string tati6;
            public string tati7;
            public string tati8;
            public string tati9;
            public int tati5;
        }
        public void tキー入力(int 行)
        {
            
            n現在の選択行 = 行;
            ctキー制限.Start();
            ctキー制限.Value = 0;
        }
        public void tキー入力R(int 行)
        {

            n現在の選択行R = 行;
            ctキー制限.Start();
            ctキー制限.Value = 0;
        }
        public void tキー入力D(int ダメージ)
        {

            nダメージ = ダメージ;
            ctキー制限2.Start();
            ctキー制限2.Value = 0;
        }
        float hp;
    }
}