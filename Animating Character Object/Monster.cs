 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Animating_Character_Object
{
    
    class Monster
    {
        //varaible
        public int x, y, size, speed, direction;
        public Image[] monsterImage = new Image[4];

        //constructor method to transfer the values to create the object for the bullet
        public Monster(int _x, int _y, int _size, int _speed, int _direction, Image[] _monsterImage)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            monsterImage = _monsterImage;
            direction = _direction;
        }

        //which direction the monster will move
        public void move(Monster m)
        {
            switch (m.direction)
            {
                case 0:
                    m.y += m.speed;
                    break;

                case 1:
                    m.x -= m.speed;
                    break;

                case 2:
                    m.x += m.speed;
                    break;

                case 3:
                    m.y -= m.speed;
                    break;

                default:
                    break;

            }
        }
        //collision between monster and bullet
        public bool collision(Monster m,Bullet b)
        {
            Rectangle monsterRec = new Rectangle(m.x, m.y, m.size, m.size);
            Rectangle bulletRec = new Rectangle(b.x, b.y, b.size, b.size);
            
            if (monsterRec.IntersectsWith(bulletRec))
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
