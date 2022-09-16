using System;
using System.Collections.Generic;
using System.Numerics;

namespace _05_Students2
{

    class Student{
        public string FirstName {get; set;}
        
        public string LastName {get; set;}

        public int Age {get; set;}

        public string City {get; set;}

    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput;
            List<Student> lstStudents = new List<Student>();
            Student objNewStudent;
            string sHomeTown;

            arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while(arrInput[0] != "end"){

                objNewStudent = new Student(){
                    FirstName = arrInput[0],
                    LastName = arrInput[1],
                    Age = int.Parse(arrInput[2]),
                    City = arrInput[3]
                };

                if(IsStudentExisting(lstStudents, objNewStudent)){
                    ModifyStudent(lstStudents, objNewStudent);
                }
                else
                    lstStudents.Add(objNewStudent);{
                }
                
                arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            sHomeTown = Console.ReadLine();

            foreach(Student objNextStudent in lstStudents){
                if(objNextStudent.City == sHomeTown){
                    Console.WriteLine("{0} {1} is {2} years old.", 
                                        objNextStudent.FirstName, objNextStudent.LastName, objNextStudent.Age);
                }
            }

        }
    
        static bool IsStudentExisting(List<Student> lstStudents, Student objNewStudent){
            foreach(Student objNextStudent in lstStudents){
                if(objNewStudent.FirstName == objNextStudent.FirstName &&
                    objNewStudent.LastName == objNextStudent.LastName){
                        return true;
                    }
            }

            return false;
        }

        static void ModifyStudent(List<Student> lstStudents, Student objNewStudent){

            Student objNextStudent = GetStudent(lstStudents, objNewStudent);
            
            objNextStudent.FirstName = objNewStudent.FirstName;
            objNextStudent.LastName = objNewStudent.LastName;
            objNextStudent.Age = objNewStudent.Age;
            objNextStudent.City = objNewStudent.City;

            return;
        }   
    
        static Student GetStudent(List<Student> lstStudents, Student objNewStudent){

            Student objRetStudent = null;

            foreach(Student objNextStudent in lstStudents){
                if(objNewStudent.FirstName == objNextStudent.FirstName &&
                    objNewStudent.LastName == objNextStudent.LastName){
                        objRetStudent = objNextStudent;
                        break;
                }
            }

            return objRetStudent;
        }

    }
}
