using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class Control
    {
        private SaveData sd = new SaveData();

        // Parameter for tetris field
        public int width = 15;
        public int length = 28;
        public int death_range = 5;

        public int massSize = 16;
        public int[] anchor = new int[2] {120, 40};

        // Calcurate 
        public int[,] massData;

        // Shift
        public string shift = null;

        // Kinds of mass shape
        ////// 改善の余地あり．最初がランダムにならない．
        // 原因    : https://ict119.com/c-random/
        // 解決案  : https://kitigai.hatenablog.com/entry/2018/01/14/010000 
        private Random r = new Random();

        public int score = 0;
        public int bestScore = 0;
        public bool switch_game_over = false;
        private bool switch_touch_obj = false;
        private int obj_shape = 0;
        private int[,] obj_pos;
        private int[] obj_anchor = new int[2] {0, 0};

        public void init()
        {
            score = 0;
            bestScore = sd.getBestScore();
            massData = new int[length, width];
            for (int i = 0; i < length; i++) for (int j = 0; j < width; j++) massData[i, j] = 0;
            create_object();
        }

        public void update_massData()
        {
            if (shift == "A") shift_left();
            if (shift == "D") shift_right();
            if (shift == "W") shift_rotate();
            if (shift == "S") shift_down();
        }

        // 移動させるマスの位置をi, jとする

        private void shift_left()
        {
            // Check touching or not
            for (int i = 0; i < length; i++)
            {
                for (int j = 1; j < width; j++)
                {
                    if (massData[i, 0] == 1)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                    if (massData[i, j] == 1 && massData[i, j - 1] == 2)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                }
                if (switch_touch_obj) break;
            }

            if (switch_touch_obj == false)
            {
                obj_anchor[1] = obj_anchor[1] - 1;
                for (int i = 0; i < length; i++)
                {
                    for (int j = 1; j < width; j++)
                    {
                        if (massData[i, j] != 2 && massData[i, j - 1] == 0)
                        { 
                                massData[i, j - 1] = massData[i, j];
                                massData[i, j] = 0;
                        }
                    }
                }
            }

            if (switch_touch_obj == true)
            {
                switch_touch_obj = false;
            }
        }

        private void shift_right()
        {
            // Check touching or not
            for (int i = 0; i < length; i++)
            {
                for (int j = width - 2; j > 0; j--)
                {
                    if (massData[i, width - 1] == 1)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                    if (massData[i, j] == 1 && massData[i, j + 1] == 2)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                }
                if (switch_touch_obj) break;
            }

            if (switch_touch_obj == false)
            {
                obj_anchor[1] = obj_anchor[1] + 1;
                for (int i = 0; i < length; i++)
                {
                    for (int j = width - 2; j > -1; j--)
                    {
                        if (massData[i, j] != 2 && massData[i, j + 1] == 0)
                        {
                            massData[i, j + 1] = massData[i, j];
                            massData[i, j] = 0;
                        }
                    }
                }
            }

            if (switch_touch_obj == true)
            {
                switch_touch_obj = false;
            }
        }

        private void shift_down()
        {
            // Check touching or not
            for (int j = 0; j < width; j++)
            {
                for (int i = length - 2; i > -1; i--)
                {
                    if (massData[length - 1, j] == 1)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                    if (massData[i, j] == 1 && massData[i + 1, j] == 2)
                    {
                        switch_touch_obj = true;
                        break;
                    }
                }
                if (switch_touch_obj) break;
            }

            // Shift down
            if (switch_touch_obj == false)
            {
                obj_anchor[0] = obj_anchor[0] + 1;
                for (int j = 0; j < width; j++)
                {
                    for (int i = length - 2; i > -1; i--)
                    {
                        if (massData[i, j] != 2 && massData[i + 1, j] == 0)
                        {
                            massData[i + 1, j] = massData[i, j];
                            massData[i, j] = 0;
                        }
                    }
                }
            }

            if (switch_touch_obj == true)
            {
                for (int j = 0; j < width; j++) for (int i = length - 1; i > -1; i--) if (massData[i, j] == 1) massData[i, j] = 2;

                delete_line();
                judge_game_over();
                judge_best_score();

                if (switch_game_over == false) create_object();
                switch_touch_obj = false;
            }
        }

        private void shift_rotate()
        {
            int x = obj_anchor[0]; int y = obj_anchor[1];
            if (0  <= obj_shape && obj_shape <= 0 ) if (-1<y && y<width-3 && x<length-3) judge_rotate(x, y, 4);
            if (1  <= obj_shape && obj_shape <= 5 ) if (-1 < y && y < width - 2 && x < length - 2) judge_rotate(x, y, 3);
            
            if (7  <= obj_shape && obj_shape <= 10) if (-1<y && y<width-3 && x<length-3) judge_rotate(x, y, 4);
            if (11 <= obj_shape && obj_shape <= 13) if (-1 < y && y < width - 2 && x < length - 2) judge_rotate(x, y, 3);

            if (14 <= obj_shape && obj_shape <= 14) if (-1 < y && y < width - 4 && x < length - 4) judge_rotate(x, y, 5);
            if (15 <= obj_shape && obj_shape <= 16) if (-1 < y && y < width - 3 && x < length - 3) judge_rotate(x, y, 4);
            if (18 <= obj_shape && obj_shape <= 19) if (-1 < y && y < width - 2 && x < length - 2) judge_rotate(x, y, 3);

            if (20 <= obj_shape && obj_shape <= 20) if (-1 < y && y < width - 4 && x < length - 4) judge_rotate(x, y, 5);
            if (21 <= obj_shape && obj_shape <= 21) if (-1 < y && y < width - 3 && x < length - 3) judge_rotate(x, y, 4);

            if (28 <= obj_shape && obj_shape <= 29) if (-1 < y && y < width - 3 && x < length - 3) judge_rotate(x, y, 4);

            // 6, 17, 22, 23, 24, 25, 26 ; no rotate
        }

        private void create_object()
        {
            if (score>=0)   obj_shape = r.Next(7);
            if (score>=100) obj_shape = r.Next(13);
            if (score >= 200) obj_shape = r.Next(19);
            if (score >= 300) obj_shape = r.Next(25);
            if (score >= 400) obj_shape = r.Next(29);
            obj_library();

            for (int i = 0; i < obj_pos.GetLength(0); i++)  massData[obj_pos[i, 0], obj_pos[i, 1]] = 1;
        }

        private void delete_line()
        {
            int count_delete_line = 0;
            for (int i = length-1; i > -1 ; i--)
            {
                int sum = 0;
                for (int j = 0; j < width; j++) sum = sum + massData[i, j];

                if (sum == 2 * width) count_delete_line = count_delete_line + 1;
                if (sum < 2 * width && count_delete_line > 0) for (int j = 0; j < width; j++) massData[i + count_delete_line, j] = massData[i, j];

            }
            score = score + count_delete_line * 10;
        }

        private void judge_game_over()
        {
            for (int i=0; i<death_range; i++) for (int j=0; j<width; j++) if (massData[i, j] == 2) switch_game_over = true;
        }

        private void judge_best_score()
        {
            if (score > bestScore) { bestScore = score; sd.saveBestScore(bestScore); }
            else { }
        }

        private void judge_rotate(int anchorX, int anchorY, int size)
        {
            int[, ] rotatedData = new int[size, size];
            bool switch_rotate = true;

            // rotated_dataの初期化
            for (int i=0; i<size; i++) for (int j = 0; j < size; j++) rotatedData[i, j] = 0;

            // 当たり判定
            for (int i=0; i<size; i++) for (int j = 0; j < size; j++) 
                    if (massData[i + anchorX, j + anchorY] == 1)
                    {
                        if (massData[anchorX + j, anchorY + size - i - 1] == 1 || massData[anchorX + j, anchorY + size - i - 1] == 0) rotatedData[j, size - i - 1] = 1;
                        if (massData[anchorX + j, anchorY + size - i - 1] == 2) switch_rotate = false;
                    }

            // 当たり判定(switch_rotate)でtrueになった場合，rotated_dataをmassDataに適用．
            if (switch_rotate)
            {
                for (int i = anchorX; i < anchorX + size; i++) for (int j = anchorY; j < anchorY + size; j++) if (massData[i, j] == 1) massData[i, j] = 0;

                for (int i = anchorX; i < anchorX + size; i++) for (int j = anchorY; j < anchorY + size; j++) if (rotatedData[i - anchorX, j - anchorY] == 1) massData[i, j] = rotatedData[i-anchorX, j-anchorY];
            }
        }

        private void obj_library()
        {
            int y = width / 2;

            // ###### define anchor ######
            // lebel 1
            // Define values of anchor
            if (obj_shape == 0) { obj_anchor[0] = 1; obj_anchor[1] = y - 2; }
            if (1 <= obj_shape && obj_shape <= 5) { obj_anchor[0] = 2; obj_anchor[1] = y - 1; }

            // lebel 2
            // Define values of anchor
            if (7 <= obj_shape && obj_shape <= 10) { obj_anchor[0] = 1; obj_anchor[1] = y - 2; }
            if (11 <= obj_shape && obj_shape <= 13) { obj_anchor[0] = 2; obj_anchor[1] = y - 1; }

            // lebel 3
            // Define values of anchor
            if (obj_shape == 14) { obj_anchor[0] = 0; obj_anchor[1] = y - 2; }
            if (15 <= obj_shape && obj_shape <= 16) { obj_anchor[0] = 1; obj_anchor[1] = y - 2; }
            if (17 <= obj_shape && obj_shape <= 19) { obj_anchor[0] = 2; obj_anchor[1] = y - 1; }

            // lebel 4
            // Define values of anchor
            if (obj_shape == 20) { obj_anchor[0] = 0; obj_anchor[1] = y - 2; }
            if (21 <= obj_shape && obj_shape <= 22) { obj_anchor[0] = 1; obj_anchor[1] = y - 2; }
            if (23 <= obj_shape && obj_shape <= 25) { obj_anchor[0] = 2; obj_anchor[1] = y - 1; }

            // lebel 5
            // Define values of anchor
            if (obj_shape == 27) { obj_anchor[0] = 0; obj_anchor[1] = y - 2; }
            if (28 <= obj_shape && obj_shape <= 29) { obj_anchor[0] = 1; obj_anchor[1] = y - 2; }


            // ###### obj library ######
            // lebel 1
            // Anchor size 4
            if (obj_shape == 0) obj_pos = new int[4, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y } };

            // Anchor size 3
            if (obj_shape == 1) obj_pos = new int[4, 2] { { 2, y }, { 3, y }, { 3, y + 1 }, { 4, y + 1 } };
            if (obj_shape == 2) obj_pos = new int[4, 2] { { 2, y }, { 3, y }, { 3, y - 1 }, { 4, y - 1 } };
            if (obj_shape == 3) obj_pos = new int[4, 2] { { 2, y }, { 3, y }, { 4, y }, { 3, y + 1 } };
            if (obj_shape == 4) obj_pos = new int[4, 2] { { 2, y }, { 3, y }, { 4, y }, { 4, y + 1 } };
            if (obj_shape == 5) obj_pos = new int[4, 2] { { 2, y }, { 3, y }, { 4, y }, { 4, y - 1 } };
            
            // Anchor size 2
            if (obj_shape == 6) obj_pos = new int[4, 2] { { 3, y }, { 3, y + 1 }, { 4, y }, { 4, y + 1 } };


            // lebel 2

            // Anchor size 4
            if (obj_shape == 7) obj_pos = new int[5, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y }, { 1, y + 1 } };
            if (obj_shape == 8) obj_pos = new int[5, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y }, { 2, y + 1 } };
            if (obj_shape == 9) obj_pos = new int[5, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y }, { 3, y + 1 } };
            if (obj_shape == 10) obj_pos = new int[5, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y }, { 4, y + 1 } };

            // Anchor size 3
            if (obj_shape == 11) obj_pos = new int[5, 2] { { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 4, y }, { 4, y - 1 } };
            if (obj_shape == 12) obj_pos = new int[5, 2] { { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 2, y }, { 4, y } };
            if (obj_shape == 13) obj_pos = new int[6, 2] { { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 4, y }, { 4, y - 1 }, { 3, y } };


            // lebel 3

            // Anchor size 5
            if (obj_shape == 14) obj_pos = new int[5, 2] { {0, y }, { 1, y }, { 2, y }, { 3, y }, { 4, y }};

            // Anchor size 4
            if (obj_shape == 15) obj_pos = new int[7, 2] { { 1, y }, { 2, y }, { 3, y }, { 4, y }, { 4, y + 1 }, { 4, y - 1 }, { 4, y - 2 } };
            if (obj_shape == 16) obj_pos = new int[7, 2] { { 1, y + 1 }, { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 4, y }, { 4, y - 1 }, { 4, y - 2 } };

            // Anchor size 3
            if (obj_shape == 17) obj_pos = new int[9, 2] { { 2, y - 1 }, { 3, y - 1 }, { 4, y - 1 }, { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 2, y }, { 3, y }, { 4, y } };
            if (obj_shape == 18) obj_pos = new int[8, 2] { { 2, y - 1 }, { 3, y - 1 }, { 4, y - 1 }, { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 2, y }, { 3, y } };
            if (obj_shape == 19) obj_pos = new int[7, 2] { { 2, y - 1 }, { 3, y - 1 }, { 4, y - 1 }, { 2, y + 1 }, { 3, y + 1 }, { 4, y + 1 }, { 2, y } };

            // level 4
            // Anchor size 5
            if (obj_shape == 20) obj_pos = new int[9, 2] { { 0, y + 2 }, { 1, y + 2 }, { 2, y + 2 }, { 3, y + 2 }, { 4, y + 2 }, { 4, y + 1 }, { 4, y }, { 4, y - 1 }, { 4, y - 2 } };

            // Anchor size 4
            if (obj_shape == 21) obj_pos = new int[4, 2] { { 2, y - 2 }, { 3, y - 1 }, { 2, y }, { 3, y + 1 } };
            if (obj_shape == 22) obj_pos = new int[12, 2] { { 1, y - 2 }, { 1, y - 1 }, { 1, y }, { 1, y + 1 }, { 2, y - 2 }, { 2, y + 1 }, { 3, y - 2 }, { 3, y + 1 }, { 4, y - 2 }, { 4, y - 1 }, { 4, y }, { 4, y + 1 } };

            // Anchor size 3
            if (obj_shape == 23) obj_pos = new int[8, 2] { { 2, y - 1 }, { 2, y }, { 2, y + 1 }, { 3, y - 1 }, { 3, y + 1 }, { 4, y - 1 }, { 4, y }, { 4, y + 1 } };
            if (obj_shape == 24) obj_pos = new int[4, 2] { { 2, y }, { 3, y - 1 }, { 3, y + 1 }, { 4, y } };
            if (obj_shape == 25) obj_pos = new int[5, 2] { { 2, y - 1 }, { 2, y + 1 }, { 3, y }, { 4, y - 1 }, { 4, y + 1 } };


            // level 5 
            // Anchor size 5
            if (obj_shape == 26) obj_pos = new int[9, 2] { { 0, y - 2 }, { 1, y - 1 }, { 2, y }, { 3, y + 1 }, { 4, y + 2 }, { 4, y - 2 }, { 3, y - 1 }, { 1, y + 1 }, { 0, y + 2 } };
            if (obj_shape == 27) obj_pos = new int[16, 2] { { 0, y + 2 }, { 1, y + 2 }, { 2, y + 2 }, { 3, y + 2 }, { 4, y + 2 }, { 0, y - 2 }, { 1, y - 2 }, { 2, y - 2 }, { 3, y - 2 }, { 4, y - 2 }, { 0, y + 1 }, { 0, y }, { 0, y - 1 }, { 4, y + 1 }, { 4, y }, { 4, y - 1 } };

            // Anchor size 4 
            if (obj_shape == 28) obj_pos = new int[8, 2] { { 1, y - 2 }, { 2, y - 1 }, { 1, y }, { 2, y + 1 }, { 3, y - 2 }, { 4, y - 1 }, { 3, y }, { 4, y + 1 } };
            if (obj_shape == 29) obj_pos = new int[4, 2] { { 1, y - 2 }, { 2, y - 1 }, { 3, y }, { 4, y + 1 } };
        }
    }
}
