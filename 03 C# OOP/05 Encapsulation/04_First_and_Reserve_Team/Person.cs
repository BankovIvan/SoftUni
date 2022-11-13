namespace PersonsInfo
{
    using System;
    using System.Text;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        
        public string FirstName { 
            get => this.firstName; 
            set {
                if(value.Length < 3){
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                } 
                else{
                    this.firstName = value;
                } 
            }
        }
        public string LastName { 
            get => this.lastName; 
            set {
                if(value.Length < 3){
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!!");
                } 
                else{
                    this.lastName = value;
                }
            } 
        }
        public int Age { 
            get => this.age; 
            set {
                if(value <= 0){
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                } 
                else {
                    this.age = value;
                }
            }
        }
        public decimal Salary { 
            get => this.salary; 
            set {
                if(value < 650){
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
                else{
                    this.salary = value;
                }
            } 
        }

        public Person(string firstName, string lastName, int age, decimal salary){
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("{0} {1} receives {2:F2} leva.", this.FirstName, this.LastName, this.Salary));

            return ret.ToString().Trim();
        }

        public void IncreaseSalary(decimal percentage){
            if(this.Age < 30){
                this.Salary += (this.Salary * percentage) * 0.005M;
            }
            else{
                this.Salary += (this.Salary * percentage) * 0.01M;
            }
        }

    }
}