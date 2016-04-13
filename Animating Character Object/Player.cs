using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animating_Character_Object
{
    class Player
    {  
        //varaible
        public int x, y, size, speed, direction;
        public Image[] playerImages = new Image[4];

        //constructor method to transfer the values to create the object for the player
        public Player(int _x, int _y, int _size, int _speed, int _direction, Image[] _playerImages)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
            playerImages = _playerImages;

        }

        //which direction the player will move
        public void move(Player p)
        {
            switch (p.direction)
            {
                case 0:
                    p.y += p.speed;
                    break;

                case 1:
                    p.x -= p.speed;
                    break;

                case 2:
                    p.x += p.speed;
                    break;

                case 3:
                    p.y -= p.speed;
                    break;

                default:
                    break;

            }

        }

        //collision between player and monster
        public bool collision(Player po, Monster m)
        {
            Rectangle playerRec = new Rectangle(po.x, po.y, po.size, po.size);
            Rectangle monsterRec = new Rectangle(m.x, m.y, m.size, m.size);

            if (playerRec.IntersectsWith(monsterRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
