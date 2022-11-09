namespace Food.Models
{
    using Food.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Robot : Identity, IRobot
    {
        private string model;

        public string Model { get => this.model; set => this.model = value; }

        public Robot(string model, string id) : base(id)
        {
            this.Model = model;
        }
    }
}
