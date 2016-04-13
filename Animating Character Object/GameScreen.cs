
//Name :Jess Nguyen
//Date Started : April 4, 2016
//Date Finished : April 8, 2016 
//Summary : A Game engine that uses classes, object animation and multi screens. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animating_Character_Object
{
    public partial class GameScreen : UserControl
    {
        #region Variables   
        List<Monster> phoenix = new List<Monster>();
        List<Bullet> flame = new List<Bullet>();
  
        int direction = 0;

        Player isaac;
        //array for the arrows to use direction as an int to change images
        bool[] arrow = new bool[4];
        bool downArrowDown, leftArrowDown, rightArrowDown, upArrowDown, spaceDown = false;

        Random randomLocation = new Random();
        //isaac's images
        Image[] tempIsaac = new Image[] { Properties.Resources.IsaacDown,
            Properties.Resources.IsaacLeft,
            Properties.Resources.IsaacRight,
            Properties.Resources.IsaacUp
        };
        //phoeniz's images
        Image[] tempPhoenix = new Image[] { Properties.Resources.monsterDown,
            Properties.Resources.monsterLeft,
            Properties.Resources.monsterRight,
            Properties.Resources.monsterUp
        };
        //fireball bullet's image
        Image fireBullet = Properties.Resources.fireball;

        //know the current x and y to compare it to the window length and width 
        int currentX = 0;
        int currentY = 0;
        public static int score = 0;
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            gameTimer.Enabled = true;
            gameTimer.Start();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(isaac.playerImages[isaac.direction], isaac.x, isaac.y, isaac.size, isaac.size);

            foreach (Monster monster in phoenix)
            {
                e.Graphics.DrawImage(monster.monsterImage[monster.direction], monster.x, monster.y, monster.size, monster.size);
            }

            foreach (Bullet fireball in flame)
            {
                e.Graphics.DrawImage(fireball.fireBullet, fireball.x, fireball.y, fireball.size, fireball.size);
            }

        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            this.Focus();

            //creating objects: locations, size, speed, direction, and array
            isaac = new Player(currentX, currentY, 20, 7, direction, tempIsaac);
            Monster monster = new Monster(randomLocation.Next(this.Width), randomLocation.Next(this.Height),
            25, 2, 0, tempPhoenix);

            phoenix.Add(monster);

            //put arrow in the boolean array
            arrow = new bool[] { downArrowDown, leftArrowDown, rightArrowDown, upArrowDown };

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region Isaac Movement
            currentX = isaac.x;
            currentY = isaac.y;

            for (int i = 0; i < 4; i++)
            {
                if (arrow[i] == true)
                {
                    isaac.direction = i;
                    isaac.move(isaac);

                    if (isaac.x + isaac.size > this.Width || isaac.x < 0 || isaac.y + isaac.size > this.Height
                        || isaac.y < 0)
                    {
                        isaac.x = currentX;
                        isaac.y = currentY;
                    }
                }
            }
            #endregion

            #region Phoenix Movement
            //foreach loop that looks at each monster in phoenix           
            foreach (Monster monster in phoenix)
            {
                if (isaac.collision(isaac, monster))
                {
                    gameTimer.Stop();

                    Form f = this.FindForm();
                    f.Controls.Remove(this);

                    MainScreen ms = new MainScreen();
                    f.Controls.Add(ms);

                }
                else
                {
                    //if isaac is more to the right, monster moves right
                    if (isaac.x - monster.x > 0)
                    {
                        monster.direction = 2;
                        monster.move(monster);
                    }
                    //if isaac is more to the left, monster moves left
                    else if (isaac.x - monster.x < 0)
                    {
                        monster.direction = 1;
                        monster.move(monster);
                    }
                    //if isaac is more up, monster moves up
                    if (isaac.y - monster.y > 0)
                    {
                        monster.direction = 0;
                        monster.move(monster);
                    }
                    //if isaac is more down, monster moves down
                    else if (isaac.y - monster.y < 0)
                    {
                        monster.direction = 3;
                        monster.move(monster);
                    }

                }
            }
            #endregion

            #region Bullet Movement
            if (spaceDown == true)
            {
                Bullet fireBall = new Bullet(isaac.x + (isaac.size / 2), isaac.y + (isaac.size / 2), 10, 9,
                isaac.direction, fireBullet);
                flame.Add(fireBall);
            }
                        
            //foreach loop that looks at each bullet in flame
            foreach (Bullet fireball in flame)
            {
                fireball.move(fireball);

                if (fireball.x > this.Width || fireball.x < 0 || fireball.y > this.Height || fireball.y < 0)
                {
                    flame.Remove(fireball);
                    break;
                }               
            }

            foreach (Monster monster in phoenix)
            {
                foreach (Bullet fireball in flame)
                {
                    if (monster.collision(monster, fireball))
                    {
                        phoenix.Remove(monster);
                        flame.Remove(fireball);
                        score++;
                        break;

                    }
                }
            }
            #endregion

            labelScore.Text = Convert.ToString(score);

            Refresh();
        } 

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {            
            switch (e.KeyCode)
            {
                case Keys.Down:
                    arrow[0] = true;
                    break;
                case Keys.Left:
                    arrow[1] = true;
                    break;
                case Keys.Right:
                    arrow[2] = true;
                    break;
                case Keys.Up:
                    arrow[3] = true;
                    break;
                case Keys.Space:
                    spaceDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    arrow[0] = false;
                    break;
                case Keys.Left:
                    arrow[1] = false;
                    break;
                case Keys.Right:
                    arrow[2] = false;
                    break;
                case Keys.Up:
                    arrow[3] = false;
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
                default:
                    break;
            }
        }
    }
}
