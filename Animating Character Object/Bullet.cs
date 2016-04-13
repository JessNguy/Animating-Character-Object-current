using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Animating_Character_Object
{
    class Bullet
    {   //varaibles
        public int x, y, size, speed, direction;
        public Image fireBullet;

        //constructor method to transfer the values to create the object for the bullet
        public Bullet(int _x, int _y, int _size, int _speed, int _direction, Image _fireBullet)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
            fireBullet = _fireBullet;
        }

        //which direction the bullet will move
        public void move(Bullet b)
        {
           switch (b.direction)
            {
                case 0:
                    b.y += b.speed;
                    break;

                case 1:
                    b.x -= b.speed;
                    break;

                case 2:
                    b.x += b.speed;
                    break;

                case 3:
                    b.y -= b.speed;
                    break;

                default:
                    break;

            }
        }
    }
}
