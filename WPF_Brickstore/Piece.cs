using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Brickstore
{
    internal class Piece
    {
        string id;
        string name;
        string category;
        string color;
        int quantity;

        public Piece(string id, string name, string category, string color, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Color = color;
            this.Quantity = quantity;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Color { get => color; set => color = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
