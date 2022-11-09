namespace _04_Border_Control.Models
{
    using _04_Border_Control.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Robot : Identity, IRobot
    {
        private string model;

        public string Model { get => this.model; set => this.model = value; }

        public Robot(string id, string model) : base(id)
        {
            this.Model = model;
        }
    }
}
